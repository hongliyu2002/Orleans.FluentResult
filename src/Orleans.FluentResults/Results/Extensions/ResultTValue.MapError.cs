using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region MapError

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given map error function.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static Result<T> MapError<T>(this Result<T> result, Func<IError, IError> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var errors = result.Errors.Select(mapError);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(errors).AddRange(result.Successes) };
    }

    #endregion

    #region MapError Full Async

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given map error function.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static async Task<Result<T>> MapErrorAsync<T>(this Task<Result<T>> resultTask, Func<IError, Task<IError>> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var result = await resultTask.ConfigureAwait(true);
        var errors = await Task.WhenAll(result.Errors.Select(mapError)).ConfigureAwait(true);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(errors).AddRange(result.Successes) };
    }

    #endregion

    #region MapError Full ValueTask Async

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given map error function.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static async ValueTask<Result<T>> MapErrorAsync<T>(this ValueTask<Result<T>> resultTask, Func<IError, ValueTask<IError>> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var result = await resultTask.ConfigureAwait(true);
        var errors = await Task.WhenAll(result.Errors.Select(error => mapError(error).AsTask())).ConfigureAwait(true);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(errors).AddRange(result.Successes) };
    }

    #endregion

    #region MapError Right Async

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given map error function.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static async Task<Result<T>> MapErrorAsync<T>(this Result<T> result, Func<IError, Task<IError>> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var errors = await Task.WhenAll(result.Errors.Select(mapError)).ConfigureAwait(true);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(errors).AddRange(result.Successes) };
    }

    #endregion

    #region MapError Right ValueTask Async

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given map error function.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static async ValueTask<Result<T>> MapErrorAsync<T>(this Result<T> result, Func<IError, ValueTask<IError>> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var errors = await Task.WhenAll(result.Errors.Select(error => mapError(error).AsTask())).ConfigureAwait(true);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(errors).AddRange(result.Successes) };
    }

    #endregion

    #region MapError Left Async

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given map error function.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static async Task<Result<T>> MapErrorAsync<T>(this Task<Result<T>> resultTask, Func<IError, IError> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var result = await resultTask.ConfigureAwait(true);
        var errors = result.Errors.Select(mapError);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(errors).AddRange(result.Successes) };
    }

    #endregion

    #region MapError Left ValueTask Async

    /// <summary>
    ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given map error function.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapError">Action that may fail.</param>
    public static async ValueTask<Result<T>> MapErrorAsync<T>(this ValueTask<Result<T>> resultTask, Func<IError, IError> mapError)
    {
        ArgumentNullException.ThrowIfNull(mapError);
        var result = await resultTask.ConfigureAwait(true);
        var errors = result.Errors.Select(mapError);
        return result with { Reasons = ImmutableList<IReason>.Empty.AddRange(errors).AddRange(result.Successes) };
    }

    #endregion

}
