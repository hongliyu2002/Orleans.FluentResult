namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Combine

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine<T>(this Result result, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine<T>(this IEnumerable<Result> results, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine(this Result result, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static Result Combine(this IEnumerable<Result> results, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

    #region Combine Full Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Task<Result> resultTask, Task<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var result = await resultTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Task<IEnumerable<Result>> resultsTask, Task<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var results = await resultsTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync(this Task<Result> resultTask, Task<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var result = await resultTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync(this Task<IEnumerable<Result>> resultsTask, Task<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var results = await resultsTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

    #region Combine Full ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<Result> resultTask, ValueTask<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var result = await resultTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<IEnumerable<Result>> resultsTask, ValueTask<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var results = await resultsTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync(this ValueTask<Result> resultTask, ValueTask<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var result = await resultTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync(this ValueTask<IEnumerable<Result>> resultsTask, ValueTask<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var results = await resultsTask.ConfigureAwait(false);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

    #region Combine Right Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Result result, Task<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this IEnumerable<Result> results, Task<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync(this Result result, Task<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync(this IEnumerable<Result> results, Task<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

    #region Combine Right ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this Result result, ValueTask<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this IEnumerable<Result> results, ValueTask<IEnumerable<Result<T>>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync(this Result result, ValueTask<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync(this IEnumerable<Result> results, ValueTask<IEnumerable<Result>> otherResultsTask)
    {
        ArgumentNullException.ThrowIfNull(otherResultsTask);
        var otherResults = await otherResultsTask.ConfigureAwait(false);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

    #region Combine Left Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Task<Result> resultTask, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(false);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync<T>(this Task<IEnumerable<Result>> resultsTask, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await resultsTask.ConfigureAwait(false);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync(this Task<Result> resultTask, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(false);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async Task<Result> CombineAsync(this Task<IEnumerable<Result>> resultsTask, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await resultsTask.ConfigureAwait(false);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

    #region Combine Left ValueTask Async

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<Result> resultTask, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(false);
        return Result.Combine(new[] { result }.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync<T>(this ValueTask<IEnumerable<Result>> resultsTask, IEnumerable<Result<T>> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await resultsTask.ConfigureAwait(false);
        return Result.Combine(results.Union(otherResults.Select(otherResult => otherResult.ToResult())));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync(this ValueTask<Result> resultTask, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var result = await resultTask.ConfigureAwait(false);
        return Result.Combine(new[] { result }.Union(otherResults));
    }

    /// <summary>
    ///     Combine multiple result objects to one result object together. Return one result with a list of combined values.
    /// </summary>
    public static async ValueTask<Result> CombineAsync(this ValueTask<IEnumerable<Result>> resultsTask, IEnumerable<Result> otherResults)
    {
        ArgumentNullException.ThrowIfNull(otherResults);
        var results = await resultsTask.ConfigureAwait(false);
        return Result.Combine(results.Union(otherResults));
    }

    #endregion

}
