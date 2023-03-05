namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region BindTry

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result BindTry(this Result result, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
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
    public static Result<T> BindTry<T>(this Result result, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null)
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

    #endregion

    #region BindTry Full Async

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result> BindTryAsync(this Task<Result> resultTask, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(true);
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
    public static async Task<Result<T>> BindTryAsync<T>(this Task<Result> resultTask, Func<Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(true);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
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
    public static async ValueTask<Result> BindTryAsync(this ValueTask<Result> resultTask, Func<ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(true);
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
    public static async ValueTask<Result<T>> BindTryAsync<T>(this ValueTask<Result> resultTask, Func<ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(true);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
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
    public static async Task<Result> BindTryAsync(this Result result, Func<Task<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(true);
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
    public static async Task<Result<T>> BindTryAsync<T>(this Result result, Func<Task<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(true);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
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
    public static async ValueTask<Result> BindTryAsync(this Result result, Func<ValueTask<Result>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(true);
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
    public static async ValueTask<Result<T>> BindTryAsync<T>(this Result result, Func<ValueTask<Result<T>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(true);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(catchHandler(ex.InnerException ?? ex));
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
    public static async Task<Result> BindTryAsync(this Task<Result> resultTask, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
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
    public static async Task<Result<T>> BindTryAsync<T>(this Task<Result> resultTask, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
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

    #endregion

    #region BindTry Left ValueTask Async

    /// <summary>
    ///     Selects result from the return value of a given bind function. If the calling Result is a failure, a new failure result is returned instead.
    ///     If a given function throws an exception, an error is returned from the given error handler
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result> BindTryAsync(this ValueTask<Result> resultTask, Func<Result> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
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
    public static async ValueTask<Result<T>> BindTryAsync<T>(this ValueTask<Result> resultTask, Func<Result<T>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
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

    #endregion

}
