﻿using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region MapSuccess

    /// <summary>
    ///     If the calling Result is a success, a new success result from the return value of a given map success function is returned. Otherwise, creates a new failure result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapSuccess">map success function</param>
    public static Result<T> MapSuccess<T>(this Result<T> result, Func<ISuccess, ISuccess> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var successes = result.Successes.Select(mapSuccess);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

    #region MapSuccess Full Async

    /// <summary>
    ///     If the calling Result is a success, a new success result from the return value of a given map success function is returned. Otherwise, creates a new failure result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapSuccess">map success function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> MapSuccessAsync<T>(this Task<Result<T>> resultTask, Func<ISuccess, Task<ISuccess>> mapSuccess, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        var successes = await Task.WhenAll(result.Successes.Select(mapSuccess)).ConfigureAwait(configureAwait);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

    #region MapSuccess Full ValueTask Async

    /// <summary>
    ///     If the calling Result is a success, a new success result from the return value of a given map success function is returned. Otherwise, creates a new failure result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapSuccess">map success function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> MapSuccessAsync<T>(this ValueTask<Result<T>> resultTask, Func<ISuccess, ValueTask<ISuccess>> mapSuccess, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        var successes = await Task.WhenAll(result.Successes.Select(success => mapSuccess(success).AsTask())).ConfigureAwait(configureAwait);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

    #region MapSuccess Right Async

    /// <summary>
    ///     If the calling Result is a success, a new success result from the return value of a given map success function is returned. Otherwise, creates a new failure result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapSuccess">map success function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> MapSuccessAsync<T>(this Result<T> result, Func<ISuccess, Task<ISuccess>> mapSuccess, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var successes = await Task.WhenAll(result.Successes.Select(mapSuccess)).ConfigureAwait(configureAwait);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

    #region MapSuccess Right ValueTask Async

    /// <summary>
    ///     If the calling Result is a success, a new success result from the return value of a given map success function is returned. Otherwise, creates a new failure result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapSuccess">map success function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> MapSuccessAsync<T>(this Result<T> result, Func<ISuccess, ValueTask<ISuccess>> mapSuccess, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var successes = await Task.WhenAll(result.Successes.Select(success => mapSuccess(success).AsTask())).ConfigureAwait(configureAwait);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

    #region MapSuccess Left Async

    /// <summary>
    ///     If the calling Result is a success, a new success result from the return value of a given map success function is returned. Otherwise, creates a new failure result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapSuccess">map success function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> MapSuccessAsync<T>(this Task<Result<T>> resultTask, Func<ISuccess, ISuccess> mapSuccess, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        var successes = result.Successes.Select(mapSuccess);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

    #region MapSuccess Left ValueTask Async

    /// <summary>
    ///     If the calling Result is a success, a new success result from the return value of a given map success function is returned. Otherwise, creates a new failure result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapSuccess">map success function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> MapSuccessAsync<T>(this ValueTask<Result<T>> resultTask, Func<ISuccess, ISuccess> mapSuccess, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        var successes = result.Successes.Select(mapSuccess);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

}
