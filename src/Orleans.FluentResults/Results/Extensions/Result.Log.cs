using Microsoft.Extensions.Logging;

namespace Orleans.FluentResults;

public static partial class ResultExtensions
{

    #region Log

    /// <summary>
    ///     Log the this. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result Log(this Result result, LogLevel logLevel = LogLevel.Information)
    {
        return Log(result, string.Empty, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the this. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result Log(this Result result, string context, LogLevel logLevel = LogLevel.Information)
    {
        return Log(result, context, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the this with a specific logger context. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result Log(this Result result, string context, string content, LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        var logger = ResultSettings.Current.Logger;
        logger.Log(context, content, result, logLevel);
        return result;
    }

    /// <summary>
    ///     Log the this with a typed context. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result Log<TContext>(this Result result, LogLevel logLevel = LogLevel.Information)
    {
        return Log<TContext>(result, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the this with a typed context. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result Log<TContext>(this Result result, string content, LogLevel logLevel = LogLevel.Information)
    {
        var logger = ResultSettings.Current.Logger;
        logger.Log<TContext>(content, result, logLevel);
        return result;
    }

    #endregion

    #region Log If Success

    /// <summary>
    ///     Log the this only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result LogIfSuccess(this Result result, LogLevel logLevel = LogLevel.Information)
    {
        return result.IsSuccess ? Log(result, logLevel) : result;
    }

    /// <summary>
    ///     Log the this with a specific logger context only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result LogIfSuccess(this Result result, string context, string content = "", LogLevel logLevel = LogLevel.Information)
    {
        return result.IsSuccess ? Log(result, context, content, logLevel) : result;
    }

    /// <summary>
    ///     Log the this with a typed context only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result LogIfSuccess<TContext>(this Result result, string content = "", LogLevel logLevel = LogLevel.Information)
    {
        return result.IsSuccess ? Log<TContext>(result, content, logLevel) : result;
    }

    #endregion

    #region Log If Failed

    /// <summary>
    ///     Log the this only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result LogIfFailed(this Result result, LogLevel logLevel = LogLevel.Error)
    {
        return result.IsFailed ? Log(result, logLevel) : result;
    }

    /// <summary>
    ///     Log the this with a specific logger context only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result LogIfFailed(this Result result, string context, string content = "", LogLevel logLevel = LogLevel.Error)
    {
        return result.IsFailed ? Log(result, context, content, logLevel) : result;
    }

    /// <summary>
    ///     Log the this with a typed context only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result LogIfFailed<TContext>(this Result result, string content = "", LogLevel logLevel = LogLevel.Error)
    {
        return result.IsFailed ? Log<TContext>(result, content, logLevel) : result;
    }

    #endregion

}
