namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region EnsureNotNull

    /// <summary>
    ///     Returns a new failure result with errorMessage if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="errorMessage"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, string errorMessage)
    {
        return result.Ensure(r => r.Value is not null, errorMessage);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="errorMessages"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, IEnumerable<string> errorMessages)
    {
        return result.Ensure(r => r.Value is not null, errorMessages);
    }

    /// <summary>
    ///     Returns a new failure result with error if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="error"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, IError error)
    {
        return result.Ensure(r => r.Value is not null, error);
    }

    /// <summary>
    ///     Returns a new failure result with error if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="errors"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, IEnumerable<IError> errors)
    {
        return result.Ensure(r => r.Value is not null, errors);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="exception"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, Exception exception)
    {
        return result.Ensure(r => r.Value is not null, exception);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="exceptions"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, IEnumerable<Exception> exceptions)
    {
        return result.Ensure(r => r.Value is not null, exceptions);
    }

    #endregion

    #region EnsureNotNull Full Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMessage"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, string errorMessage)
    {
        return resultTask.EnsureAsync(r => r.Value is not null, errorMessage);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMessages"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, IEnumerable<string> errorMessages)
    {
        return resultTask.EnsureAsync(r => r.Value is not null, errorMessages);
    }

    /// <summary>
    ///     Returns a new failure result with error if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="error"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, IError error)
    {
        return resultTask.EnsureAsync(r => r.Value is not null, error);
    }

    /// <summary>
    ///     Returns a new failure result with error if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errors"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, IEnumerable<IError> errors)
    {
        return resultTask.EnsureAsync(r => r.Value is not null, errors);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="exception"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, Exception exception)
    {
        return resultTask.EnsureAsync(r => r.Value is not null, exception);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="exceptions"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, IEnumerable<Exception> exceptions)
    {
        return resultTask.EnsureAsync(r => r.Value is not null, exceptions);
    }

    #endregion

    #region EnsureNotNull Full ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMessage"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, string errorMessage)
    {
        return resultTask.EnsureAsync(r => r.Value is not null, errorMessage);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMessages"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, IEnumerable<string> errorMessages)
    {
        return resultTask.EnsureAsync(r => r.Value is not null, errorMessages);
    }

    /// <summary>
    ///     Returns a new failure result with error if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="error"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, IError error)
    {
        return resultTask.EnsureAsync(r => r.Value is not null, error);
    }

    /// <summary>
    ///     Returns a new failure result with error if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errors"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, IEnumerable<IError> errors)
    {
        return resultTask.EnsureAsync(r => r.Value is not null, errors);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="exception"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, Exception exception)
    {
        return resultTask.EnsureAsync(r => r.Value is not null, exception);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="exceptions"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, IEnumerable<Exception> exceptions)
    {
        return resultTask.EnsureAsync(r => r.Value is not null, exceptions);
    }

    #endregion

}
