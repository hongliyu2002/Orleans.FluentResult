﻿namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region TapErrorTryIf

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapErrorTryIf<T>(this Result<T> result, bool condition, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapErrorTryIf<T>(this Result<T> result, bool condition, Action<T, IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    #endregion

    #region TapErrorTryIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler, configureAwait) : resultTask;
    }

    #endregion

    #region TapErrorTryIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler, configureAwait) : resultTask;
    }

    #endregion

    #region TapErrorTryIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, bool condition, Func<IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.TapErrorTryAsync(tapError, catchHandler, configureAwait) : Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, bool condition, Func<T, IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.TapErrorTryAsync(tapError, catchHandler, configureAwait) : Task.FromResult(result);
    }

    #endregion

    #region TapErrorTryIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, bool condition, Func<IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.TapErrorTryAsync(tapError, catchHandler, configureAwait) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, bool condition, Func<T, IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.TapErrorTryAsync(tapError, catchHandler, configureAwait) : ValueTask.FromResult(result);
    }

    #endregion

    #region TapErrorTryIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Action<T, IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler, configureAwait) : resultTask;
    }

    #endregion

    #region TapErrorTryIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Action<T, IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler, configureAwait) : resultTask;
    }

    #endregion

}
