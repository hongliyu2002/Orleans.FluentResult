using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public interface IReason
{
    /// <summary>
    ///     Message of the reason
    /// </summary>
    string Message { get; }

    /// <summary>
    ///     Metadata of the reason
    /// </summary>
    IImmutableDictionary<string, object> Metadata { get; }
}
