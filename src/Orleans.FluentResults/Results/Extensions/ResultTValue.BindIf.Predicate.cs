namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region BindIf

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result BindIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result BindIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Result> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> BindIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> BindIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<TOutput> BindIf<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<TOutput> BindIf<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Full Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<Result<TOutput>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<Result<TOutput>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Full ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<Result<TOutput>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<TOutput>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Right Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<Result<TOutput>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<Result<TOutput>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Right ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<Result<TOutput>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<TOutput>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(true) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Left Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Left ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    #endregion

}
