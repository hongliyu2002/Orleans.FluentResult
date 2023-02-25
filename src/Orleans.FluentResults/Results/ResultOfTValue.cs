using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
[Immutable]
[GenerateSerializer]
public partial class Result<TValue> : Result, IResult<TValue>
{
    /// <summary>
    /// </summary>
    public Result()
    {
        Value = default!;
    }

    /// <inheritdoc />
    public Result(TValue value)
    {
        Value = value;
    }

    /// <summary>
    /// </summary>
    /// <param name="reasons"></param>
    public Result(IImmutableList<IReason> reasons)
        : base(reasons)
    {
        Value = default!;
    }

    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="reasons"></param>
    public Result(TValue value, IImmutableList<IReason> reasons)
        : base(reasons)
    {
        Value = value;
    }

    /// <inheritdoc />
    [Id(0)]
    public TValue Value { get; }

    /// <inheritdoc />
    public TValue? ValueOrDefault => IsSuccess ? Value : default;

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{base.ToString()}, {Value.ToLabelValueStringOrEmpty(nameof(Value))}";
    }

    #region Deconstruct

    /// <summary>
    ///     Deconstruct Result
    /// </summary>
    /// <param name="isSuccess"></param>
    /// <param name="isFailed"></param>
    /// <param name="valueOrDefault"></param>
    public void Deconstruct(out bool isSuccess, out bool isFailed, out TValue? valueOrDefault)
    {
        isSuccess = IsSuccess;
        isFailed = IsFailed;
        valueOrDefault = ValueOrDefault;
    }

    /// <summary>
    ///     Deconstruct Result
    /// </summary>
    /// <param name="isSuccess"></param>
    /// <param name="isFailed"></param>
    /// <param name="valueOrDefault"></param>
    /// <param name="errors"></param>
    public void Deconstruct(out bool isSuccess, out bool isFailed, out TValue? valueOrDefault, out IImmutableList<IError> errors)
    {
        isSuccess = IsSuccess;
        isFailed = IsFailed;
        valueOrDefault = ValueOrDefault;
        errors = IsFailed ? Errors : ImmutableList.Create<IError>();
    }

    #endregion

    #region Implicit Operator

    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(TValue value)
    {
        return value as Result<TValue> ?? Ok(value);
    }

    /// <summary>
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(Error error)
    {
        return Fail(error);
    }

    /// <summary>
    /// </summary>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(List<Error> errors)
    {
        return Fail(errors);
    }

    #endregion

}
