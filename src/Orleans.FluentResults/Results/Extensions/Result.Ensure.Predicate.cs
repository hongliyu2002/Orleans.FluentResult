namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Ensure

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    public static Result Ensure(this Result result, Func<bool> predicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.Ensure(predicate, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    public static Result Ensure(this Result result, Func<bool> predicate, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.Ensure(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    public static Result Ensure(this Result result, Func<bool> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        if (result.IsSuccess && !predicate())
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    public static Result Ensure(this Result result, Func<bool> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        if (result.IsSuccess && !predicate())
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    public static Result Ensure(this Result result, Func<bool> predicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.Ensure(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    public static Result Ensure(this Result result, Func<bool> predicate, IEnumerable<Exception> exceptions)
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
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess && !await predicate().ConfigureAwait(configureAwait))
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess && !await predicate().ConfigureAwait(configureAwait))
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

    #region Ensure Full ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess && !await predicate().ConfigureAwait(configureAwait))
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess && !await predicate().ConfigureAwait(configureAwait))
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

    #region Ensure Right Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Result result, Func<Task<bool>> predicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Result result, Func<Task<bool>> predicate, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> EnsureAsync(this Result result, Func<Task<bool>> predicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        if (result.IsSuccess && !await predicate().ConfigureAwait(configureAwait))
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> EnsureAsync(this Result result, Func<Task<bool>> predicate, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        if (result.IsSuccess && !await predicate().ConfigureAwait(configureAwait))
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Result result, Func<Task<bool>> predicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Result result, Func<Task<bool>> predicate, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

    #region Ensure Right ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this Result result, Func<ValueTask<bool>> predicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this Result result, Func<ValueTask<bool>> predicate, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> EnsureAsync(this Result result, Func<ValueTask<bool>> predicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        if (result.IsSuccess && !await predicate().ConfigureAwait(configureAwait))
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> EnsureAsync(this Result result, Func<ValueTask<bool>> predicate, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        if (result.IsSuccess && !await predicate().ConfigureAwait(configureAwait))
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this Result result, Func<ValueTask<bool>> predicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this Result result, Func<ValueTask<bool>> predicate, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

    #region Ensure Left Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, Func<bool> predicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, Func<bool> predicate, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask, Func<bool> predicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess && !predicate())
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask, Func<bool> predicate, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess && !predicate())
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, Func<bool> predicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, Func<bool> predicate, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

    #region Ensure Left ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<bool> predicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<bool> predicate, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(predicate, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<bool> predicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess && !predicate())
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<bool> predicate, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess && !predicate())
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<bool> predicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(predicate, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<bool> predicate, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(predicate, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

}
