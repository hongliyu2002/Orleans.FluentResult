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
    /// <param name="map">map function</param>
    public static Result MapIf(this Result result, Func<bool> predicate, Action map)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? result.Map(map) : result.ToResult();
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
    public static async Task<Result> MapIfAsync(this Task<Result> resultTask, Func<bool> predicate, Func<Task> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
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
    public static async ValueTask<Result> MapIfAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Func<ValueTask> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
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
    public static async Task<Result> MapIfAsync(this Result result, Func<bool> predicate, Func<Task> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
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
    public static async ValueTask<Result> MapIfAsync(this Result result, Func<bool> predicate, Func<ValueTask> map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate() ? await result.MapAsync(map, configureAwait).ConfigureAwait(configureAwait) : result.ToResult();
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
    public static async Task<Result> MapIfAsync(this Task<Result> resultTask, Func<bool> predicate, Action map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result.Map(map) : result.ToResult();
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
    public static async ValueTask<Result> MapIfAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Action map, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result.Map(map) : result.ToResult();
    }

    #endregion

}
