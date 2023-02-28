namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region ToResult

    /// <summary>
    ///     Convert result to result
    /// </summary>
    public static Result ToResult<T>(this Result<T> result)
    {
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Convert result with value to result with a new value
    /// </summary>
    public static Result<T> ToResult<T>(this Result<T> result, T value)
    {
        return result with { Value = value };
    }

    /// <summary>
    ///     Convert result with value to result.
    /// </summary>
    public static Result<T2> ToResult<T, T2>(this Result<T> result)
    {
        try
        {
            var value = Convert.ChangeType(result.Value, typeof(T2));
            return value != null ? new Result<T2>((T2)value, result.Reasons) : new Result<T2>(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<T2>.Fail(ex.InnerException ?? ex).WithReasons(result.Reasons);
        }
    }

    /// <summary>
    ///     Convert result with value to result with another value.
    /// </summary>
    public static Result<T2> ToResult<T, T2>(this Result<T> result, T2 value)
    {
        return new Result<T2>(value, result.Reasons);
    }

    #endregion

    #region ToResult Async

    /// <summary>
    ///     Convert result to result
    /// </summary>
    public static async Task<Result> ToResultAsync<T>(this Task<Result<T>> resultTask)
    {
        var result = await resultTask.ConfigureAwait(false);
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Convert result with value to result with a new value
    /// </summary>
    public static async Task<Result<T>> ToResultAsync<T>(this Task<Result<T>> resultTask, T value)
    {
        var result = await resultTask.ConfigureAwait(false);
        return result with { Value = value };
    }

    /// <summary>
    ///     Convert result with value to result.
    /// </summary>
    public static async Task<Result<T2>> ToResultAsync<T, T2>(this Task<Result<T>> resultTask)
    {
        var result = await resultTask.ConfigureAwait(false);
        try
        {
            var value = Convert.ChangeType(result.Value, typeof(T2));
            return value != null ? new Result<T2>((T2)value, result.Reasons) : new Result<T2>(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<T2>.Fail(ex.InnerException ?? ex).WithReasons(result.Reasons);
        }
    }

    /// <summary>
    ///     Convert result with value to result with another value.
    /// </summary>
    public static async Task<Result<T2>> ToResultAsync<T, T2>(this Task<Result<T>> resultTask, T2 value)
    {
        var result = await resultTask.ConfigureAwait(false);
        return new Result<T2>(value, result.Reasons);
    }

    #endregion

    #region ToResult ValueTask Async

    /// <summary>
    ///     Convert result to result
    /// </summary>
    public static async ValueTask<Result> ToResultAsync<T>(this ValueTask<Result<T>> resultTask)
    {
        var result = await resultTask.ConfigureAwait(false);
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Convert result with value to result with a new value
    /// </summary>
    public static async ValueTask<Result<T>> ToResultAsync<T>(this ValueTask<Result<T>> resultTask, T value)
    {
        var result = await resultTask.ConfigureAwait(false);
        return result with { Value = value };
    }

    /// <summary>
    ///     Convert result with value to result.
    /// </summary>
    public static async ValueTask<Result<T2>> ToResultAsync<T, T2>(this ValueTask<Result<T>> resultTask)
    {
        var result = await resultTask.ConfigureAwait(false);
        try
        {
            var value = Convert.ChangeType(result.Value, typeof(T2));
            return value != null ? new Result<T2>((T2)value, result.Reasons) : new Result<T2>(result.Reasons);
        }
        catch (Exception ex)
        {
            return Result<T2>.Fail(ex.InnerException ?? ex).WithReasons(result.Reasons);
        }
    }

    /// <summary>
    ///     Convert result with value to result with another value.
    /// </summary>
    public static async ValueTask<Result<T2>> ToResultAsync<T, T2>(this ValueTask<Result<T>> resultTask, T2 value)
    {
        var result = await resultTask.ConfigureAwait(false);
        return new Result<T2>(value, result.Reasons);
    }

    #endregion

}
