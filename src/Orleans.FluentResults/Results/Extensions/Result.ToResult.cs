namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region To Result

    /// <summary>
    ///     Convert result to result
    /// </summary>
    public static Result ToResult(this Result result)
    {
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Convert result to result
    /// </summary>
    public static Result<T> ToResult<T>(this Result result)
    {
        return new Result<T>(result.Reasons);
    }

    /// <summary>
    ///     Convert result to result with a new value
    /// </summary>
    public static Result<T> ToResult<T>(this Result result, T value)
    {
        return new Result<T>(value, result.Reasons);
    }

    #endregion

    #region To Result Async

    /// <summary>
    ///     Convert result to result with a value
    /// </summary>
    public static async Task<Result> ToResultAsync(this Task<Result> resultTask, bool configureAwait = true)
    {
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Convert result to result with a value
    /// </summary>
    public static async Task<Result<T>> ToResultAsync<T>(this Task<Result> resultTask, bool configureAwait = true)
    {
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return new Result<T>(result.Reasons);
    }

    /// <summary>
    ///     Convert result to result with a new value
    /// </summary>
    public static async Task<Result<T>> ToResultAsync<T>(this Task<Result> resultTask, T value, bool configureAwait = true)
    {
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return new Result<T>(value, result.Reasons);
    }

    #endregion

    #region To Result ValueTask Async

    /// <summary>
    ///     Convert result to result with a value
    /// </summary>
    public static async ValueTask<Result> ToResultAsync(this ValueTask<Result> resultTask, bool configureAwait = true)
    {
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Convert result to result with a value
    /// </summary>
    public static async ValueTask<Result<T>> ToResultAsync<T>(this ValueTask<Result> resultTask, bool configureAwait = true)
    {
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return new Result<T>(result.Reasons);
    }

    /// <summary>
    ///     Convert result to result with a new value
    /// </summary>
    public static async ValueTask<Result<T>> ToResultAsync<T>(this ValueTask<Result> resultTask, T value, bool configureAwait = true)
    {
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return new Result<T>(value, result.Reasons);
    }

    #endregion

}
