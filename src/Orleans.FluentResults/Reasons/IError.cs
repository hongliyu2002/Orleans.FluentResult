using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public interface IError : IReason
{
    /// <summary>
    ///     Reasons of the error
    /// </summary>
    IImmutableList<IError> Reasons { get; }
}
