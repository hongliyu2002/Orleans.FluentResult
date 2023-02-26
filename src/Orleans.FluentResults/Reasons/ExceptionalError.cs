using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
///     Error class which stores additionally the exception
/// </summary>
[Immutable]
[GenerateSerializer]
public record ExceptionalError(string Message, IImmutableDictionary<string, object> Metadata, IImmutableList<Error> Reasons, Exception Exception)
    : Error(Message, Metadata, Reasons), IExceptionalError
{
    /// <summary>
    ///     Creates a new instance of <see cref="ExceptionalError" />
    /// </summary>
    public ExceptionalError()
        : this(string.Empty, ImmutableDictionary<string, object>.Empty, ImmutableList<Error>.Empty, new Exception(string.Empty))
    {
    }

    /// <summary>
    ///     Creates a new instance of <see cref="ExceptionalError" />
    /// </summary>
    /// <param name="message">Message of the error</param>
    public ExceptionalError(string message)
        : this(message, ImmutableDictionary<string, object>.Empty, ImmutableList<Error>.Empty, new Exception(message))
    {
    }

    /// <summary>
    ///     Creates a new instance of <see cref="ExceptionalError" />
    /// </summary>
    /// <param name="exception">Exception of the error</param>
    public ExceptionalError(Exception exception)
        : this(exception.Message, ImmutableDictionary<string, object>.Empty, ImmutableList<Error>.Empty, exception)
    {
    }

    /// <summary>
    ///     Creates a new instance of <see cref="ExceptionalError" />
    /// </summary>
    /// <param name="message">Message of the error</param>
    /// <param name="exception">Exception of the error</param>
    public ExceptionalError(string message, Exception exception)
        : this(message, ImmutableDictionary<string, object>.Empty, ImmutableList<Error>.Empty, exception)
    {
    }

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
