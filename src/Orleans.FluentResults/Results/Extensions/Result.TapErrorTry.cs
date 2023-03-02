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
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result TapErrorTry(this Result result, Action tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tapError();
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
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> TapErrorTryAsync(this Task<Result> resultTask, Func<Task> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError();
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
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> TapErrorTryAsync(this ValueTask<Result> resultTask, Func<ValueTask> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError();
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
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> TapErrorTryAsync(this Result result, Func<Task> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError();
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
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> TapErrorTryAsync(this Result result, Func<ValueTask> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError();
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
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> TapErrorTryAsync(this Task<Result> resultTask, Action tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tapError();
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
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> TapErrorTryAsync(this ValueTask<Result> resultTask, Action tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tapError();
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
