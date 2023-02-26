namespace Orleans.FluentResults;

public partial record Result
{

    #region Bind to Function

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result" />.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var done = this.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Action that may fail.</param>
    public Result Bind(Func<Result> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this;
        if (IsFailed)
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
    ///  var done = this.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Action that may fail.</param>
    public async Task<Result> Bind(Func<Task<Result>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this;
        if (IsFailed)
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
    ///  var done = this.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Action that may fail.</param>
    public async ValueTask<Result> Bind(Func<ValueTask<Result>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this;
        if (IsFailed)
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
    ///  var done = this.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Action that may fail.</param>
    public Result<TValue> Bind<TValue>(Func<Result<TValue>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this as Result<TValue> ?? new Result<TValue>(Reasons);
        if (IsFailed)
        {
            return result;
        }
        var bindResult = bindAction();
        return result.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{TValue}" /> asynchronously.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var bakeryDtoResult = this.Bind(GetWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Transformation that may fail.</param>
    public async Task<Result<TValue>> Bind<TValue>(Func<Task<Result<TValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this as Result<TValue> ?? new Result<TValue>(Reasons);
        if (IsFailed)
        {
            return result;
        }
        var bindResult = await bindAction();
        return result.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{TValue}" /> asynchronously.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var bakeryDtoResult = this.Bind(GetWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Transformation that may fail.</param>
    public async ValueTask<Result<TValue>> Bind<TValue>(Func<ValueTask<Result<TValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this as Result<TValue> ?? new Result<TValue>(Reasons);
        if (IsFailed)
        {
            return result;
        }
        var bindResult = await bindAction();
        return result.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
    }

    #endregion

}
