using System.Collections.Immutable;

namespace Orleans.FluentResults;

public partial record Result
{

    #region Merge

    /// <summary>
    ///     Merge multiple result objects to one result object together. Return one result with a list of merged values.
    /// </summary>
    public static Result Merge(IEnumerable<Result> results)
    {
        return Merge(results.ToArray());
    }

    /// <summary>
    ///     Merge multiple result objects to one result object together
    /// </summary>
    public static Result Merge(params Result[] results)
    {
        ArgumentNullException.ThrowIfNull(results);
        return new Result(results.SelectMany(result => result.Reasons).ToImmutableList());
    }

    #endregion

    #region Merge Generic

    /// <summary>
    ///     Merge multiple result objects to one result object together. Return one result with a list of merged values.
    /// </summary>
    public static Result<IEnumerable<TValue>> Merge<TValue>(IEnumerable<Result<TValue>> results)
    {
        return Result<TValue>.Merge(results);
    }

    /// <summary>
    ///     Merge multiple result objects to one result object together. Return one result with a list of merged values.
    /// </summary>
    public static Result<IEnumerable<TValue>> Merge<TValue>(params Result<TValue>[] results)
    {
        return Result<TValue>.Merge(results);
    }

    #endregion

}
