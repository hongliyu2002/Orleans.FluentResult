namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Finally

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="finalize">finalize function</param>
    public static T Finally<T>(this Result result, Func<Result, T> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        return finalize(result);
    }

    #endregion

    #region Finally Full Async

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="finalize">finalize function</param>
    /// <param name="configureAwait"></param>
    public static async Task<T> FinallyAsync<T>(this Task<Result> resultTask, Func<Result, Task<T>> finalize, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return await finalize(result).ConfigureAwait(configureAwait);
    }

    #endregion

    #region Finally Full ValueTask Async

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="finalize">finalize function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<T> FinallyAsync<T>(this ValueTask<Result> resultTask, Func<Result, ValueTask<T>> finalize, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return await finalize(result).ConfigureAwait(configureAwait);
    }

    #endregion

    #region Finally Right Async

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="finalize">finalize function</param>
    /// <param name="configureAwait"></param>
    public static async Task<T> FinallyAsync<T>(this Result result, Func<Result, Task<T>> finalize, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        return await finalize(result).ConfigureAwait(configureAwait);
    }

    #endregion

    #region Finally Right ValueTask Async

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="finalize">finalize function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<T> FinallyAsync<T>(this Result result, Func<Result, ValueTask<T>> finalize, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        return await finalize(result).ConfigureAwait(configureAwait);
    }

    #endregion

    #region Finally Left Async

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="finalize">finalize function</param>
    /// <param name="configureAwait"></param>
    public static async Task<T> FinallyAsync<T>(this Task<Result> resultTask, Func<Result, T> finalize, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return finalize(result);
    }

    #endregion

    #region Finally Left ValueTask Async

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="finalize">finalize function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<T> FinallyAsync<T>(this ValueTask<Result> resultTask, Func<Result, T> finalize, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return finalize(result);
    }

    #endregion

}
