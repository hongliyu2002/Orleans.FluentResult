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
    /// <param name="map">Action that may fail.</param>
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
    /// <param name="map">Action that may fail.</param>
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
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<Task<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    #endregion

    #region MapTryIf Full ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<TOutput>> map,
                                                             Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<TOutput>> map,
                                                             Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    #endregion

    #region MapTryIf Right Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<Task<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTryAsync(map, catchHandler) : Task.FromResult(result.ToResult<T, TOutput>());
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<T, Task<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTryAsync(map, catchHandler) : Task.FromResult(result.ToResult<T, TOutput>());
    }

    #endregion

    #region MapTryIf Right ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTryAsync(map, catchHandler) : ValueTask.FromResult(result.ToResult<T, TOutput>());
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<T, ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTryAsync(map, catchHandler) : ValueTask.FromResult(result.ToResult<T, TOutput>());
    }

    #endregion

    #region MapTryIf Left Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<T, TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    #endregion

    #region MapTryIf Left ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    #endregion

}
