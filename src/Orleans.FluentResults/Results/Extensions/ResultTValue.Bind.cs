namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTValueExtensions
{

    #region Bind

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result Bind<T>(this Result<T> result, Func<Result> bind)
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
    public static Result Bind<T>(this Result<T> result, Func<T, Result> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = bind(result.Value);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> Bind<T>(this Result<T> result, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = bind();
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> Bind<T>(this Result<T> result, Func<T, Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = bind(result.Value);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T1> Bind<T, T1>(this Result<T> result, Func<Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = bind();
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T1> Bind<T, T1>(this Result<T> result, Func<T, Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Full Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindAsync<T, T1>(this Task<Result<T>> resultTask, Func<Task<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = await bind().ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindAsync<T, T1>(this Task<Result<T>> resultTask, Func<T, Task<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Full ValueTask Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = await bind().ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Right Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync<T>(this Result<T> result, Func<Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync<T>(this Result<T> result, Func<T, Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Result<T> result, Func<Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Result<T> result, Func<T, Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindAsync<T, T1>(this Result<T> result, Func<Task<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = await bind().ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindAsync<T, T1>(this Result<T> result, Func<T, Task<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Right ValueTask Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync<T>(this Result<T> result, Func<ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync<T>(this Result<T> result, Func<T, ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this Result<T> result, Func<ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this Result<T> result, Func<T, ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindAsync<T, T1>(this Result<T> result, Func<ValueTask<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = await bind().ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindAsync<T, T1>(this Result<T> result, Func<T, ValueTask<Result<T1>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Left Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync<T>(this Task<Result<T>> resultTask, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
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
    public static async Task<Result> BindAsync<T>(this Task<Result<T>> resultTask, Func<T, Result> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = bind(result.Value);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = bind();
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result<T>> resultTask, Func<T, Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = bind(result.Value);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindAsync<T, T1>(this Task<Result<T>> resultTask, Func<Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = bind();
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T1>> BindAsync<T, T1>(this Task<Result<T>> resultTask, Func<T, Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Left ValueTask Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
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
    public static async ValueTask<Result> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = bind(result.Value);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = bind();
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = bind(result.Value);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = bind();
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{T1}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T1>> BindAsync<T, T1>(this ValueTask<Result<T>> resultTask, Func<T, Result<T1>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(false);
        if (result.IsFailed)
        {
            return new Result<T1>(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

}
