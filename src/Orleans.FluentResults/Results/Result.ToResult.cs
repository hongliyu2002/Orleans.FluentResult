namespace Orleans.FluentResults;

public partial record Result
{

    #region To Result

    /// <summary>
    ///     Convert result to result
    /// </summary>
    public Result ToResult()
    {
        return new Result(Reasons);
    }

    /// <summary>
    ///     Convert result to result with a value
    /// </summary>
    public Result<T> ToResult<T>()
    {
        return new Result<T>(Reasons);
    }

    /// <summary>
    ///     Convert result to result with a new value
    /// </summary>
    public Result<T> ToResult<T>(T value)
    {
        return new Result<T>(value, Reasons);
    }

    #endregion

}
