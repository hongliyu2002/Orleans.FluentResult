using System.Collections.Immutable;

namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region Merge

    /// <summary>
    ///     Merge multiple result objects to one result object together. Return one result with a list of merged values.
    /// </summary>
    public static Result<IEnumerable<T>> Merge(IEnumerable<Result<T>> results)
    {
        return Merge(results.ToArray());
    }

    /// <summary>
    ///     Merge multiple result objects to one result object together. Return one result with a list of merged values.
    /// </summary>
    public static Result<IEnumerable<T>> Merge(params Result<T>[] results)
    {
        ArgumentNullException.ThrowIfNull(results);
        return new Result<IEnumerable<T>>(results.Select(result => result.Value), results.SelectMany(result => result.Reasons).ToImmutableList());
    }

    #endregion

}
