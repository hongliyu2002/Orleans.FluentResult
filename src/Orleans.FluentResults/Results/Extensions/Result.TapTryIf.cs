namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region TapTryIf

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result TapTryIf(this Result result, bool condition, Action tap, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapTry(tap, catchHandler) : result;
    }

    #endregion

    #region TapTryIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result> TapTryIfAsync(this Task<Result> resultTask, bool condition, Func<Task> tap, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapTryAsync(tap, catchHandler) : resultTask;
    }

    #endregion

    #region TapTryIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> TapTryIfAsync(this ValueTask<Result> resultTask, bool condition, Func<ValueTask> tap, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapTryAsync(tap, catchHandler) : resultTask;
    }

    #endregion

    #region TapTryIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result> TapTryIfAsync(this Result result, bool condition, Func<Task> tap, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapTryAsync(tap, catchHandler) : Task.FromResult(result);
    }

    #endregion

    #region TapTryIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> TapTryIfAsync(this Result result, bool condition, Func<ValueTask> tap, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.TapTryAsync(tap, catchHandler) : ValueTask.FromResult(result);
    }

    #endregion

    #region TapTryIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result> TapTryIfAsync(this Task<Result> resultTask, bool condition, Action tap, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapTryAsync(tap, catchHandler) : resultTask;
    }

    #endregion

    #region TapTryIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> TapTryIfAsync(this ValueTask<Result> resultTask, bool condition, Action tap, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.TapTryAsync(tap, catchHandler) : resultTask;
    }

    #endregion

}
