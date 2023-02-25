﻿namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class EnumerableExtensions
{
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
    public static Result<IEnumerable<TValue>> Merge<TValue>(this IEnumerable<Result<TValue>> results)
    {
        ArgumentNullException.ThrowIfNull(results);
        return ResultHelper.Merge(results);
    }
}