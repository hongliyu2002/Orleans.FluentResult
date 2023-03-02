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
    /// <param name="check">Action that may fail.</param>
    public static Result<T> Check<T>(this Result<T> result, Func<Result> check)
    {
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> Check<T>(this Result<T> result, Func<T, Result> check)
    {
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> Check<T>(this Result<T> result, Func<Result<T>> check)
    {
        var checkResult = result.BindTry<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> Check<T>(this Result<T> result, Func<T, Result<T>> check)
    {
        var checkResult = result.BindTry<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> Check<T, T1>(this Result<T> result, Func<Result<T1>> check)
    {
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> Check<T, T1>(this Result<T> result, Func<T, Result<T1>> check)
    {
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
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result<T>>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = await result.BindTryAsync<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result<T>>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = await result.BindTryAsync<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T, T1>(this Task<Result<T>> resultTask, Func<Task<Result<T1>>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T, T1>(this Task<Result<T>> resultTask, Func<T, Task<Result<T1>>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    #endregion

    #region Check Full ValueTask Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = await result.BindTryAsync<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T>>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = await result.BindTryAsync<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T1>>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T1>>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    #endregion

    #region Check Right Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Result<T> result, Func<Task<Result>> check)
    {
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Result<T> result, Func<T, Task<Result>> check)
    {
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Result<T> result, Func<Task<Result<T>>> check)
    {
        var checkResult = await result.BindTryAsync<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Result<T> result, Func<T, Task<Result<T>>> check)
    {
        var checkResult = await result.BindTryAsync<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T, T1>(this Result<T> result, Func<Task<Result<T1>>> check)
    {
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T, T1>(this Result<T> result, Func<T, Task<Result<T1>>> check)
    {
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    #endregion

    #region Check Right ValueTask Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this Result<T> result, Func<ValueTask<Result>> check)
    {
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this Result<T> result, Func<T, ValueTask<Result>> check)
    {
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this Result<T> result, Func<ValueTask<Result<T>>> check)
    {
        var checkResult = await result.BindTryAsync<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this Result<T> result, Func<T, ValueTask<Result<T>>> check)
    {
        var checkResult = await result.BindTryAsync<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T, T1>(this Result<T> result, Func<ValueTask<Result<T1>>> check)
    {
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T, T1>(this Result<T> result, Func<T, ValueTask<Result<T1>>> check)
    {
        var checkResult = await result.BindTryAsync(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    #endregion

    #region Check Left Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<Result> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<T, Result> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = result.BindTry<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<T, Result<T>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = result.BindTry<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T1>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T, T1>(this Task<Result<T>> resultTask, Func<T, Result<T1>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
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
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = result.BindTry<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result<T>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = result.BindTry<T>(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T1>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<T, Result<T1>> check)
    {
        var result = await resultTask.ConfigureAwait(false);
        var checkResult = result.BindTry(check);
        return checkResult.IsFailed ? Result<T>.Fail(checkResult.Errors) : result;
    }

    #endregion

}
