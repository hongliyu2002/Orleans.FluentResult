﻿namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region Bind

    /// <summary>
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
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
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
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
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync(this Task<Result> resultTask, Func<Task<Result>> bind)
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
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result> resultTask, Func<Task<Result<T>>> bind)
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

    #endregion

    #region Bind Full ValueTask Async

    /// <summary>
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync(this ValueTask<Result> resultTask, Func<ValueTask<Result>> bind)
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
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result> resultTask, Func<ValueTask<Result<T>>> bind)
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

    #endregion

    #region Bind Right Async

    /// <summary>
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
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
        var bindResult = await bind().ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
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
        var bindResult = await bind().ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Right ValueTask Async

    /// <summary>
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
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
        var bindResult = await bind().ConfigureAwait(false);
        return new Result(result.Reasons.AddRange(bindResult.Reasons));
    }

    /// <summary>
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
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
        var bindResult = await bind().ConfigureAwait(false);
        return bindResult with { Reasons = result.Reasons.AddRange(bindResult.Reasons) };
    }

    #endregion

    #region Bind Left Async

    /// <summary>
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result> BindAsync(this Task<Result> resultTask, Func<Result> bind)
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
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async Task<Result<T>> BindAsync<T>(this Task<Result> resultTask, Func<Result<T>> bind)
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

    #endregion

    #region Bind Left ValueTask Async

    /// <summary>
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result> BindAsync(this ValueTask<Result> resultTask, Func<Result> bind)
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
    ///     Execute an bind action which returns a <see cref="Result{T}" />.
    /// </summary>
    /// <param name="resultTask"></param>
    /// <param name="bind">Action that may fail.</param>
    public static async ValueTask<Result<T>> BindAsync<T>(this ValueTask<Result> resultTask, Func<Result<T>> bind)
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

    #endregion

}
