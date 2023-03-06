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
    /// <param name="bind">bind action</param>
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
    /// <param name="bind">bind action</param>
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
    /// <param name="bind">bind action</param>
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
    /// <param name="bind">bind action</param>
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
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    public static Result<TOutput> Bind<T, TOutput>(this Result<T> result, Func<Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        var bindResult = bind();
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    public static Result<TOutput> Bind<T, TOutput>(this Result<T> result, Func<T, Result<TOutput>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
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
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> BindAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(configureAwait);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> BindAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(configureAwait);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> BindAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Task<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        var bindResult = await bind().ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> BindAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, Task<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Full ValueTask Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(configureAwait);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(configureAwait);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> BindAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        var bindResult = await bind().ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> BindAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Right Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> BindAsync<T>(this Result<T> result, Func<Task<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(configureAwait);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> BindAsync<T>(this Result<T> result, Func<T, Task<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(configureAwait);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> BindAsync<T>(this Result<T> result, Func<Task<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> BindAsync<T>(this Result<T> result, Func<T, Task<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> BindAsync<T, TOutput>(this Result<T> result, Func<Task<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        var bindResult = await bind().ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> BindAsync<T, TOutput>(this Result<T> result, Func<T, Task<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Right ValueTask Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> BindAsync<T>(this Result<T> result, Func<ValueTask<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(configureAwait);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> BindAsync<T>(this Result<T> result, Func<T, ValueTask<Result>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(configureAwait);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> BindAsync<T>(this Result<T> result, Func<ValueTask<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind().ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> BindAsync<T>(this Result<T> result, Func<T, ValueTask<Result<T>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> BindAsync<T, TOutput>(this Result<T> result, Func<ValueTask<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        var bindResult = await bind().ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> BindAsync<T, TOutput>(this Result<T> result, Func<T, ValueTask<Result<TOutput>>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        var bindResult = await bind(result.Value).ConfigureAwait(configureAwait);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Left Async

    /// <summary>
    ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> BindAsync<T>(this Task<Result<T>> resultTask, Func<Result> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
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
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result> BindAsync<T>(this Task<Result<T>> resultTask, Func<T, Result> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
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
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
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
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result<T>> resultTask, Func<T, Result<T>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = bind(result.Value);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> BindAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<Result<TOutput>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        var bindResult = bind();
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async Task<Result<TOutput>> BindAsync<T, TOutput>(this Task<Result<T>> resultTask, Func<T, Result<TOutput>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
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
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
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
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
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
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
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
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result<T>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return Result.Fail<T>(result.Errors);
        }
        var bindResult = bind(result.Value);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> BindAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<Result<TOutput>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        var bindResult = bind();
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    /// <summary>
    ///     Execute an bind function which returns a <see cref="Result{TOutput}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">bind action</param>
    /// <param name="configureAwait"></param>
    public static async ValueTask<Result<TOutput>> BindAsync<T, TOutput>(this ValueTask<Result<T>> resultTask, Func<T, Result<TOutput>> bind, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask.ConfigureAwait(configureAwait);
        if (result.IsFailed)
        {
            return new Result<TOutput>(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

}
