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
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T1> MapTryIf<T, T1>(this Result<T> result, bool condition, Func<T1> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTry(map, catchHandler) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T1> MapTryIf<T, T1>(this Result<T> result, bool condition, Func<T, T1> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTry(map, catchHandler) : result.ToResult<T, T1>();
    }

    #endregion

    #region MapTryIf Full Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T1>> MapTryIfAsync<T, T1>(this Task<Result<T>> resultTask, bool condition, Func<Task<T1>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T1>> MapTryIfAsync<T, T1>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<T1>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

    #region MapTryIf Full ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T1>> MapTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<T1>> map,
                                                             Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T1>> MapTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<T1>> map,
                                                             Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

    #region MapTryIf Right Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T1>> MapTryIfAsync<T, T1>(this Result<T> result, bool condition, Func<Task<T1>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTryAsync(map, catchHandler) : Task.FromResult(result.ToResult<T, T1>());
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T1>> MapTryIfAsync<T, T1>(this Result<T> result, bool condition, Func<T, Task<T1>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTryAsync(map, catchHandler) : Task.FromResult(result.ToResult<T, T1>());
    }

    #endregion

    #region MapTryIf Right ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T1>> MapTryIfAsync<T, T1>(this Result<T> result, bool condition, Func<ValueTask<T1>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTryAsync(map, catchHandler) : ValueTask.FromResult(result.ToResult<T, T1>());
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T1>> MapTryIfAsync<T, T1>(this Result<T> result, bool condition, Func<T, ValueTask<T1>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTryAsync(map, catchHandler) : ValueTask.FromResult(result.ToResult<T, T1>());
    }

    #endregion

    #region MapTryIf Left Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T1>> MapTryIfAsync<T, T1>(this Task<Result<T>> resultTask, bool condition, Func<T1> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T1>> MapTryIfAsync<T, T1>(this Task<Result<T>> resultTask, bool condition, Func<T, T1> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

    #region MapTryIf Left ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T1>> MapTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool condition, Func<T1> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T1>> MapTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, T1> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

}
