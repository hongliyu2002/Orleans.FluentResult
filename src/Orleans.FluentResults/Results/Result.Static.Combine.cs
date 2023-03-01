using System.Collections.Immutable;

namespace Orleans.FluentResults;

public partial record Result
{

    #region Combine

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine(IEnumerable<Result> results)
    {
        var resultsArray = results as Result[] ?? results.ToArray();
        return Combine(resultsArray);
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together
    /// </summary>
    public static Result Combine(params Result[] results)
    {
        ArgumentNullException.ThrowIfNull(results);
        var combinedResult = new Result(ImmutableList<IReason>.Empty.AddRange(results.SelectMany(result => result.Reasons)));
        return combinedResult.IsSuccess ? combinedResult : Fail(combinedResult.Errors);
    }

    #endregion

    #region Combine Generic

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result<IEnumerable<T>> Combine<T>(IEnumerable<Result<T>> results)
    {
        return Result<T>.Combine(results);
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result<IEnumerable<T>> Combine<T>(params Result<T>[] results)
    {
        return Result<T>.Combine(results);
    }

    #endregion

}
