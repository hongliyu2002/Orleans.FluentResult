# Fluent Results Pattern for Microsoft Orleans

## Samples first:
```csharp
public Task<Result<bool>> InitializeAsync(SnackMachineInitializeCommand cmd)
{
    var id = this.GetPrimaryKey();
    return Result.Ok()
                 .Ensure(State.IsDeleted == false, $"Snack machine {id} has already been removed.")
                 .TapErrorTryAsync(errors => PublishErrorAsync(new SnackMachineErrorOccurredEvent(id, ErrorCodes.SnackMachineRemoved.Value, errors.ToReasons(), cmd.TraceId, DateTimeOffset.UtcNow, cmd.OperatedBy, Version)))
                 .EnsureAsync(State.IsCreated == false, $"Snack machine {id} already exists.")
                 .TapErrorTryAsync(errors => PublishErrorAsync(new SnackMachineErrorOccurredEvent(id, ErrorCodes.SnackMachineExists.Value, errors.ToReasons(), cmd.TraceId, DateTimeOffset.UtcNow, cmd.OperatedBy, Version)))
                 .BindTryAsync(() => PublishPersistedAsync(new SnackMachineInitializedEvent(id, cmd.MoneyInside, cmd.Slots, cmd.TraceId, DateTimeOffset.UtcNow, cmd.OperatedBy, Version)));
}

protected Task<Result<bool>> PublishPersistedAsync(DomainEvent evt)
{
    return Result.Ok()
                 .MapTryAsync(() => RaiseConditionalEvent(evt))
                 .MapTryIfAsync(raised => raised, _ => PersistAsync(evt))
                 .TapTryAsync(() => _stream.OnNextAsync(evt with { Version = Version }, new EventSequenceTokenV2(Version)));
}
```
#### Explanation of the above steps:
- Ensure is used to check a known condition. If successful, the input result of the previous step is passed directly to the next step, otherwise the failure result is passed with the specified error message attached.
- TapError is used to execute a specified operation when the previous step has an error input. If the previous step input is a successful result, no operation is performed. Regardless of the operation result, the input result of the previous step is passed directly to the next step (this is a feature of the Tap series).
- TapErrorTryAsync is used for executing asynchronous operations and uses Try/Catch internally. Asynchronous operations do not need to specify async/await as the internal process will automatically determine whether to wait or not. Asynchronous operations are classified into two categories:
  - If the method body requires the use of asynchronous operations, the method must be marked as Async.
  - If the input result of the previous step is asynchronous, the method must also be marked as Async.
- Bind is used when the output result needs to be converted. If the input to the method body is another Result<TOther>, the output result is also Result<TOther>.
