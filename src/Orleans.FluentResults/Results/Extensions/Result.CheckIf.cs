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
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result CheckIf(this Result result, bool checkCondition, Func<Result> check)
    {
        return checkCondition ? result.Check(check) : result;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result CheckIf<T1>(this Result result, bool checkCondition, Func<Result<T1>> check)
    {
        return checkCondition ? result.Check(check) : result;
    }

    #endregion

    #region CheckIf Full Async

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result> CheckIfAsync(this Task<Result> resultTask, bool checkCondition, Func<Task<Result>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result> CheckIfAsync<T1>(this Task<Result> resultTask, bool checkCondition, Func<Task<Result<T1>>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    #endregion

    #region CheckIf Full ValueTask Async

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result> CheckIfAsync(this ValueTask<Result> resultTask, bool checkCondition, Func<ValueTask<Result>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result> CheckIfAsync<T1>(this ValueTask<Result> resultTask, bool checkCondition, Func<ValueTask<Result<T1>>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    #endregion

    #region CheckIf Right Async

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result> CheckIfAsync(this Result result, bool checkCondition, Func<Task<Result>> check)
    {
        return checkCondition ? result.CheckAsync(check) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result> CheckIfAsync<T1>(this Result result, bool checkCondition, Func<Task<Result<T1>>> check)
    {
        return checkCondition ? result.CheckAsync(check) : Task.FromResult(result);
    }

    #endregion

    #region CheckIf Right ValueTask Async

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result> CheckIfAsync(this Result result, bool checkCondition, Func<ValueTask<Result>> check)
    {
        return checkCondition ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result> CheckIfAsync<T1>(this Result result, bool checkCondition, Func<ValueTask<Result<T1>>> check)
    {
        return checkCondition ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }

    #endregion

    #region CheckIf Left Async

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result> CheckIfAsync(this Task<Result> resultTask, bool checkCondition, Func<Result> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result> CheckIfAsync<T1>(this Task<Result> resultTask, bool checkCondition, Func<Result<T1>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    #endregion

    #region CheckIf Left ValueTask Async

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result> CheckIfAsync(this ValueTask<Result> resultTask, bool checkCondition, Func<Result> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result> CheckIfAsync<T1>(this ValueTask<Result> resultTask, bool checkCondition, Func<Result<T1>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    #endregion

}
