namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region Check

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    public static Result<T> Check<T>(this Result<T> result, Func<Result> check)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    public static Result<T> Check<T>(this Result<T> result, Func<T, Result> check)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    public static Result<T> Check<T>(this Result<T> result, Func<Result<T>> check)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    public static Result<T> Check<T>(this Result<T> result, Func<T, Result<T>> check)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    public static Result<T> Check<T, TOutput>(this Result<T> result, Func<Result<TOutput>> check)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    public static Result<T> Check<T, TOutput>(this Result<T> result, Func<T, Result<TOutput>> check)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
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
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result<T>>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync<T>(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result<T>>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync<T>(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
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
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync<T>(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T>>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync<T>(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
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
    public static async Task<Result<T>> CheckAsync<T>(this Result<T> result, Func<Task<Result>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T>(this Result<T> result, Func<T, Task<Result>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T>(this Result<T> result, Func<Task<Result<T>>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync<T>(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T>(this Result<T> result, Func<T, Task<Result<T>>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync<T>(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T, TOutput>(this Result<T> result, Func<Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T, TOutput>(this Result<T> result, Func<T, Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
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
    public static async ValueTask<Result<T>> CheckAsync<T>(this Result<T> result, Func<ValueTask<Result>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this Result<T> result, Func<T, ValueTask<Result>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this Result<T> result, Func<ValueTask<Result<T>>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync<T>(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this Result<T> result, Func<T, ValueTask<Result<T>>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync<T>(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T, TOutput>(this Result<T> result, Func<ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T, TOutput>(this Result<T> result, Func<T, ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = await result.BindTryAsync(check, null, configureAwait).ConfigureAwait(configureAwait);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
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
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<Result> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<T, Result> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<T, Result<T>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<TOutput>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, Result<TOutput>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
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
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result<T>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<TOutput>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, Result<TOutput>> check, bool configureAwait = true)
    {
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return result;
        }
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    #endregion

}
