namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Verify

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    public static Result Verify(this Result result, Func<bool> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.Verify(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    public static Result Verify(this Result result, Func<bool> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.Verify(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    public static Result Verify(this Result result, Func<bool> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        return predicate() ? result : new Result(result.Reasons.Add(error));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    public static Result Verify(this Result result, Func<bool> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        return predicate() ? result : new Result(result.Reasons.AddRange(errors));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    public static Result Verify(this Result result, Func<bool> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.Verify(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    public static Result Verify(this Result result, Func<bool> predicate, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.Verify(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    #endregion

    #region Verify Full Async

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> VerifyAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.VerifyAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> VerifyAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.VerifyAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> VerifyAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return await predicate().ConfigureAwait(configureAwait) ? result : new Result(result.Reasons.Add(error));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> VerifyAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return await predicate().ConfigureAwait(configureAwait) ? result : new Result(result.Reasons.AddRange(errors));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> VerifyAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.VerifyAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> VerifyAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.VerifyAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

    #region Verify Full ValueTask Async

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.VerifyAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.VerifyAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return await predicate().ConfigureAwait(configureAwait) ? result : new Result(result.Reasons.Add(error));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return await predicate().ConfigureAwait(configureAwait) ? result : new Result(result.Reasons.AddRange(errors));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.VerifyAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.VerifyAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

    #region Verify Right Async

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> VerifyAsync(this Result result, Func<Task<bool>> predicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.VerifyAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> VerifyAsync(this Result result, Func<Task<bool>> predicate, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.VerifyAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> VerifyAsync(this Result result, Func<Task<bool>> predicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        return await predicate().ConfigureAwait(configureAwait) ? result : new Result(result.Reasons.Add(error));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> VerifyAsync(this Result result, Func<Task<bool>> predicate, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        return await predicate().ConfigureAwait(configureAwait) ? result : new Result(result.Reasons.AddRange(errors));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> VerifyAsync(this Result result, Func<Task<bool>> predicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.VerifyAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> VerifyAsync(this Result result, Func<Task<bool>> predicate, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.VerifyAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

    #region Verify Right ValueTask Async

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> VerifyAsync(this Result result, Func<ValueTask<bool>> predicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.VerifyAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> VerifyAsync(this Result result, Func<ValueTask<bool>> predicate, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.VerifyAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> VerifyAsync(this Result result, Func<ValueTask<bool>> predicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        return await predicate().ConfigureAwait(configureAwait) ? result : new Result(result.Reasons.Add(error));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> VerifyAsync(this Result result, Func<ValueTask<bool>> predicate, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        return await predicate().ConfigureAwait(configureAwait) ? result : new Result(result.Reasons.AddRange(errors));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> VerifyAsync(this Result result, Func<ValueTask<bool>> predicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.VerifyAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> VerifyAsync(this Result result, Func<ValueTask<bool>> predicate, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.VerifyAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

    #region Verify Left Async

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> VerifyAsync(this Task<Result> resultTask, Func<bool> predicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.VerifyAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> VerifyAsync(this Task<Result> resultTask, Func<bool> predicate, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.VerifyAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> VerifyAsync(this Task<Result> resultTask, Func<bool> predicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result : new Result(result.Reasons.Add(error));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> VerifyAsync(this Task<Result> resultTask, Func<bool> predicate, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result : new Result(result.Reasons.AddRange(errors));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> VerifyAsync(this Task<Result> resultTask, Func<bool> predicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.VerifyAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> VerifyAsync(this Task<Result> resultTask, Func<bool> predicate, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.VerifyAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

    #region Verify Left ValueTask Async

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, Func<bool> predicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.VerifyAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, Func<bool> predicate, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.VerifyAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, Func<bool> predicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result : new Result(result.Reasons.Add(error));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, Func<bool> predicate, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(configureAwait);
        return predicate() ? result : new Result(result.Reasons.AddRange(errors));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.VerifyAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, Func<bool> predicate, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.VerifyAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

}
