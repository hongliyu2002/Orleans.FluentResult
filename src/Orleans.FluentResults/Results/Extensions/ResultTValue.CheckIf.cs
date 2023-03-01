namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region CheckIf

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> CheckIf<T>(this Result<T> result, bool checkCondition, Func<Result> check)
    {
        return checkCondition ? result.Check(check) : result;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> CheckIf<T>(this Result<T> result, bool checkCondition, Func<T, Result> check)
    {
        return checkCondition ? result.Check(check) : result;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> CheckIf<T>(this Result<T> result, bool checkCondition, Func<Result<T>> check)
    {
        return checkCondition ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> CheckIf<T>(this Result<T> result, bool checkCondition, Func<T, Result<T>> check)
    {
        return checkCondition ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> CheckIf<T, T1>(this Result<T> result, bool checkCondition, Func<Result<T1>> check)
    {
        return checkCondition ? result.Check(check) : result;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> CheckIf<T, T1>(this Result<T> result, bool checkCondition, Func<T, Result<T1>> check)
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
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<Task<Result>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<T, Task<Result>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<Task<Result<T>>> check)
    {
        return checkCondition ? resultTask.CheckAsync<T>(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<T, Task<Result<T>>> check)
    {
        return checkCondition ? resultTask.CheckAsync<T>(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T, T1>(this Task<Result<T>> resultTask, bool checkCondition, Func<Task<Result<T1>>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T, T1>(this Task<Result<T>> resultTask, bool checkCondition, Func<T, Task<Result<T1>>> check)
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
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<ValueTask<Result>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<T, ValueTask<Result>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<ValueTask<Result<T>>> check)
    {
        return checkCondition ? resultTask.CheckAsync<T>(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<T, ValueTask<Result<T>>> check)
    {
        return checkCondition ? resultTask.CheckAsync<T>(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<ValueTask<Result<T1>>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<T, ValueTask<Result<T1>>> check)
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
    public static Task<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<Task<Result>> check)
    {
        return checkCondition ? result.CheckAsync(check) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<T, Task<Result>> check)
    {
        return checkCondition ? result.CheckAsync(check) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<Task<Result<T>>> check)
    {
        return checkCondition ? result.CheckAsync<T>(check) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<T, Task<Result<T>>> check)
    {
        return checkCondition ? result.CheckAsync<T>(check) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T, T1>(this Result<T> result, bool checkCondition, Func<Task<Result<T1>>> check)
    {
        return checkCondition ? result.CheckAsync(check) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T, T1>(this Result<T> result, bool checkCondition, Func<T, Task<Result<T1>>> check)
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
    public static ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<ValueTask<Result>> check)
    {
        return checkCondition ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<T, ValueTask<Result>> check)
    {
        return checkCondition ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<ValueTask<Result<T>>> check)
    {
        return checkCondition ? result.CheckAsync<T>(check) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<T, ValueTask<Result<T>>> check)
    {
        return checkCondition ? result.CheckAsync<T>(check) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T, T1>(this Result<T> result, bool checkCondition, Func<ValueTask<Result<T1>>> check)
    {
        return checkCondition ? result.CheckAsync(check) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T, T1>(this Result<T> result, bool checkCondition, Func<T, ValueTask<Result<T1>>> check)
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
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<Result> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<T, Result> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<Result<T>> check)
    {
        return checkCondition ? resultTask.CheckAsync<T>(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<T, Result<T>> check)
    {
        return checkCondition ? resultTask.CheckAsync<T>(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T, T1>(this Task<Result<T>> resultTask, bool checkCondition, Func<Result<T1>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T, T1>(this Task<Result<T>> resultTask, bool checkCondition, Func<T, Result<T1>> check)
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
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<Result> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<T, Result> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<Result<T>> check)
    {
        return checkCondition ? resultTask.CheckAsync<T>(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<T, Result<T>> check)
    {
        return checkCondition ? resultTask.CheckAsync<T>(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<Result<T1>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="check">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<T, Result<T1>> check)
    {
        return checkCondition ? resultTask.CheckAsync(check) : resultTask;
    }

    #endregion

}
