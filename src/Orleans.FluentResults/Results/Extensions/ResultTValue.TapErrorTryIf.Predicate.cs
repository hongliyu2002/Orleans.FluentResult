namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region TapErrorTryIf

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapErrorTryIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapErrorTryIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Action<T, IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    #endregion

    #region TapErrorTryIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapErrorTryIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapErrorTryIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapErrorTryIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapErrorTryIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action<T, IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    #endregion

    #region TapErrorTryIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action<T, IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    #endregion

}
