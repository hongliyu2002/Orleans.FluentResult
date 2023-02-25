﻿namespace Orleans.FluentResults;

/// <summary>
/// </summary>
[Immutable]
[GenerateSerializer]
public class ResultSettings
{
    /// <summary>
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="defaultTryCatchHandler"></param>
    /// <param name="successFactory"></param>
    /// <param name="errorFactory"></param>
    /// <param name="exceptionalErrorFactory"></param>
    public ResultSettings(IResultLogger logger, Func<Exception, IError> defaultTryCatchHandler, Func<string, ISuccess> successFactory, Func<string, IError> errorFactory,
                          Func<string, Exception, IExceptionalError> exceptionalErrorFactory)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(defaultTryCatchHandler);
        ArgumentNullException.ThrowIfNull(successFactory);
        ArgumentNullException.ThrowIfNull(errorFactory);
        ArgumentNullException.ThrowIfNull(exceptionalErrorFactory);
        Logger = logger;
        DefaultTryCatchHandler = defaultTryCatchHandler;
        SuccessFactory = successFactory;
        ErrorFactory = errorFactory;
        ExceptionalErrorFactory = exceptionalErrorFactory;
    }

    /// <summary>
    /// </summary>
    public static ResultSettings Current { get; private set; } = new ResultSettingsBuilder().Build();

    /// <summary>
    /// </summary>
    [Id(0)]
    public IResultLogger Logger { get; }

    /// <summary>
    /// </summary>
    [Id(1)]
    public Func<Exception, IError> DefaultTryCatchHandler { get; }

    /// <summary>
    ///     Factory to create an ISuccess object. Used in all scenarios where a success is created within FluentResults.
    /// </summary>
    [Id(2)]
    public Func<string, ISuccess> SuccessFactory { get; }

    /// <summary>
    /// </summary>
    [Id(3)]
    public Func<string, IError> ErrorFactory { get; }

    /// <summary>
    /// </summary>
    [Id(4)]
    public Func<string, Exception, IExceptionalError> ExceptionalErrorFactory { get; }

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