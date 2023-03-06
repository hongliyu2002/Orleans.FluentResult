namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public record ResultSettings(IResultLogger Logger, Func<Exception, IError> DefaultTryCatchHandler, Func<string, ISuccess> SuccessFactory, Func<string, IError> ErrorFactory, Func<string, Exception, IExceptionalError> ExceptionalErrorFactory)
{

    /// <summary>
    /// </summary>
    public static ResultSettings Current { get; private set; } = new ResultSettingsBuilder().Build();

    /// <summary>
    ///     Setup global settings like logging
    /// </summary>
    public static void Setup(Action<ResultSettingsBuilder> setupSettings)
    {
        var settingsBuilder = new ResultSettingsBuilder();
        setupSettings(settingsBuilder);
        Current = settingsBuilder.Build();
    }
}
