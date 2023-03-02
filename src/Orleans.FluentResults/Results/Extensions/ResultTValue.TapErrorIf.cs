namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region TapErrorIf

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Result<T> TapErrorIf<T>(this Result<T> result, bool condition, Action tapError)
    {
        return condition ? result.TapError(tapError) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Result<T> TapErrorIf<T>(this Result<T> result, bool condition, Action<T> tapError)
    {
        return condition ? result.TapError(tapError) : result;
    }

    #endregion

    #region TapErrorIf Full Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Task<Result<T>> TapErrorIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task> tapError)
    {
        return condition ? resultTask.TapErrorAsync(tapError) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Task<Result<T>> TapErrorIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task> tapError)
    {
        return condition ? resultTask.TapErrorAsync(tapError) : resultTask;
    }

    #endregion

    #region TapErrorIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static ValueTask<Result<T>> TapErrorIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask> tapError)
    {
        return condition ? resultTask.TapErrorAsync(tapError) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static ValueTask<Result<T>> TapErrorIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask> tapError)
    {
        return condition ? resultTask.TapErrorAsync(tapError) : resultTask;
    }

    #endregion

    #region TapErrorIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Task<Result<T>> TapErrorIfAsync<T>(this Result<T> result, bool condition, Func<Task> tapError)
    {
        return condition ? result.TapErrorAsync(tapError) : Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Task<Result<T>> TapErrorIfAsync<T>(this Result<T> result, bool condition, Func<T, Task> tapError)
    {
        return condition ? result.TapErrorAsync(tapError) : Task.FromResult(result);
    }

    #endregion

    #region TapErrorIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static ValueTask<Result<T>> TapErrorIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask> tapError)
    {
        return condition ? result.TapErrorAsync(tapError) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static ValueTask<Result<T>> TapErrorIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask> tapError)
    {
        return condition ? result.TapErrorAsync(tapError) : ValueTask.FromResult(result);
    }

    #endregion

    #region TapErrorIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Task<Result<T>> TapErrorIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Action tapError)
    {
        return condition ? resultTask.TapErrorAsync(tapError) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static Task<Result<T>> TapErrorIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Action<T> tapError)
    {
        return condition ? resultTask.TapErrorAsync(tapError) : resultTask;
    }

    #endregion

    #region TapErrorIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static ValueTask<Result<T>> TapErrorIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Action tapError)
    {
        return condition ? resultTask.TapErrorAsync(tapError) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tapError">Action that may fail.</param>
    public static ValueTask<Result<T>> TapErrorIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Action<T> tapError)
    {
        return condition ? resultTask.TapErrorAsync(tapError) : resultTask;
    }

    #endregion

}
