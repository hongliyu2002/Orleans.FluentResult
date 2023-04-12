namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region BindTryIf

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result BindTryIf<T>(this Result<T> result, Func<T, bool> predicate, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result BindTryIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result<T> BindTryIf<T>(this Result<T> result, Func<T, bool> predicate, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result<T> BindTryIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> BindTryIf<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.BindTry(bind, catchHandler) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> BindTryIf<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.BindTry(bind, catchHandler) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindTryIf Full Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindTryAsync<T>(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindTryAsync<T>(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindTryIf Full ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindTryAsync<T>(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindTryAsync<T>(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<ValueTask<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindTryIf Right Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindTryAsync<T>(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindTryAsync<T>(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindTryIf Right ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindTryAsync<T>(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindTryAsync<T>(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<ValueTask<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindTryIf Left Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Result> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<T>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.BindTry(bind, catchHandler) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.BindTry(bind, catchHandler) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindTryIf Left ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<Result> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<T>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.BindTry(bind, catchHandler) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.BindTry(bind, catchHandler) : result.ToResult<T, TOutput>();
    }

    #endregion

}
