namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Tap

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">tap action</param>
    public static Result Tap(this Result result, Action tap)
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
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> TapAsync(this Task<Result> resultTask, Func<Task> tap, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess)
        {
            await tap().ConfigureAwait(configureAwait);
        }
        return result;
    }

    #endregion

    #region Tap Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> TapAsync(this ValueTask<Result> resultTask, Func<ValueTask> tap, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess)
        {
            await tap().ConfigureAwait(configureAwait);
        }
        return result;
    }

    #endregion

    #region Tap Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> TapAsync(this Result result, Func<Task> tap, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            await tap().ConfigureAwait(configureAwait);
        }
        return result;
    }

    #endregion

    #region Tap Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> TapAsync(this Result result, Func<ValueTask> tap, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            await tap().ConfigureAwait(configureAwait);
        }
        return result;
    }

    #endregion

    #region Tap Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> TapAsync(this Task<Result> resultTask, Action tap, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
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
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> TapAsync(this ValueTask<Result> resultTask, Action tap, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess)
        {
            tap();
        }
        return result;
    }

    #endregion

}
