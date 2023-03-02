namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region TapError

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Result<T> TapError<T>(this Result<T> result, Action tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            tapError();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Result<T> TapError<T>(this Result<T> result, Action<T> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            tapError(result.Value);
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
    public static async Task<Result<T>> TapErrorAsync<T>(this Task<Result<T>> resultTask, Func<Task> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            await tapError();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result<T>> TapErrorAsync<T>(this Task<Result<T>> resultTask, Func<T, Task> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            await tapError(result.Value);
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
    public static async ValueTask<Result<T>> TapErrorAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            await tapError();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result<T>> TapErrorAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            await tapError(result.Value);
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
    public static async Task<Result<T>> TapErrorAsync<T>(this Result<T> result, Func<Task> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            await tapError();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result<T>> TapErrorAsync<T>(this Result<T> result, Func<T, Task> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            await tapError(result.Value);
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
    public static async ValueTask<Result<T>> TapErrorAsync<T>(this Result<T> result, Func<ValueTask> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            await tapError();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result<T>> TapErrorAsync<T>(this Result<T> result, Func<T, ValueTask> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        if (result.IsFailed)
        {
            await tapError(result.Value);
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
    public static async Task<Result<T>> TapErrorAsync<T>(this Task<Result<T>> resultTask, Action tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            tapError();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async Task<Result<T>> TapErrorAsync<T>(this Task<Result<T>> resultTask, Action<T> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            tapError(result.Value);
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
    public static async ValueTask<Result<T>> TapErrorAsync<T>(this ValueTask<Result<T>> resultTask, Action tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            tapError();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static async ValueTask<Result<T>> TapErrorAsync<T>(this ValueTask<Result<T>> resultTask, Action<T> tapError)
    {
        ArgumentNullException.ThrowIfNull(tapError);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            tapError(result.Value);
        }
        return result;
    }

    #endregion

}
