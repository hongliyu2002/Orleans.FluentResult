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
    /// <param name="bind">bind action</param>
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
    /// <param name="bind">bind action</param>
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
    /// <param name="bind">bind action</param>
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
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result<T> BindTryIf<T>(this Result<T> result, bool condition, Func<T, Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTry<T>(bind, catchHandler) : result;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> BindTryIf<T, TOutput>(this Result<T> result, bool condition, Func<Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTry(bind, catchHandler) : result.ToResult<T, TOutput>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> BindTryIf<T, TOutput>(this Result<T> result, bool condition, Func<T, Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTry(bind, catchHandler) : result.ToResult<T, TOutput>();
    }

    #endregion

    #region BindTryIf Full Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    #endregion

    #region BindTryIf Full ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    #endregion

    #region BindTryIf Right Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.BindTryAsync(bind, catchHandler, configureAwait) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<T, Task<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.BindTryAsync(bind, catchHandler, configureAwait) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.BindTryAsync<T>(bind, catchHandler, configureAwait) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<T, Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.BindTryAsync<T>(bind, catchHandler, configureAwait) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.BindTryAsync(bind, catchHandler, configureAwait) : Task.FromResult(result.ToResult<T, TOutput>());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<T, Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.BindTryAsync(bind, catchHandler, configureAwait) : Task.FromResult(result.ToResult<T, TOutput>());
    }

    #endregion

    #region BindTryIf Right ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.BindTryAsync(bind, catchHandler, configureAwait) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.BindTryAsync(bind, catchHandler, configureAwait) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.BindTryAsync<T>(bind, catchHandler, configureAwait) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.BindTryAsync<T>(bind, catchHandler, configureAwait) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<ValueTask<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.BindTryAsync(bind, catchHandler, configureAwait) : ValueTask.FromResult(result.ToResult<T, TOutput>());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<T, ValueTask<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? result.BindTryAsync(bind, catchHandler, configureAwait) : ValueTask.FromResult(result.ToResult<T, TOutput>());
    }

    #endregion

    #region BindTryIf Left Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Result> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<T>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    #endregion

    #region BindTryIf Left ValueTask Async

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync(configureAwait);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<T>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, catchHandler, configureAwait) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null, bool configureAwait = true)
    {
        return condition ? resultTask.BindTryAsync(bind, catchHandler, configureAwait) : resultTask.ToResultAsync<T, TOutput>(configureAwait);
    }

    #endregion

}
