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
    /// <param name="bind">bind action</param>
    public static Result BindIf<T>(this Result<T> result, Func<T, bool> predicate, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    public static Result BindIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    public static Result<T> BindIf<T>(this Result<T> result, Func<T, bool> predicate, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    public static Result<T> BindIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    public static Result<TOutput> BindIf<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    public static Result<TOutput> BindIf<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Full Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Task<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Task<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindAsync<T>(bind, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindAsync<T>(bind, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Task<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Full ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<ValueTask<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<ValueTask<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindAsync<T>(bind, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindAsync<T>(bind, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<ValueTask<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Right Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> BindIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<Task<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> BindIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> BindIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<Task<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindAsync<T>(bind, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> BindIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindAsync<T>(bind, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<Task<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Right ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> BindIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<ValueTask<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> BindIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> BindIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<ValueTask<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindAsync<T>(bind, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> BindIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindAsync<T>(bind, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<ValueTask<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindAsync(bind, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Left Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Result> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Result<T>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> BindIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<T>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Result<TOutput>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> BindIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<TOutput>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindIf Left ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<Result> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Bind(bind) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<Result<T>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> BindIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<T>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Bind<T>(bind) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<Result<TOutput>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> BindIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<TOutput>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Bind(bind) : result.ToResult<T, TOutput>();
    }

    #endregion

}
