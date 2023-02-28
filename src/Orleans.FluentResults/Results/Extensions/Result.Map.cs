namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Map

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static Result<T1> Map<T1>(this Result result, Func<T1> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = map();
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

    #region Map Full Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<T1>> MapAsync<T1>(this Task<Result> resultTask, Func<Task<T1>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(false);
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

    #region Map Full ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<T1>> MapAsync<T1>(this ValueTask<Result> resultTask, Func<ValueTask<T1>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(false);
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

    #region Map Right Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<T1>> MapAsync<T1>(this Result result, Func<Task<T1>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(false);
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

    #region Map Right ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<T1>> MapAsync<T1>(this Result result, Func<ValueTask<T1>> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = await map().ConfigureAwait(false);
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

    #region Map Left Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async Task<Result<T1>> MapAsync<T1>(this Task<Result> resultTask, Func<T1> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = map();
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

    #region Map Left ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="map">Action that may fail.</param>
    public static async ValueTask<Result<T1>> MapAsync<T1>(this ValueTask<Result> resultTask, Func<T1> map)
    {
        ArgumentNullException.ThrowIfNull(map);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result<T1>.Fail(result.Errors);
        }
        var value = map();
        return new Result<T1>(value, result.Reasons);
    }

    #endregion

}
