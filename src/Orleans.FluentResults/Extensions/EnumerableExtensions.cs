using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class EnumerableExtensions
{

    #region Merge

    /// <summary>
    ///     Merge multiple result objects to one result together
    /// </summary>
    public static Result Merge(this IEnumerable<Result> results)
    {
        return new Result(ImmutableList<IReason>.Empty.AddRange(results.SelectMany(result => result.Reasons)));
    }

    /// <summary>
    ///     Merge multiple result objects to one result together
    /// </summary>
    public static Result<IEnumerable<T>> Merge<T>(this IEnumerable<Result<T>> results)
    {
        var resultsList = results as Result<T>[] ?? results.ToArray();
        return new Result<IEnumerable<T>>(resultsList.Select(result => result.Value), ImmutableList<IReason>.Empty.AddRange(resultsList.SelectMany(result => result.Reasons)));
    }

    #endregion

}
