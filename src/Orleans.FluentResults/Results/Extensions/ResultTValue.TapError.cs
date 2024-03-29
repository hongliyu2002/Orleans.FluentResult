﻿namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region TapError

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">tap error action</param>
    public static Result<T> TapError<T>(this Result<T> result, Action<IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            tapError(result.Errors);
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">tap error action</param>
    public static Result<T> TapError<T>(this Result<T> result, Action<T, IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            tapError(result.Value, result.Errors);
        }
        return result;
    }

    #endregion

    #region TapError Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> TapErrorAsync<T>(this Task<Result<T>> resultTask, Func<IEnumerable<IError>, Task> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            await tapError(result.Errors).ConfigureAwait(configureAwait);
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> TapErrorAsync<T>(this Task<Result<T>> resultTask, Func<T, IEnumerable<IError>, Task> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            await tapError(result.Value, result.Errors).ConfigureAwait(configureAwait);
        }
        return result;
    }

    #endregion

    #region TapError Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> TapErrorAsync<T>(this ValueTask<Result<T>> resultTask, Func<IEnumerable<IError>, ValueTask> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            await tapError(result.Errors).ConfigureAwait(configureAwait);
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> TapErrorAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, IEnumerable<IError>, ValueTask> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            await tapError(result.Value, result.Errors).ConfigureAwait(configureAwait);
        }
        return result;
    }

    #endregion

    #region TapError Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> TapErrorAsync<T>(this Result<T> result, Func<IEnumerable<IError>, Task> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            await tapError(result.Errors).ConfigureAwait(configureAwait);
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> TapErrorAsync<T>(this Result<T> result, Func<T, IEnumerable<IError>, Task> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            await tapError(result.Value, result.Errors).ConfigureAwait(configureAwait);
        }
        return result;
    }

    #endregion

    #region TapError Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> TapErrorAsync<T>(this Result<T> result, Func<IEnumerable<IError>, ValueTask> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            await tapError(result.Errors).ConfigureAwait(configureAwait);
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> TapErrorAsync<T>(this Result<T> result, Func<T, IEnumerable<IError>, ValueTask> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            await tapError(result.Value, result.Errors).ConfigureAwait(configureAwait);
        }
        return result;
    }

    #endregion

    #region TapError Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> TapErrorAsync<T>(this Task<Result<T>> resultTask, Action<IEnumerable<IError>> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            tapError(result.Errors);
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> TapErrorAsync<T>(this Task<Result<T>> resultTask, Action<T, IEnumerable<IError>> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            tapError(result.Value, result.Errors);
        }
        return result;
    }

    #endregion

    #region TapError Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> TapErrorAsync<T>(this ValueTask<Result<T>> resultTask, Action<IEnumerable<IError>> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            tapError(result.Errors);
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> TapErrorAsync<T>(this ValueTask<Result<T>> resultTask, Action<T, IEnumerable<IError>> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            tapError(result.Value, result.Errors);
        }
        return result;
    }

    #endregion

}
