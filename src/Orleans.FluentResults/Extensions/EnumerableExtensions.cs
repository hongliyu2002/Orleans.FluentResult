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
        ArgumentNullException.ThrowIfNull(results);
        return ResultHelper.Merge(results);
    }

    /// <summary>
    ///     Merge multiple result objects to one result together
    /// </summary>
    public static Result<IEnumerable<T>> Merge<T>(this IEnumerable<Result<T>> results)
    {
        ArgumentNullException.ThrowIfNull(results);
        return ResultHelper.Merge(results);
    }

    #endregion

}
