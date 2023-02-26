namespace Orleans.FluentResults;

/// <inheritdoc />
/// <summary>
/// </summary>
/// <typeparam name="TValue"></typeparam>
public interface IResult<out TValue> : IResult
{
    /// <summary>
    ///     Get the original value regardless the status is failed or success.
    /// </summary>
    TValue Value { get; }

    /// <summary>
    ///     Get the Value. If result is failed then a default value is returned. Opposite see property Value.
    /// </summary>
    TValue? ValueOrDefault { get; }
}
