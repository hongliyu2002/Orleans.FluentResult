namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region CheckIf

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> CheckIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> CheckIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> CheckIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Result<T>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> CheckIf<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Result<T>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> CheckIf<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Result<T1>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static Result<T> CheckIf<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Result<T1>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? result.Check(check) : result;
    }

    #endregion

    #region CheckIf Full Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<Result<T>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.CheckAsync<T>(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<Result<T>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.CheckAsync<T>(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Task<Result<T1>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Task<Result<T1>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    #endregion

    #region CheckIf Full ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<Result<T>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.CheckAsync<T>(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<T>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.CheckAsync<T>(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<ValueTask<Result<T1>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<T1>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    #endregion

    #region CheckIf Right Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<Result<T>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync<T>(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<Result<T>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync<T>(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<Task<Result<T1>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, Task<Result<T1>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    #endregion

    #region CheckIf Right ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<Result<T>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync<T>(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<T>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync<T>(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<ValueTask<Result<T1>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T, T1>(this Result<T> result, Func<Result<T>, bool> predicate, Func<T, ValueTask<Result<T1>>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result) ? await result.CheckAsync(check).ConfigureAwait(false) : result;
    }

    #endregion

    #region CheckIf Left Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<T>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<T>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<T1>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async Task<Result<T>> CheckIfAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<T1>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Check(check) : result;
    }

    #endregion

    #region CheckIf Left ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<T>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<T>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<Result<T1>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">Action that may fail.</param>
    public static async ValueTask<Result<T>> CheckIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T>, bool> predicate, Func<T, Result<T1>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = await resultTask.ConfigureAwait(false);
        return predicate(result) ? result.Check(check) : result;
    }

    #endregion

}
