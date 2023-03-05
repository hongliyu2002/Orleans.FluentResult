namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region TapErrorIf

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Result<T> TapErrorIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Action<IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.TapError(tapError) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Result<T> TapErrorIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Action<T, IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.TapError(tapError) : result;
    }

    #endregion

    #region TapErrorIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result<T>> TapErrorIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<IEnumerable<IError>, Task> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.TapErrorAsync(tapError).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result<T>> TapErrorIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, IEnumerable<IError>, Task> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.TapErrorAsync(tapError).ConfigureAwait(true) : result;
    }

    #endregion

    #region TapErrorIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result<T>> TapErrorIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<IEnumerable<IError>, ValueTask> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.TapErrorAsync(tapError).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result<T>> TapErrorIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, IEnumerable<IError>, ValueTask> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.TapErrorAsync(tapError).ConfigureAwait(true) : result;
    }

    #endregion

    #region TapErrorIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result<T>> TapErrorIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<IEnumerable<IError>, Task> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorAsync(tapError).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result<T>> TapErrorIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, IEnumerable<IError>, Task> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorAsync(tapError).ConfigureAwait(true) : result;
    }

    #endregion

    #region TapErrorIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result<T>> TapErrorIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<IEnumerable<IError>, ValueTask> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorAsync(tapError).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result<T>> TapErrorIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, IEnumerable<IError>, ValueTask> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorAsync(tapError).ConfigureAwait(true) : result;
    }

    #endregion

    #region TapErrorIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result<T>> TapErrorIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action<IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.TapError(tapError) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result<T>> TapErrorIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action<T, IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.TapError(tapError) : result;
    }

    #endregion

    #region TapErrorIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result<T>> TapErrorIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action<IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.TapError(tapError) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result<T>> TapErrorIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action<T, IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.TapError(tapError) : result;
    }

    #endregion

}
