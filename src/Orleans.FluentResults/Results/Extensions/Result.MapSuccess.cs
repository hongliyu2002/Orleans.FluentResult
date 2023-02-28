using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region MapSuccess

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static Result MapSuccess(this Result result, Func<ISuccess, ISuccess> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var successes = result.Successes.Select(mapSuccess);
        return new Result(ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors));
    }

    #endregion

    #region MapSuccess Full Async

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static async Task<Result> MapSuccessAsync(this Task<Result> resultTask, Func<ISuccess, Task<ISuccess>> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var result = await resultTask.ConfigureAwait(false);
        var successes = await Task.WhenAll(result.Successes.Select(mapSuccess)).ConfigureAwait(false);
        return new Result(ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors));
    }

    #endregion

    #region MapSuccess Full ValueTask Async

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static async ValueTask<Result> MapSuccessAsync(this ValueTask<Result> resultTask, Func<ISuccess, ValueTask<ISuccess>> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var result = await resultTask.ConfigureAwait(false);
        var successes = await Task.WhenAll(result.Successes.Select(success => mapSuccess(success).AsTask())).ConfigureAwait(false);
        return new Result(ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors));
    }

    #endregion

    #region MapSuccess Right Async

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static async Task<Result> MapSuccessAsync(this Result result, Func<ISuccess, Task<ISuccess>> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var successes = await Task.WhenAll(result.Successes.Select(mapSuccess)).ConfigureAwait(false);
        return new Result(ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors));
    }

    #endregion

    #region MapSuccess Right ValueTask Async

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static async ValueTask<Result> MapSuccessAsync(this Result result, Func<ISuccess, ValueTask<ISuccess>> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var successes = await Task.WhenAll(result.Successes.Select(success => mapSuccess(success).AsTask())).ConfigureAwait(false);
        return new Result(ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors));
    }

    #endregion

    #region MapSuccess Left Async

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static async Task<Result> MapSuccessAsync(this Task<Result> resultTask, Func<ISuccess, ISuccess> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var result = await resultTask.ConfigureAwait(false);
        var successes = result.Successes.Select(mapSuccess);
        return new Result(ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors));
    }

    #endregion

    #region MapSuccess Left ValueTask Async

    /// <summary>
    ///     Execute an mapSuccess function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="mapSuccess">Action that may fail.</param>
    public static async ValueTask<Result> MapSuccessAsync(this ValueTask<Result> resultTask, Func<ISuccess, ISuccess> mapSuccess)
    {
        ArgumentNullException.ThrowIfNull(mapSuccess);
        var result = await resultTask.ConfigureAwait(false);
        var successes = result.Successes.Select(mapSuccess);
        return new Result(ImmutableList<IReason>.Empty.AddRange(successes).AddRange(result.Errors));
    }

    #endregion

}
