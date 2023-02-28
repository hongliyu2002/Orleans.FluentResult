using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public interface IResult
{
    /// <summary>
    ///     Is true if Reasons contains at least one error
    /// </summary>
    bool IsFailed { get; }

    /// <summary>
    ///     Is true if Reasons contains no errors
    /// </summary>
    bool IsSuccess { get; }

    /// <summary>
    ///     Get all reasons (errors and successes)
    /// </summary>
    IImmutableList<IReason> Reasons { get; }

    /// <summary>
    ///     Get all errors
    /// </summary>
    IImmutableList<IError> Errors { get; }

    /// <summary>
    ///     Get all successes
    /// </summary>
    IImmutableList<ISuccess> Successes { get; }
}
