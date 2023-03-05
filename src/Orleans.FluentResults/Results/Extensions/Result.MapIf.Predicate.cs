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
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    public static Result<TOutput> MapIf<TOutput>(this Result result, Func<Result, bool> predicate, Func<TOutput> map)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Map(map) : result.ToResult<TOutput>();
    }

    #endregion

    #region MapIf Full Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<TOutput>> MapIfAsync<TOutput>(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Task<TOutput>> map)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.MapAsync(map).ConfigureAwait(true) : result.ToResult<TOutput>();
    }

    #endregion

    #region MapIf Full ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> MapIfAsync<TOutput>(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<ValueTask<TOutput>> map)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.MapAsync(map).ConfigureAwait(true) : result.ToResult<TOutput>();
    }

    #endregion

    #region MapIf Right Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<TOutput>> MapIfAsync<TOutput>(this Result result, Func<Result, bool> predicate, Func<Task<TOutput>> map)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapAsync(map).ConfigureAwait(true) : result.ToResult<TOutput>();
    }

    #endregion

    #region MapIf Right ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> MapIfAsync<TOutput>(this Result result, Func<Result, bool> predicate, Func<ValueTask<TOutput>> map)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapAsync(map).ConfigureAwait(true) : result.ToResult<TOutput>();
    }

    #endregion

    #region MapIf Left Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<TOutput>> MapIfAsync<TOutput>(this Task<Result> resultTask, Func<Result, bool> predicate, Func<TOutput> map)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Map(map) : result.ToResult<TOutput>();
    }

    #endregion

    #region MapIf Left ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<TOutput>> MapIfAsync<TOutput>(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<TOutput> map)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Map(map) : result.ToResult<TOutput>();
    }

    #endregion

}
