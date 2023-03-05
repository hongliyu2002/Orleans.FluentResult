namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region TapErrorTryIf

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result TapErrorTryIf(this Result result, bool condition, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
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
    public static Task<Result> TapErrorTryIfAsync(this Task<Result> resultTask, bool condition, Func<IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null)
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
    public static ValueTask<Result> TapErrorTryIfAsync(this ValueTask<Result> resultTask, bool condition, Func<IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null)
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
    public static Task<Result> TapErrorTryIfAsync(this Result result, bool condition, Func<IEnumerable<IError>, Task> tapError, Func<Exception, IError>? catchHandler = null)
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
    public static ValueTask<Result> TapErrorTryIfAsync(this Result result, bool condition, Func<IEnumerable<IError>, ValueTask> tapError, Func<Exception, IError>? catchHandler = null)
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
    public static Task<Result> TapErrorTryIfAsync(this Task<Result> resultTask, bool condition, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
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
    public static ValueTask<Result> TapErrorTryIfAsync(this ValueTask<Result> resultTask, bool condition, Action<IEnumerable<IError>> tapError, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapErrorTryAsync(tapError, catchHandler) : resultTask;
    }

    #endregion

}
