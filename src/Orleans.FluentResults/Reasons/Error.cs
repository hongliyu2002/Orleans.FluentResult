using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <inheritdoc />
/// <summary>
///     Objects from Error class cause a failed result
/// </summary>
[Immutable]
[GenerateSerializer]
public class Error : IError
{
    /// <summary>
    ///     Creates a new instance of <see cref="Error" />
    /// </summary>
    protected Error()
    {
        Message = string.Empty;
        Metadata = ImmutableDictionary.Create<string, object>();
        Reasons = ImmutableList.Create<IError>();
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Error" />
    /// </summary>
    /// <param name="message">Message of the error</param>
    public Error(string message)
        : this()
    {
        ArgumentException.ThrowIfNullOrEmpty(message);
        Message = message;
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Error" />
    /// </summary>
    /// <param name="message">Message of the error</param>
    /// <param name="causedBy">The root cause of the <see cref="Error" /></param>
    public Error(string message, IError causedBy)
        : this(message)
    {
        ArgumentNullException.ThrowIfNull(causedBy);
        Reasons = Reasons.Add(causedBy);
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Error" />
    /// </summary>
    /// <param name="message">Message of the error</param>
    /// <param name="metadata">Metadata of the error</param>
    /// <param name="reasons">Reasons of the error</param>
    public Error(string message, IImmutableDictionary<string, object> metadata, IImmutableList<IError> reasons)
    {
        ArgumentException.ThrowIfNullOrEmpty(message);
        ArgumentNullException.ThrowIfNull(metadata);
        ArgumentNullException.ThrowIfNull(reasons);
        Message = message;
        Metadata = metadata;
        Reasons = reasons;
    }

    /// <summary>
    ///     Message of the error
    /// </summary>
    [Id(0)]
    public string Message { get; }

    /// <summary>
    ///     Metadata of the error
    /// </summary>
    [Id(1)]
    public IImmutableDictionary<string, object> Metadata { get; }

    /// <summary>
    ///     Get the reasons of an error
    /// </summary>
    [Id(2)]
    public IImmutableList<IError> Reasons { get; }

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
