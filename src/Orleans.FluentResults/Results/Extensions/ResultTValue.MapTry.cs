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
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> MapTry<T, TOutput>(this Result<T> result, Func<TOutput> map, Func<Exception, IError>? catchHandler = null)
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

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> MapTry<T, TOutput>(this Result<T> result, Func<T, TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = map(result.Value);
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
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Task<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map().ConfigureAwait(false);
            return new Result<TOutput>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<TOutput>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, Task<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map(result.Value).ConfigureAwait(false);
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
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map().ConfigureAwait(false);
            return new Result<TOutput>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<TOutput>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map(result.Value).ConfigureAwait(false);
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
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryAsync<T, TOutput>(this Result<T> result, Func<Task<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map().ConfigureAwait(false);
            return new Result<TOutput>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<TOutput>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryAsync<T, TOutput>(this Result<T> result, Func<T, Task<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map(result.Value).ConfigureAwait(false);
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
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryAsync<T, TOutput>(this Result<T> result, Func<ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map().ConfigureAwait(false);
            return new Result<TOutput>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<TOutput>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryAsync<T, TOutput>(this Result<T> result, Func<T, ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await map(result.Value).ConfigureAwait(false);
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
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
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

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = map(result.Value);
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
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
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

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = map(result.Value);
            return new Result<TOutput>(value, result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<TOutput>.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    #endregion

}
