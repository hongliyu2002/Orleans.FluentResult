namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region TapTryIf

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="catchHandler"></param>
    public static Result TapTryIf(this Result result, Func<bool> predicate, Action tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? result.TapTry(tap, catchHandler) : result;
    }

    #endregion

    #region TapTryIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> TapTryIfAsync(this Task<Result> resultTask, Func<bool> predicate, Func<Task> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? await result.TapTryAsync(tap, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapTryIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> TapTryIfAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Func<ValueTask> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? await result.TapTryAsync(tap, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapTryIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> TapTryIfAsync(this Result result, Func<bool> predicate, Func<Task> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? await result.TapTryAsync(tap, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapTryIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> TapTryIfAsync(this Result result, Func<bool> predicate, Func<ValueTask> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? await result.TapTryAsync(tap, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapTryIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> TapTryIfAsync(this Task<Result> resultTask, Func<bool> predicate, Action tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result.TapTry(tap, catchHandler) : result;
    }

    #endregion

    #region TapTryIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> TapTryIfAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Action tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result.TapTry(tap, catchHandler) : result;
    }

    #endregion

}
