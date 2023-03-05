namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region Combine

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result<IEnumerable<T>> Combine<T>(this Result<T> result, params Result<T>[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result<IEnumerable<T>> Combine<T>(this IEnumerable<Result<T>> results, params Result<T>[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine<T>(this Result<T> result, params Result[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine<T>(this IEnumerable<Result<T>> results, params Result[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Full Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this Task<Result<T>> resultTask, params Task<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var result = await resultTask.ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<Task<Result<T>>> resultTasks, params Task<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var results = await Task.WhenAll(resultTasks).ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Task<Result<T>> resultTask, params Task<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var result = await resultTask.ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this IEnumerable<Task<Result<T>>> resultTasks, params Task<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var results = await Task.WhenAll(resultTasks).ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Full ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this ValueTask<Result<T>> resultTask, params ValueTask<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var result = await resultTask.ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<ValueTask<Result<T>>> resultTasks, params ValueTask<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var results = await Task.WhenAll(resultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<Result<T>> resultTask, params ValueTask<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var result = await resultTask.ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this IEnumerable<ValueTask<Result<T>>> resultTasks, params ValueTask<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var results = await Task.WhenAll(resultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Right Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this Result<T> result, params Task<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<Result<T>> results, params Task<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Result<T> result, params Task<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this IEnumerable<Result<T>> results, params Task<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(true);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Right ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this Result<T> result, params ValueTask<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<Result<T>> results, params ValueTask<Result<T>>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this Result<T> result, params ValueTask<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this IEnumerable<Result<T>> results, params ValueTask<Result>[] otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Left Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this Task<Result<T>> resultTask, params Result<T>[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(true);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<Task<Result<T>>> resultTasks, params Result<T>[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await Task.WhenAll(resultTasks).ConfigureAwait(true);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Task<Result<T>> resultTask, params Result[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(true);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this IEnumerable<Task<Result<T>>> resultTasks, params Result[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await Task.WhenAll(resultTasks).ConfigureAwait(true);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Left ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this ValueTask<Result<T>> resultTask, params Result<T>[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(true);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<ValueTask<Result<T>>> resultTasks, params Result<T>[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await Task.WhenAll(resultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<Result<T>> resultTask, params Result[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(true);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this IEnumerable<ValueTask<Result<T>>> resultTasks, params Result[] otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await Task.WhenAll(resultTasks.Select(t => t.AsTask())).ConfigureAwait(true);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

}
