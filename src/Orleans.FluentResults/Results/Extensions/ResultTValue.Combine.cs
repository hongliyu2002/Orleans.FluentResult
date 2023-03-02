namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region Combine

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result<IEnumerable<T>> Combine<T>(this Result<T> result, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result<IEnumerable<T>> Combine<T>(this IEnumerable<Result<T>> results, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine<T>(this Result<T> result, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine<T>(this IEnumerable<Result<T>> results, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Full Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this Task<Result<T>> resultTask, IEnumerable<Task<Result<T>>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var result = await resultTask.ConfigureAwait(false);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(false);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<Task<Result<T>>> resultTasks, IEnumerable<Task<Result<T>>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var results = await Task.WhenAll(resultTasks).ConfigureAwait(false);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(false);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Task<Result<T>> resultTask, IEnumerable<Task<Result>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var result = await resultTask.ConfigureAwait(false);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(false);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this IEnumerable<Task<Result<T>>> resultTasks, IEnumerable<Task<Result>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var results = await Task.WhenAll(resultTasks).ConfigureAwait(false);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(false);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Full ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this ValueTask<Result<T>> resultTask, IEnumerable<ValueTask<Result<T>>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var result = await resultTask.ConfigureAwait(false);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(false);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<ValueTask<Result<T>>> resultTasks, IEnumerable<ValueTask<Result<T>>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var results = await Task.WhenAll(resultTasks.Select(t => t.AsTask())).ConfigureAwait(false);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(false);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<Result<T>> resultTask, IEnumerable<ValueTask<Result>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var result = await resultTask.ConfigureAwait(false);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(false);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this IEnumerable<ValueTask<Result<T>>> resultTasks, IEnumerable<ValueTask<Result>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var results = await Task.WhenAll(resultTasks.Select(t => t.AsTask())).ConfigureAwait(false);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(false);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Right Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this Result<T> result, IEnumerable<Task<Result<T>>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(false);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<Result<T>> results, IEnumerable<Task<Result<T>>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(false);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Result<T> result, IEnumerable<Task<Result>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(false);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this IEnumerable<Result<T>> results, IEnumerable<Task<Result>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks).ConfigureAwait(false);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Right ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this Result<T> result, IEnumerable<ValueTask<Result<T>>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(false);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<Result<T>> results, IEnumerable<ValueTask<Result<T>>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(false);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this Result<T> result, IEnumerable<ValueTask<Result>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(false);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this IEnumerable<Result<T>> results, IEnumerable<ValueTask<Result>> otherResultTasks)
    {
        ArgumentNullException.ThrowIfNull(otherResultTasks);
        var otherResults = await Task.WhenAll(otherResultTasks.Select(t => t.AsTask())).ConfigureAwait(false);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Left Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this Task<Result<T>> resultTask, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(false);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<Task<Result<T>>> resultTasks, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await Task.WhenAll(resultTasks).ConfigureAwait(false);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Task<Result<T>> resultTask, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(false);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this IEnumerable<Task<Result<T>>> resultTasks, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await Task.WhenAll(resultTasks).ConfigureAwait(false);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Left ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this ValueTask<Result<T>> resultTask, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(false);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<ValueTask<Result<T>>> resultTasks, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await Task.WhenAll(resultTasks.Select(t => t.AsTask())).ConfigureAwait(false);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<Result<T>> resultTask, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(false);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this IEnumerable<ValueTask<Result<T>>> resultTasks, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await Task.WhenAll(resultTasks.Select(t => t.AsTask())).ConfigureAwait(false);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

}
