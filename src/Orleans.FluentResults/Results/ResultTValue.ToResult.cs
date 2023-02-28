namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region To Result

    /// <summary>
    ///     Convert result to result with a new value
    /// </summary>
    public Result ToResult()
    {
        return new Result(Reasons);
    }

    /// <summary>
    ///     Convert result to result with a new value
    /// </summary>
    public Result<T> ToResult(T value)
    {
        return new Result<T>(value, Reasons);
    }

    /// <summary>
    ///     Convert result with value to result.
    /// </summary>
    public Result<T2> ToResult<T2>()
    {
        try
        {
            var value = Convert.ChangeType(Value, typeof(T2));
            return value != null ? new Result<T2>((T2)value, Reasons) : new Result<T2>(Reasons);
        }
        catch (Exception ex)
        {
            return Result<T2>.Fail(ex.InnerException ?? ex).WithReasons(Reasons);
        }
    }

    /// <summary>
    ///     Convert result with value to result with another value.
    /// </summary>
    public Result<T2> ToResult<T2>(T2 value)
    {
        return new Result<T2>(value, Reasons);
    }

    /// <summary>
    ///     Convert result with value to result with another value. Use valueConverter parameter to specify the value transformation logic.
    /// </summary>
    public Result<T2> ToResult<T2>(Func<T, T2> valueMapper)
    {
        ArgumentNullException.ThrowIfNull(valueMapper);
        return new Result<T2>(valueMapper(Value), Reasons);
    }

    #endregion

}
