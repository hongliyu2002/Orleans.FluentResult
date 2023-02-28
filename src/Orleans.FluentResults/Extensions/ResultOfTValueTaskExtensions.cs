namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class ResultOfTTaskExtensions
{

    #region To Result

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<Result<T>> ToResult<T>(this Task<Result> resultTask, T value)
    {
        var result = await resultTask;
        return result.ToResult(value);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<Result<T>> ToResult<T>(this ValueTask<Result> resultTask, T value)
    {
        var result = await resultTask;
        return result.ToResult(value);
    }

    #endregion

}
