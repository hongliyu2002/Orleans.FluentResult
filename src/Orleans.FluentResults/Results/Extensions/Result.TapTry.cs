namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region TapTry

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result TapTry(this Result result, Action tap, Func<Exception, IError>? catchHandler = null)
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
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> TapTryAsync(this Task<Result> resultTask, Func<Task> tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tap();
            }
            catch (Exception ex)
            {
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> TapTryAsync(this ValueTask<Result> resultTask, Func<ValueTask> tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tap();
            }
            catch (Exception ex)
            {
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> TapTryAsync(this Result result, Func<Task> tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tap();
            }
            catch (Exception ex)
            {
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> TapTryAsync(this Result result, Func<ValueTask> tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tap();
            }
            catch (Exception ex)
            {
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> TapTryAsync(this Task<Result> resultTask, Action tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tap();
            }
            catch (Exception ex)
            {
                return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> TapTryAsync(this ValueTask<Result> resultTask, Action tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsSuccess)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tap();
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
