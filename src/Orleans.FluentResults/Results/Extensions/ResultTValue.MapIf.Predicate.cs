namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region MapIf

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    public static Result<TOutput> MapIf<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<TOutput> map)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Map(map) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    public static Result<TOutput> MapIf<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, TOutput> map)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Map(map) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region MapIf Full Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> MapIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> MapIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region MapIf Full ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> MapIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> MapIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region MapIf Right Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> MapIfAsync<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> MapIfAsync<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region MapIf Right ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> MapIfAsync<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> MapIfAsync<T, TOutput>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<TOutput>> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region MapIf Left Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> MapIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<TOutput> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? result.Map(map) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> MapIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, TOutput> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? result.Map(map) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region MapIf Left ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> MapIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<TOutput> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? result.Map(map) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> MapIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, TOutput> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result) ? result.Map(map) : result.ToResult<T, TOutput>();
    }

    #endregion

}
