namespace Orleans.FluentResults;

public partial record Result<TValue>
{

    #region Bind to Function

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{TValue}" />.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Action that may fail.</param>
    public Result<TValue> Bind(Func<Result<TValue>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this;
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
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Action that may fail.</param>
    public async Task<Result<TValue>> Bind(Func<Task<Result<TValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this;
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
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Action that may fail.</param>
    public async ValueTask<Result<TValue>> Bind(Func<ValueTask<Result<TValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this;
        if (IsFailed)
        {
            return result;
        }
        var bindResult = await bindAction();
        return result.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
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
    /// <param name="bindAction">Action that may fail.</param>
    public Result Bind(Func<TValue, Result> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this;
        if (IsFailed)
        {
            return result;
        }
        var bindResult = bindAction(Value);
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
    /// <param name="bindAction">Action that may fail.</param>
    public async Task<Result> Bind(Func<TValue, Task<Result>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this;
        if (IsFailed)
        {
            return result;
        }
        var bindResult = await bindAction(Value);
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
    /// <param name="bindAction">Action that may fail.</param>
    public async ValueTask<Result> Bind(Func<TValue, ValueTask<Result>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this;
        if (IsFailed)
        {
            return result;
        }
        var bindResult = await bindAction(Value);
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
    /// <param name="bindAction">Action that may fail.</param>
    public Result<TValue> Bind(Func<TValue, Result<TValue>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this;
        if (IsFailed)
        {
            return result;
        }
        var bindResult = bindAction(Value);
        return result.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{TValue}" /> asynchronously.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var bakeryDtoResult = result.Bind(GetWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Transformation that may fail.</param>
    public async Task<Result<TValue>> Bind(Func<TValue, Task<Result<TValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this;
        if (IsFailed)
        {
            return result;
        }
        var bindResult = await bindAction(Value);
        return result.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{TValue}" /> asynchronously.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var bakeryDtoResult = result.Bind(GetWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Transformation that may fail.</param>
    public async ValueTask<Result<TValue>> Bind(Func<TValue, ValueTask<Result<TValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = this;
        if (IsFailed)
        {
            return result;
        }
        var bindResult = await bindAction(Value);
        return result.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
    }

    #endregion

    #region Bind to New Value Function

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{TNewValue}" />.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var done = result.Bind(ActionWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Action that may fail.</param>
    public Result<TNewValue> Bind<TNewValue>(Func<TValue, Result<TNewValue>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = new Result<TNewValue>(Reasons);
        if (IsFailed)
        {
            return result;
        }
        var bindResult = bindAction(Value);
        return result.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{TNewValue}" /> asynchronously.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var bakeryDtoResult = result.Bind(GetWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Transformation that may fail.</param>
    public async Task<Result<TNewValue>> Bind<TNewValue>(Func<TValue, Task<Result<TNewValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = new Result<TNewValue>(Reasons);
        if (IsFailed)
        {
            return result;
        }
        var bindResult = await bindAction(Value);
        return result.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
    }

    /// <summary>
    ///     Execute an bindAction which returns a <see cref="Result{TNewValue}" /> asynchronously.
    /// </summary>
    /// <example>
    ///     <code>
    ///  var bakeryDtoResult = result.Bind(GetWhichMayFail);
    /// </code>
    /// </example>
    /// <param name="bindAction">Transformation that may fail.</param>
    public async ValueTask<Result<TNewValue>> Bind<TNewValue>(Func<TValue, ValueTask<Result<TNewValue>>> bindAction)
    {
        ArgumentNullException.ThrowIfNull(bindAction);
        var result = new Result<TNewValue>(Reasons);
        if (IsFailed)
        {
            return result;
        }
        var bindResult = await bindAction(Value);
        return result.WithValue(bindResult.Value).WithReasons(bindResult.Reasons);
    }

    #endregion

}
