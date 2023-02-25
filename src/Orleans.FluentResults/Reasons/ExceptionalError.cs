using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
///     Error class which stores additionally the exception
/// </summary>
[Immutable]
[GenerateSerializer]
public class ExceptionalError : Error, IExceptionalError
{
    /// <inheritdoc />
    /// <summary>
    ///     Creates a new instance of <see cref="ExceptionalError" />
    /// </summary>
    public ExceptionalError()
    {
        Exception = null!;
    }

    /// <inheritdoc />
    /// <summary>
    ///     Creates a new instance of <see cref="ExceptionalError" />
    /// </summary>
    /// <param name="exception">Exception of the error</param>
    public ExceptionalError(Exception exception)
        : this(exception.Message, exception)
    {
    }

    /// <inheritdoc />
    /// <summary>
    ///     Creates a new instance of <see cref="T:Orleans.FluentResults.ExceptionalError" />
    /// </summary>
    /// <param name="message">Message of the error</param>
    /// <param name="exception">Exception of the error</param>
    public ExceptionalError(string message, Exception exception)
        : base(message)
    {
        ArgumentNullException.ThrowIfNull(exception);
        Exception = exception;
    }

    /// <inheritdoc />
    /// <summary>
    ///     Creates a new instance of <see cref="T:Orleans.FluentResults.ExceptionalError" />
    /// </summary>
    /// <param name="message">Message of the error</param>
    /// <param name="metadata"></param>
    /// <param name="reasons"></param>
    /// <param name="exception">Exception of the error</param>
    public ExceptionalError(string message, IImmutableDictionary<string, object> metadata, IImmutableList<IError> reasons, Exception exception)
        : base(message, metadata, reasons)
    {
        ArgumentNullException.ThrowIfNull(exception);
        Exception = exception;
    }

    /// <inheritdoc />
    [Id(0)]
    public Exception Exception { get; }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return new ReasonStringBuilder().WithReasonType(GetType())
                                        .WithInfo(nameof(Message), Message)
                                        .WithInfo(nameof(Metadata), string.Join("; ", Metadata))
                                        .WithInfo(nameof(Reasons), string.Join("; ", Reasons))
                                        .WithInfo(nameof(Exception), Exception.ToString())
                                        .Build();
    }
}
