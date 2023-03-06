namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public sealed class ResultSettingsBuilder
{
    /// <summary>
    ///     Set the ResultLogger
    /// </summary>
    public IResultLogger Logger { get; set; } = new DefaultLogger();

    /// <summary>
    ///     Handler that try to transform Exception to Error object.
    /// </summary>
    public Func<Exception, IError> DefaultTryCatchHandler { get; set; } = ex => ResultSettings.Current.ExceptionalErrorFactory(ex.Message, ex);

    /// <summary>
    ///     Factory to create an Success object. Used in all scenarios where a success is created within FluentResults.
    /// </summary>
    public Func<string, ISuccess> SuccessFactory { get; set; } = successMessage => new Success(successMessage);

    /// <summary>
    ///     Factory to create an Error object. Used in all scenarios where an error is created within FluentResults.
    /// </summary>
    public Func<string, IError> ErrorFactory { get; set; } = errorMessage => new Error(errorMessage);

    /// <summary>
    ///     Factory to create an ExceptionalError object. Used in all scenarios where an exceptional error is created within FluentResults.
    /// </summary>
    public Func<string, Exception, IExceptionalError> ExceptionalErrorFactory { get; set; } = (errorMessage, exception) => new ExceptionalError(string.IsNullOrEmpty(errorMessage) ? exception.Message : errorMessage, exception);

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public ResultSettings Build()
    {
        return new ResultSettings(Logger, DefaultTryCatchHandler, SuccessFactory, ErrorFactory, ExceptionalErrorFactory);
    }
}
