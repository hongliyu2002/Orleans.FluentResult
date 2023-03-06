namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Check

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    public static Result Check(this Result result, Func<Result> check)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    public static Result Check<TOutput>(this Result result, Func<Result<TOutput>> check)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    #endregion

    #region Check Full Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> CheckAsync(this Task<Result> resultTask, Func<Task<Result>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> CheckAsync<TOutput>(this Task<Result> resultTask, Func<Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    #endregion

    #region Check Full ValueTask Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> CheckAsync(this ValueTask<Result> resultTask, Func<ValueTask<Result>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> CheckAsync<TOutput>(this ValueTask<Result> resultTask, Func<ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    #endregion

    #region Check Right Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> CheckAsync(this Result result, Func<Task<Result>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> CheckAsync<TOutput>(this Result result, Func<Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    #endregion

    #region Check Right ValueTask Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> CheckAsync(this Result result, Func<ValueTask<Result>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> CheckAsync<TOutput>(this Result result, Func<ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    #endregion

    #region Check Left Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> CheckAsync(this Task<Result> resultTask, Func<Result> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> CheckAsync<TOutput>(this Task<Result> resultTask, Func<Result<TOutput>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    #endregion

    #region Check Left ValueTask Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> CheckAsync(this ValueTask<Result> resultTask, Func<Result> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> CheckAsync<TOutput>(this ValueTask<Result> resultTask, Func<Result<TOutput>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result.Fail(checkResult.Errors) : result;
    }

    #endregion

}
