namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region Map

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    public static Result Map<T>(this Result<T> result, Action map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        map();
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    public static Result Map<T>(this Result<T> result, Action<T> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        map(result.Value);
        return new Result(result.Reasons);
    }

    #endregion

    #region Map Full Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> MapAsync<T>(this Task<Result<T>> resultTask, Func<Task> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        await map().ConfigureAwait(configureAwait);
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> MapAsync<T>(this Task<Result<T>> resultTask, Func<T, Task> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        await map(result.Value).ConfigureAwait(configureAwait);
        return new Result(result.Reasons);
    }

    #endregion

    #region Map Full ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> MapAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        await map().ConfigureAwait(configureAwait);
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> MapAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        await map(result.Value).ConfigureAwait(configureAwait);
        return new Result(result.Reasons);
    }

    #endregion

    #region Map Right Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> MapAsync<T>(this Result<T> result, Func<Task> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        await map().ConfigureAwait(configureAwait);
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> MapAsync<T>(this Result<T> result, Func<T, Task> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        await map(result.Value).ConfigureAwait(configureAwait);
        return new Result(result.Reasons);
    }

    #endregion

    #region Map Right ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> MapAsync<T>(this Result<T> result, Func<ValueTask> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        await map().ConfigureAwait(configureAwait);
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> MapAsync<T>(this Result<T> result, Func<T, ValueTask> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        await map(result.Value).ConfigureAwait(configureAwait);
        return new Result(result.Reasons);
    }

    #endregion

    #region Map Left Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> MapAsync<T>(this Task<Result<T>> resultTask, Action map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        map();
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> MapAsync<T>(this Task<Result<T>> resultTask, Action<T> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        map(result.Value);
        return new Result(result.Reasons);
    }

    #endregion

    #region Map Left ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> MapAsync<T>(this ValueTask<Result<T>> resultTask, Action map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        map();
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> MapAsync<T>(this ValueTask<Result<T>> resultTask, Action<T> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        map(result.Value);
        return new Result(result.Reasons);
    }

    #endregion

}
