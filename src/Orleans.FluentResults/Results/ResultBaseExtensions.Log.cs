﻿using Microsoft.Extensions.Logging;

namespace Orleans.FluentResults;

public static partial class ResultBaseExtensions
{

    #region Log

    /// <summary>
    ///     Log the result. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result Log(this IResultBase result, LogLevel logLevel = LogLevel.Information)
    {
        return Log(result, string.Empty, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the result. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result Log(this IResultBase result, string context, LogLevel logLevel = LogLevel.Information)
    {
        return Log(result, context, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the result with a specific logger context. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result Log(this IResultBase result, string context, string content, LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        var logger = ResultSettings.Current.Logger;
        logger.Log(context, content, result, logLevel);
        return result as Result ?? new Result(result.Reasons);
    }

    /// <summary>
    ///     Log the result with a typed context. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result Log<TContext>(this IResultBase result, LogLevel logLevel = LogLevel.Information)
    {
        return Log<TContext>(result, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the result with a typed context. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result Log<TContext>(this IResultBase result, string content, LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        var logger = ResultSettings.Current.Logger;
        logger.Log<TContext>(content, result, logLevel);
        return result as Result ?? new Result(result.Reasons);
    }

    #endregion

    #region Log If Success

    /// <summary>
    ///     Log the result only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result LogIfSuccess(this IResultBase result, LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsSuccess ? Log(result, logLevel) : result as Result ?? new Result(result.Reasons);
    }

    /// <summary>
    ///     Log the result with a specific logger context only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result LogIfSuccess(this IResultBase result, string context, string content = "", LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsSuccess ? Log(result, context, content, logLevel) : result as Result ?? new Result(result.Reasons);
    }

    /// <summary>
    ///     Log the result with a typed context only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result LogIfSuccess<TContext>(this IResultBase result, string content = "", LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsSuccess ? Log<TContext>(result, content, logLevel) : result as Result ?? new Result(result.Reasons);
    }

    #endregion

    #region Log If Failed

    /// <summary>
    ///     Log the result only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result LogIfFailed(this IResultBase result, LogLevel logLevel = LogLevel.Error)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsFailed ? Log(result, logLevel) : result as Result ?? new Result(result.Reasons);
    }

    /// <summary>
    ///     Log the result with a specific logger context only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result LogIfFailed(this IResultBase result, string context, string content = "", LogLevel logLevel = LogLevel.Error)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsFailed ? Log(result, context, content, logLevel) : result as Result ?? new Result(result.Reasons);
    }

    /// <summary>
    ///     Log the result with a typed context only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public static Result LogIfFailed<TContext>(this IResultBase result, string content = "", LogLevel logLevel = LogLevel.Error)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result.IsFailed ? Log<TContext>(result, content, logLevel) : result as Result ?? new Result(result.Reasons);
    }

    #endregion

}
