using Microsoft.Extensions.Logging;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public interface IResultLogger
{
    /// <summary>
    /// </summary>
    /// <param name="context"></param>
    /// <param name="content"></param>
    /// <param name="result"></param>
    /// <param name="logLevel"></param>
    void Log(string context, string content, Result result, LogLevel logLevel);

    /// <summary>
    /// </summary>
    /// <param name="content"></param>
    /// <param name="result"></param>
    /// <param name="logLevel"></param>
    /// <typeparam name="TContext"></typeparam>
    void Log<TContext>(string content, Result result, LogLevel logLevel);
}
