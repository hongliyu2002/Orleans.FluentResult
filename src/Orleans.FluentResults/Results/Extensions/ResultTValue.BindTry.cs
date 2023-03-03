namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region BindTry

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result BindTry<T>(this Result<T> result, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind();
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result BindTry<T>(this Result<T> result, Func<T, Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind(result.Value);
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> BindTry<T>(this Result<T> result, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind();
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T> BindTry<T>(this Result<T> result, Func<T, Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind(result.Value);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> BindTry<T, TOutput>(this Result<T> result, Func<Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind();
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<TOutput> BindTry<T, TOutput>(this Result<T> result, Func<T, Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind(result.Value);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    #endregion

    #region BindTry Full Async

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    #endregion

    #region BindTry Full ValueTask Async

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<TOutput>>> bind,
                                                                  Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<TOutput>>> bind,
                                                                  Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    #endregion

    #region BindTry Right Async

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryAsync<T>(this Result<T> result, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryAsync<T>(this Result<T> result, Func<T, Task<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryAsync<T>(this Result<T> result, Func<Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryAsync<T>(this Result<T> result, Func<T, Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryAsync<T, TOutput>(this Result<T> result, Func<Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryAsync<T, TOutput>(this Result<T> result, Func<T, Task<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    #endregion

    #region BindTry Right ValueTask Async

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryAsync<T>(this Result<T> result, Func<ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryAsync<T>(this Result<T> result, Func<T, ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryAsync<T>(this Result<T> result, Func<ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryAsync<T>(this Result<T> result, Func<T, ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryAsync<T, TOutput>(this Result<T> result, Func<ValueTask<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryAsync<T, TOutput>(this Result<T> result, Func<T, ValueTask<Result<TOutput>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    #endregion

    #region BindTry Left Async

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryAsync<T>(this Task<Result<T>> resultTask, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind();
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryAsync<T>(this Task<Result<T>> resultTask, Func<T, Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind(result.Value);
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind();
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T>> BindTryAsync<T>(this Task<Result<T>> resultTask, Func<T, Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind(result.Value);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind();
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<TOutput>> BindTryAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind(result.Value);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    #endregion

    #region BindTry Left ValueTask Async

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind();
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind(result.Value);
            return new Result(result.Reasons.AddRange(bindResult.Reasons));
        }
        catch (Exception ex)
        {
            return Result.Fail(result.Errors.Add(catchHandler(ex.InnerException ?? ex)));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind();
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T>> BindTryAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind(result.Value);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind();
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<TOutput>> BindTryAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, Result<TOutput>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind(result.Value);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(catchHandler(ex.InnerException ?? ex));
        }
    }

    #endregion

}
