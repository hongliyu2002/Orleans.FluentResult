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
    public static Result<TOutput> MapTryIf<T, TOutput>(this Result<T> result, bool condition, Func<TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTry(map, catchHandler) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> MapTryIf<T, TOutput>(this Result<T> result, bool condition, Func<T, TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTry(map, catchHandler) : result.ToResult<T, TOutput>();
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
    public static Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<Task<TOutput>> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<TOutput>> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
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
    public static ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
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
    public static Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<Task<TOutput>> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.MapTryAsync(map, catchHandler, configureAwait) : Task.FromResult(result.ToResult<T, TOutput>());
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<T, Task<TOutput>> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.MapTryAsync(map, catchHandler, configureAwait) : Task.FromResult(result.ToResult<T, TOutput>());
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
    public static ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.MapTryAsync(map, catchHandler, configureAwait) : ValueTask.FromResult(result.ToResult<T, TOutput>());
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<T, ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.MapTryAsync(map, catchHandler, configureAwait) : ValueTask.FromResult(result.ToResult<T, TOutput>());
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
    public static Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<TOutput> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<T, TOutput> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
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
    public static ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<TOutput> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, TOutput> map, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    #endregion

}
