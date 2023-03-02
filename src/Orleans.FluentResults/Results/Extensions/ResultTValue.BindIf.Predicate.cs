namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
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
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T1> BindIf<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T1> BindIf<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T, T1>();
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
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult();
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
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult();
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
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(false) : result;
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
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult<T, T1>();
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
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult();
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
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult();
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
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(false) : result;
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
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult<T, T1>();
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
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult();
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
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult();
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
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(false) : result;
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
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult<T, T1>();
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
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult();
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
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult();
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
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(false) : result;
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
        return predicate(result) ? await result.BindAsync<T>(bind).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindAsync(bind).ConfigureAwait(false) : result.ToResult<T, T1>();
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
        var result = await resultTask.ConfigureAwait(false);
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
        var result = await resultTask.ConfigureAwait(false);
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
        var result = await resultTask.ConfigureAwait(false);
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
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T, T1>();
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
        var result = await resultTask.ConfigureAwait(false);
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
        var result = await resultTask.ConfigureAwait(false);
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
        var result = await resultTask.ConfigureAwait(false);
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
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Bind(bind) : result.ToResult<T, T1>();
    }

    #endregion

}
