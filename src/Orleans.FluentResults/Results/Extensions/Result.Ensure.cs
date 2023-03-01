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
    /// <param name="predicate">Action that may fail.</param>
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
    /// <param name="predicate">Action that may fail.</param>
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
    /// <param name="predicate">Action that may fail.</param>
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
    /// <param name="predicate">Action that may fail.</param>
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

    #endregion

    #region Ensure Full Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, string errorMessage)
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
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, IEnumerable<string> errorMessages)
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
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask, Func<Task<bool>> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    #endregion

    #region Ensure Full ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, string errorMessage)
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
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, IEnumerable<string> errorMessages)
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
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    #endregion

    #region Ensure Right Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static Task<Result> EnsureAsync(this Result result, Func<Task<bool>> predicate, string errorMessage)
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
    public static Task<Result> EnsureAsync(this Result result, Func<Task<bool>> predicate, IEnumerable<string> errorMessages)
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
    public static async Task<Result> EnsureAsync(this Result result, Func<Task<bool>> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async Task<Result> EnsureAsync(this Result result, Func<Task<bool>> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    #endregion

    #region Ensure Right ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static ValueTask<Result> EnsureAsync(this Result result, Func<ValueTask<bool>> predicate, string errorMessage)
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
    public static ValueTask<Result> EnsureAsync(this Result result, Func<ValueTask<bool>> predicate, IEnumerable<string> errorMessages)
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
    public static async ValueTask<Result> EnsureAsync(this Result result, Func<ValueTask<bool>> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async ValueTask<Result> EnsureAsync(this Result result, Func<ValueTask<bool>> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        if (result.IsSuccess && !await predicate().ConfigureAwait(false))
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    #endregion

    #region Ensure Left Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, Func<bool> predicate, string errorMessage)
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
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, Func<bool> predicate, IEnumerable<string> errorMessages)
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
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask, Func<bool> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && predicate())
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask, Func<bool> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && predicate())
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    #endregion

    #region Ensure Left ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errorMessage"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<bool> predicate, string errorMessage)
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
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<bool> predicate, IEnumerable<string> errorMessages)
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
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<bool> predicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(error);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && predicate())
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate">Action that may fail.</param>
    /// <param name="errors"></param>
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, Func<bool> predicate, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(errors);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsSuccess && predicate())
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    #endregion

}
