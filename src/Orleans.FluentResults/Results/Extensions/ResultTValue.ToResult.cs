namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
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
        return result with
               {
                   Value = value
               };
    }

    /// <summary>
    ///     Convert result with value to result.
    /// </summary>
    public static Result<TOutput> ToResult<T, TOutput>(this Result<T> result)
    {
        try
        {
            if (result.Value is null)
            {
                return new Result<TOutput>(result.Reasons);
            }
            if (result.Value is TOutput output)
            {
                return new Result<TOutput>(output, result.Reasons);
            }
            var value = Convert.ChangeType(result.Value, typeof(TOutput));
            return new Result<TOutput>((TOutput)value, result.Reasons);
        }
        catch (Exception)
        {
            return new Result<TOutput>(result.Reasons);
        }
    }

    /// <summary>
    ///     Convert result with value to result with another value.
    /// </summary>
    public static Result<TOutput> ToResult<T, TOutput>(this Result<T> result, TOutput value)
    {
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region ToResult Async

    /// <summary>
    ///     Convert result to result
    /// </summary>
    public static async Task<Result> ToResultAsync<T>(this Task<Result<T>> resultTask, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Convert result with value to result with a new value
    /// </summary>
    public static async Task<Result<T>> ToResultAsync<T>(this Task<Result<T>> resultTask, T value, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        return result with
               {
                   Value = value
               };
    }

    /// <summary>
    ///     Convert result with value to result.
    /// </summary>
    public static async Task<Result<TOutput>> ToResultAsync<T, TOutput>(this Task<Result<T>> resultTask, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        try
        {
            if (result.Value is null)
            {
                return new Result<TOutput>(result.Reasons);
            }
            if (result.Value is TOutput output)
            {
                return new Result<TOutput>(output, result.Reasons);
            }
            var value = Convert.ChangeType(result.Value, typeof(TOutput));
            return new Result<TOutput>((TOutput)value, result.Reasons);
        }
        catch (Exception)
        {
            return new Result<TOutput>(result.Reasons);
        }
    }

    /// <summary>
    ///     Convert result with value to result with another value.
    /// </summary>
    public static async Task<Result<TOutput>> ToResultAsync<T, TOutput>(this Task<Result<T>> resultTask, TOutput value, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

    #region ToResult ValueTask Async

    /// <summary>
    ///     Convert result to result
    /// </summary>
    public static async ValueTask<Result> ToResultAsync<T>(this ValueTask<Result<T>> resultTask, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        return new Result(result.Reasons);
    }

    /// <summary>
    ///     Convert result with value to result with a new value
    /// </summary>
    public static async ValueTask<Result<T>> ToResultAsync<T>(this ValueTask<Result<T>> resultTask, T value, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        return result with
               {
                   Value = value
               };
    }

    /// <summary>
    ///     Convert result with value to result.
    /// </summary>
    public static async ValueTask<Result<TOutput>> ToResultAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        try
        {
            if (result.Value is null)
            {
                return new Result<TOutput>(result.Reasons);
            }
            if (result.Value is TOutput output)
            {
                return new Result<TOutput>(output, result.Reasons);
            }
            var value = Convert.ChangeType(result.Value, typeof(TOutput));
            return new Result<TOutput>((TOutput)value, result.Reasons);
        }
        catch (Exception)
        {
            return new Result<TOutput>(result.Reasons);
        }
    }

    /// <summary>
    ///     Convert result with value to result with another value.
    /// </summary>
    public static async ValueTask<Result<TOutput>> ToResultAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, TOutput value, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        return new Result<TOutput>(value, result.Reasons);
    }

    #endregion

}
