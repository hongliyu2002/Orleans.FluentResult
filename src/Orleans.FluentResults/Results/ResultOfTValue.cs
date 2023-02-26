using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
[Immutable]
[GenerateSerializer]
public partial record Result<TValue>(TValue Value, IImmutableList<IReason> Reasons) : Result(Reasons), IResult<TValue>
{
    /// <summary>
    ///     Creates a new instance of <see cref="Result{TValue}" />
    /// </summary>
    public Result()
        : this(default!, ImmutableList<IReason>.Empty)
    {
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Result{TValue}" />
    /// </summary>
    /// <param name="value">Value of the result</param>
    public Result(TValue value)
        : this(value, ImmutableList<IReason>.Empty)
    {
    }

    /// <summary>
    ///     Creates a new instance of <see cref="Result{TValue}" />
    /// </summary>
    /// <param name="reasons">Reasons of the result</param>
    public Result(IImmutableList<IReason> reasons)
        : this(default!, reasons)
    {
    }

    /// <inheritdoc />
    public TValue? ValueOrDefault => IsSuccess ? Value : default;

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{base.ToString()}, {Value.ToLabelValueStringOrEmpty(nameof(Value))}";
    }
}
