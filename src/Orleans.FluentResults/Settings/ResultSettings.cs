namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public record ResultSettings(IResultLogger Logger, Func<Exception, Error> DefaultTryCatchHandler, Func<string, ISuccess> SuccessFactory, Func<string, Error> ErrorFactory,
                             Func<string, Exception, ExceptionalError> ExceptionalErrorFactory)
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
