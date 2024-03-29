﻿namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Map

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    public static Result Map(this Result result, Action map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        map();
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
    public static async Task<Result> MapAsync(this Task<Result> resultTask, Func<Task> map, bool configureAwait = true)
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

    #endregion

    #region Map Full ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> MapAsync(this ValueTask<Result> resultTask, Func<ValueTask> map, bool configureAwait = true)
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

    #endregion

    #region Map Right Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> MapAsync(this Result result, Func<Task> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        await map().ConfigureAwait(configureAwait);
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
    public static async ValueTask<Result> MapAsync(this Result result, Func<ValueTask> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        await map().ConfigureAwait(configureAwait);
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
    public static async Task<Result> MapAsync(this Task<Result> resultTask, Action map, bool configureAwait = true)
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

    #endregion

    #region Map Left ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> MapAsync(this ValueTask<Result> resultTask, Action map, bool configureAwait = true)
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

    #endregion

}
