namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class ResultOfTValueTaskExtensions
{

    #region To Result

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task<Result<TValue>> ToResult<TValue>(this Task<Result> resultTask, TValue value)
    {
        var result = await resultTask;
        return result.ToResult(value);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task<Result<TValue>> ToResult<TValue>(this ValueTask<Result> resultTask, TValue value)
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
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TNewValue"></typeparam>
    /// <returns></returns>
    public static async Task<Result<TNewValue>> Map<TValue, TNewValue>(this Task<Result<TValue>> resultTask, Func<TValue, TNewValue> valueMapper)
    {
        var result = await resultTask;
        return result.Map(valueMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="valueMapper"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TNewValue"></typeparam>
    /// <returns></returns>
    public static async Task<Result<TNewValue>> Map<TValue, TNewValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, TNewValue> valueMapper)
    {
        var result = await resultTask;
        return result.Map(valueMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMapper"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task<Result<TValue>> MapErrors<TValue>(this Task<Result<TValue>> resultTask, Func<Error, Error> errorMapper)
    {
        var result = await resultTask;
        return result.MapErrors(errorMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMapper"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Result<TValue>> MapErrors<TValue>(this ValueTask<Result<TValue>> resultTask, Func<Error, Error> errorMapper)
    {
        var result = await resultTask;
        return result.MapErrors(errorMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="successMapper"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task<Result<TValue>> MapSuccesses<TValue>(this Task<Result<TValue>> resultTask, Func<Success, Success> successMapper)
    {
        var result = await resultTask;
        return result.MapSuccesses(successMapper);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="successMapper"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Result<TValue>> MapSuccesses<TValue>(this ValueTask<Result<TValue>> resultTask, Func<Success, Success> successMapper)
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
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TNewValue"></typeparam>
    /// <returns></returns>
    public static async Task<Result<TNewValue>> Bind<TValue, TNewValue>(this Task<Result<TValue>> resultTask, Func<TValue, Result<TNewValue>> bindAction)
    {
        var result = await resultTask;
        return result.Bind(bindAction);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindAction"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TNewValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Result<TNewValue>> Bind<TValue, TNewValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, Result<TNewValue>> bindAction)
    {
        var result = await resultTask;
        return result.Bind(bindAction);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindAction"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TNewValue"></typeparam>
    /// <returns></returns>
    public static async Task<Result<TNewValue>> Bind<TValue, TNewValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<Result<TNewValue>>> bindAction)
    {
        var result = await resultTask;
        return await result.Bind(bindAction);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindAction"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TNewValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Result<TNewValue>> Bind<TValue, TNewValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, ValueTask<Result<TNewValue>>> bindAction)
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
    public static async Task<Result> Bind<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<Result>> bindAction)
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
    public static async Task<Result> Bind<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Result> bindAction)
    {
        var result = await resultTask;
        return result.Bind(bindAction);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindAction"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Result> Bind<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, Result> bindAction)
    {
        var result = await resultTask;
        return result.Bind(bindAction);
    }

    /// <summary>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindAction"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Result> Bind<TValue>(this ValueTask<Result<TValue>> resultTask, Func<TValue, ValueTask<Result>> bindAction)
    {
        var result = await resultTask;
        return await result.Bind(bindAction);
    }

    #endregion

}
