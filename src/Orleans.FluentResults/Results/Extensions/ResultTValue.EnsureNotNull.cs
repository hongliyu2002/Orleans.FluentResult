namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region EnsureNotNull

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="errorMessage"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.EnsureNotNull(ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="errorMessages"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.EnsureNotNull(errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="error"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        if (result is { IsSuccess: true, Value: null })
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="errors"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        if (result is { IsSuccess: true, Value: null })
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    #endregion

    #region EnsureNotNull Full Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMessage"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureNotNullAsync(ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMessages"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureNotNullAsync(errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="error"></param>
    public static async Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result is { IsSuccess: true, Value: null })
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errors"></param>
    public static async Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result is { IsSuccess: true, Value: null })
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    #endregion

    #region EnsureNotNull Full ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMessage"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureNotNullAsync(ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMessages"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureNotNullAsync(errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="error"></param>
    public static async ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result is { IsSuccess: true, Value: null })
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errors"></param>
    public static async ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result is { IsSuccess: true, Value: null })
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    #endregion

}
