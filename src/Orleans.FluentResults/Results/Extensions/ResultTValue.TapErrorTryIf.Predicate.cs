namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region TapErrorTryIf

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapErrorTryIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Action tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapErrorTryIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Action<T> tapError, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    #endregion

    #region TapErrorTryIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task> tapError,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task> tapError,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler).ConfigureAwait(false) : result;
    }

    #endregion

    #region TapErrorTryIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask> tapError,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask> tapError,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler).ConfigureAwait(false) : result;
    }

    #endregion

    #region TapErrorTryIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task> tapError,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task> tapError,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler).ConfigureAwait(false) : result;
    }

    #endregion

    #region TapErrorTryIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask> tapError,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask> tapError,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.TapErrorTryAsync(tapError, catchHandler).ConfigureAwait(false) : result;
    }

    #endregion

    #region TapErrorTryIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action tapError,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action<T> tapError,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    #endregion

    #region TapErrorTryIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action tapError,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Action<T> tapError,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    #endregion

}
