namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Match

    /// <summary>
    ///     Returns the result of the given <paramref name="onSuccess" /> function if the calling Result is a success.
    ///     Otherwise, it returns the result of the given <paramref name="onFailure" /> function.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="onSuccess">Action that may fail.</param>
    /// <param name="onFailure"></param>
    public static void Match(this Result result, Action onSuccess, Action<IEnumerable<IError>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        if (result.IsSuccess)
        {
            onSuccess();
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
    public static TOutput Match<TOutput>(this Result result, Func<TOutput> onSuccess, Func<IEnumerable<IError>, TOutput> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        return result.IsSuccess ? onSuccess() : onFailure(result.Errors);
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
    public static async Task MatchAsync(this Task<Result> resultTask, Func<Task> onSuccess, Func<IEnumerable<IError>, Task> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            await onSuccess();
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
    public static async Task<TOutput> MatchAsync<TOutput>(this Task<Result> resultTask, Func<Task<TOutput>> onSuccess, Func<IEnumerable<IError>, Task<TOutput>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(false);
        return result.IsSuccess ? await onSuccess() : await onFailure(result.Errors);
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
    public static async ValueTask MatchAsync(this ValueTask<Result> resultTask, Func<ValueTask> onSuccess, Func<IEnumerable<IError>, ValueTask> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            await onSuccess();
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
    public static async ValueTask<TOutput> MatchAsync<TOutput>(this ValueTask<Result> resultTask, Func<ValueTask<TOutput>> onSuccess, Func<IEnumerable<IError>, ValueTask<TOutput>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(false);
        return result.IsSuccess ? await onSuccess() : await onFailure(result.Errors);
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
    public static async Task MatchAsync(this Result result, Func<Task> onSuccess, Func<IEnumerable<IError>, Task> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        if (result.IsSuccess)
        {
            await onSuccess();
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
    public static async Task<TOutput> MatchAsync<TOutput>(this Result result, Func<Task<TOutput>> onSuccess, Func<IEnumerable<IError>, Task<TOutput>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        return result.IsSuccess ? await onSuccess() : await onFailure(result.Errors);
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
    public static async ValueTask MatchAsync(this Result result, Func<ValueTask> onSuccess, Func<IEnumerable<IError>, ValueTask> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        if (result.IsSuccess)
        {
            await onSuccess();
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
    public static async ValueTask<TOutput> MatchAsync<TOutput>(this Result result, Func<ValueTask<TOutput>> onSuccess, Func<IEnumerable<IError>, ValueTask<TOutput>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        return result.IsSuccess ? await onSuccess() : await onFailure(result.Errors);
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
    public static async Task MatchAsync(this Task<Result> resultTask, Action onSuccess, Action<IEnumerable<IError>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            onSuccess();
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
    public static async Task<TOutput> MatchAsync<TOutput>(this Task<Result> resultTask, Func<TOutput> onSuccess, Func<IEnumerable<IError>, TOutput> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(false);
        return result.IsSuccess ? onSuccess() : onFailure(result.Errors);
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
    public static async ValueTask MatchAsync(this ValueTask<Result> resultTask, Action onSuccess, Action<IEnumerable<IError>> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            onSuccess();
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
    public static async ValueTask<TOutput> MatchAsync<TOutput>(this ValueTask<Result> resultTask, Func<TOutput> onSuccess, Func<IEnumerable<IError>, TOutput> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);
        var result = await resultTask.ConfigureAwait(false);
        return result.IsSuccess ? onSuccess() : onFailure(result.Errors);
    }

    #endregion

}
