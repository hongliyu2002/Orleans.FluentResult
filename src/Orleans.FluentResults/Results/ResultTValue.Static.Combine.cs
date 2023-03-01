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
        var resultsArray = results as Result<T>[] ?? results.ToArray();
        return Combine(resultsArray);
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result<IEnumerable<T>> Combine(params Result<T>[] results)
    {
        ArgumentNullException.ThrowIfNull(results);
        var combinedResult = new Result<IEnumerable<T>>(ImmutableList<IReason>.Empty.AddRange(results.SelectMany(result => result.Reasons)));
        return combinedResult.IsSuccess ? combinedResult with { Value = results.Select(result => result.Value) } : Result<IEnumerable<T>>.Fail(combinedResult.Errors);
    }

    #endregion

}
