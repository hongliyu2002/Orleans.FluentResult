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
    /// <param name="map">Action that may fail.</param>
    public static Result<TOutput> Map<TOutput>(this Result result, Func<TOutput> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = map();
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region Map Full Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<TOutput>> MapAsync<TOutput>(this Task<Result> resultTask, Func<Task<TOutput>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(true);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region Map Full ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> MapAsync<TOutput>(this ValueTask<Result> resultTask, Func<ValueTask<TOutput>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(true);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region Map Right Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<TOutput>> MapAsync<TOutput>(this Result result, Func<Task<TOutput>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(true);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region Map Right ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> MapAsync<TOutput>(this Result result, Func<ValueTask<TOutput>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(true);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region Map Left Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<TOutput>> MapAsync<TOutput>(this Task<Result> resultTask, Func<TOutput> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = map();
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region Map Left ValueTask Async

    /// <summary>
    ///     Creates a new result from the return value of a given map function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> MapAsync<TOutput>(this ValueTask<Result> resultTask, Func<TOutput> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result<TOutput>.Fail(result.Errors);
        }
        var value = map();
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

}
