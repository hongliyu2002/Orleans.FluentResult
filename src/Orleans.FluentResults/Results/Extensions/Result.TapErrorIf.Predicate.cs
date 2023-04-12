namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region TapErrorIf

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    public static Result TapErrorIf(this Result result, Func<bool> predicate, Action<IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? result.TapError(tapError) : result;
    }

    #endregion

    #region TapErrorIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> TapErrorIfAsync(this Task<Result> resultTask, Func<bool> predicate, Func<IEnumerable<IError>, Task> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? await result.TapErrorAsync(tapError, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapErrorIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> TapErrorIfAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Func<IEnumerable<IError>, ValueTask> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? await result.TapErrorAsync(tapError, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapErrorIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> TapErrorIfAsync(this Result result, Func<bool> predicate, Func<IEnumerable<IError>, Task> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? await result.TapErrorAsync(tapError, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapErrorIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> TapErrorIfAsync(this Result result, Func<bool> predicate, Func<IEnumerable<IError>, ValueTask> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? await result.TapErrorAsync(tapError, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapErrorIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> TapErrorIfAsync(this Task<Result> resultTask, Func<bool> predicate, Action<IEnumerable<IError>> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result.TapError(tapError) : result;
    }

    #endregion

    #region TapErrorIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> TapErrorIfAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Action<IEnumerable<IError>> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result.TapError(tapError) : result;
    }

    #endregion

}
