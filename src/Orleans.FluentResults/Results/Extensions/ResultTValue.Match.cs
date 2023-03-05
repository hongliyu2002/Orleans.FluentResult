namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region Match

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static void Match<T>(this Result<T> result, Action<T> onSuccess, Action<IEnumerable<IError>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        if (result.IsSuccess)
        {
            onSuccess(result.Value);
        }
        else
        {
            onFailure(result.Errors);
        }
    }

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static TOutput Match<T, TOutput>(this Result<T> result, Func<T, TOutput> onSuccess, Func<IEnumerable<IError>, TOutput> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Errors);
    }

    #endregion

    #region Match Full Async

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static async Task MatchAsync<T>(this Task<Result<T>> resultTask, Func<T, Task> onSuccess, Func<IEnumerable<IError>, Task> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsSuccess)
        {
            await onSuccess(result.Value);
        }
        else
        {
            await onFailure(result.Errors);
        }
    }

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static async Task<TOutput> MatchAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, Task<TOutput>> onSuccess, Func<IEnumerable<IError>, Task<TOutput>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(true);
        return result.IsSuccess ? await onSuccess(result.Value) : await onFailure(result.Errors);
    }

    #endregion

    #region Match Full ValueTask Async

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static async ValueTask MatchAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask> onSuccess, Func<IEnumerable<IError>, ValueTask> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsSuccess)
        {
            await onSuccess(result.Value);
        }
        else
        {
            await onFailure(result.Errors);
        }
    }

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static async ValueTask<TOutput> MatchAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<TOutput>> onSuccess, Func<IEnumerable<IError>, ValueTask<TOutput>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(true);
        return result.IsSuccess ? await onSuccess(result.Value) : await onFailure(result.Errors);
    }

    #endregion

    #region Match Right Async

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static async Task MatchAsync<T>(this Result<T> result, Func<T, Task> onSuccess, Func<IEnumerable<IError>, Task> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        if (result.IsSuccess)
        {
            await onSuccess(result.Value);
        }
        else
        {
            await onFailure(result.Errors);
        }
    }

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static async Task<TOutput> MatchAsync<T, TOutput>(this Result<T> result, Func<T, Task<TOutput>> onSuccess, Func<IEnumerable<IError>, Task<TOutput>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        return result.IsSuccess ? await onSuccess(result.Value) : await onFailure(result.Errors);
    }

    #endregion

    #region Match Right ValueTask Async

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static async ValueTask MatchAsync<T>(this Result<T> result, Func<T, ValueTask> onSuccess, Func<IEnumerable<IError>, ValueTask> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        if (result.IsSuccess)
        {
            await onSuccess(result.Value);
        }
        else
        {
            await onFailure(result.Errors);
        }
    }

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static async ValueTask<TOutput> MatchAsync<T, TOutput>(this Result<T> result, Func<T, ValueTask<TOutput>> onSuccess, Func<IEnumerable<IError>, ValueTask<TOutput>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        return result.IsSuccess ? await onSuccess(result.Value) : await onFailure(result.Errors);
    }

    #endregion

    #region Match Left Async

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static async Task MatchAsync<T>(this Task<Result<T>> resultTask, Action<T> onSuccess, Action<IEnumerable<IError>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsSuccess)
        {
            onSuccess(result.Value);
        }
        else
        {
            onFailure(result.Errors);
        }
    }

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static async Task<TOutput> MatchAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, TOutput> onSuccess, Func<IEnumerable<IError>, TOutput> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(true);
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Errors);
    }

    #endregion

    #region Match Left ValueTask Async

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static async ValueTask MatchAsync<T>(this ValueTask<Result<T>> resultTask, Action<T> onSuccess, Action<IEnumerable<IError>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsSuccess)
        {
            onSuccess(result.Value);
        }
        else
        {
            onFailure(result.Errors);
        }
    }

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static async ValueTask<TOutput> MatchAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, TOutput> onSuccess, Func<IEnumerable<IError>, TOutput> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(true);
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Errors);
    }

    #endregion

}
