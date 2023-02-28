using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <inheritdoc />
/// <summary>
///     Objects from Success class cause no failed result
/// </summary>
[Immutable]
[GenerateSerializer]
public record Success(string Message, IImmutableDictionary<string, object> Metadata) : ISuccess
{
    /// <summary>
    ///     Creates a new instance of <see cref="Success" />
    /// </summary>
    public Success()
        : this(string.Empty, ImmutableDictionary<string, object>.Empty)
    {
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Success" />
    /// </summary>
    /// <param name="message">Message of the success</param>
    public Success(string message)
        : this(message, ImmutableDictionary<string, object>.Empty)
    {
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return new ReasonStringBuilder().WithReasonType(GetType()).WithInfo(nameof(Message), Message).WithInfo(nameof(Metadata), string.Join("; ", Metadata)).Build();
    }
}
