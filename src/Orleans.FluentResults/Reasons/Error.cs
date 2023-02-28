using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <inheritdoc />
/// <summary>
///     Objects from Error class cause a failed result
/// </summary>
[Immutable]
[GenerateSerializer]
public record Error(string Message, IImmutableDictionary<string, object> Metadata, IImmutableList<IError> Reasons) : IError
{
    /// <summary>
    ///     Creates a new instance of <see cref="Error" />
    /// </summary>
    public Error()
        : this(string.Empty, ImmutableDictionary<string, object>.Empty, ImmutableList<IError>.Empty)
    {
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Error" />
    /// </summary>
    /// <param name="message">Message of the error</param>
    public Error(string message)
        : this(message, ImmutableDictionary<string, object>.Empty, ImmutableList<IError>.Empty)
    {
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Error" />
    /// </summary>
    /// <param name="message">Message of the error</param>
    /// <param name="causedBy">The root cause of the <see cref="Error" /></param>
    public Error(string message, Error causedBy)
        : this(message, ImmutableDictionary<string, object>.Empty, ImmutableList<IError>.Empty.Add(causedBy))
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
                                        .Build();
    }
}
