namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region BindIf

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result BindIf<T>(this Result<T> result, bool bindCondition, Func<Result> bind)
    {
        return bindCondition ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result BindIf<T>(this Result<T> result, bool bindCondition, Func<T, Result> bind)
    {
        return bindCondition ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> BindIf<T>(this Result<T> result, bool bindCondition, Func<Result<T>> bind)
    {
        return bindCondition ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> BindIf<T>(this Result<T> result, bool bindCondition, Func<T, Result<T>> bind)
    {
        return bindCondition ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T1> BindIf<T, T1>(this Result<T> result, bool bindCondition, Func<Result<T1>> bind)
    {
        return bindCondition ? result.Bind(bind) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T1> BindIf<T, T1>(this Result<T> result, bool bindCondition, Func<T, Result<T1>> bind)
    {
        return bindCondition ? result.Bind(bind) : result.ToResult<T, T1>();
    }

    #endregion

    #region BindIf Full Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<Task<Result>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<T, Task<Result>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<Task<Result<T>>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<T, Task<Result<T>>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T1>> BindIfAsync<T, T1>(this Task<Result<T>> resultTask, bool bindCondition, Func<Task<Result<T1>>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T1>> BindIfAsync<T, T1>(this Task<Result<T>> resultTask, bool bindCondition, Func<T, Task<Result<T1>>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

    #region BindIf Full ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<ValueTask<Result>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<T, ValueTask<Result>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<ValueTask<Result<T>>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<T, ValueTask<Result<T>>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T1>> BindIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<ValueTask<Result<T1>>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T1>> BindIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<T, ValueTask<Result<T1>>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

    #region BindIf Right Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<Task<Result>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<T, Task<Result>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<Task<Result<T>>> bind)
    {
        return bindCondition ? result.BindAsync<T>(bind) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<T, Task<Result<T>>> bind)
    {
        return bindCondition ? result.BindAsync<T>(bind) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T1>> BindIfAsync<T, T1>(this Result<T> result, bool bindCondition, Func<Task<Result<T1>>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : Task.FromResult(result.ToResult<T, T1>());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T1>> BindIfAsync<T, T1>(this Result<T> result, bool bindCondition, Func<T, Task<Result<T1>>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : Task.FromResult(result.ToResult<T, T1>());
    }

    #endregion

    #region BindIf Right ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<ValueTask<Result>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<T, ValueTask<Result>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<ValueTask<Result<T>>> bind)
    {
        return bindCondition ? result.BindAsync<T>(bind) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<T, ValueTask<Result<T>>> bind)
    {
        return bindCondition ? result.BindAsync<T>(bind) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T1>> BindIfAsync<T, T1>(this Result<T> result, bool bindCondition, Func<ValueTask<Result<T1>>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult<T, T1>());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T1>> BindIfAsync<T, T1>(this Result<T> result, bool bindCondition, Func<T, ValueTask<Result<T1>>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult<T, T1>());
    }

    #endregion

    #region BindIf Left Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<Result> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<T, Result> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<Result<T>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<T, Result<T>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T1>> BindIfAsync<T, T1>(this Task<Result<T>> resultTask, bool bindCondition, Func<Result<T1>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T1>> BindIfAsync<T, T1>(this Task<Result<T>> resultTask, bool bindCondition, Func<T, Result<T1>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

    #region BindIf Left ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<Result> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<T, Result> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<Result<T>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<T, Result<T>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T1>> BindIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<Result<T1>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T1>> BindIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<T, Result<T1>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

}
