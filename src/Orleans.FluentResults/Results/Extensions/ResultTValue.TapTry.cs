namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region TapTry

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">tap action</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapTry<T>(this Result<T> result, Action tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tap();
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapTry<T>(this Result<T> result, Action<T> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tap(result.Value);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

    #region TapTry Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapTryAsync<T>(this Task<Result<T>> resultTask, Func<Task> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tap().ConfigureAwait(configureAwait);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapTryAsync<T>(this Task<Result<T>> resultTask, Func<T, Task> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tap(result.Value).ConfigureAwait(configureAwait);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

    #region TapTry Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tap().ConfigureAwait(configureAwait);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tap(result.Value).ConfigureAwait(configureAwait);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

    #region TapTry Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapTryAsync<T>(this Result<T> result, Func<Task> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tap().ConfigureAwait(configureAwait);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapTryAsync<T>(this Result<T> result, Func<T, Task> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tap(result.Value).ConfigureAwait(configureAwait);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

    #region TapTry Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapTryAsync<T>(this Result<T> result, Func<ValueTask> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tap().ConfigureAwait(configureAwait);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapTryAsync<T>(this Result<T> result, Func<T, ValueTask> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tap(result.Value).ConfigureAwait(configureAwait);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

    #region TapTry Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapTryAsync<T>(this Task<Result<T>> resultTask, Action tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tap();
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapTryAsync<T>(this Task<Result<T>> resultTask, Action<T> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tap(result.Value);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

    #region TapTry Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapTryAsync<T>(this ValueTask<Result<T>> resultTask, Action tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tap();
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapTryAsync<T>(this ValueTask<Result<T>> resultTask, Action<T> tap, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tap(result.Value);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

}
