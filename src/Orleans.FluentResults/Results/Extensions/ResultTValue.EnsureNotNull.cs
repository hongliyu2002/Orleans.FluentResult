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
        return result.Ensure(value => value is not null, errorMessage);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="errorMessages"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, IEnumerable<string> errorMessages)
    {
        return result.Ensure(value => value is not null, errorMessages);
    }

    /// <summary>
    ///     Returns a new failure result with error if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="error"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, IError error)
    {
        return result.Ensure(value => value is not null, error);
    }

    /// <summary>
    ///     Returns a new failure result with error if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="errors"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, IEnumerable<IError> errors)
    {
        return result.Ensure(value => value is not null, errors);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="exception"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, Exception exception)
    {
        return result.Ensure(value => value is not null, exception);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="exceptions"></param>
    public static Result<T> EnsureNotNull<T>(this Result<T> result, IEnumerable<Exception> exceptions)
    {
        return result.Ensure(value => value is not null, exceptions);
    }

    #endregion

    #region EnsureNotNull Full Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, string errorMessage, bool configureAwait = true)
    {
        return resultTask.EnsureAsync(value => value is not null, errorMessage, configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        return resultTask.EnsureAsync(value => value is not null, errorMessages, configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with error if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, IError error, bool configureAwait = true)
    {
        return resultTask.EnsureAsync(value => value is not null, error, configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with error if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, IEnumerable<IError> errors, bool configureAwait = true)
    {
        return resultTask.EnsureAsync(value => value is not null, errors, configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, Exception exception, bool configureAwait = true)
    {
        return resultTask.EnsureAsync(value => value is not null, exception, configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result<T>> EnsureNotNullAsync<T>(this Task<Result<T>> resultTask, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        return resultTask.EnsureAsync(value => value is not null, exceptions, configureAwait);
    }

    #endregion

    #region EnsureNotNull Full ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, string errorMessage, bool configureAwait = true)
    {
        return resultTask.EnsureAsync(value => value is not null, errorMessage, configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        return resultTask.EnsureAsync(value => value is not null, errorMessages, configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with error if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, IError error, bool configureAwait = true)
    {
        return resultTask.EnsureAsync(value => value is not null, error, configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with error if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, IEnumerable<IError> errors, bool configureAwait = true)
    {
        return resultTask.EnsureAsync(value => value is not null, errors, configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, Exception exception, bool configureAwait = true)
    {
        return resultTask.EnsureAsync(value => value is not null, exception, configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the result value is null. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result<T>> EnsureNotNullAsync<T>(this ValueTask<Result<T>> resultTask, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        return resultTask.EnsureAsync(value => value is not null, exceptions, configureAwait);
    }

    #endregion

}
