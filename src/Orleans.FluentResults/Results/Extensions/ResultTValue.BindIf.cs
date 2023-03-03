namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region BindIf

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result BindIf<T>(this Result<T> result, bool condition, Func<Result> bind)
    {
        return condition ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result BindIf<T>(this Result<T> result, bool condition, Func<T, Result> bind)
    {
        return condition ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> BindIf<T>(this Result<T> result, bool condition, Func<Result<T>> bind)
    {
        return condition ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> BindIf<T>(this Result<T> result, bool condition, Func<T, Result<T>> bind)
    {
        return condition ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<TOutput> BindIf<T, TOutput>(this Result<T> result, bool condition, Func<Result<TOutput>> bind)
    {
        return condition ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<TOutput> BindIf<T, TOutput>(this Result<T> result, bool condition, Func<T, Result<TOutput>> bind)
    {
        return condition ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Full Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result<T>>> bind)
    {
        return condition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<T>>> bind)
    {
        return condition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result<TOutput>>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, TOutput>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<TOutput>>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, TOutput>();
    }

    #endregion

    #region BindIf Full ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result<T>>> bind)
    {
        return condition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<T>>> bind)
    {
        return condition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result<TOutput>>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, TOutput>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<TOutput>>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, TOutput>();
    }

    #endregion

    #region BindIf Right Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Result<T> result, bool condition, Func<Task<Result>> bind)
    {
        return condition ? result.BindAsync(bind) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Result<T> result, bool condition, Func<T, Task<Result>> bind)
    {
        return condition ? result.BindAsync(bind) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Result<T> result, bool condition, Func<Task<Result<T>>> bind)
    {
        return condition ? result.BindAsync<T>(bind) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Result<T> result, bool condition, Func<T, Task<Result<T>>> bind)
    {
        return condition ? result.BindAsync<T>(bind) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<Task<Result<TOutput>>> bind)
    {
        return condition ? result.BindAsync(bind) : Task.FromResult(result.ToResult<T, TOutput>());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<T, Task<Result<TOutput>>> bind)
    {
        return condition ? result.BindAsync(bind) : Task.FromResult(result.ToResult<T, TOutput>());
    }

    #endregion

    #region BindIf Right ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask<Result>> bind)
    {
        return condition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result>> bind)
    {
        return condition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask<Result<T>>> bind)
    {
        return condition ? result.BindAsync<T>(bind) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result<T>>> bind)
    {
        return condition ? result.BindAsync<T>(bind) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<ValueTask<Result<TOutput>>> bind)
    {
        return condition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult<T, TOutput>());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<T, ValueTask<Result<TOutput>>> bind)
    {
        return condition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult<T, TOutput>());
    }

    #endregion

    #region BindIf Left Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Result> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Result<T>> bind)
    {
        return condition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<T>> bind)
    {
        return condition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<Result<TOutput>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, TOutput>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<TOutput>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, TOutput>();
    }

    #endregion

    #region BindIf Left ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result<T>> bind)
    {
        return condition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<T>> bind)
    {
        return condition ? resultTask.BindAsync<T>(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result<TOutput>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, TOutput>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<TOutput>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T, TOutput>();
    }

    #endregion

}
