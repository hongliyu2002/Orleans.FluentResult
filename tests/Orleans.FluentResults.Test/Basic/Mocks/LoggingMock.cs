using Microsoft.Extensions.Logging;

namespace Orleans.FluentResults.Test.Mocks;

public class LoggingMock : IResultLogger
{
    public string LoggedContext { get; private set; }
    public string LoggedContent { get; private set; }
    public Result LoggedResult { get; private set; }
    public LogLevel LoggedLevel { get; private set; }

    /// <inheritdoc />
    public void Log(string context, string content, Result result, LogLevel logLevel = LogLevel.Information)
    {
        LoggedContext = context;
        LoggedContent = content;
        LoggedResult = result;
        LoggedLevel = logLevel;
    }

    /// <inheritdoc />
    public void Log<TContext>(string content, Result result, LogLevel logLevel = LogLevel.Information)
    {
        LoggedContext = typeof(TContext).ToString();
        LoggedContent = content;
        LoggedResult = result;
        LoggedLevel = logLevel;
    }
}
