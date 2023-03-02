using Microsoft.Extensions.Logging;

namespace Orleans.FluentResults;

public static partial class ResultTValueExtensions
{

    #region Log

    /// <summary>
    ///     Log the this. Configure the logger via ResultSettings.Setup(..)
    /// </summary>
    public static Result<T> Log<T>(this Result<T> result, LogLevel logLevel = LogLevel.Information)
    {
        return Log(result, string.Empty, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the this. Configure the logger via ResultSettings.Setup(..)
    /// </summary>
    public static Result<T> Log<T>(this Result<T> result, string context, LogLevel logLevel = LogLevel.Information)
    {
        return Log(result, context, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the this with a specific logger context. Configure the logger via ResultSettings.Setup(..)
    /// </summary>
    public static Result<T> Log<T>(this Result<T> result, string context, string content, LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        var logger = ResultSettings.Current.Logger;
        logger.Log(context, content, result, logLevel);
        return result;
    }

    /// <summary>
    ///     Log the this with a typed context. Configure the logger via ResultSettings.Setup(..)
    /// </summary>
    public static Result<T> Log<T, TContext>(this Result<T> result, LogLevel logLevel = LogLevel.Information)
    {
        return Log<T, TContext>(result, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the this with a typed context. Configure the logger via ResultSettings.Setup(..)
    /// </summary>
    public static Result<T> Log<T, TContext>(this Result<T> result, string content, LogLevel logLevel = LogLevel.Information)
    {
        var logger = ResultSettings.Current.Logger;
        logger.Log<TContext>(content, result, logLevel);
        return result;
    }

    #endregion

    #region Log If Success

    /// <summary>
    ///     Log the this only when it is successful. Configure the logger via ResultSettings.Setup(..)
    /// </summary>
    public static Result<T> LogIfSuccess<T>(this Result<T> result, LogLevel logLevel = LogLevel.Information)
    {
        return result.IsSuccess ? Log(result, logLevel) : result;
    }

    /// <summary>
    ///     Log the this with a specific logger context only when it is successful. Configure the logger via ResultSettings.Setup(..)
    /// </summary>
    public static Result<T> LogIfSuccess<T>(this Result<T> result, string context, string content = "", LogLevel logLevel = LogLevel.Information)
    {
        return result.IsSuccess ? Log(result, context, content, logLevel) : result;
    }

    /// <summary>
    ///     Log the this with a typed context only when it is successful. Configure the logger via ResultSettings.Setup(..)
    /// </summary>
    public static Result<T> LogIfSuccess<T, TContext>(this Result<T> result, string content = "", LogLevel logLevel = LogLevel.Information)
    {
        return result.IsSuccess ? Log<T, TContext>(result, content, logLevel) : result;
    }

    #endregion

    #region Log If Failed

    /// <summary>
    ///     Log the this only when it is failed. Configure the logger via ResultSettings.Setup(..)
    /// </summary>
    public static Result<T> LogIfFailed<T>(this Result<T> result, LogLevel logLevel = LogLevel.Error)
    {
        return result.IsFailed ? Log(result, logLevel) : result;
    }

    /// <summary>
    ///     Log the this with a specific logger context only when it is failed. Configure the logger via ResultSettings.Setup(..)
    /// </summary>
    public static Result<T> LogIfFailed<T>(this Result<T> result, string context, string content = "", LogLevel logLevel = LogLevel.Error)
    {
        return result.IsFailed ? Log(result, context, content, logLevel) : result;
    }

    /// <summary>
    ///     Log the this with a typed context only when it is failed. Configure the logger via ResultSettings.Setup(..)
    /// </summary>
    public static Result<T> LogIfFailed<T, TContext>(this Result<T> result, string content = "", LogLevel logLevel = LogLevel.Error)
    {
        return result.IsFailed ? Log<T, TContext>(result, content, logLevel) : result;
    }

    #endregion

}
