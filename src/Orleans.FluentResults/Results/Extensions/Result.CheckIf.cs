namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region CheckIf

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    public static Result CheckIf(this Result result, bool condition, Func<Result> check)
    {
        return condition ? result.Check(check) : result;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="check">check action</param>
    public static Result CheckIf<TOutput>(this Result result, bool condition, Func<Result<TOutput>> check)
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
    public static Task<Result> CheckIfAsync(this Task<Result> resultTask, bool condition, Func<Task<Result>> check, bool configureAwait = true)
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
    public static Task<Result> CheckIfAsync<TOutput>(this Task<Result> resultTask, bool condition, Func<Task<Result<TOutput>>> check, bool configureAwait = true)
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
    public static ValueTask<Result> CheckIfAsync(this ValueTask<Result> resultTask, bool condition, Func<ValueTask<Result>> check, bool configureAwait = true)
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
    public static ValueTask<Result> CheckIfAsync<TOutput>(this ValueTask<Result> resultTask, bool condition, Func<ValueTask<Result<TOutput>>> check, bool configureAwait = true)
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
    public static Task<Result> CheckIfAsync(this Result result, bool condition, Func<Task<Result>> check, bool configureAwait = true)
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
    public static Task<Result> CheckIfAsync<TOutput>(this Result result, bool condition, Func<Task<Result<TOutput>>> check, bool configureAwait = true)
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
    public static ValueTask<Result> CheckIfAsync(this Result result, bool condition, Func<ValueTask<Result>> check, bool configureAwait = true)
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
    public static ValueTask<Result> CheckIfAsync<TOutput>(this Result result, bool condition, Func<ValueTask<Result<TOutput>>> check, bool configureAwait = true)
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
    public static Task<Result> CheckIfAsync(this Task<Result> resultTask, bool condition, Func<Result> check, bool configureAwait = true)
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
    public static Task<Result> CheckIfAsync<TOutput>(this Task<Result> resultTask, bool condition, Func<Result<TOutput>> check, bool configureAwait = true)
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
    public static ValueTask<Result> CheckIfAsync(this ValueTask<Result> resultTask, bool condition, Func<Result> check, bool configureAwait = true)
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
    public static ValueTask<Result> CheckIfAsync<TOutput>(this ValueTask<Result> resultTask, bool condition, Func<Result<TOutput>> check, bool configureAwait = true)
    {
        return condition ? resultTask.CheckAsync(check, configureAwait) : resultTask;
    }

    #endregion

}
