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
    public static Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result<T>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, configureAwait, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<T>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, configureAwait, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<Task<Result<TOutput>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<TOutput>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
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
    public static ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result<T>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, configureAwait, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<T>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, configureAwait, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask<Result<TOutput>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<TOutput>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
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
    public static Task<Result> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<Task<Result>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, configureAwait, catchHandler) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<T, Task<Result>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, configureAwait, catchHandler) : Task.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<Task<Result<T>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync<T>(bind, configureAwait, catchHandler) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<T, Task<Result<T>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync<T>(bind, configureAwait, catchHandler) : Task.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<Task<Result<TOutput>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, configureAwait, catchHandler) : Task.FromResult(result.ToResult<T, TOutput>());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<T, Task<Result<TOutput>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, configureAwait, catchHandler) : Task.FromResult(result.ToResult<T, TOutput>());
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
    public static ValueTask<Result> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask<Result>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, configureAwait, catchHandler) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, configureAwait, catchHandler) : ValueTask.FromResult(result.ToResult());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<ValueTask<Result<T>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync<T>(bind, configureAwait, catchHandler) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result<T>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync<T>(bind, configureAwait, catchHandler) : ValueTask.FromResult(result);
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<ValueTask<Result<TOutput>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, configureAwait, catchHandler) : ValueTask.FromResult(result.ToResult<T, TOutput>());
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Result<T> result, bool condition, Func<T, ValueTask<Result<TOutput>>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? result.BindTryAsync(bind, configureAwait, catchHandler) : ValueTask.FromResult(result.ToResult<T, TOutput>());
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
    public static Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Result> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<Result<T>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, configureAwait, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<T>> BindTryIfAsync<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<T>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, configureAwait, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<Result<TOutput>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static Task<Result<TOutput>> BindTryIfAsync<T, TOutput>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<TOutput>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
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
    public static ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result<T>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, configureAwait, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<T>> BindTryIfAsync<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<T>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync<T>(bind, configureAwait, catchHandler) : resultTask;
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<Result<TOutput>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    /// <summary>
    ///     When condition is true, execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="condition"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    /// <param name="catchHandler"></param>
    public static ValueTask<Result<TOutput>> BindTryIfAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<TOutput>> bind, bool configureAwait = true, Func<Exception, IError>? catchHandler = null)
    {
        return condition ? resultTask.BindTryAsync(bind, configureAwait, catchHandler) : resultTask.ToResultAsync<T, TOutput>();
    }

    #endregion

}
