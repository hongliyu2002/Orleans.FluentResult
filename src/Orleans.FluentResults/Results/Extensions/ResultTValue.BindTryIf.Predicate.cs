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
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result BindTryIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result BindTryIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> BindTryIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> BindTryIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T1> BindTryIf<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T1> BindTryIf<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult<T, T1>();
    }

    #endregion

    #region BindTryIf Full Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<Result>> bind,
                                                       Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<Result>> bind,
                                                       Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<Result<T>>> bind,
                                                          Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync<T>(bind, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<Result<T>>> bind,
                                                          Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync<T>(bind, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<Result<T1>>> bind,
                                                               Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<Result<T1>>> bind,
                                                               Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    #endregion

    #region BindTryIf Full ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<Result>> bind,
                                                            Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result>> bind,
                                                            Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<Result<T>>> bind,
                                                               Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync<T>(bind, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<T>>> bind,
                                                               Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync<T>(bind, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<Result<T1>>> bind,
                                                                    Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<T1>>> bind,
                                                                    Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    #endregion

    #region BindTryIf Right Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<Result>> bind,
                                                       Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<Result>> bind,
                                                       Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<Result<T>>> bind,
                                                          Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync<T>(bind, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<Result<T>>> bind,
                                                          Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync<T>(bind, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<Result<T1>>> bind,
                                                               Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<Result<T1>>> bind,
                                                               Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    #endregion

    #region BindTryIf Right ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<Result>> bind,
                                                            Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result>> bind,
                                                            Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<Result<T>>> bind,
                                                               Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync<T>(bind, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<T>>> bind,
                                                               Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync<T>(bind, catchHandler).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<Result<T1>>> bind,
                                                                    Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<T1>>> bind,
                                                                    Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.BindTryAsync(bind, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    #endregion

    #region BindTryIf Left Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result> bind,
                                                       Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result> bind,
                                                       Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<T>> bind,
                                                          Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<T>> bind,
                                                          Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<T1>> bind,
                                                               Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<T1>> bind,
                                                               Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult<T, T1>();
    }

    #endregion

    #region BindTryIf Left ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result> bind,
                                                            Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result> bind,
                                                            Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<T>> bind,
                                                               Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<T>> bind,
                                                               Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<T1>> bind,
                                                                    Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When predicate is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<T1>> bind,
                                                                    Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.BindTry(bind, catchHandler) : result.ToResult<T, T1>();
    }

    #endregion

}
