﻿using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region MapSuccess

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static Result<T> MapSuccess<T>(this Result<T> result, Func<ISuccess, ISuccess> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var successes = result.Successes.Select(success => mapSuccess(success));
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

    #region MapSuccess Full Async

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static async Task<Result<T>> MapSuccessAsync<T>(this Task<Result<T>> resultTask, Func<ISuccess, Task<ISuccess>> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var result = await resultTask.ConfigureAwait(false);
        var successes = await Task.WhenAll(result.Successes.Select(success => mapSuccess(success))).ConfigureAwait(false);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

    #region MapSuccess Full ValueTask Async

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static async ValueTask<Result<T>> MapSuccessAsync<T>(this ValueTask<Result<T>> resultTask, Func<ISuccess, ValueTask<ISuccess>> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var result = await resultTask.ConfigureAwait(false);
        var successes = await Task.WhenAll(result.Successes.Select(success => mapSuccess(success).AsTask())).ConfigureAwait(false);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

    #region MapSuccess Right Async

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static async Task<Result<T>> MapSuccessAsync<T>(this Result<T> result, Func<ISuccess, Task<ISuccess>> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var successes = await Task.WhenAll(result.Successes.Select(success => mapSuccess(success))).ConfigureAwait(false);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

    #region MapSuccess Right ValueTask Async

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static async ValueTask<Result<T>> MapSuccessAsync<T>(this Result<T> result, Func<ISuccess, ValueTask<ISuccess>> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var successes = await Task.WhenAll(result.Successes.Select(success => mapSuccess(success).AsTask())).ConfigureAwait(false);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

    #region MapSuccess Left Async

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static async Task<Result<T>> MapSuccessAsync<T>(this Task<Result<T>> resultTask, Func<ISuccess, ISuccess> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var result = await resultTask.ConfigureAwait(false);
        var successes = result.Successes.Select(success => mapSuccess(success));
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

    #region MapSuccess Left ValueTask Async

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static async ValueTask<Result<T>> MapSuccessAsync<T>(this ValueTask<Result<T>> resultTask, Func<ISuccess, ISuccess> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var result = await resultTask.ConfigureAwait(false);
        var successes = result.Successes.Select(success => mapSuccess(success));
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors) };
    }

    #endregion

}
