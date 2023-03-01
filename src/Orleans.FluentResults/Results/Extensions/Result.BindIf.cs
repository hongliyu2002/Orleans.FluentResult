namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region BindIf

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result BindIf(this Result result, bool condition, Func<Result> bind)
    {
        return condition ? result.Bind(bind) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> BindIf<T>(this Result result, bool condition, Func<Result<T>> bind)
    {
        return condition ? result.Bind(bind) : result.ToResult<T>();
    }

    #endregion

    #region BindIf Full Async

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync(this Task<Result> resultTask, bool condition, Func<Task<Result>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result> resultTask, bool condition, Func<Task<Result<T>>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T>();
    }

    #endregion

    #region BindIf Full ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync(this ValueTask<Result> resultTask, bool condition, Func<ValueTask<Result>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result> resultTask, bool condition, Func<ValueTask<Result<T>>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T>();
    }

    #endregion

    #region BindIf Right Async

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync(this Result result, bool condition, Func<Task<Result>> bind)
    {
        return condition ? result.BindAsync(bind) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Result result, bool condition, Func<Task<Result<T>>> bind)
    {
        return condition ? result.BindAsync(bind) : Task.FromResult(result.ToResult<T>());
    }

    #endregion

    #region BindIf Right ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync(this Result result, bool condition, Func<ValueTask<Result>> bind)
    {
        return condition ? result.BindAsync(bind) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this Result result, bool condition, Func<ValueTask<Result<T>>> bind)
    {
        return condition ? result.BindAsync(bind) : ValueTask.FromResult(result.ToResult<T>());
    }

    #endregion

    #region BindIf Left Async

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result> BindIfAsync(this Task<Result> resultTask, bool condition, Func<Result> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Task<Result<T>> BindIfAsync<T>(this Task<Result> resultTask, bool condition, Func<Result<T>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T>();
    }

    #endregion

    #region BindIf Left ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result> BindIfAsync(this ValueTask<Result> resultTask, bool condition, Func<Result> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    public static ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result> resultTask, bool condition, Func<Result<T>> bind)
    {
        return condition ? resultTask.BindAsync(bind) : resultTask.ToResultAsync<T>();
    }

    #endregion

}
