namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region TapErrorIf

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Result TapErrorIf(this Result result, Func<Result, bool> predicate, Action<IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.TapError(tapError) : result;
    }

    #endregion

    #region TapErrorIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result> TapErrorIfAsync(this Task<Result> resultTask, Func<Result, bool> predicate, Func<IEnumerable<IError>, Task> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.TapErrorAsync(tapError).ConfigureAwait(true) : result;
    }

    #endregion

    #region TapErrorIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result> TapErrorIfAsync(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<IEnumerable<IError>, ValueTask> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.TapErrorAsync(tapError).ConfigureAwait(true) : result;
    }

    #endregion

    #region TapErrorIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result> TapErrorIfAsync(this Result result, Func<Result, bool> predicate, Func<IEnumerable<IError>, Task> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorAsync(tapError).ConfigureAwait(true) : result;
    }

    #endregion

    #region TapErrorIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result> TapErrorIfAsync(this Result result, Func<Result, bool> predicate, Func<IEnumerable<IError>, ValueTask> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorAsync(tapError).ConfigureAwait(true) : result;
    }

    #endregion

    #region TapErrorIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result> TapErrorIfAsync(this Task<Result> resultTask, Func<Result, bool> predicate, Action<IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.TapError(tapError) : result;
    }

    #endregion

    #region TapErrorIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result> TapErrorIfAsync(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Action<IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.TapError(tapError) : result;
    }

    #endregion

}
