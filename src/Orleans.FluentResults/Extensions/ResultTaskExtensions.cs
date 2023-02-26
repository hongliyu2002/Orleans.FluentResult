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

    #region Bind

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindAction"></param>
    /// <returns></returns>
    public static async Task<Result> Bind(this Task<Result> resultTask, Func<Task<Result>> bindAction)
    {
        var result = await resultTask;
        return await result.Bind(bindAction);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindAction"></param>
    /// <returns></returns>
    public static async ValueTask<Result> Bind(this ValueTask<Result> resultTask, Func<ValueTask<Result>> bindAction)
    {
        var result = await resultTask;
        return await result.Bind(bindAction);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindAction"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task<Result<TValue>> Bind<TValue>(this Task<Result> resultTask, Func<Task<Result<TValue>>> bindAction)
    {
        var result = await resultTask;
        return await result.Bind(bindAction);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindAction"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Result<TValue>> Bind<TValue>(this ValueTask<Result> resultTask, Func<ValueTask<Result<TValue>>> bindAction)
    {
        var result = await resultTask;
        return await result.Bind(bindAction);
    }

    #endregion

}
