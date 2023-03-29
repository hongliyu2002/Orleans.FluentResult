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
    public static Result MapIf(this Result result, bool condition, Action map)
    {
        return condition ? result.Map(map) : result.ToResult();
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
    public static Task<Result> MapIfAsync(this Task<Result> resultTask, bool condition, Func<Task> map, bool configureAwait = true)
    {
        return condition ? resultTask.MapAsync(map, configureAwait) : resultTask.ToResultAsync(configureAwait);
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
    public static ValueTask<Result> MapIfAsync(this ValueTask<Result> resultTask, bool condition, Func<ValueTask> map, bool configureAwait = true)
    {
        return condition ? resultTask.MapAsync(map, configureAwait) : resultTask.ToResultAsync(configureAwait);
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
    public static Task<Result> MapIfAsync(this Result result, bool condition, Func<Task> map, bool configureAwait = true)
    {
        return condition ? result.MapAsync(map, configureAwait) : Task.FromResult(result.ToResult());
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
    public static ValueTask<Result> MapIfAsync(this Result result, bool condition, Func<ValueTask> map, bool configureAwait = true)
    {
        return condition ? result.MapAsync(map, configureAwait) : ValueTask.FromResult(result.ToResult());
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
    public static Task<Result> MapIfAsync(this Task<Result> resultTask, bool condition, Action map, bool configureAwait = true)
    {
        return condition ? resultTask.MapAsync(map, configureAwait) : resultTask.ToResultAsync(configureAwait);
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
    public static ValueTask<Result> MapIfAsync(this ValueTask<Result> resultTask, bool condition, Action map, bool configureAwait = true)
    {
        return condition ? resultTask.MapAsync(map, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    #endregion

}
