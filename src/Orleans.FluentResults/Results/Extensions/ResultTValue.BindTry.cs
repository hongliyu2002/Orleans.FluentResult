namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region BindTry

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T1> BindTry<T, T1>(this Result<T> result, Func<Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind();
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static Result<T1> BindTry<T, T1>(this Result<T> result, Func<T, Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind(result.Value);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    #endregion

    #region BindTry Full Async

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryAsync<T, T1>(this Task<Result<T>> resultTask, Func<Task<Result<T1>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryAsync<T, T1>(this Task<Result<T>> resultTask, Func<T, Task<Result<T1>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    #endregion

    #region BindTry Full ValueTask Async

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T1>>> bind,
                                                                  Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T1>>> bind,
                                                                  Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    #endregion

    #region BindTry Right Async

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryAsync<T, T1>(this Result<T> result, Func<Task<Result<T1>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryAsync<T, T1>(this Result<T> result, Func<T, Task<Result<T1>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    #endregion

    #region BindTry Right ValueTask Async

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryAsync<T, T1>(this Result<T> result, Func<ValueTask<Result<T1>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind().ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryAsync<T, T1>(this Result<T> result, Func<T, ValueTask<Result<T1>>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = await bind(result.Value).ConfigureAwait(false);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    #endregion

    #region BindTry Left Async

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind();
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async Task<Result<T1>> BindTryAsync<T, T1>(this Task<Result<T>> resultTask, Func<T, Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind(result.Value);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    #endregion

    #region BindTry Left ValueTask Async

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T}" />.
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
            return Result.Fail<T>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind();
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Try to execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    /// <param name="catchHandler"></param>
    public static async ValueTask<Result<T1>> BindTryAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<T, Result<T1>> bind, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var bindResult = bind(result.Value);
            return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
        }
        catch (Exception ex)
        {
            return Result.Fail<T1>(catchHandler(ex));
        }
    }

    #endregion

}
