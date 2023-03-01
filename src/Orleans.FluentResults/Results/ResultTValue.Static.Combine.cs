using System.Collections.Immutable;

namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region Combine

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result<IEnumerable<T>> Combine(IEnumerable<Result<T>> results)
    {
        return Combine(results.ToArray());
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result<IEnumerable<T>> Combine(params Result<T>[] results)
    {
        ArgumentNullException.ThrowIfNull(results);
        return new Result<IEnumerable<T>>(results.Select(result => result.Value), ImmutableList<IReason>.Empty.AddRange(results.SelectMany(result => result.Reasons)));
    }

    #endregion

}
