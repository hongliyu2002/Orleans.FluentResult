namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region TapErrorTry

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapErrorTry<T>(this Result<T> result, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
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
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapErrorTry<T>(this Result<T> result, Action<T, IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tapError(result.Value, result.Errors);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    public static async Task<Result<T>> TapErrorTryAsync<T>(this Task<Result<T>> resultTask, Func<IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError(result.Errors);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryAsync<T>(this Task<Result<T>> resultTask, Func<T, IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError(result.Value, result.Errors);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    public static async ValueTask<Result<T>> TapErrorTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError(result.Errors);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError(result.Value, result.Errors);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    public static async Task<Result<T>> TapErrorTryAsync<T>(this Result<T> result, Func<IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError(result.Errors);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryAsync<T>(this Result<T> result, Func<T, IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError(result.Value, result.Errors);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    public static async ValueTask<Result<T>> TapErrorTryAsync<T>(this Result<T> result, Func<IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError(result.Errors);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryAsync<T>(this Result<T> result, Func<T, IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                await tapError(result.Value, result.Errors);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    public static async Task<Result<T>> TapErrorTryAsync<T>(this Task<Result<T>> resultTask, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tapError(result.Errors);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryAsync<T>(this Task<Result<T>> resultTask, Action<T, IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tapError(result.Value, result.Errors);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    public static async ValueTask<Result<T>> TapErrorTryAsync<T>(this ValueTask<Result<T>> resultTask, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tapError(result.Errors);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
            }
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryAsync<T>(this ValueTask<Result<T>> resultTask, Action<T, IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
            try
            {
                tapError(result.Value, result.Errors);
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
