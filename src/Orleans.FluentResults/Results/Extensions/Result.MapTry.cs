namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region MapTry

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T1> MapTry<T1>(this Result result, Func<T1> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = map();
            return new Result<T1>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<T1>.Fail(result.Errors.Add(catchHandler(ex)));
        }
    }

    #endregion

    #region MapTry Full Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> MapTryAsync<T1>(this Task<Result> resultTask, Func<Task<T1>> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map().ConfigureAwait(false);
            return new Result<T1>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<T1>.Fail(result.Errors.Add(catchHandler(ex)));
        }
    }

    #endregion

    #region MapTry Full ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> MapTryAsync<T1>(this ValueTask<Result> resultTask, Func<ValueTask<T1>> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map().ConfigureAwait(false);
            return new Result<T1>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<T1>.Fail(result.Errors.Add(catchHandler(ex)));
        }
    }

    #endregion

    #region MapTry Right Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> MapTryAsync<T1>(this Result result, Func<Task<T1>> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map().ConfigureAwait(false);
            return new Result<T1>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<T1>.Fail(result.Errors.Add(catchHandler(ex)));
        }
    }

    #endregion

    #region MapTry Right ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> MapTryAsync<T1>(this Result result, Func<ValueTask<T1>> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map().ConfigureAwait(false);
            return new Result<T1>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<T1>.Fail(result.Errors.Add(catchHandler(ex)));
        }
    }

    #endregion

    #region MapTry Left Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> MapTryAsync<T1>(this Task<Result> resultTask, Func<T1> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = map();
            return new Result<T1>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<T1>.Fail(result.Errors.Add(catchHandler(ex)));
        }
    }

    #endregion

    #region MapTry Left ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> MapTryAsync<T1>(this ValueTask<Result> resultTask, Func<T1> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = map();
            return new Result<T1>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<T1>.Fail(result.Errors.Add(catchHandler(ex)));
        }
    }

    #endregion

}
