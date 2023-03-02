﻿namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region TapError

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Result TapError(this Result result, Action tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            tapError();
        }
        return result;
    }

    #endregion

    #region TapError Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result> TapErrorAsync(this Task<Result> resultTask, Func<Task> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            await tapError();
        }
        return result;
    }

    #endregion

    #region TapError Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result> TapErrorAsync(this ValueTask<Result> resultTask, Func<ValueTask> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            await tapError();
        }
        return result;
    }

    #endregion

    #region TapError Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result> TapErrorAsync(this Result result, Func<Task> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            await tapError();
        }
        return result;
    }

    #endregion

    #region TapError Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result> TapErrorAsync(this Result result, Func<ValueTask> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            await tapError();
        }
        return result;
    }

    #endregion

    #region TapError Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result> TapErrorAsync(this Task<Result> resultTask, Action tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            tapError();
        }
        return result;
    }

    #endregion

    #region TapError Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result> TapErrorAsync(this ValueTask<Result> resultTask, Action tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            tapError();
        }
        return result;
    }

    #endregion

}
