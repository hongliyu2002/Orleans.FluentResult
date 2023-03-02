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
    /// <param name="map">Action that may fail.</param>
    public static Result<T1> Map<T, T1>(this Result<T> result, Func<T1> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = map();
        return new Result<T1>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static Result<T1> Map<T, T1>(this Result<T> result, Func<T, T1> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = map(result.Value);
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

    #region Map Full Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<T1>> MapAsync<T, T1>(this Task<Result<T>> resultTask, Func<Task<T1>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(false);
        return new Result<T1>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<T1>> MapAsync<T, T1>(this Task<Result<T>> resultTask, Func<T, Task<T1>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = await map(result.Value).ConfigureAwait(false);
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

    #region Map Full ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<T1>> MapAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<ValueTask<T1>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(false);
        return new Result<T1>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<T1>> MapAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<T1>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = await map(result.Value).ConfigureAwait(false);
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

    #region Map Right Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<T1>> MapAsync<T, T1>(this Result<T> result, Func<Task<T1>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(false);
        return new Result<T1>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<T1>> MapAsync<T, T1>(this Result<T> result, Func<T, Task<T1>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = await map(result.Value).ConfigureAwait(false);
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

    #region Map Right ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<T1>> MapAsync<T, T1>(this Result<T> result, Func<ValueTask<T1>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(false);
        return new Result<T1>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<T1>> MapAsync<T, T1>(this Result<T> result, Func<T, ValueTask<T1>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = await map(result.Value).ConfigureAwait(false);
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

    #region Map Left Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<T1>> MapAsync<T, T1>(this Task<Result<T>> resultTask, Func<T1> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = map();
        return new Result<T1>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<T1>> MapAsync<T, T1>(this Task<Result<T>> resultTask, Func<T, T1> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = map(result.Value);
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

    #region Map Left ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<T1>> MapAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<T1> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = map();
        return new Result<T1>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<T1>> MapAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<T, T1> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = map(result.Value);
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

}
