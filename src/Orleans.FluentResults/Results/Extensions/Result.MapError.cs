namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region MapError

    /// <summary>
    ///     Execute an mapError function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static Result MapError(this Result result, Func<IError, IError> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var errors = result.Errors.Select(error => mapError(error));
        return new Result(result.Reasons.AddRange(errors).AddRange(result.Successes));
    }

    #endregion

    #region MapError Full Async

    /// <summary>
    ///     Execute an mapError function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static async Task<Result> MapErrorAsync(this Task<Result> resultTask, Func<IError, Task<IError>> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var result = await resultTask.ConfigureAwait(false);
        var errors = await Task.WhenAll(result.Errors.Select(error => mapError(error))).ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(errors).AddRange(result.Successes));
    }

    #endregion

    #region MapError Full ValueTask Async

    /// <summary>
    ///     Execute an mapError function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static async ValueTask<Result> MapErrorAsync(this ValueTask<Result> resultTask, Func<IError, ValueTask<IError>> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var result = await resultTask.ConfigureAwait(false);
        var errors = await Task.WhenAll(result.Errors.Select(error => mapError(error).AsTask())).ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(errors).AddRange(result.Successes));
    }

    #endregion

    #region MapError Right Async

    /// <summary>
    ///     Execute an mapError function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static async Task<Result> MapErrorAsync(this Result result, Func<IError, Task<IError>> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var errors = await Task.WhenAll(result.Errors.Select(error => mapError(error))).ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(errors).AddRange(result.Successes));
    }

    #endregion

    #region MapError Right ValueTask Async

    /// <summary>
    ///     Execute an mapError function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static async ValueTask<Result> MapErrorAsync(this Result result, Func<IError, ValueTask<IError>> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var errors = await Task.WhenAll(result.Errors.Select(error => mapError(error).AsTask())).ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(errors).AddRange(result.Successes));
    }

    #endregion

    #region MapError Left Async

    /// <summary>
    ///     Execute an mapError function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static async Task<Result> MapErrorAsync(this Task<Result> resultTask, Func<IError, IError> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var result = await resultTask.ConfigureAwait(false);
        var errors = result.Errors.Select(error => mapError(error));
        return new Result(result.Reasons.AddRange(errors).AddRange(result.Successes));
    }

    #endregion

    #region MapError Left ValueTask Async

    /// <summary>
    ///     Execute an mapError function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static async ValueTask<Result> MapErrorAsync(this ValueTask<Result> resultTask, Func<IError, IError> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var result = await resultTask.ConfigureAwait(false);
        var errors = result.Errors.Select(error => mapError(error));
        return new Result(result.Reasons.AddRange(errors).AddRange(result.Successes));
    }

    #endregion

}
