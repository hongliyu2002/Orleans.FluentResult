namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region TapTryIf

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapTryIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Action tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.TapTry(tap, catchHandler) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapTryIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Action<T> tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.TapTry(tap, catchHandler) : result;
    }

    #endregion

    #region TapTryIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task> tap,
                                                         Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.TapTryAsync(tap, catchHandler).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task> tap,
                                                         Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.TapTryAsync(tap, catchHandler).ConfigureAwait(true) : result;
    }

    #endregion

    #region TapTryIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask> tap,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.TapTryAsync(tap, catchHandler).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask> tap,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.TapTryAsync(tap, catchHandler).ConfigureAwait(true) : result;
    }

    #endregion

    #region TapTryIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task> tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapTryAsync(tap, catchHandler).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task> tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapTryAsync(tap, catchHandler).ConfigureAwait(true) : result;
    }

    #endregion

    #region TapTryIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask> tap,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapTryAsync(tap, catchHandler).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask> tap,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapTryAsync(tap, catchHandler).ConfigureAwait(true) : result;
    }

    #endregion

    #region TapTryIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action tap, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.TapTry(tap, catchHandler) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action<T> tap,
                                                         Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.TapTry(tap, catchHandler) : result;
    }

    #endregion

    #region TapTryIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action tap,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.TapTry(tap, catchHandler) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and predicate is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action<T> tap,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.TapTry(tap, catchHandler) : result;
    }

    #endregion

}
