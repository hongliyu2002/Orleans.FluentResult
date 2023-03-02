﻿namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Tap

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">Action that may fail.</param>
    public static Result Tap<T>(this Result result, Action tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            tap();
        }
        return result;
    }

    #endregion

    #region Tap Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">Action that may fail.</param>
    public static async Task<Result> TapAsync<T>(this Task<Result> resultTask, Func<Task> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            await tap();
        }
        return result;
    }

    #endregion

    #region Tap Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">Action that may fail.</param>
    public static async ValueTask<Result> TapAsync<T>(this ValueTask<Result> resultTask, Func<ValueTask> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            await tap();
        }
        return result;
    }

    #endregion

    #region Tap Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">Action that may fail.</param>
    public static async Task<Result> TapAsync<T>(this Result result, Func<Task> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            await tap();
        }
        return result;
    }

    #endregion

    #region Tap Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">Action that may fail.</param>
    public static async ValueTask<Result> TapAsync<T>(this Result result, Func<ValueTask> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            await tap();
        }
        return result;
    }

    #endregion

    #region Tap Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">Action that may fail.</param>
    public static async Task<Result> TapAsync<T>(this Task<Result> resultTask, Action tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            tap();
        }
        return result;
    }

    #endregion

    #region Tap Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">Action that may fail.</param>
    public static async ValueTask<Result> TapAsync<T>(this ValueTask<Result> resultTask, Action tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            tap();
        }
        return result;
    }

    #endregion

}
