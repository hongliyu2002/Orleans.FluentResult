namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region Check

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> Check<T>(this Result<T> result, Func<Result> bind)
    {
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> Check<T>(this Result<T> result, Func<T, Result> bind)
    {
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> Check<T>(this Result<T> result, Func<Result<T>> bind)
    {
        var bindResult = result.BindTry<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> Check<T>(this Result<T> result, Func<T, Result<T>> bind)
    {
        var bindResult = result.BindTry<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> Check<T, T1>(this Result<T> result, Func<Result<T1>> bind)
    {
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> Check<T, T1>(this Result<T> result, Func<T, Result<T1>> bind)
    {
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    #endregion

    #region Check Full Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result<T>>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result<T>>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T, T1>(this Task<Result<T>> resultTask, Func<Task<Result<T1>>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T, T1>(this Task<Result<T>> resultTask, Func<T, Task<Result<T1>>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    #endregion

    #region Check Full ValueTask Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T>>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T1>>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T1>>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    #endregion

    #region Check Right Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Result<T> result, Func<Task<Result>> bind)
    {
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Result<T> result, Func<T, Task<Result>> bind)
    {
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Result<T> result, Func<Task<Result<T>>> bind)
    {
        var bindResult = await result.BindTryAsync<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Result<T> result, Func<T, Task<Result<T>>> bind)
    {
        var bindResult = await result.BindTryAsync<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T, T1>(this Result<T> result, Func<Task<Result<T1>>> bind)
    {
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T, T1>(this Result<T> result, Func<T, Task<Result<T1>>> bind)
    {
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    #endregion

    #region Check Right ValueTask Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this Result<T> result, Func<ValueTask<Result>> bind)
    {
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this Result<T> result, Func<T, ValueTask<Result>> bind)
    {
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this Result<T> result, Func<ValueTask<Result<T>>> bind)
    {
        var bindResult = await result.BindTryAsync<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this Result<T> result, Func<T, ValueTask<Result<T>>> bind)
    {
        var bindResult = await result.BindTryAsync<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T, T1>(this Result<T> result, Func<ValueTask<Result<T1>>> bind)
    {
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T, T1>(this Result<T> result, Func<T, ValueTask<Result<T1>>> bind)
    {
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    #endregion

    #region Check Left Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<Result> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<T, Result> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T>(this Task<Result<T>> resultTask, Func<T, Result<T>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T1>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> CheckAsync<T, T1>(this Task<Result<T>> resultTask, Func<T, Result<T1>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    #endregion

    #region Check Left ValueTask Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result<T>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry<T>(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T1>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<T, Result<T1>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result<T>.Fail(bindResult.Errors) : result;
    }

    #endregion

}
