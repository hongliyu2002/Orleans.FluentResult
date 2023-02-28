using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
[Alias("ResultOfT")]
[Immutable]
[GenerateSerializer]
public partial record Result<T>(T Value, IImmutableList<IReason> Reasons) : IResult<T>
{
    /// <summary>
    ///     Creates a new instance of <see cref="Result{T}" />
    /// </summary>
    public Result()
        : this(default!, ImmutableList<IReason>.Empty)
    {
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Result{T}" />
    /// </summary>
    /// <param name="value">Value of the result</param>
    public Result(T value)
        : this(value, ImmutableList<IReason>.Empty)
    {
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Result{T}" />
    /// </summary>
    /// <param name="reasons">Reasons of the result</param>
    public Result(IImmutableList<IReason> reasons)
        : this(default!, reasons)
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

    /// <inheritdoc />
    public T? ValueOrDefault => IsSuccess ? Value : default;

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var reasonsString = Reasons.Any() ? $", Reasons='{string.Join("; ", Reasons)}'" : string.Empty;
        return $"Result: IsSuccess='{IsSuccess}'{reasonsString}, {Value.ToLabelValueStringOrEmpty(nameof(Value))}";
    }
}
