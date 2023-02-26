namespace Orleans.FluentResults;

public static partial class ResultOfTValueExtensions
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
    public static Result Bind<TValue>(this Result<TValue> result, Func<Result> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result with {};
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = bindAction();
        return boundResult.WithReasons(bindResult.Reasons);
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
    public static async Task<Result> Bind<TValue>(this Result<TValue> result, Func<Task<Result>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result with {};
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction();
        return boundResult.WithReasons(bindResult.Reasons);
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
    public static async ValueTask<Result> Bind<TValue>(this Result<TValue> result, Func<ValueTask<Result>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result with {};
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction();
        return boundResult.WithReasons(bindResult.Reasons);
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
    public static Result<TValue> Bind<TValue>(this Result<TValue> result, Func<Result<TValue>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result with {};
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
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Action that may fail.</param>
    public static async Task<Result<TValue>> Bind<TValue>(this Result<TValue> result, Func<Task<Result<TValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result with {};
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
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="result"></param>
    /// <param name="bindAction">Action that may fail.</param>
    public static async ValueTask<Result<TValue>> Bind<TValue>(this Result<TValue> result, Func<ValueTask<Result<TValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result with {};
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction();
        return boundResult.WithValue(bindResult.Value)
                          .WithReasons(bindResult.Reasons);
    }

    #endregion

    #region Bind to Value Function

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
    public static Result Bind<TValue>(this Result<TValue> result, Func<TValue, Result> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result with {};
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = bindAction(result.Value);
        return boundResult.WithReasons(bindResult.Reasons);
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
    public static async Task<Result> Bind<TValue>(this Result<TValue> result, Func<TValue, Task<Result>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result with {};
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction(result.Value);
        return boundResult.WithReasons(bindResult.Reasons);
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
    public static async ValueTask<Result> Bind<TValue>(this Result<TValue> result, Func<TValue, ValueTask<Result>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result with {};
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction(result.Value);
        return boundResult.WithReasons(bindResult.Reasons);
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
    public static Result<TValue> Bind<TValue>(this Result<TValue> result, Func<TValue, Result<TValue>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result with {};
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = bindAction(result.Value);
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
    public static async Task<Result<TValue>> Bind<TValue>(this Result<TValue> result, Func<TValue, Task<Result<TValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(bindAction);
        var boundResult = result with {};
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction(result.Value);
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
    public static async ValueTask<Result<TValue>> Bind<TValue>(this Result<TValue> result, Func<TValue, ValueTask<Result<TValue>>> bindAction)
    {
        var boundResult = result with {};
        if (result.IsFailed)
        {
            return boundResult;
        }
        var bindResult = await bindAction(result.Value);
        return boundResult.WithValue(bindResult.Value)
                          .WithReasons(bindResult.Reasons);
    }

    #endregion

}
