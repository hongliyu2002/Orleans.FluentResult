using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <inheritdoc />
/// <summary>
///     Objects from Success class cause no failed result
/// </summary>
[Immutable]
[GenerateSerializer]
public class Success : ISuccess
{
    /// <summary>
    ///     Creates a new instance of <see cref="Success" />
    /// </summary>
    protected Success()
    {
        Message = string.Empty;
        Metadata = ImmutableDictionary.Create<string, object>();
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Success" />
    /// </summary>
    /// <param name="message">Message of the success</param>
    public Success(string message)
        : this()
    {
        ArgumentNullException.ThrowIfNull(message);
        Message = message;
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Success" />
    /// </summary>
    /// <param name="message">Message of the success</param>
    /// <param name="metadata">Metadata of the success</param>
    public Success(string message, IImmutableDictionary<string, object> metadata)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(metadata);
        Message = message;
        Metadata = metadata;
    }

    /// <inheritdoc />
    /// <summary>
    ///     Message of the success
    /// </summary>
    [Id(0)]
    public string Message { get; }

    /// <inheritdoc />
    /// <summary>
    ///     Metadata of the success
    /// </summary>
    [Id(1)]
    public IImmutableDictionary<string, object> Metadata { get; }

    /// <inheritdoc />
    public virtual IReason Copy()
    {
        return new Success(Message, Metadata);
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return new ReasonStringBuilder().WithReasonType(GetType()).WithInfo(nameof(Message), Message).WithInfo(nameof(Metadata), string.Join("; ", Metadata)).Build();
    }
}
