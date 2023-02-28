using Microsoft.Extensions.Logging;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public class DefaultLogger : IResultLogger
{
    /// <inheritdoc />
    public void Log(string context, string content, IResult result, LogLevel logLevel)
    {
    }

    /// <inheritdoc />
    public void Log<TContext>(string content, IResult result, LogLevel logLevel)
    {
    }
}
