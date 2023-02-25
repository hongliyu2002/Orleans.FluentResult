using Microsoft.Extensions.Logging;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class ResultBaseExtensions
{

    #region To Result

    /// <summary>
    ///     Convert result to result with a new value
    /// </summary>
    public static Result ToResult(this IResultBase result)
    {
        ArgumentNullException.ThrowIfNull(result);
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Convert result to result with a new value
    /// </summary>
    public static Result<TValue> ToResult<TValue>(this IResultBase result, TValue value)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(value);
        return new Result<TValue>(value, result.Reasons);
    }

    #endregion

    #region With Success

    /// <summary>
    ///     Add a success message
    /// </summary>
    public static Result WithSuccess(this IResultBase result, string successMessage)
    {
        ArgumentException.ThrowIfNullOrEmpty(successMessage);
        return WithSuccess(result, ResultSettings.Current.SuccessFactory(successMessage));
    }

    /// <summary>
    ///     Add a success
    /// </summary>
    public static Result WithSuccess(this IResultBase result, ISuccess success)
    {
        ArgumentNullException.ThrowIfNull(success);
        return WithReason(result, success);
    }

    /// <summary>
    ///     Add a success
    /// </summary>
    public static Result WithSuccess<TSuccess>(this IResultBase result)
        where TSuccess : ISuccess, new()
    {
        return WithSuccess(result, new TSuccess());
    }

    /// <summary>
    ///     Add multiple successes
    /// </summary>
    /// <param name="result"></param>
    /// <param name="successes"></param>
    /// <returns></returns>
    public static Result WithSuccesses(this IResultBase result, IEnumerable<ISuccess> successes)
    {
        ArgumentNullException.ThrowIfNull(successes);
        return WithReasons(result, successes);
    }

    /// <summary>
    ///     Add multiple success messages
    /// </summary>
    public static Result WithSuccesses(this IResultBase result, IEnumerable<string> successMessages)
    {
        ArgumentNullException.ThrowIfNull(successMessages);
        return WithReasons(result, successMessages.Select(successMessage => ResultSettings.Current.SuccessFactory(successMessage)));
    }

    #endregion

    #region With Error

    /// <summary>
    ///     Add an error message
    /// </summary>
    public static Result WithError(this IResultBase result, string errorMessage)
    {
        ArgumentException.ThrowIfNullOrEmpty(errorMessage);
        return WithError(result, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Add an error
    /// </summary>
    public static Result WithError(this IResultBase result, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return WithReason(result, error);
    }

    /// <summary>
    ///     Add an error
    /// </summary>
    public static Result WithError<TError>(this IResultBase result)
        where TError : IError, new()
    {
        return WithError(result, new TError());
    }

    /// <summary>
    ///     Add multiple errors
    /// </summary>
    public static Result WithErrors(this IResultBase result, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return WithReasons(result, errors);
    }

    /// <summary>
    ///     Add multiple error messages
    /// </summary>
    public static Result WithErrors(this IResultBase result, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return WithReasons(result, errorMessages.Select(errorMessage => ResultSettings.Current.ErrorFactory(errorMessage)));
    }

    #endregion

    #region With Reason

    /// <summary>
    ///     Add a reason (success or error)
    /// </summary>
    public static Result WithReason(this IResultBase result, IReason reason)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(reason);
        return new Result(result.Reasons.Add(reason));
    }

    /// <summary>
    ///     Add multiple reasons (success or error)
    /// </summary>
    public static Result WithReasons(this IResultBase result, IEnumerable<IReason> reasons)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(reasons);
        return new Result(result.Reasons.AddRange(reasons));
    }

    #endregion

    #region Log

    /// <summary>
    ///     Log the result. Configure the logger via Result.Setup(..)
    /// </summary>
    public static IResultBase Log(this IResultBase result, LogLevel logLevel = LogLevel.Information)
    {
        return Log(result, string.Empty, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the result. Configure the logger via Result.Setup(..)
    /// </summary>
    public static IResultBase Log(this IResultBase result, string context, LogLevel logLevel = LogLevel.Information)
    {
        return Log(result, context, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the result with a specific logger context. Configure the logger via Result.Setup(..)
    /// </summary>
    public static IResultBase Log(this IResultBase result, string context, string content, LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        var logger = ResultSettings.Current.Logger;
        logger.Log(context, content, result, logLevel);
        return result;
    }

    /// <summary>
    ///     Log the result with a typed context. Configure the logger via Result.Setup(..)
    /// </summary>
    public static IResultBase Log<TContext>(this IResultBase result, LogLevel logLevel = LogLevel.Information)
    {
        return Log<TContext>(result, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the result with a typed context. Configure the logger via Result.Setup(..)
    /// </summary>
    public static IResultBase Log<TContext>(this IResultBase result, string content, LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        var logger = ResultSettings.Current.Logger;
        logger.Log<TContext>(content, result, logLevel);
        return result;
    }

    #endregion

    #region Log If Success

    /// <summary>
    ///     Log the result only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public static IResultBase LogIfSuccess(this IResultBase result, LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsSuccess ? Log(result, logLevel) : result;
    }

    /// <summary>
    ///     Log the result with a specific logger context only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public static IResultBase LogIfSuccess(this IResultBase result, string context, string content = "", LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsSuccess ? Log(result, context, content, logLevel) : result;
    }

    /// <summary>
    ///     Log the result with a typed context only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public static IResultBase LogIfSuccess<TContext>(this IResultBase result, string content = "", LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsSuccess ? Log<TContext>(result, content, logLevel) : result;
    }

    #endregion

    #region Log If Failed

    /// <summary>
    ///     Log the result only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public static IResultBase LogIfFailed(this IResultBase result, LogLevel logLevel = LogLevel.Error)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsFailed ? Log(result, logLevel) : result;
    }

    /// <summary>
    ///     Log the result with a specific logger context only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public static IResultBase LogIfFailed(this IResultBase result, string context, string content = "", LogLevel logLevel = LogLevel.Error)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsFailed ? Log(result, context, content, logLevel) : result;
    }

    /// <summary>
    ///     Log the result with a typed context only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public static IResultBase LogIfFailed<TContext>(this IResultBase result, string content = "", LogLevel logLevel = LogLevel.Error)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsFailed ? Log<TContext>(result, content, logLevel) : result;
    }

    #endregion

    #region Map

    /// <summary>
    ///     Map all successMessages of the result via successMapper
    /// </summary>
    /// <param name="result"></param>
    /// <param name="successMapper"></param>
    /// <returns></returns>
    public static Result MapSuccesses(this IResultBase result, Func<ISuccess, ISuccess> successMapper)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(successMapper);
        return new Result().WithErrors(result.Errors).WithSuccesses(result.Successes.Select(successMapper));
    }

    /// <summary>
    ///     Map all errorMessages of the result via errorMapper
    /// </summary>
    /// <param name="result"></param>
    /// <param name="errorMapper"></param>
    /// <returns></returns>
    public static Result MapErrors(this IResultBase result, Func<IError, IError> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(errorMapper);
        if (result.IsSuccess)
        {
            return new Result(result.Reasons);
        }
        return new Result().WithErrors(result.Errors.Select(errorMapper)).WithSuccesses(result.Successes);
    }

    #endregion

    #region Bind

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="IResultBase" />.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Action that may fail.</param>
    public static Result Bind(this IResultBase result, Func<IResultBase> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = new Result(result.Reasons);
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = bindAction();
        return boundResult.WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result" /> asynchronously.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Action that may fail.</param>
    public static async Task<Result> Bind(this IResultBase result, Func<Task<IResultBase>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = new Result(result.Reasons);
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction();
        return boundResult.WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result" /> asynchronously.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Action that may fail.</param>
    public static async ValueTask<Result> Bind(this IResultBase result, Func<ValueTask<Result>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = new Result(result.Reasons);
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction();
        return boundResult.WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="IResultBase" />.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Action that may fail.</param>
    public static Result<TValue> Bind<TValue>(this IResultBase result, Func<IResult<TValue>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = new Result<TValue>(result.Reasons);
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = bindAction();
        return boundResult.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
    }

    /// <summary>
    /// Convert result to result with value that may fail asynchronously.
    /// </summary>
    /// <example>
    /// <code>
    ///  var bakeryDtoResult = result.Bind(GetWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Transformation that may fail.</param>
    public static async Task<Result<TValue>> Bind<TValue>(this IResultBase result, Func<Task<Result<TValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = new Result<TValue>(result.Reasons);
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction();
        return boundResult.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
    }
    /// <summary>
    /// Convert result to result with value that may fail asynchronously.
    /// </summary>
    /// <example>
    /// <code>
    ///  var bakeryDtoResult = result.Bind(GetWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Transformation that may fail.</param>
    public static async ValueTask<Result<TValue>> Bind<TValue>(this IResultBase result, Func<ValueTask<Result<TValue>>> bindAction)
    {
        var boundResult = new Result<TValue>(result.Reasons);
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction();
        return boundResult.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
    }
    
    #endregion

}
