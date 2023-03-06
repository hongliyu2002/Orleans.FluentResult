namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region TapIf

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    public static Result<T> TapIf<T>(this Result<T> result, bool condition, Action tap)
    {
        return condition ? result.Tap(tap) : result;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    public static Result<T> TapIf<T>(this Result<T> result, bool condition, Action<T> tap)
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
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> TapIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task> tap, bool configureAwait = true)
    {
        return condition ? resultTask.TapAsync(tap, configureAwait) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> TapIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task> tap, bool configureAwait = true)
    {
        return condition ? resultTask.TapAsync(tap, configureAwait) : resultTask;
    }

    #endregion

    #region TapIf Full ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> TapIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask> tap, bool configureAwait = true)
    {
        return condition ? resultTask.TapAsync(tap, configureAwait) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> TapIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask> tap, bool configureAwait = true)
    {
        return condition ? resultTask.TapAsync(tap, configureAwait) : resultTask;
    }

    #endregion

    #region TapIf Right Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> TapIfAsync<T>(this Result<T> result, bool condition, Func<Task> tap, bool configureAwait = true)
    {
        return condition ? result.TapAsync(tap, configureAwait) : Task.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> TapIfAsync<T>(this Result<T> result, bool condition, Func<T, Task> tap, bool configureAwait = true)
    {
        return condition ? result.TapAsync(tap, configureAwait) : Task.FromResult(result);
    }

    #endregion

    #region TapIf Right ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> TapIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask> tap, bool configureAwait = true)
    {
        return condition ? result.TapAsync(tap, configureAwait) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> TapIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask> tap, bool configureAwait = true)
    {
        return condition ? result.TapAsync(tap, configureAwait) : ValueTask.FromResult(result);
    }

    #endregion

    #region TapIf Left Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> TapIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Action tap, bool configureAwait = true)
    {
        return condition ? resultTask.TapAsync(tap, configureAwait) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> TapIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Action<T> tap, bool configureAwait = true)
    {
        return condition ? resultTask.TapAsync(tap, configureAwait) : resultTask;
    }

    #endregion

    #region TapIf Left ValueTask Async

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> TapIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Action tap, bool configureAwait = true)
    {
        return condition ? resultTask.TapAsync(tap, configureAwait) : resultTask;
    }

    /// <summary>
    ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="tap">tap action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> TapIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Action<T> tap, bool configureAwait = true)
    {
        return condition ? resultTask.TapAsync(tap, configureAwait) : resultTask;
    }

    #endregion

}
