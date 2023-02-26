using Microsoft.Extensions.Logging;

namespace Orleans.FluentResults;

public partial record Result
{

    #region Log

    /// <summary>
    ///     Log the this. Configure the logger via Result.Setup(..)
    /// </summary>
    public Result Log(LogLevel logLevel = LogLevel.Information)
    {
        return Log(string.Empty, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the this. Configure the logger via Result.Setup(..)
    /// </summary>
    public Result Log(string context, LogLevel logLevel = LogLevel.Information)
    {
        return Log(context, string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the this with a specific logger context. Configure the logger via Result.Setup(..)
    /// </summary>
    public Result Log(string context, string content, LogLevel logLevel = LogLevel.Information)
    {
        ArgumentNullException.ThrowIfNull(this);
        var logger = ResultSettings.Current.Logger;
        logger.Log(context, content, this, logLevel);
        return this;
    }

    /// <summary>
    ///     Log the this with a typed context. Configure the logger via Result.Setup(..)
    /// </summary>
    public Result Log<TContext>(LogLevel logLevel = LogLevel.Information)
    {
        return Log<TContext>(string.Empty, logLevel);
    }

    /// <summary>
    ///     Log the this with a typed context. Configure the logger via Result.Setup(..)
    /// </summary>
    public Result Log<TContext>(string content, LogLevel logLevel = LogLevel.Information)
    {
        var logger = ResultSettings.Current.Logger;
        logger.Log<TContext>(content, this, logLevel);
        return this;
    }

    #endregion

    #region Log If Success

    /// <summary>
    ///     Log the this only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public Result LogIfSuccess(LogLevel logLevel = LogLevel.Information)
    {
        return IsSuccess ? Log(logLevel) : this;
    }

    /// <summary>
    ///     Log the this with a specific logger context only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public Result LogIfSuccess(string context, string content = "", LogLevel logLevel = LogLevel.Information)
    {
        return IsSuccess ? Log(context, content, logLevel) : this;
    }

    /// <summary>
    ///     Log the this with a typed context only when it is successful. Configure the logger via Result.Setup(..)
    /// </summary>
    public Result LogIfSuccess<TContext>(string content = "", LogLevel logLevel = LogLevel.Information)
    {
        return IsSuccess ? Log<TContext>(content, logLevel) : this;
    }

    #endregion

    #region Log If Failed

    /// <summary>
    ///     Log the this only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public Result LogIfFailed(LogLevel logLevel = LogLevel.Error)
    {
        return IsFailed ? Log(logLevel) : this;
    }

    /// <summary>
    ///     Log the this with a specific logger context only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public Result LogIfFailed(string context, string content = "", LogLevel logLevel = LogLevel.Error)
    {
        return IsFailed ? Log(context, content, logLevel) : this;
    }

    /// <summary>
    ///     Log the this with a typed context only when it is failed. Configure the logger via Result.Setup(..)
    /// </summary>
    public Result LogIfFailed<TContext>(string content = "", LogLevel logLevel = LogLevel.Error)
    {
        return IsFailed ? Log<TContext>(content, logLevel) : this;
    }

    #endregion

}
