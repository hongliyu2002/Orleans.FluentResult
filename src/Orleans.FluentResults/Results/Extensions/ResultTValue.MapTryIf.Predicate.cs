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
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> MapTryIf<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.MapTry(map, catchHandler) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> MapTryIf<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.MapTry(map, catchHandler) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region MapTryIf Full Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<TOutput>> map,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<TOutput>> map,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region MapTryIf Full ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<TOutput>> map,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<TOutput>> map,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region MapTryIf Right Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<TOutput>> map,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<TOutput>> map,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region MapTryIf Right ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<TOutput>> map,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<TOutput>> map,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region MapTryIf Left Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<TOutput> map,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.MapTry(map, catchHandler) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> MapTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, TOutput> map,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.MapTry(map, catchHandler) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region MapTryIf Left ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<TOutput> map,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.MapTry(map, catchHandler) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> MapTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, TOutput> map,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.MapTry(map, catchHandler) : result.ToResult<T, TOutput>();
    }

    #endregion

}
