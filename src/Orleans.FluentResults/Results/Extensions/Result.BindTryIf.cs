namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region BindTryIf

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result BindTryIf(this Result result, bool condition, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTry(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result<T> BindTryIf<T>(this Result result, bool condition, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTry(bind, catchHandler) : result.ToResult<T>();
    }

    #endregion

    #region BindTryIf Full Async

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync(this Task<Result> resultTask, bool condition, Func<Task<Result>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result> resultTask, bool condition, Func<Task<Result<T>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync<T>();
    }

    #endregion

    #region BindTryIf Full ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync(this ValueTask<Result> resultTask, bool condition, Func<ValueTask<Result>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result> resultTask, bool condition, Func<ValueTask<Result<T>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync<T>();
    }

    #endregion

    #region BindTryIf Right Async

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync(this Result result, bool condition, Func<Task<Result>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, configureAwait, catchHandler) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Result result, bool condition, Func<Task<Result<T>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, configureAwait, catchHandler) : Task.FromResult(result.ToResult<T>());
    }

    #endregion

    #region BindTryIf Right ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync(this Result result, bool condition, Func<ValueTask<Result>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, configureAwait, catchHandler) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this Result result, bool condition, Func<ValueTask<Result<T>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, configureAwait, catchHandler) : ValueTask.FromResult(result.ToResult<T>());
    }

    #endregion

    #region BindTryIf Left Async

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync(this Task<Result> resultTask, bool condition, Func<Result> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result> resultTask, bool condition, Func<Result<T>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync<T>();
    }

    #endregion

    #region BindTryIf Left ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync(this ValueTask<Result> resultTask, bool condition, Func<Result> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind action which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result> resultTask, bool condition, Func<Result<T>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync<T>();
    }

    #endregion

}
