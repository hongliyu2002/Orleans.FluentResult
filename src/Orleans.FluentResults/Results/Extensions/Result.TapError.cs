namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region TapError

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">tap error action</param>
    public static Result TapError(this Result result, Action<IEnumerable<IError>> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            tapError(result.Errors);
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
    public static async Task<Result> TapErrorAsync(this Task<Result> resultTask, Func<IEnumerable<IError>, Task> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            await tapError(result.Errors).ConfigureAwait(configureAwait);
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
    public static async ValueTask<Result> TapErrorAsync(this ValueTask<Result> resultTask, Func<IEnumerable<IError>, ValueTask> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            await tapError(result.Errors).ConfigureAwait(configureAwait);
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
    public static async Task<Result> TapErrorAsync(this Result result, Func<IEnumerable<IError>, Task> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            await tapError(result.Errors).ConfigureAwait(configureAwait);
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
    public static async ValueTask<Result> TapErrorAsync(this Result result, Func<IEnumerable<IError>, ValueTask> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            await tapError(result.Errors).ConfigureAwait(configureAwait);
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
    public static async Task<Result> TapErrorAsync(this Task<Result> resultTask, Action<IEnumerable<IError>> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            tapError(result.Errors);
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
    public static async ValueTask<Result> TapErrorAsync(this ValueTask<Result> resultTask, Action<IEnumerable<IError>> tapError, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            tapError(result.Errors);
        }
        return result;
    }

    #endregion

}
