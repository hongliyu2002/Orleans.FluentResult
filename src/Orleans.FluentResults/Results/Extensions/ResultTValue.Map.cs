﻿namespace Orleans.FluentResults;

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
    public static Result<TOutput> Map<T, TOutput>(this Result<T> result, Func<TOutput> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = map();
        return new Result<TOutput>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    public static Result<TOutput> Map<T, TOutput>(this Result<T> result, Func<T, TOutput> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = map(result.Value);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region Map Full Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> MapAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Task<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(configureAwait);
        return new Result<TOutput>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> MapAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, Task<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = await map(result.Value).ConfigureAwait(configureAwait);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region Map Full ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> MapAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<ValueTask<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(configureAwait);
        return new Result<TOutput>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> MapAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = await map(result.Value).ConfigureAwait(configureAwait);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region Map Right Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> MapAsync<T, TOutput>(this Result<T> result, Func<Task<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(configureAwait);
        return new Result<TOutput>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> MapAsync<T, TOutput>(this Result<T> result, Func<T, Task<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = await map(result.Value).ConfigureAwait(configureAwait);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region Map Right ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> MapAsync<T, TOutput>(this Result<T> result, Func<ValueTask<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(configureAwait);
        return new Result<TOutput>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> MapAsync<T, TOutput>(this Result<T> result, Func<T, ValueTask<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = await map(result.Value).ConfigureAwait(configureAwait);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region Map Left Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> MapAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<TOutput> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = map();
        return new Result<TOutput>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> MapAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, TOutput> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = map(result.Value);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region Map Left ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> MapAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<TOutput> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = map();
        return new Result<TOutput>(value, result.Reasons);
    }

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> MapAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, TOutput> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = map(result.Value);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

}
