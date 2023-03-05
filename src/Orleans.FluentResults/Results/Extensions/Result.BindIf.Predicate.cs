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
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<TOutput> BindIf<TOutput>(this Result result, Func<Result, bool> predicate, Func<Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Bind(bind) : result.ToResult<TOutput>();
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
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<TOutput>> BindIfAsync<TOutput>(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Task<Result<TOutput>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult<TOutput>();
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
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<TOutput>(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<ValueTask<Result<TOutput>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult<TOutput>();
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
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<TOutput>> BindIfAsync<TOutput>(this Result result, Func<Result, bool> predicate, Func<Task<Result<TOutput>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult<TOutput>();
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
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<TOutput>(this Result result, Func<Result, bool> predicate, Func<ValueTask<Result<TOutput>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult<TOutput>();
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
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<TOutput>> BindIfAsync<TOutput>(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind(bind) : result.ToResult<TOutput>();
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
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<TOutput>(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind(bind) : result.ToResult<TOutput>();
    }

    #endregion

}
