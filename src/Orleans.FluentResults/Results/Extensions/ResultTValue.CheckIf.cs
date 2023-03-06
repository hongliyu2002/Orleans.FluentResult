namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region CheckIf

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    public static Result<T> CheckIf<T>(this Result<T> result, bool condition, Func<Result> check)
    {
        return condition ? result.Check(check) : result;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    public static Result<T> CheckIf<T>(this Result<T> result, bool condition, Func<T, Result> check)
    {
        return condition ? result.Check(check) : result;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    public static Result<T> CheckIf<T>(this Result<T> result, bool condition, Func<Result<T>> check)
    {
        return condition ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    public static Result<T> CheckIf<T>(this Result<T> result, bool condition, Func<T, Result<T>> check)
    {
        return condition ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    public static Result<T> CheckIf<T, TOutput>(this Result<T> result, bool condition, Func<Result<TOutput>> check)
    {
        return condition ? result.Check(check) : result;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    public static Result<T> CheckIf<T, TOutput>(this Result<T> result, bool condition, Func<T, Result<TOutput>> check)
    {
        return condition ? result.Check(check) : result;
    }

    #endregion

    #region CheckIf Full Async

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result<T>>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync<T>(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<T>>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync<T>(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    #endregion

    #region CheckIf Full ValueTask Async

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result<T>>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync<T>(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<T>>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync<T>(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    #endregion

    #region CheckIf Right Async

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T>(this Result<T> result, bool condition, Func<Task<Result>> check, bool configureAwait = true)
    {
        return condition ? result.CheckAsync(check, configureAwait) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T>(this Result<T> result, bool condition, Func<T, Task<Result>> check, bool configureAwait = true)
    {
        return condition ? result.CheckAsync(check, configureAwait) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T>(this Result<T> result, bool condition, Func<Task<Result<T>>> check, bool configureAwait = true)
    {
        return condition ? result.CheckAsync<T>(check, configureAwait) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T>(this Result<T> result, bool condition, Func<T, Task<Result<T>>> check, bool configureAwait = true)
    {
        return condition ? result.CheckAsync<T>(check, configureAwait) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        return condition ? result.CheckAsync(check, configureAwait) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<T, Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        return condition ? result.CheckAsync(check, configureAwait) : Task.FromResult(result);
    }

    #endregion

    #region CheckIf Right ValueTask Async

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask<Result>> check, bool configureAwait = true)
    {
        return condition ? result.CheckAsync(check, configureAwait) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result>> check, bool configureAwait = true)
    {
        return condition ? result.CheckAsync(check, configureAwait) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask<Result<T>>> check, bool configureAwait = true)
    {
        return condition ? result.CheckAsync<T>(check, configureAwait) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result<T>>> check, bool configureAwait = true)
    {
        return condition ? result.CheckAsync<T>(check, configureAwait) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        return condition ? result.CheckAsync(check, configureAwait) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<T, ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        return condition ? result.CheckAsync(check, configureAwait) : ValueTask.FromResult(result);
    }

    #endregion

    #region CheckIf Left Async

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Result> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Result<T>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync<T>(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<T>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync<T>(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<Result<TOutput>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> CheckIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<TOutput>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    #endregion

    #region CheckIf Left ValueTask Async

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result<T>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync<T>(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<T>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync<T>(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result<TOutput>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> CheckIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<TOutput>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    #endregion

}
