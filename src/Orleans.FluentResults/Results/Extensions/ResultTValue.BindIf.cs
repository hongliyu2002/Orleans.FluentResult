namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region BindIf

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result BindIf<T>(this Result<T> result, bool bindCondition, Func<Result> bind)
    {
        return bindCondition ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result BindIf<T>(this Result<T> result, bool bindCondition, Func<T, Result> bind)
    {
        return bindCondition ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> BindIf<T>(this Result<T> result, bool bindCondition, Func<Result<T>> bind)
    {
        return bindCondition ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> BindIf<T>(this Result<T> result, bool bindCondition, Func<T, Result<T>> bind)
    {
        return bindCondition ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T2> BindIf<T, T2>(this Result<T> result, bool bindCondition, Func<Result<T2>> bind)
    {
        return bindCondition ? result.Bind(bind) : result.ToResult<T, T2>();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T2> BindIf<T, T2>(this Result<T> result, bool bindCondition, Func<T, Result<T2>> bind)
    {
        return bindCondition ? result.Bind(bind) : result.ToResult<T, T2>();
    }

    #endregion

    #region BindIf Full Async

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<Task<Result>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<T, Task<Result>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<Task<Result<T>>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<T, Task<Result<T>>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T2>> BindIfAsync<T, T2>(this Task<Result<T>> resultTask, bool bindCondition, Func<Task<Result<T2>>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T2>();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T2>> BindIfAsync<T, T2>(this Task<Result<T>> resultTask, bool bindCondition, Func<T, Task<Result<T2>>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T2>();
    }

    #endregion

    #region BindIf Full ValueTask Async

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<ValueTask<Result>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<T, ValueTask<Result>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<ValueTask<Result<T>>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<T, ValueTask<Result<T>>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T2>> BindIfAsync<T, T2>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<ValueTask<Result<T2>>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T2>();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T2>> BindIfAsync<T, T2>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<T, ValueTask<Result<T2>>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T2>();
    }

    #endregion

    #region BindIf Right Async

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<Task<Result>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<T, Task<Result>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<Task<Result<T>>> bind)
    {
        return bindCondition ? result.BindAsync<T>(bind) : Task.FromResult(result);
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<T, Task<Result<T>>> bind)
    {
        return bindCondition ? result.BindAsync<T>(bind) : Task.FromResult(result);
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T2>> BindIfAsync<T, T2>(this Result<T> result, bool bindCondition, Func<Task<Result<T2>>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : Task.FromResult(result.ToResult<T, T2>());
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T2>> BindIfAsync<T, T2>(this Result<T> result, bool bindCondition, Func<T, Task<Result<T2>>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : Task.FromResult(result.ToResult<T, T2>());
    }

    #endregion

    #region BindIf Right ValueTask Async

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<ValueTask<Result>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<T, ValueTask<Result>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<ValueTask<Result<T>>> bind)
    {
        return bindCondition ? result.BindAsync<T>(bind) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this Result<T> result, bool bindCondition, Func<T, ValueTask<Result<T>>> bind)
    {
        return bindCondition ? result.BindAsync<T>(bind) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T2>> BindIfAsync<T, T2>(this Result<T> result, bool bindCondition, Func<ValueTask<Result<T2>>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult<T, T2>());
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T2>> BindIfAsync<T, T2>(this Result<T> result, bool bindCondition, Func<T, ValueTask<Result<T2>>> bind)
    {
        return bindCondition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult<T, T2>());
    }

    #endregion

    #region BindIf Left Async

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<Result> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<T, Result> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<Result<T>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, bool bindCondition, Func<T, Result<T>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T2>> BindIfAsync<T, T2>(this Task<Result<T>> resultTask, bool bindCondition, Func<Result<T2>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T2>();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T2>> BindIfAsync<T, T2>(this Task<Result<T>> resultTask, bool bindCondition, Func<T, Result<T2>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T2>();
    }

    #endregion

    #region BindIf Left ValueTask Async

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<Result> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<T, Result> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<Result<T>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<T, Result<T>> bind)
    {
        return bindCondition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T2>> BindIfAsync<T, T2>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<Result<T2>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T2>();
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bindCondition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T2>> BindIfAsync<T, T2>(this ValueTask<Result<T>> resultTask, bool bindCondition, Func<T, Result<T2>> bind)
    {
        return bindCondition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, T2>();
    }

    #endregion

}
