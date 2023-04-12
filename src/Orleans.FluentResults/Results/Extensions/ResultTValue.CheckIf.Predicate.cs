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
    /// <param name="check">check action</param>
    public static Result<T> CheckIf<T>(this Result<T> result, Func<T, bool> predicate, Func<Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    public static Result<T> CheckIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    public static Result<T> CheckIf<T>(this Result<T> result, Func<T, bool> predicate, Func<Result<T>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    public static Result<T> CheckIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<T>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    public static Result<T> CheckIf<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<Result<TOutput>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    public static Result<T> CheckIf<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<TOutput>> check)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? result.Check(check) : result;
    }

    #endregion

    #region CheckIf Full Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Task<Result>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Task<Result<T>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.CheckAsync<T>(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result<T>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.CheckAsync<T>(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region CheckIf Full ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<ValueTask<Result>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<ValueTask<Result<T>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.CheckAsync<T>(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result<T>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.CheckAsync<T>(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region CheckIf Right Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<Task<Result>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<Task<Result<T>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.CheckAsync<T>(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result<T>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.CheckAsync<T>(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result<TOutput>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region CheckIf Right ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<ValueTask<Result>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<ValueTask<Result<T>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.CheckAsync<T>(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result<T>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.CheckAsync<T>(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T, TOutput>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result<TOutput>>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return predicate(result.Value) ? await result.CheckAsync(check, configureAwait).ConfigureAwait(configureAwait) : result;
    }

    #endregion

    #region CheckIf Left Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Result> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Result<T>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<T>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Result<TOutput>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> CheckIfAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<TOutput>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Check(check) : result;
    }

    #endregion

    #region CheckIf Left ValueTask Async

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<Result> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<Result<T>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<T>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Check<T>(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<Result<TOutput>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Check(check) : result;
    }

    /// <summary>
    ///     When predicate is true, execute an check function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="predicate"></param>
    /// <param name="check">check action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> CheckIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<TOutput>> check, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var result = resultTask.IsCompleted ? resultTask.Result : await resultTask.ConfigureAwait(configureAwait);
        return predicate(result.Value) ? result.Check(check) : result;
    }

    #endregion

}
