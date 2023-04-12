namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Compensate

    /// <summary>
    ///     If the calling result is a failure, the given compensate function is executed and its result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="compensate">compensate function</param>
    public static Result Compensate(this Result result, Func<IEnumerable<IError>, Result> compensate)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsSuccess ? result : compensate(result.Errors);
    }

    #endregion

    #region Compensate Full Async

    /// <summary>
    ///     If the calling result is a failure, the given compensate function is executed and its result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="compensate">compensate function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> CompensateAsync(this Task<Result> resultTask, Func<IEnumerable<IError>, Task<Result>> compensate, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return result.IsSuccess ? result : await compensate(result.Errors).ConfigureAwait(configureAwait);
    }

    #endregion

    #region Compensate Full ValueTask Async

    /// <summary>
    ///     If the calling result is a failure, the given compensate function is executed and its result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="compensate">compensate function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> CompensateAsync(this ValueTask<Result> resultTask, Func<IEnumerable<IError>, ValueTask<Result>> compensate, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return result.IsSuccess ? result : await compensate(result.Errors).ConfigureAwait(configureAwait);
    }

    #endregion

    #region Compensate Right Async

    /// <summary>
    ///     If the calling result is a failure, the given compensate function is executed and its result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="compensate">compensate function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> CompensateAsync(this Result result, Func<IEnumerable<IError>, Task<Result>> compensate, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsSuccess ? result : await compensate(result.Errors).ConfigureAwait(configureAwait);
    }

    #endregion

    #region Compensate Right ValueTask Async

    /// <summary>
    ///     If the calling result is a failure, the given compensate function is executed and its result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="compensate">compensate function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> CompensateAsync(this Result result, Func<IEnumerable<IError>, ValueTask<Result>> compensate, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        return result.IsSuccess ? result : await compensate(result.Errors).ConfigureAwait(configureAwait);
    }

    #endregion

    #region Compensate Left Async

    /// <summary>
    ///     If the calling result is a failure, the given compensate function is executed and its result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="compensate">compensate function</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> CompensateAsync(this Task<Result> resultTask, Func<IEnumerable<IError>, Result> compensate, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return result.IsSuccess ? result : compensate(result.Errors);
    }

    #endregion

    #region Compensate Left ValueTask Async

    /// <summary>
    ///     If the calling result is a failure, the given compensate function is executed and its result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="compensate">compensate function</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> CompensateAsync(this ValueTask<Result> resultTask, Func<IEnumerable<IError>, Result> compensate, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(compensate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return result.IsSuccess ? result : compensate(result.Errors);
    }

    #endregion

}
