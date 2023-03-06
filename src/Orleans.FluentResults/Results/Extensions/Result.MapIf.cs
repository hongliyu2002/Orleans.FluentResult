namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region MapIf

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    public static Result<TOutput> MapIf<TOutput>(this Result result, bool condition, Func<TOutput> map)
    {
        return condition ? result.Map(map) : result.ToResult<TOutput>();
    }

    #endregion

    #region MapIf Full Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<TOutput>> MapIfAsync<TOutput>(this Task<Result> resultTask, bool condition, Func<Task<TOutput>> map, bool configureAwait = true)
    {
        return condition ? resultTask.MapAsync(map, configureAwait) : resultTask.ToResultAsync<TOutput>(configureAwait);
    }

    #endregion

    #region MapIf Full ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<TOutput>> MapIfAsync<TOutput>(this ValueTask<Result> resultTask, bool condition, Func<ValueTask<TOutput>> map, bool configureAwait = true)
    {
        return condition ? resultTask.MapAsync(map, configureAwait) : resultTask.ToResultAsync<TOutput>(configureAwait);
    }

    #endregion

    #region MapIf Right Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<TOutput>> MapIfAsync<TOutput>(this Result result, bool condition, Func<Task<TOutput>> map, bool configureAwait = true)
    {
        return condition ? result.MapAsync(map, configureAwait) : Task.FromResult(result.ToResult<TOutput>());
    }

    #endregion

    #region MapIf Right ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<TOutput>> MapIfAsync<TOutput>(this Result result, bool condition, Func<ValueTask<TOutput>> map, bool configureAwait = true)
    {
        return condition ? result.MapAsync(map, configureAwait) : ValueTask.FromResult(result.ToResult<TOutput>());
    }

    #endregion

    #region MapIf Left Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static Task<Result<TOutput>> MapIfAsync<TOutput>(this Task<Result> resultTask, bool condition, Func<TOutput> map, bool configureAwait = true)
    {
        return condition ? resultTask.MapAsync(map, configureAwait) : resultTask.ToResultAsync<TOutput>(configureAwait);
    }

    #endregion

    #region MapIf Left ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<TOutput>> MapIfAsync<TOutput>(this ValueTask<Result> resultTask, bool condition, Func<TOutput> map, bool configureAwait = true)
    {
        return condition ? resultTask.MapAsync(map, configureAwait) : resultTask.ToResultAsync<TOutput>(configureAwait);
    }

    #endregion

}
