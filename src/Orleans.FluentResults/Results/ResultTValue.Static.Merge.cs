using System.Collections.Immutable;

namespace Orleans.FluentResults;

public partial record Result<TValue>
{

    #region Merge

    /// <summary>
    ///     Merge multiple result objects to one result object together. Return one result with a list of merged values.
    /// </summary>
    public static Result<IEnumerable<TValue>> Merge(IEnumerable<Result<TValue>> results)
    {
        return Merge(results.ToArray());
    }

    /// <summary>
    ///     Merge multiple result objects to one result object together. Return one result with a list of merged values.
    /// </summary>
    public static Result<IEnumerable<TValue>> Merge(params Result<TValue>[] results)
    {
        ArgumentNullException.ThrowIfNull(results);
        return new Result<IEnumerable<TValue>>(results.Select(result => result.Value), results.SelectMany(result => result.Reasons).ToImmutableList());
    }

    #endregion

}
