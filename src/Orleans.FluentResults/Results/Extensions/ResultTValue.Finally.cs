namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region Finally

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static T Finally<T>(this Result<T> result, Func<Result<T>, T> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        return finalize(result);
    }

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static TOutput Finally<T, TOutput>(this Result<T> result, Func<Result<T>, TOutput> finalize)
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
    /// <param name="finalize">Action that may fail.</param>
    public static async Task<T> FinallyAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, Task<T>> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        var result = await resultTask.ConfigureAwait(false);
        return await finalize(result);
    }

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static async Task<TOutput> FinallyAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, Task<TOutput>> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        var result = await resultTask.ConfigureAwait(false);
        return await finalize(result);
    }

    #endregion

    #region Finally Full ValueTask Async

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static async ValueTask<T> FinallyAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, ValueTask<T>> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        var result = await resultTask.ConfigureAwait(false);
        return await finalize(result);
    }

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static async ValueTask<TOutput> FinallyAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, ValueTask<TOutput>> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        var result = await resultTask.ConfigureAwait(false);
        return await finalize(result);
    }

    #endregion

    #region Finally Right Async

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static async Task<T> FinallyAsync<T>(this Result<T> result, Func<Result<T>, Task<T>> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        return await finalize(result);
    }

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static async Task<TOutput> FinallyAsync<T, TOutput>(this Result<T> result, Func<Result<T>, Task<TOutput>> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        return await finalize(result);
    }

    #endregion

    #region Finally Right ValueTask Async

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static async ValueTask<T> FinallyAsync<T>(this Result<T> result, Func<Result<T>, ValueTask<T>> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        return await finalize(result);
    }

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static async ValueTask<TOutput> FinallyAsync<T, TOutput>(this Result<T> result, Func<Result<T>, ValueTask<TOutput>> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        return await finalize(result);
    }

    #endregion

    #region Finally Left Async

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static async Task<T> FinallyAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, T> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        var result = await resultTask.ConfigureAwait(false);
        return finalize(result);
    }

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static async Task<TOutput> FinallyAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, TOutput> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        var result = await resultTask.ConfigureAwait(false);
        return finalize(result);
    }

    #endregion

    #region Finally Left ValueTask Async

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static async ValueTask<T> FinallyAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, T> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        var result = await resultTask.ConfigureAwait(false);
        return finalize(result);
    }

    /// <summary>
    ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="finalize">Action that may fail.</param>
    public static async ValueTask<TOutput> FinallyAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, TOutput> finalize)
    {
        ArgumentNullException.ThrowIfNull(finalize);
        var result = await resultTask.ConfigureAwait(false);
        return finalize(result);
    }

    #endregion

}
