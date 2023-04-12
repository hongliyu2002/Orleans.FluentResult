namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region MapTry

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="catchHandler"></param>
    public static Result MapTry<T>(this Result<T> result, Action map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            map();
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="catchHandler"></param>
    public static Result MapTry<T>(this Result<T> result, Action<T> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            map(result.Value);
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    public static async Task<Result> MapTryAsync<T>(this Task<Result<T>> resultTask, Func<Task> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            await map().ConfigureAwait(configureAwait);
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> MapTryAsync<T>(this Task<Result<T>> resultTask, Func<T, Task> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            await map(result.Value).ConfigureAwait(configureAwait);
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    public static async ValueTask<Result> MapTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            await map().ConfigureAwait(configureAwait);
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> MapTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            await map(result.Value).ConfigureAwait(configureAwait);
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    public static async Task<Result> MapTryAsync<T>(this Result<T> result, Func<Task> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            await map().ConfigureAwait(configureAwait);
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> MapTryAsync<T>(this Result<T> result, Func<T, Task> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            await map(result.Value).ConfigureAwait(configureAwait);
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    public static async ValueTask<Result> MapTryAsync<T>(this Result<T> result, Func<ValueTask> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            await map().ConfigureAwait(configureAwait);
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> MapTryAsync<T>(this Result<T> result, Func<T, ValueTask> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            await map(result.Value).ConfigureAwait(configureAwait);
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    public static async Task<Result> MapTryAsync<T>(this Task<Result<T>> resultTask, Action map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            map();
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> MapTryAsync<T>(this Task<Result<T>> resultTask, Action<T> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            map(result.Value);
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
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
    public static async ValueTask<Result> MapTryAsync<T>(this ValueTask<Result<T>> resultTask, Action map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            map();
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> MapTryAsync<T>(this ValueTask<Result<T>> resultTask, Action<T> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            map(result.Value);
            return new Result(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    #endregion

}
