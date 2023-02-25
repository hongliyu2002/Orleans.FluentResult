using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
[Immutable]
[GenerateSerializer]
public abstract partial class ResultBase : IResultBase
{
    /// <summary>
    ///     Creates a new instance of <see cref="ResultBase" />
    /// </summary>
    protected ResultBase()
    {
        Reasons = ImmutableList.Create<IReason>();
    }

    /// <summary>
    ///     Creates a new instance of <see cref="ResultBase" />
    /// </summary>
    /// <param name="reasons"></param>
    protected ResultBase(IImmutableList<IReason> reasons)
    {
        ArgumentNullException.ThrowIfNull(reasons);
        Reasons = reasons;
    }

    /// <inheritdoc />
    public bool IsFailed => Reasons.OfType<IError>().Any();
    /// <inheritdoc />
    public bool IsSuccess => !IsFailed;

    /// <inheritdoc />
    [Id(0)]
    public IImmutableList<IReason> Reasons { get; }
    /// <inheritdoc />
    public IImmutableList<IError> Errors => Reasons.OfType<IError>().ToImmutableList();
    /// <inheritdoc />
    public IImmutableList<ISuccess> Successes => Reasons.OfType<ISuccess>().ToImmutableList();
}
