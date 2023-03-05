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
    /// <param name="condition"></param>
    /// <param name="errorMessage"></param>
    public static Result Verify(this Result result, bool condition, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.Verify(condition, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="errorMessages"></param>
    public static Result Verify(this Result result, bool condition, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.Verify(condition, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="error"></param>
    public static Result Verify(this Result result, bool condition, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return condition ? result : new Result(result.Reasons.Add(error));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="errors"></param>
    public static Result Verify(this Result result, bool condition, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return condition ? result : new Result(result.Reasons.AddRange(errors));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="exception"></param>
    public static Result Verify(this Result result, bool condition, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.Verify(condition, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="exceptions"></param>
    public static Result Verify(this Result result, bool condition, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.Verify(condition, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    #endregion

    #region Verify Async

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="errorMessage"></param>
    public static Task<Result> VerifyAsync(this Task<Result> resultTask, bool condition, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.VerifyAsync(condition, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="errorMessages"></param>
    public static Task<Result> VerifyAsync(this Task<Result> resultTask, bool condition, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.VerifyAsync(condition, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="error"></param>
    public static async Task<Result> VerifyAsync(this Task<Result> resultTask, bool condition, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(true);
        return condition ? result : new Result(result.Reasons.Add(error));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="errors"></param>
    public static async Task<Result> VerifyAsync(this Task<Result> resultTask, bool condition, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(true);
        return condition ? result : new Result(result.Reasons.AddRange(errors));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="exception"></param>
    public static Task<Result> VerifyAsync(this Task<Result> resultTask, bool condition, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.VerifyAsync(condition, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="exceptions"></param>
    public static Task<Result> VerifyAsync(this Task<Result> resultTask, bool condition, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.VerifyAsync(condition, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    #endregion

    #region Verify ValueTask Async

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="errorMessage"></param>
    public static ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, bool condition, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.VerifyAsync(condition, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns the starting result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="errorMessages"></param>
    public static ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, bool condition, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.VerifyAsync(condition, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="error"></param>
    public static async ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, bool condition, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(true);
        return condition ? result : new Result(result.Reasons.Add(error));
    }

    /// <summary>
    ///     Returns the starting result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="errors"></param>
    public static async ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, bool condition, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(true);
        return condition ? result : new Result(result.Reasons.AddRange(errors));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="exception"></param>
    public static ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, bool condition, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.VerifyAsync(condition, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns the starting result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="exceptions"></param>
    public static ValueTask<Result> VerifyAsync(this ValueTask<Result> resultTask, bool condition, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.VerifyAsync(condition, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    #endregion

}
