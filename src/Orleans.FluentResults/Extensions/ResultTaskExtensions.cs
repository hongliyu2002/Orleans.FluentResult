namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class ResultTaskExtensions
{

    #region Map

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMapper"></param>
    /// <returns></returns>
    public static async Task<Result> MapErrors(this Task<Result> resultTask, Func<Error, Error> errorMapper)
    {
        var result = await resultTask;
        return result.MapErrors(errorMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMapper"></param>
    /// <returns></returns>
    public static async ValueTask<Result> MapErrors(this ValueTask<Result> resultTask, Func<Error, Error> errorMapper)
    {
        var result = await resultTask;
        return result.MapErrors(errorMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="successMapper"></param>
    /// <returns></returns>
    public static async Task<Result> MapSuccesses(this Task<Result> resultTask, Func<Success, Success> successMapper)
    {
        var result = await resultTask;
        return result.MapSuccesses(successMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="successMapper"></param>
    /// <returns></returns>
    public static async ValueTask<Result> MapSuccesses(this ValueTask<Result> resultTask, Func<Success, Success> successMapper)
    {
        var result = await resultTask;
        return result.MapSuccesses(successMapper);
    }

    #endregion

}
