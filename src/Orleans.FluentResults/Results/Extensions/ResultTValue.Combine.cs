namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
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
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this Task<Result<T>> resultTask, Task<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var result = await resultTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this Task<IEnumerable<Result<T>>> resultsTask, Task<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var results = await resultsTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Task<Result<T>> resultTask, Task<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var result = await resultTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Task<IEnumerable<Result<T>>> resultsTask, Task<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var results = await resultsTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Full ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this ValueTask<Result<T>> resultTask, ValueTask<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var result = await resultTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this ValueTask<IEnumerable<Result<T>>> resultsTask, ValueTask<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var results = await resultsTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<Result<T>> resultTask, ValueTask<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var result = await resultTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<IEnumerable<Result<T>>> resultsTask, ValueTask<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var results = await resultsTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Right Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this Result<T> result, Task<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<Result<T>> results, Task<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Result<T> result, Task<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this IEnumerable<Result<T>> results, Task<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

    #region Combine Right ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this Result<T> result, ValueTask<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result<T>.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<Result<T>> results, ValueTask<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result<T>.Combine(results.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this Result<T> result, ValueTask<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(new[] { result.ToResult() }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this IEnumerable<Result<T>> results, ValueTask<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
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
    public static async Task<Result<IEnumerable<T>>> CombineAsync<T>(this Task<IEnumerable<Result<T>>> resultsTask, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await resultsTask.ConfigureAwait(false);
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
    public static async Task<Result> CombineAsync<T>(this Task<IEnumerable<Result<T>>> resultsTask, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await resultsTask.ConfigureAwait(false);
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
    public static async ValueTask<Result<IEnumerable<T>>> CombineAsync<T>(this ValueTask<IEnumerable<Result<T>>> resultsTask, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await resultsTask.ConfigureAwait(false);
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
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<IEnumerable<Result<T>>> resultsTask, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await resultsTask.ConfigureAwait(false);
        return Result.Combine(results.Select(result => result.ToResult()).Union(otherResults));
    }

    #endregion

}
