namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region TapIf

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    public static Result TapIf(this Result result, bool condition, Action tap)
    {
        return condition ? result.Tap(tap) : result;
    }

    #endregion

    #region TapIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    public static Task<Result> TapIfAsync(this Task<Result> resultTask, bool condition, Func<Task> tap)
    {
        return condition ? resultTask.TapAsync(tap) : resultTask;
    }

    #endregion

    #region TapIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    public static ValueTask<Result> TapIfAsync(this ValueTask<Result> resultTask, bool condition, Func<ValueTask> tap)
    {
        return condition ? resultTask.TapAsync(tap) : resultTask;
    }

    #endregion

    #region TapIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    public static Task<Result> TapIfAsync(this Result result, bool condition, Func<Task> tap)
    {
        return condition ? result.TapAsync(tap) : Task.FromResult(result);
    }

    #endregion

    #region TapIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    public static ValueTask<Result> TapIfAsync(this Result result, bool condition, Func<ValueTask> tap)
    {
        return condition ? result.TapAsync(tap) : ValueTask.FromResult(result);
    }

    #endregion

    #region TapIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    public static Task<Result> TapIfAsync(this Task<Result> resultTask, bool condition, Action tap)
    {
        return condition ? resultTask.TapAsync(tap) : resultTask;
    }

    #endregion

    #region TapIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">Action that may fail.</param>
    public static ValueTask<Result> TapIfAsync(this ValueTask<Result> resultTask, bool condition, Action tap)
    {
        return condition ? resultTask.TapAsync(tap) : resultTask;
    }

    #endregion

}
