namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region CheckIf

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> CheckIf<T>(this Result<T> result, bool checkCondition, Func<Result> bind)
    {
        return checkCondition ? result.Check(bind) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> CheckIf<T>(this Result<T> result, bool checkCondition, Func<T, Result> bind)
    {
        return checkCondition ? result.Check(bind) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> CheckIf<T>(this Result<T> result, bool checkCondition, Func<Result<T>> bind)
    {
        return checkCondition ? result.Check<T>(bind) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> CheckIf<T>(this Result<T> result, bool checkCondition, Func<T, Result<T>> bind)
    {
        return checkCondition ? result.Check<T>(bind) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> CheckIf<T, T1>(this Result<T> result, bool checkCondition, Func<Result<T1>> bind)
    {
        return checkCondition ? result.Check(bind) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> CheckIf<T, T1>(this Result<T> result, bool checkCondition, Func<T, Result<T1>> bind)
    {
        return checkCondition ? result.Check(bind) : result;
    }

    #endregion

    #region CheckIf Full Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<Task<Result>> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<T, Task<Result>> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<Task<Result<T>>> bind)
    {
        return checkCondition ? resultTask.CheckAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<T, Task<Result<T>>> bind)
    {
        return checkCondition ? resultTask.CheckAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T, T1>(this Task<Result<T>> resultTask, bool checkCondition, Func<Task<Result<T1>>> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T, T1>(this Task<Result<T>> resultTask, bool checkCondition, Func<T, Task<Result<T1>>> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    #endregion

    #region CheckIf Full ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<ValueTask<Result>> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<T, ValueTask<Result>> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<ValueTask<Result<T>>> bind)
    {
        return checkCondition ? resultTask.CheckAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<T, ValueTask<Result<T>>> bind)
    {
        return checkCondition ? resultTask.CheckAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<ValueTask<Result<T1>>> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<T, ValueTask<Result<T1>>> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    #endregion

    #region CheckIf Right Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<Task<Result>> bind)
    {
        return checkCondition ? result.CheckAsync(bind) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<T, Task<Result>> bind)
    {
        return checkCondition ? result.CheckAsync(bind) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<Task<Result<T>>> bind)
    {
        return checkCondition ? result.CheckAsync<T>(bind) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<T, Task<Result<T>>> bind)
    {
        return checkCondition ? result.CheckAsync<T>(bind) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T, T1>(this Result<T> result, bool checkCondition, Func<Task<Result<T1>>> bind)
    {
        return checkCondition ? result.CheckAsync(bind) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T, T1>(this Result<T> result, bool checkCondition, Func<T, Task<Result<T1>>> bind)
    {
        return checkCondition ? result.CheckAsync(bind) : Task.FromResult(result);
    }

    #endregion

    #region CheckIf Right ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<ValueTask<Result>> bind)
    {
        return checkCondition ? result.CheckAsync(bind) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<T, ValueTask<Result>> bind)
    {
        return checkCondition ? result.CheckAsync(bind) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<ValueTask<Result<T>>> bind)
    {
        return checkCondition ? result.CheckAsync<T>(bind) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, bool checkCondition, Func<T, ValueTask<Result<T>>> bind)
    {
        return checkCondition ? result.CheckAsync<T>(bind) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T, T1>(this Result<T> result, bool checkCondition, Func<ValueTask<Result<T1>>> bind)
    {
        return checkCondition ? result.CheckAsync(bind) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T, T1>(this Result<T> result, bool checkCondition, Func<T, ValueTask<Result<T1>>> bind)
    {
        return checkCondition ? result.CheckAsync(bind) : ValueTask.FromResult(result);
    }

    #endregion

    #region CheckIf Left Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<Result> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<T, Result> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<Result<T>> bind)
    {
        return checkCondition ? resultTask.CheckAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, bool checkCondition, Func<T, Result<T>> bind)
    {
        return checkCondition ? resultTask.CheckAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T, T1>(this Task<Result<T>> resultTask, bool checkCondition, Func<Result<T1>> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> CheckIfAsync<T, T1>(this Task<Result<T>> resultTask, bool checkCondition, Func<T, Result<T1>> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    #endregion

    #region CheckIf Left ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<Result> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<T, Result> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<Result<T>> bind)
    {
        return checkCondition ? resultTask.CheckAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<T, Result<T>> bind)
    {
        return checkCondition ? resultTask.CheckAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<Result<T1>> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="checkCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> CheckIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool checkCondition, Func<T, Result<T1>> bind)
    {
        return checkCondition ? resultTask.CheckAsync(bind) : resultTask;
    }

    #endregion

}
