namespace Orleans.FluentResults;

public static partial class ResultExtensions
{

    #region Bind to Function

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result" />.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Action that may fail.</param>
    public static Result Bind(this Result result, Func<Result> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        if (result.IsFailed)
        {
            return result;
        }
        var bindResult = bindAction();
        return result.WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result" /> asynchronously.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Action that may fail.</param>
    public static async Task<Result> Bind(this Result result, Func<Task<Result>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        if (result.IsFailed)
        {
            return result;
        }
        var bindResult = await bindAction();
        return result.WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result" /> asynchronously.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Action that may fail.</param>
    public static async ValueTask<Result> Bind(this Result result, Func<ValueTask<Result>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        if (result.IsFailed)
        {
            return result;
        }
        var bindResult = await bindAction();
        return result.WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{TValue}" />.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Action that may fail.</param>
    public static Result<TValue> Bind<TValue>(this Result result, Func<Result<TValue>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result as Result<TValue> ?? new Result<TValue>(result.Reasons);
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = bindAction();
        return boundResult.WithValue(bindResult.Value)
                          .WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{TValue}" /> asynchronously.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var bakeryDtoResult = result.Bind(GetWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Transformation that may fail.</param>
    public static async Task<Result<TValue>> Bind<TValue>(this Result result, Func<Task<Result<TValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result as Result<TValue> ?? new Result<TValue>(result.Reasons);
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction();
        return boundResult.WithValue(bindResult.Value)
                          .WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{TValue}" /> asynchronously.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var bakeryDtoResult = result.Bind(GetWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Transformation that may fail.</param>
    public static async ValueTask<Result<TValue>> Bind<TValue>(this Result result, Func<ValueTask<Result<TValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result as Result<TValue> ?? new Result<TValue>(result.Reasons);
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction();
        return boundResult.WithValue(bindResult.Value)
                          .WithReasons(bindResult.Reasons);
    }

    #endregion

}
