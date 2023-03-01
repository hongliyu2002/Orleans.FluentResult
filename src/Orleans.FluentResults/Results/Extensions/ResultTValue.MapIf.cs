namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region MapIf

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static Result<T1> MapIf<T, T1>(this Result<T> result, bool condition, Func<T1> map)
    {
        return condition ? result.Map(map) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static Result<T1> MapIf<T, T1>(this Result<T> result, bool condition, Func<T, T1> map)
    {
        return condition ? result.Map(map) : result.ToResult<T, T1>();
    }

    #endregion

    #region MapIf Full Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static Task<Result<T1>> MapIfAsync<T, T1>(this Task<Result<T>> resultTask, bool condition, Func<Task<T1>> map)
    {
        return condition ? resultTask.MapAsync(map) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static Task<Result<T1>> MapIfAsync<T, T1>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<T1>> map)
    {
        return condition ? resultTask.MapAsync(map) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

    #region MapIf Full ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static ValueTask<Result<T1>> MapIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<T1>> map)
    {
        return condition ? resultTask.MapAsync(map) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static ValueTask<Result<T1>> MapIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<T1>> map)
    {
        return condition ? resultTask.MapAsync(map) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

    #region MapIf Right Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static Task<Result<T1>> MapIfAsync<T, T1>(this Result<T> result, bool condition, Func<Task<T1>> map)
    {
        return condition ? result.MapAsync(map) : Task.FromResult(result.ToResult<T, T1>());
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static Task<Result<T1>> MapIfAsync<T, T1>(this Result<T> result, bool condition, Func<T, Task<T1>> map)
    {
        return condition ? result.MapAsync(map) : Task.FromResult(result.ToResult<T, T1>());
    }

    #endregion

    #region MapIf Right ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static ValueTask<Result<T1>> MapIfAsync<T, T1>(this Result<T> result, bool condition, Func<ValueTask<T1>> map)
    {
        return condition ? result.MapAsync(map) : ValueTask.FromResult(result.ToResult<T, T1>());
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static ValueTask<Result<T1>> MapIfAsync<T, T1>(this Result<T> result, bool condition, Func<T, ValueTask<T1>> map)
    {
        return condition ? result.MapAsync(map) : ValueTask.FromResult(result.ToResult<T, T1>());
    }

    #endregion

    #region MapIf Left Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static Task<Result<T1>> MapIfAsync<T, T1>(this Task<Result<T>> resultTask, bool condition, Func<T1> map)
    {
        return condition ? resultTask.MapAsync(map) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static Task<Result<T1>> MapIfAsync<T, T1>(this Task<Result<T>> resultTask, bool condition, Func<T, T1> map)
    {
        return condition ? resultTask.MapAsync(map) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

    #region MapIf Left ValueTask Async

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static ValueTask<Result<T1>> MapIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool condition, Func<T1> map)
    {
        return condition ? resultTask.MapAsync(map) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     Execute an map function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="map">Action that may fail.</param>
    public static ValueTask<Result<T1>> MapIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, T1> map)
    {
        return condition ? resultTask.MapAsync(map) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

}
