﻿namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region TapErrorIf

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    public static Result<T> TapErrorIf<T>(this Result<T> result, Func<T, bool> predicate, Action<IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.TapError(tapError) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    public static Result<T> TapErrorIf<T>(this Result<T> result, Func<T, bool> predicate, Action<T, IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.TapError(tapError) : result;
    }

    #endregion

    #region TapErrorIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> TapErrorIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<IEnumerable<IError>, Task> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.TapErrorAsync(tapError, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> TapErrorIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, IEnumerable<IError>, Task> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.TapErrorAsync(tapError, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapErrorIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> TapErrorIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<IEnumerable<IError>, ValueTask> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.TapErrorAsync(tapError, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> TapErrorIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, IEnumerable<IError>, ValueTask> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.TapErrorAsync(tapError, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapErrorIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> TapErrorIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<IEnumerable<IError>, Task> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.TapErrorAsync(tapError, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> TapErrorIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, IEnumerable<IError>, Task> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.TapErrorAsync(tapError, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapErrorIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> TapErrorIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<IEnumerable<IError>, ValueTask> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.TapErrorAsync(tapError, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> TapErrorIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, IEnumerable<IError>, ValueTask> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.TapErrorAsync(tapError, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapErrorIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> TapErrorIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Action<IEnumerable<IError>> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.TapError(tapError) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> TapErrorIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Action<T, IEnumerable<IError>> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.TapError(tapError) : result;
    }

    #endregion

    #region TapErrorIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> TapErrorIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Action<IEnumerable<IError>> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.TapError(tapError) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">tap error action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> TapErrorIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Action<T, IEnumerable<IError>> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.TapError(tapError) : result;
    }

    #endregion

}
