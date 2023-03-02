namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region MapTryIf

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T1> MapTryIf<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T1> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.MapTry(map, catchHandler) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T1> MapTryIf<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, T1> map, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.MapTry(map, catchHandler) : result.ToResult<T, T1>();
    }

    #endregion

    #region MapTryIf Full Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> MapTryIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<T1>> map,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> MapTryIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<T1>> map,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    #endregion

    #region MapTryIf Full ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> MapTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<T1>> map,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> MapTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<T1>> map,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    #endregion

    #region MapTryIf Right Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> MapTryIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<T1>> map,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> MapTryIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<T1>> map,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    #endregion

    #region MapTryIf Right ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> MapTryIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<T1>> map,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> MapTryIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<T1>> map,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapTryAsync(map, catchHandler).ConfigureAwait(false) : result.ToResult<T, T1>();
    }

    #endregion

    #region MapTryIf Left Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> MapTryIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T1> map,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.MapTry(map, catchHandler) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> MapTryIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, T1> map,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.MapTry(map, catchHandler) : result.ToResult<T, T1>();
    }

    #endregion

    #region MapTryIf Left ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> MapTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T1> map,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.MapTry(map, catchHandler) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> MapTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, T1> map,
                                                                   Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.MapTry(map, catchHandler) : result.ToResult<T, T1>();
    }

    #endregion

}
