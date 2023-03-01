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
    /// <param name="bind">Action that may fail.</param>
    public static Result Check(this Result result, Func<Result> bind)
    {
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result Check<T1>(this Result result, Func<Result<T1>> bind)
    {
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    #endregion

    #region Check Full Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> CheckAsync<T>(this Task<Result> resultTask, Func<Task<Result>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> CheckAsync<T1>(this Task<Result> resultTask, Func<Task<Result<T1>>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    #endregion

    #region Check Full ValueTask Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> CheckAsync<T>(this ValueTask<Result> resultTask, Func<ValueTask<Result>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> CheckAsync<T1>(this ValueTask<Result> resultTask, Func<ValueTask<Result<T1>>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    #endregion

    #region Check Right Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> CheckAsync<T>(this Result result, Func<Task<Result>> bind)
    {
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> CheckAsync<T1>(this Result result, Func<Task<Result<T1>>> bind)
    {
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    #endregion

    #region Check Right ValueTask Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> CheckAsync<T>(this Result result, Func<ValueTask<Result>> bind)
    {
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> CheckAsync<T1>(this Result result, Func<ValueTask<Result<T1>>> bind)
    {
        var bindResult = await result.BindTryAsync(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    #endregion

    #region Check Left Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> CheckAsync<T>(this Task<Result> resultTask, Func<Result> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> CheckAsync<T1>(this Task<Result> resultTask, Func<Result<T1>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    #endregion

    #region Check Left ValueTask Async

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> CheckAsync<T>(this ValueTask<Result> resultTask, Func<Result> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    /// <summary>
    ///     If the calling result is a success, the given function is executed and its Result is checked.
    ///     If this Result is a failure, it is returned. Otherwise, the calling result is returned.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> CheckAsync<T1>(this ValueTask<Result> resultTask, Func<Result<T1>> bind)
    {
        var result = await resultTask.ConfigureAwait(false);
        var bindResult = result.BindTry(bind);
        return bindResult.IsFailed ? Result.Fail(bindResult.Errors) : result;
    }

    #endregion

}
