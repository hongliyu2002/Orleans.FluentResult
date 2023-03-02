namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region Tap

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">Action that may fail.</param>
    public static Result<T> Tap<T>(this Result<T> result, Action tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            tap();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">Action that may fail.</param>
    public static Result<T> Tap<T>(this Result<T> result, Action<T> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            tap(result.Value);
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
    public static async Task<Result<T>> TapAsync<T>(this Task<Result<T>> resultTask, Func<Task> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            await tap();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">Action that may fail.</param>
    public static async Task<Result<T>> TapAsync<T>(this Task<Result<T>> resultTask, Func<T, Task> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            await tap(result.Value);
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
    public static async ValueTask<Result<T>> TapAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            await tap();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">Action that may fail.</param>
    public static async ValueTask<Result<T>> TapAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            await tap(result.Value);
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
    public static async Task<Result<T>> TapAsync<T>(this Result<T> result, Func<Task> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            await tap();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">Action that may fail.</param>
    public static async Task<Result<T>> TapAsync<T>(this Result<T> result, Func<T, Task> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            await tap(result.Value);
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
    public static async ValueTask<Result<T>> TapAsync<T>(this Result<T> result, Func<ValueTask> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            await tap();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="tap">Action that may fail.</param>
    public static async ValueTask<Result<T>> TapAsync<T>(this Result<T> result, Func<T, ValueTask> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        if (result.IsSuccess)
        {
            await tap(result.Value);
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
    public static async Task<Result<T>> TapAsync<T>(this Task<Result<T>> resultTask, Action tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            tap();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">Action that may fail.</param>
    public static async Task<Result<T>> TapAsync<T>(this Task<Result<T>> resultTask, Action<T> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            tap(result.Value);
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
    public static async ValueTask<Result<T>> TapAsync<T>(this ValueTask<Result<T>> resultTask, Action tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            tap();
        }
        return result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="tap">Action that may fail.</param>
    public static async ValueTask<Result<T>> TapAsync<T>(this ValueTask<Result<T>> resultTask, Action<T> tap)
    {
        ArgumentNullException.ThrowIfNull(tap);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            tap(result.Value);
        }
        return result;
    }

    #endregion

}
