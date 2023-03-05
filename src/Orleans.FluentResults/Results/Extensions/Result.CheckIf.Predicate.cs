namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region CheckIf

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result CheckIf(this Result result, Func<Result, bool> predicate, Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result CheckIf<TOutput>(this Result result, Func<Result, bool> predicate, Func<Result<TOutput>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Check(check) : result;
    }

    #endregion

    #region CheckIf Full Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result> CheckIfAsync(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result> CheckIfAsync<TOutput>(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Task<Result<TOutput>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(true) : result;
    }

    #endregion

    #region CheckIf Full ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result> CheckIfAsync(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result> CheckIfAsync<TOutput>(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<ValueTask<Result<TOutput>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(true) : result;
    }

    #endregion

    #region CheckIf Right Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result> CheckIfAsync(this Result result, Func<Result, bool> predicate, Func<Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result> CheckIfAsync<TOutput>(this Result result, Func<Result, bool> predicate, Func<Task<Result<TOutput>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(true) : result;
    }

    #endregion

    #region CheckIf Right ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result> CheckIfAsync(this Result result, Func<Result, bool> predicate, Func<ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(true) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result> CheckIfAsync<TOutput>(this Result result, Func<Result, bool> predicate, Func<ValueTask<Result<TOutput>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(true) : result;
    }

    #endregion

    #region CheckIf Left Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result> CheckIfAsync(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result> CheckIfAsync<TOutput>(this Task<Result> resultTask, Func<Result, bool> predicate, Func<Result<TOutput>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Check(check) : result;
    }

    #endregion

    #region CheckIf Left ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result> CheckIfAsync(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result> CheckIfAsync<TOutput>(this ValueTask<Result> resultTask, Func<Result, bool> predicate, Func<Result<TOutput>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(true);
        return predicate(result) ? result.Check(check) : result;
    }

    #endregion

}
