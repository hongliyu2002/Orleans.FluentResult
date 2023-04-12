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
    /// <param name="map">map function</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> MapTry<TOutput>(this Result result, Func<TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = map();
            return new Result<TOutput>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<TOutput>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    #endregion

    #region MapTry Full Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryAsync<TOutput>(this Task<Result> resultTask, Func<Task<TOutput>> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map().ConfigureAwait(configureAwait);
            return new Result<TOutput>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<TOutput>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    #endregion

    #region MapTry Full ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryAsync<TOutput>(this ValueTask<Result> resultTask, Func<ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map().ConfigureAwait(configureAwait);
            return new Result<TOutput>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<TOutput>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    #endregion

    #region MapTry Right Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryAsync<TOutput>(this Result result, Func<Task<TOutput>> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map().ConfigureAwait(configureAwait);
            return new Result<TOutput>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<TOutput>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    #endregion

    #region MapTry Right ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryAsync<TOutput>(this Result result, Func<ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map().ConfigureAwait(configureAwait);
            return new Result<TOutput>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<TOutput>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    #endregion

    #region MapTry Left Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryAsync<TOutput>(this Task<Result> resultTask, Func<TOutput> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = map();
            return new Result<TOutput>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<TOutput>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    #endregion

    #region MapTry Left ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryAsync<TOutput>(this ValueTask<Result> resultTask, Func<TOutput> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = map();
            return new Result<TOutput>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<TOutput>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    #endregion

}
