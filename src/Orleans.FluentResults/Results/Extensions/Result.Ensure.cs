﻿namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Ensure

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="errorMessage"></param>
    public static Result Ensure(this Result result, bool condition, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return result.Ensure(condition, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="errorMessages"></param>
    public static Result Ensure(this Result result, bool condition, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return result.Ensure(condition, errorMessages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="error"></param>
    public static Result Ensure(this Result result, bool condition, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        if (result.IsSuccess && !condition)
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="errors"></param>
    public static Result Ensure(this Result result, bool condition, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        if (result.IsSuccess && !condition)
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="exception"></param>
    public static Result Ensure(this Result result, bool condition, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return result.Ensure(condition, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception));
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="exceptions"></param>
    public static Result Ensure(this Result result, bool condition, IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return result.Ensure(condition, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    #endregion

    #region Ensure Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, bool condition, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(condition, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, bool condition, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(condition, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask, bool condition, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(error);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess && !condition)
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> EnsureAsync(this Task<Result> resultTask, bool condition, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errors);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess && !condition)
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, bool condition, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(condition, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static Task<Result> EnsureAsync(this Task<Result> resultTask, bool condition, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(condition, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

    #region Ensure ValueTask Async

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="errorMessage"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, bool condition, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return resultTask.EnsureAsync(condition, ResultSettings.Current.ErrorFactory(errorMessage), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with errorMessage if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="errorMessages"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, bool condition, IEnumerable<string> errorMessages, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return resultTask.EnsureAsync(condition, errorMessages.Select(ResultSettings.Current.ErrorFactory), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="error"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, bool condition, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(error);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess && !condition)
        {
            return new Result(result.Reasons.Add(error));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with error if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="errors"></param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, bool condition, IEnumerable<IError> errors, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(errors);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        if (result.IsSuccess && !condition)
        {
            return new Result(result.Reasons.AddRange(errors));
        }
        return result;
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="exception"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, bool condition, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return resultTask.EnsureAsync(condition, ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception), configureAwait);
    }

    /// <summary>
    ///     Returns a new failure result with exception if the predicate is false. Otherwise returns the starting result.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="exceptions"></param>
    /// <param name="configureAwait"></param>
    public static ValueTask<Result> EnsureAsync(this ValueTask<Result> resultTask, bool condition, IEnumerable<Exception> exceptions, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return resultTask.EnsureAsync(condition, exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)), configureAwait);
    }

    #endregion

}
