namespace Orleans.FluentResults;

public static partial class ResultTExtensions
{

    #region Bind

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result Bind<T>(this Result<T> result, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = bind();
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result Bind<T>(this Result<T> result, Func<T, Result> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> Bind<T>(this Result<T> result, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = bind();
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T> Bind<T>(this Result<T> result, Func<T, Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T2> Bind<T, T2>(this Result<T> result, Func<Result<T2>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = bind();
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static Result<T2> Bind<T, T2>(this Result<T> result, Func<T, Result<T2>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    #endregion

    #region Bind Full Async

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = await bind();
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = await bind(result.Value);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result<T>> resultTask, Func<Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = await bind();
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result<T>> resultTask, Func<T, Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = await bind(result.Value);
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T2>> BindAsync<T, T2>(this Task<Result<T>> resultTask, Func<Task<Result<T2>>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = await bind();
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T2>> BindAsync<T, T2>(this Task<Result<T>> resultTask, Func<T, Task<Result<T2>>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = await bind(result.Value);
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    #endregion

    #region Bind Full ValueTask Async

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = await bind();
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = await bind(result.Value);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = await bind();
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = await bind(result.Value);
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T2>> BindAsync<T, T2>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T2>>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = await bind();
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T2>> BindAsync<T, T2>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T2>>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = await bind(result.Value);
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    #endregion

    #region Bind Right Async

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync<T>(this Result<T> result, Func<Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = await bind();
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync<T>(this Result<T> result, Func<T, Task<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = await bind(result.Value);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Result<T> result, Func<Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = await bind();
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Result<T> result, Func<T, Task<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = await bind(result.Value);
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T2>> BindAsync<T, T2>(this Result<T> result, Func<Task<Result<T2>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = await bind();
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T2>> BindAsync<T, T2>(this Result<T> result, Func<T, Task<Result<T2>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = await bind(result.Value);
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    #endregion

    #region Bind Right ValueTask Async

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync<T>(this Result<T> result, Func<ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = await bind();
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync<T>(this Result<T> result, Func<T, ValueTask<Result>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = await bind(result.Value);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this Result<T> result, Func<ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = await bind();
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this Result<T> result, Func<T, ValueTask<Result<T>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = await bind(result.Value);
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T2>> BindAsync<T, T2>(this Result<T> result, Func<ValueTask<Result<T2>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = await bind();
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T2>> BindAsync<T, T2>(this Result<T> result, Func<T, ValueTask<Result<T2>>> bind)
    {
        ArgumentNullException.ThrowIfNull(bind);
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = await bind(result.Value);
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    #endregion

    #region Bind Left Async

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync<T>(this Task<Result<T>> resultTask, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = bind();
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync<T>(this Task<Result<T>> resultTask, Func<T, Result> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result<T>> resultTask, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = bind();
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result<T>> resultTask, Func<T, Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T2>> BindAsync<T, T2>(this Task<Result<T>> resultTask, Func<Result<T2>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = bind();
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T2>> BindAsync<T, T2>(this Task<Result<T>> resultTask, Func<T, Result<T2>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    #endregion

    #region Bind Left ValueTask Async

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = bind();
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = bind();
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result<T>> resultTask, Func<T, Result<T>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T>(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return new Result<T>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T2>> BindAsync<T, T2>(this ValueTask<Result<T>> resultTask, Func<Result<T2>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = bind();
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{T2}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T2>> BindAsync<T, T2>(this ValueTask<Result<T>> resultTask, Func<T, Result<T2>> bind)
    {
        ArgumentNullException.ThrowIfNull(resultTask);
        ArgumentNullException.ThrowIfNull(bind);
        var result = await resultTask;
        if (result.IsFailed)
        {
            return new Result<T2>(result.Reasons);
        }
        var bindResult = bind(result.Value);
        return new Result<T2>(bindResult.Value, result.Reasons.AddRange(bindResult.Reasons));
    }

    #endregion

}
