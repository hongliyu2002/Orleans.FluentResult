using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <inheritdoc />
/// <summary>
/// </summary>
[Alias("Result")]
[Immutable]
[GenerateSerializer]
public partial record Result(IImmutableList<IReason> Reasons) : IResult
{
    /// <inheritdoc />
    /// <summary>
    ///     Creates a new instance of <see cref="T:Orleans.FluentResults.Result" />
    /// </summary>
    public Result()
        : this(ImmutableList<IReason>.Empty)
    {
    }

    /// <inheritdoc />
    public bool IsFailed => Reasons.OfType<IError>().Any();

    /// <inheritdoc />
    public bool IsSuccess => !IsFailed;

    /// <inheritdoc />
    public IImmutableList<IError> Errors => Reasons.OfType<IError>().ToImmutableList();

    /// <inheritdoc />
    public IImmutableList<ISuccess> Successes => Reasons.OfType<ISuccess>().ToImmutableList();

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var reasonsString = Reasons.Any() ? $", Reasons='{string.Join("; ", Reasons)}'" : string.Empty;
        return $"Result: IsSuccess='{IsSuccess}'{reasonsString}";
    }
}
