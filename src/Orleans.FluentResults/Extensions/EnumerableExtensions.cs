namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class EnumerableExtensions
{

    #region Combine

    /// <summary>
    ///     Merge multiple result objects to one result together
    /// </summary>
    public static Result Combine(this IEnumerable<Result> results)
    {
        return Result.Combine(results);
    }

    /// <summary>
    ///     Merge multiple result objects to one result together
    /// </summary>
    public static Result<IEnumerable<T>> Combine<T>(this IEnumerable<Result<T>> results)
    {
        return Result.Combine(results);
    }

    #endregion

}
