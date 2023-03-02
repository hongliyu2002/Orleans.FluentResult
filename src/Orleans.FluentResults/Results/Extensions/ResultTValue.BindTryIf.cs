namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region BindTryIf

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result BindTryIf<T>(this Result<T> result, bool condition, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result BindTryIf<T>(this Result<T> result, bool condition, Func<T, Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTry(bind, catchHandler) : result.ToResult();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> BindTryIf<T>(this Result<T> result, bool condition, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> BindTryIf<T>(this Result<T> result, bool condition, Func<T, Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T1> BindTryIf<T, T1>(this Result<T> result, bool condition, Func<Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTry(bind, catchHandler) : result.ToResult<T, T1>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T1> BindTryIf<T, T1>(this Result<T> result, bool condition, Func<T, Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTry(bind, catchHandler) : result.ToResult<T, T1>();
    }

    #endregion

    #region BindTryIf Full Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T1>> BindTryIfAsync<T, T1>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result<T1>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T1>> BindTryIfAsync<T, T1>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<T1>>> bind,
                                                         Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

    #region BindTryIf Full ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result>> bind,
                                                      Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result>> bind,
                                                      Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result<T>>> bind,
                                                         Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<T>>> bind,
                                                         Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T1>> BindTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result<T1>>> bind,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T1>> BindTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<T1>>> bind,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

    #region BindTryIf Right Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, catchHandler) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<T, Task<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, catchHandler) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync<T>(bind, catchHandler) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<T, Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync<T>(bind, catchHandler) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T1>> BindTryIfAsync<T, T1>(this Result<T> result, bool condition, Func<Task<Result<T1>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, catchHandler) : Task.FromResult(result.ToResult<T, T1>());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T1>> BindTryIfAsync<T, T1>(this Result<T> result, bool condition, Func<T, Task<Result<T1>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, catchHandler) : Task.FromResult(result.ToResult<T, T1>());
    }

    #endregion

    #region BindTryIf Right ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, catchHandler) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, catchHandler) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync<T>(bind, catchHandler) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync<T>(bind, catchHandler) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T1>> BindTryIfAsync<T, T1>(this Result<T> result, bool condition, Func<ValueTask<Result<T1>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, catchHandler) : ValueTask.FromResult(result.ToResult<T, T1>());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T1>> BindTryIfAsync<T, T1>(this Result<T> result, bool condition, Func<T, ValueTask<Result<T1>>> bind,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, catchHandler) : ValueTask.FromResult(result.ToResult<T, T1>());
    }

    #endregion

    #region BindTryIf Left Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T1>> BindTryIfAsync<T, T1>(this Task<Result<T>> resultTask, bool condition, Func<Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T1>> BindTryIfAsync<T, T1>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

    #region BindTryIf Left ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<T>> bind,
                                                         Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T1>> BindTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result<T1>> bind,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T1>> BindTryIfAsync<T, T1>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<T1>> bind,
                                                              Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler) : resultTask.ToResultAsync<T, T1>();
    }

    #endregion

}
