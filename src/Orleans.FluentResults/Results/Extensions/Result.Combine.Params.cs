﻿namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Combine

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine<T>(this Result result, params Result<T>[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine<T>(this IEnumerable<Result> results, params Result<T>[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine(this Result result, params Result[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine(this IEnumerable<Result> results, params Result[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

    #region Combine Full Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Task<Result> resultTask, params Task<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var result = await resultTask.ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this IEnumerable<Task<Result>> resultTasks, params Task<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var results = await Task.WhenAll(resultTasks).ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync(this Task<Result> resultTask, params Task<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var result = await resultTask.ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync(this IEnumerable<Task<Result>> resultTasks, params Task<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var results = await Task.WhenAll(resultTasks).ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

    #region Combine Full ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<Result> resultTask, params ValueTask<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var result = await resultTask.ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this IEnumerable<ValueTask<Result>> resultTasks, params ValueTask<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var results = await Task.WhenAll(resultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync(this ValueTask<Result> resultTask, params ValueTask<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var result = await resultTask.ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync(this IEnumerable<ValueTask<Result>> resultTasks, params ValueTask<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var results = await Task.WhenAll(resultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

    #region Combine Right Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Result result, params Task<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this IEnumerable<Result> results, params Task<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync(this Result result, params Task<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync(this IEnumerable<Result> results, params Task<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

    #region Combine Right ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this Result result, params ValueTask<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this IEnumerable<Result> results, params ValueTask<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync(this Result result, params ValueTask<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync(this IEnumerable<Result> results, params ValueTask<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

    #region Combine Left Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Task<Result> resultTask, params Result<T>[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(true);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this IEnumerable<Task<Result>> resultTasks, params Result<T>[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await Task.WhenAll(resultTasks).ConfigureAwait(true);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync(this Task<Result> resultTask, params Result[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(true);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync(this IEnumerable<Task<Result>> resultTasks, params Result[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await Task.WhenAll(resultTasks).ConfigureAwait(true);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

    #region Combine Left ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<Result> resultTask, params Result<T>[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(true);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this IEnumerable<ValueTask<Result>> resultTasks, params Result<T>[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await Task.WhenAll(resultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync(this ValueTask<Result> resultTask, params Result[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(true);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync(this IEnumerable<ValueTask<Result>> resultTasks, params Result[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await Task.WhenAll(resultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

}
