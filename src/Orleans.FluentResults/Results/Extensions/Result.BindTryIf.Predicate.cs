namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region BindTryIf

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result BindTryIf(this Result result, Func<bool> predicate, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? result.BindTry(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> BindTryIf<TOutput>(this Result result, Func<bool> predicate, Func<Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? result.BindTry(bind, catchHandler) : result.ToResult<TOutput>();
    }

    #endregion

    #region BindTryIf Full Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync(this Task<Result> resultTask, Func<bool> predicate, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryIfAsync<TOutput>(this Task<Result> resultTask, Func<bool> predicate, Func<Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<TOutput>();
    }

    #endregion

    #region BindTryIf Full ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Func<ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryIfAsync<TOutput>(this ValueTask<Result> resultTask, Func<bool> predicate, Func<ValueTask<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<TOutput>();
    }

    #endregion

    #region BindTryIf Right Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync(this Result result, Func<bool> predicate, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryIfAsync<TOutput>(this Result result, Func<bool> predicate, Func<Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<TOutput>();
    }

    #endregion

    #region BindTryIf Right ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync(this Result result, Func<bool> predicate, Func<ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryIfAsync<TOutput>(this Result result, Func<bool> predicate, Func<ValueTask<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? await result.BindTryAsync(bind, catchHandler, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<TOutput>();
    }

    #endregion

    #region BindTryIf Left Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync(this Task<Result> resultTask, Func<bool> predicate, Func<Result> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result.BindTry(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryIfAsync<TOutput>(this Task<Result> resultTask, Func<bool> predicate, Func<Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result.BindTry(bind, catchHandler) : result.ToResult<TOutput>();
    }

    #endregion

    #region BindTryIf Left ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Func<Result> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result.BindTry(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryIfAsync<TOutput>(this ValueTask<Result> resultTask, Func<bool> predicate, Func<Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result.BindTry(bind, catchHandler) : result.ToResult<TOutput>();
    }

    #endregion

}
