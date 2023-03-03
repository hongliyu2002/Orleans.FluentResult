namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region MapTryIf

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> MapTryIf<TOutput>(this Result result, bool condition, Func<TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTry(map, catchHandler) : result.ToResult<TOutput>();
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
    public static Task<Result<TOutput>> MapTryIfAsync<TOutput>(this Task<Result> resultTask, bool condition, Func<Task<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<TOutput>();
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
    public static ValueTask<Result<TOutput>> MapTryIfAsync<TOutput>(this ValueTask<Result> resultTask, bool condition, Func<ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<TOutput>();
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
    public static Task<Result<TOutput>> MapTryIfAsync<TOutput>(this Result result, bool condition, Func<Task<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTryAsync(map, catchHandler) : Task.FromResult(result.ToResult<TOutput>());
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
    public static ValueTask<Result<TOutput>> MapTryIfAsync<TOutput>(this Result result, bool condition, Func<ValueTask<TOutput>> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.MapTryAsync(map, catchHandler) : ValueTask.FromResult(result.ToResult<TOutput>());
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
    public static Task<Result<TOutput>> MapTryIfAsync<TOutput>(this Task<Result> resultTask, bool condition, Func<TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<TOutput>();
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
    public static ValueTask<Result<TOutput>> MapTryIfAsync<TOutput>(this ValueTask<Result> resultTask, bool condition, Func<TOutput> map, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.MapTryAsync(map, catchHandler) : resultTask.ToResultAsync<TOutput>();
    }

    #endregion

}
