namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region Ensure

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static Result<T> Ensure<T>(this Result<T> result, Func<bool> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.Ensure(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.Ensure(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static Result<T> Ensure<T>(this Result<T> result, Func<bool> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.Ensure(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.Ensure(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static Result<T> Ensure<T>(this Result<T> result, Func<bool> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        if (result.IsSuccess && !predicate())
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        if (result.IsSuccess && !predicate(result.Value))
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static Result<T> Ensure<T>(this Result<T> result, Func<bool> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        if (result.IsSuccess && !predicate())
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        if (result.IsSuccess && !predicate(result.Value))
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static Result<T> Ensure<T>(this Result<T> result, Func<bool> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.Ensure(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.Ensure(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static Result<T> Ensure<T>(this Result<T> result, Func<bool> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.Ensure(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.Ensure(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    #endregion

    #region Ensure Full Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<Task<bool>> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<Task<bool>> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static async Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<Task<bool>> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static async Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && !await predicate(result.Value).ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<Task<bool>> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && !await predicate(result.Value).ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<Task<bool>> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<Task<bool>> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    #endregion

    #region Ensure Full ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<bool>> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<bool>> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static async ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<bool>> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static async ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && !await predicate(result.Value).ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<bool>> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && !await predicate(result.Value).ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<bool>> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<bool>> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    #endregion

    #region Ensure Right Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Result<T> result, Func<Task<bool>> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Result<T> result, Func<T, Task<bool>> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Result<T> result, Func<Task<bool>> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Result<T> result, Func<T, Task<bool>> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static async Task<Result<T>> EnsureAsync<T>(this Result<T> result, Func<Task<bool>> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static async Task<Result<T>> EnsureAsync<T>(this Result<T> result, Func<T, Task<bool>> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        if (result.IsSuccess && !await predicate(result.Value).ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async Task<Result<T>> EnsureAsync<T>(this Result<T> result, Func<Task<bool>> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async Task<Result<T>> EnsureAsync<T>(this Result<T> result, Func<T, Task<bool>> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        if (result.IsSuccess && !await predicate(result.Value).ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Result<T> result, Func<Task<bool>> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Result<T> result, Func<T, Task<bool>> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Result<T> result, Func<Task<bool>> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Result<T> result, Func<T, Task<bool>> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    #endregion

    #region Ensure Right ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this Result<T> result, Func<ValueTask<bool>> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this Result<T> result, Func<T, ValueTask<bool>> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this Result<T> result, Func<ValueTask<bool>> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this Result<T> result, Func<T, ValueTask<bool>> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static async ValueTask<Result<T>> EnsureAsync<T>(this Result<T> result, Func<ValueTask<bool>> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static async ValueTask<Result<T>> EnsureAsync<T>(this Result<T> result, Func<T, ValueTask<bool>> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        if (result.IsSuccess && !await predicate(result.Value).ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async ValueTask<Result<T>> EnsureAsync<T>(this Result<T> result, Func<ValueTask<bool>> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async ValueTask<Result<T>> EnsureAsync<T>(this Result<T> result, Func<T, ValueTask<bool>> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        if (result.IsSuccess && !await predicate(result.Value).ConfigureAwait(false))
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this Result<T> result, Func<ValueTask<bool>> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this Result<T> result, Func<T, ValueTask<bool>> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this Result<T> result, Func<ValueTask<bool>> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this Result<T> result, Func<T, ValueTask<bool>> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    #endregion

    #region Ensure Left Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<bool> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<bool> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static async Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<bool> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && predicate())
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static async Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && predicate(result.Value))
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<bool> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && predicate())
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && predicate(result.Value))
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<bool> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<bool> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static Task<Result<T>> EnsureAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    #endregion

    #region Ensure Left ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<bool> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<bool> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessages"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static async ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<bool> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && predicate())
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="error"></param>
    public static async ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && predicate(result.Value))
        {
            return result with { Reasons = result.Reasons.Add(error) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<bool> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && predicate())
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && predicate(result.Value))
        {
            return result with { Reasons = result.Reasons.AddRange(errors) };
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<bool> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exception"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<bool> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="exceptions"></param>
    public static ValueTask<Result<T>> EnsureAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    #endregion

}
