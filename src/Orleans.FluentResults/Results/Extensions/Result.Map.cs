namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Map

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static Result<T2> Map<T2>(this Result result, Func<T2> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var value = map();
        return new Result<T2>(value, result.Reasons);
    }

    #endregion

    #region Map Full Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<T2>> MapAsync<T2>(this Task<Result> resultTask, Func<Task<T2>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var value = await map().ConfigureAwait(false);
        return new Result<T2>(value, result.Reasons);
    }

    #endregion

    #region Map Full ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<T2>> MapAsync<T2>(this ValueTask<Result> resultTask, Func<ValueTask<T2>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var value = await map().ConfigureAwait(false);
        return new Result<T2>(value, result.Reasons);
    }

    #endregion

    #region Map Right Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<T2>> MapAsync<T2>(this Result result, Func<Task<T2>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var value = await map().ConfigureAwait(false);
        return new Result<T2>(value, result.Reasons);
    }

    #endregion

    #region Map Right ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<T2>> MapAsync<T2>(this Result result, Func<ValueTask<T2>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var value = await map().ConfigureAwait(false);
        return new Result<T2>(value, result.Reasons);
    }

    #endregion

    #region Map Left Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<T2>> MapAsync<T2>(this Task<Result> resultTask, Func<T2> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var value = map();
        return new Result<T2>(value, result.Reasons);
    }

    #endregion

    #region Map Left ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<T2>> MapAsync<T2>(this ValueTask<Result> resultTask, Func<T2> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var value = map();
        return new Result<T2>(value, result.Reasons);
    }

    #endregion

}
