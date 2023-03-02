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
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapErrorTryIf<T>(this Result<T> result, bool condition, Action tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> TapErrorTryIf<T>(this Result<T> result, bool condition, Action<T> tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapErrorTry(tapError, catchHandler) : result;
    }

    #endregion

    #region TapErrorTryIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task> tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task> tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler) : resultTask;
    }

    #endregion

    #region TapErrorTryIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask> tapError,
                                                             Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask> tapError,
                                                             Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler) : resultTask;
    }

    #endregion

    #region TapErrorTryIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, bool condition, Func<Task> tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapErrorTryAsync(tapError, catchHandler) : Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, bool condition, Func<T, Task> tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapErrorTryAsync(tapError, catchHandler) : Task.FromResult(result);
    }

    #endregion

    #region TapErrorTryIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask> tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapErrorTryAsync(tapError, catchHandler) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapErrorTryIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask> tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapErrorTryAsync(tapError, catchHandler) : ValueTask.FromResult(result);
    }

    #endregion

    #region TapErrorTryIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Action tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> TapErrorTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Action<T> tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler) : resultTask;
    }

    #endregion

    #region TapErrorTryIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Action tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> TapErrorTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Action<T> tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler) : resultTask;
    }

    #endregion

}
