namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region MapTryIf

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="catchHandler"></param>
    public static Result MapTryIf<T>(this Result<T> result, bool condition, Action map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTry(map, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="catchHandler"></param>
    public static Result MapTryIf<T>(this Result<T> result, bool condition, Action<T> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTry(map, catchHandler) : result.ToResult();
    }

    #endregion

    #region MapTryIf Full Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> MapTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> MapTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    #endregion

    #region MapTryIf Full ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> MapTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> MapTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    #endregion

    #region MapTryIf Right Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> MapTryIfAsync<T>(this Result<T> result, bool condition, Func<Task> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.MapTryAsync(map, catchHandler, configureAwait) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> MapTryIfAsync<T>(this Result<T> result, bool condition, Func<T, Task> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.MapTryAsync(map, catchHandler, configureAwait) : Task.FromResult(result.ToResult());
    }

    #endregion

    #region MapTryIf Right ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> MapTryIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.MapTryAsync(map, catchHandler, configureAwait) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> MapTryIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.MapTryAsync(map, catchHandler, configureAwait) : ValueTask.FromResult(result.ToResult());
    }

    #endregion

    #region MapTryIf Left Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> MapTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Action map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> MapTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Action<T> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    #endregion

    #region MapTryIf Left ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> MapTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Action map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> MapTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Action<T> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    #endregion

}
