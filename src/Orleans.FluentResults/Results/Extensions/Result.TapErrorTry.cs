namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region TapErrorTry

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="catchHandler"></param>
    public static Result TapErrorTry(this Result result, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tapError(result.Errors);
            }
            catch (Exception ex)
            {
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

    #region TapErrorTry Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> TapErrorTryAsync(this Task<Result> resultTask, Func<IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError(result.Errors).ConfigureAwait(configureAwait);
            }
            catch (Exception ex)
            {
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

    #region TapErrorTry Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> TapErrorTryAsync(this ValueTask<Result> resultTask, Func<IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError(result.Errors).ConfigureAwait(configureAwait);
            }
            catch (Exception ex)
            {
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

    #region TapErrorTry Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> TapErrorTryAsync(this Result result, Func<IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError(result.Errors).ConfigureAwait(configureAwait);
            }
            catch (Exception ex)
            {
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

    #region TapErrorTry Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> TapErrorTryAsync(this Result result, Func<IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError(result.Errors).ConfigureAwait(configureAwait);
            }
            catch (Exception ex)
            {
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

    #region TapErrorTry Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> TapErrorTryAsync(this Task<Result> resultTask, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tapError(result.Errors);
            }
            catch (Exception ex)
            {
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

    #region TapErrorTry Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> TapErrorTryAsync(this ValueTask<Result> resultTask, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tapError(result.Errors);
            }
            catch (Exception ex)
            {
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    #endregion

}
