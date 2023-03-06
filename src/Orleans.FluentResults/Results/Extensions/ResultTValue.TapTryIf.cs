namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region TapTryIf

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapTryIf<T>(this Result<T> result, bool condition, Action tap, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapTry(tap, catchHandler) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapTryIf<T>(this Result<T> result, bool condition, Action<T> tap, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapTry(tap, catchHandler) : result;
    }

    #endregion

    #region TapTryIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapTryAsync(tap, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapTryAsync(tap, catchHandler, configureAwait) : resultTask;
    }

    #endregion

    #region TapTryIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapTryAsync(tap, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapTryAsync(tap, catchHandler, configureAwait) : resultTask;
    }

    #endregion

    #region TapTryIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapTryIfAsync<T>(this Result<T> result, bool condition, Func<Task> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.TapTryAsync(tap, catchHandler, configureAwait) : Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapTryIfAsync<T>(this Result<T> result, bool condition, Func<T, Task> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.TapTryAsync(tap, catchHandler, configureAwait) : Task.FromResult(result);
    }

    #endregion

    #region TapTryIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapTryIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.TapTryAsync(tap, catchHandler, configureAwait) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapTryIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.TapTryAsync(tap, catchHandler, configureAwait) : ValueTask.FromResult(result);
    }

    #endregion

    #region TapTryIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Action tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapTryAsync(tap, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Action<T> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapTryAsync(tap, catchHandler, configureAwait) : resultTask;
    }

    #endregion

    #region TapTryIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Action tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapTryAsync(tap, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Action<T> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapTryAsync(tap, catchHandler, configureAwait) : resultTask;
    }

    #endregion

}
