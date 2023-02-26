using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
[Immutable]
[GenerateSerializer]
public partial record Result<TValue>(TValue Value, IImmutableList<IReason> Reasons) : Result(Reasons), IResult<TValue>
{
    /// <summary>
    ///     Creates a new instance of <see cref="Result{TValue}" />
    /// </summary>
    public Result()
        : this(default!, ImmutableList<IReason>.Empty)
    {
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Result{TValue}" />
    /// </summary>
    /// <param name="value">Value of the result</param>
    public Result(TValue value)
        : this(value, ImmutableList<IReason>.Empty)
    {
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Result{TValue}" />
    /// </summary>
    /// <param name="reasons">Reasons of the result</param>
    public Result(IImmutableList<IReason> reasons)
        : this(default!, reasons)
    {
    }

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
    public void Deconstruct(out bool isSuccess, out bool isFailed, out TValue? valueOrDefault, out IImmutableList<Error> errors)
    {
        isSuccess = IsSuccess;
        isFailed = IsFailed;
        valueOrDefault = ValueOrDefault;
        errors = IsFailed ? Errors : ImmutableList<Error>.Empty;
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
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(string errorMessage)
    {
        return Fail(errorMessage);
    }

    /// <summary>
    /// </summary>
    /// <param name="errorMessages"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(List<string> errorMessages)
    {
        return Fail(errorMessages);
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

    /// <summary>
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(Exception exception)
    {
        return Fail(exception);
    }

    /// <summary>
    /// </summary>
    /// <param name="exceptions"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(List<Exception> exceptions)
    {
        return Fail(exceptions);
    }

    #endregion

    #region To Result

    /// <summary>
    ///     Convert result to result
    /// </summary>
    public Result ToResult()
    {
        return new Result(Reasons);
    }

    /// <summary>
    ///     Convert result to result with a new value
    /// </summary>
    public Result<TValue> ToResult(TValue value)
    {
        return new Result<TValue>(value, Reasons);
    }

    /// <summary>
    ///     Convert result with value to result.
    /// </summary>
    public Result<TNewValue> ToResult<TNewValue>()
    {
        var value = Convert.ChangeType(Value, typeof(TNewValue));
        return value == null ? Result<TNewValue>.Fail(new InvalidCastException()).WithReasons(Reasons) : new Result<TNewValue>((TNewValue)value, Reasons);
    }

    /// <summary>
    ///     Convert result with value to result with another value.
    /// </summary>
    public Result<TNewValue> ToResult<TNewValue>(TNewValue value)
    {
        return new Result<TNewValue>(value, Reasons);
    }

    /// <summary>
    ///     Convert result with value to result with another value. Use valueConverter parameter to specify the value transformation logic.
    /// </summary>
    public Result<TNewValue> ToResult<TNewValue>(Func<TValue, TNewValue> valueMapper)
    {
        ArgumentNullException.ThrowIfNull(valueMapper);
        return new Result<TNewValue>(valueMapper(Value), Reasons);
    }

    #endregion

}
