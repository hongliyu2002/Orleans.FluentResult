using Microsoft.Extensions.Logging;

namespace Orleans.FluentResults;

public static partial class ResultOfTValueExtensions
{

    #region Log

    /// <summary>
    ///     Log the result. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result<TValue> Log<TValue>(this Result<TValue> result, LogLevel logLevel = LogLevel.Information)
    {
        return Log(result, string.Empty, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the result. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result<TValue> Log<TValue>(this Result<TValue> result, string context, LogLevel logLevel = LogLevel.Information)
    {
        return Log(result, context, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the result with a specific logger context. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result<TValue> Log<TValue>(this Result<TValue> result, string context, string content, LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        var logger = ResultSettings.Current.Logger;
        logger.Log(context, content, result, logLevel);
        return result;
    }

    /// <summary>
    ///     Log the result with a typed context. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result<TValue> Log<TValue, TContext>(this Result<TValue> result, LogLevel logLevel = LogLevel.Information)
    {
        return Log<TValue, TContext>(result, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the result with a typed context. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result<TValue> Log<TValue, TContext>(this Result<TValue> result, string content, LogLevel logLevel = LogLevel.Information)
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
    public static Result<TValue> LogIfSuccess<TValue>(this Result<TValue> result, LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsSuccess ? Log(result, logLevel) : result;
    }

    /// <summary>
    ///     Log the result with a specific logger context only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result<TValue> LogIfSuccess<TValue>(this Result<TValue> result, string context, string content = "", LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsSuccess ? Log(result, context, content, logLevel) : result;
    }

    /// <summary>
    ///     Log the result with a typed context only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result<TValue> LogIfSuccess<TValue, TContext>(this Result<TValue> result, string content = "", LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsSuccess ? Log<TValue, TContext>(result, content, logLevel) : result;
    }

    #endregion

    #region Log If Failed

    /// <summary>
    ///     Log the result only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result<TValue> LogIfFailed<TValue>(this Result<TValue> result, LogLevel logLevel = LogLevel.Error)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsFailed ? Log(result, logLevel) : result;
    }

    /// <summary>
    ///     Log the result with a specific logger context only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result<TValue> LogIfFailed<TValue>(this Result<TValue> result, string context, string content = "", LogLevel logLevel = LogLevel.Error)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsFailed ? Log(result, context, content, logLevel) : result;
    }

    /// <summary>
    ///     Log the result with a typed context only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result<TValue> LogIfFailed<TValue, TContext>(this Result<TValue> result, string content = "", LogLevel logLevel = LogLevel.Error)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsFailed ? Log<TValue, TContext>(result, content, logLevel) : result;
    }

    #endregion

}
