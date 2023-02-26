namespace Orleans.FluentResults;

public partial record Result<TValue>
{

    #region To Result

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
    public new Result<TNewValue> ToResult<TNewValue>()
    {
        try
        {
            var value = Convert.ChangeType(Value, typeof(TNewValue));
            return value != null ? new Result<TNewValue>((TNewValue)value, Reasons) : new Result<TNewValue>(Reasons);
        }
        catch (Exception ex)
        {
            return Result<TNewValue>.Fail(ex.InnerException ?? ex).WithReasons(Reasons);
        }
    }

    /// <summary>
    ///     Convert result with value to result with another value.
    /// </summary>
    public new Result<TNewValue> ToResult<TNewValue>(TNewValue value)
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
