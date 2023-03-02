namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region BindIf

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result BindIf(this Result result, Func<Result, bool> predicate, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Bind(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T1> BindIf<T1>(this Result result, Func<Result, bool> predicate, Func<Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T1>();
    }

    #endregion

    #region BindIf Full Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindIfAsync(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindIfAsync<T1>(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Task<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult<T1>();
    }

    #endregion

    #region BindIf Full ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindIfAsync(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindIfAsync<T1>(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<ValueTask<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult<T1>();
    }

    #endregion

    #region BindIf Right Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindIfAsync(this Result result, Func<Result, bool> predicate, Func<Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindIfAsync<T1>(this Result result, Func<Result, bool> predicate, Func<Task<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult<T1>();
    }

    #endregion

    #region BindIf Right ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindIfAsync(this Result result, Func<Result, bool> predicate, Func<ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindIfAsync<T1>(this Result result, Func<Result, bool> predicate, Func<ValueTask<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult<T1>();
    }

    #endregion

    #region BindIf Left Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindIfAsync(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Bind(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindIfAsync<T1>(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T1>();
    }

    #endregion

    #region BindIf Left ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindIfAsync(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Bind(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindIfAsync<T1>(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T1>();
    }

    #endregion

}
