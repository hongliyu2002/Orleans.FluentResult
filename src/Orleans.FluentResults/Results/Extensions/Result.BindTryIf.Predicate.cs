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
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result BindTryIf(this Result result, Func<Result, bool> predicate, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T1> BindTryIf<T1>(this Result result, Func<Result, bool> predicate, Func<Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult<T1>();
    }

    #endregion

    #region BindTryIf Full Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Task<Result>> bind,
                                                    Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryIfAsync<T1>(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Task<Result<T1>>> bind,
                                                            Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult<T1>();
    }

    #endregion

    #region BindTryIf Full ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<ValueTask<Result>> bind,
                                                         Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryIfAsync<T1>(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<ValueTask<Result<T1>>> bind,
                                                                 Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult<T1>();
    }

    #endregion

    #region BindTryIf Right Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync(this Result result, Func<Result, bool> predicate, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryIfAsync<T1>(this Result result, Func<Result, bool> predicate, Func<Task<Result<T1>>> bind,
                                                            Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult<T1>();
    }

    #endregion

    #region BindTryIf Right ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync(this Result result, Func<Result, bool> predicate, Func<ValueTask<Result>> bind,
                                                         Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryIfAsync<T1>(this Result result, Func<Result, bool> predicate, Func<ValueTask<Result<T1>>> bind,
                                                                 Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult<T1>();
    }

    #endregion

    #region BindTryIf Left Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryIfAsync<T1>(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Result<T1>> bind,
                                                            Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult<T1>();
    }

    #endregion

    #region BindTryIf Left ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<Result> bind,
                                                         Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryIfAsync<T1>(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<Result<T1>> bind,
                                                                 Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult<T1>();
    }

    #endregion

}
