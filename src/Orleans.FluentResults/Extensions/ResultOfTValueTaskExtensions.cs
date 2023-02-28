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

    #region Map

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="valueMapper"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static async Task<Result<T2>> Map<T, T2>(this Task<Result<T>> resultTask, Func<T, T2> valueMapper)
    {
        var result = await resultTask;
        return result.Map(valueMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="valueMapper"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static async Task<Result<T2>> Map<T, T2>(this ValueTask<Result<T>> resultTask, Func<T, T2> valueMapper)
    {
        var result = await resultTask;
        return result.Map(valueMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMapper"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<Result<T>> MapErrors<T>(this Task<Result<T>> resultTask, Func<Error, Error> errorMapper)
    {
        var result = await resultTask;
        return result.MapErrors(errorMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMapper"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Result<T>> MapErrors<T>(this ValueTask<Result<T>> resultTask, Func<Error, Error> errorMapper)
    {
        var result = await resultTask;
        return result.MapErrors(errorMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="successMapper"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<Result<T>> MapSuccesses<T>(this Task<Result<T>> resultTask, Func<Success, Success> successMapper)
    {
        var result = await resultTask;
        return result.MapSuccesses(successMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="successMapper"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Result<T>> MapSuccesses<T>(this ValueTask<Result<T>> resultTask, Func<Success, Success> successMapper)
    {
        var result = await resultTask;
        return result.MapSuccesses(successMapper);
    }

    #endregion

}
