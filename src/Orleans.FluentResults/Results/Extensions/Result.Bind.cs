namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Bind

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result Bind(this Result result, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = bind();
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> Bind<T>(this Result result, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = bind();
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Full Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync(this Task<Result> resultTask, Func<Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(true);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result> resultTask, Func<Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(true);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Full ValueTask Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync(this ValueTask<Result> resultTask, Func<ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(true);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result> resultTask, Func<ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(true);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Right Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync(this Result result, Func<Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(true);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Result result, Func<Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(true);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Right ValueTask Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync(this Result result, Func<ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(true);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this Result result, Func<ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(true);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Left Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync(this Task<Result> resultTask, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = bind();
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result> resultTask, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = bind();
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Left ValueTask Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync(this ValueTask<Result> resultTask, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = bind();
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result> resultTask, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(true);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = bind();
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

}
