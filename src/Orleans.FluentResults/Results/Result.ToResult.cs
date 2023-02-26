namespace Orleans.FluentResults;

public partial record Result
{

    #region To Result

    /// <summary>
    ///     Convert result to result
    /// </summary>
    public Result ToResult()
    {
        return this;
    }
    
    /// <summary>
    ///     Convert result to result with a value
    /// </summary>
    public Result<TValue> ToResult<TValue>()
    {
        if (this is Result<TValue> result)
        {
            return result;
        }
        return new Result<TValue>(Reasons);
    }

    /// <summary>
    ///     Convert result to result with a new value
    /// </summary>
    public Result<TValue> ToResult<TValue>(TValue value)
    {
        return new Result<TValue>(value, Reasons);
    }

    #endregion

}
