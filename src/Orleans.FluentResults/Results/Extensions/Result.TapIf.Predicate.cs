namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region TapIf

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    public static Result TapIf(this Result result, Func<Result, bool> predicate, Action tap)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Tap(tap) : result;
    }

    #endregion

    #region TapIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> TapIfAsync(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Task> tap, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? await result.TapAsync(tap, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> TapIfAsync(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<ValueTask> tap, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? await result.TapAsync(tap, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> TapIfAsync(this Result result, Func<Result, bool> predicate, Func<Task> tap, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapAsync(tap, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> TapIfAsync(this Result result, Func<Result, bool> predicate, Func<ValueTask> tap, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapAsync(tap, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region TapIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> TapIfAsync(this Task<Result> resultTask, Func<Result, bool> predicate, Action tap, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? result.Tap(tap) : result;
    }

    #endregion

    #region TapIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> TapIfAsync(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Action tap, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? result.Tap(tap) : result;
    }

    #endregion

}
