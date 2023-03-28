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
    public static Result MapIf<T>(this Result<T> result, Func<T, bool> predicate, Action map)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Map(map) : result.ToResult();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    public static Result MapIf<T>(this Result<T> result, Func<T, bool> predicate, Action<T> map)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Map(map) : result.ToResult();
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
    public static async Task<Result> MapIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Task> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> MapIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
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
    public static async ValueTask<Result> MapIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<ValueTask> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> MapIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
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
    public static async Task<Result> MapIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<Task> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> MapIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
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
    public static async ValueTask<Result> MapIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<ValueTask> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> MapIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
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
    public static async Task<Result> MapIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Action map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Map(map) : result.ToResult();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> MapIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Action<T> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Map(map) : result.ToResult();
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
    public static async ValueTask<Result> MapIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Action map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Map(map) : result.ToResult();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="map">map function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> MapIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Action<T> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Map(map) : result.ToResult();
    }

    #endregion

}
