namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region FailIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, IError error)
    {
        return failureCondition ? Fail(error) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, string errorMessage)
    {
        return failureCondition ? Fail(errorMessage) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf(bool failureCondition, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return failureCondition ? Fail(errorFactory.Invoke()) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf(bool failureCondition, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return failureCondition ? Fail(errorMessageFactory.Invoke()) : Ok();
    }

    #endregion

    #region FailIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, IError error)
    {
        var failureCondition = await predicate();
        return FailIf(failureCondition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, string errorMessage)
    {
        var failureCondition = await predicate();
        return FailIf(failureCondition, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var failureCondition = await predicate();
        return FailIf(failureCondition, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var failureCondition = await predicate();
        return FailIf(failureCondition, errorMessageFactory);
    }

    #endregion

    #region FailIf ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, IError error)
    {
        var failureCondition = await predicate();
        return FailIf(failureCondition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        var failureCondition = await predicate();
        return FailIf(failureCondition, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var failureCondition = await predicate();
        return FailIf(failureCondition, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var failureCondition = await predicate();
        return FailIf(failureCondition, errorMessageFactory);
    }

    #endregion

    #region FailIf With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, T successValue, IError error)
    {
        return failureCondition ? Fail(error) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, T successValue, string errorMessage)
    {
        return failureCondition ? Fail(errorMessage) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf(bool failureCondition, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return failureCondition ? Fail(errorFactory.Invoke()) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf(bool failureCondition, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return failureCondition ? Fail(errorMessageFactory.Invoke()) : Ok(successValue);
    }

    #endregion

    #region FailIf Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, T successValue, IError error)
    {
        var failureCondition = await predicate();
        return FailIf(failureCondition, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, T successValue, string errorMessage)
    {
        var failureCondition = await predicate();
        return FailIf(failureCondition, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var failureCondition = await predicate();
        return FailIf(failureCondition, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var failureCondition = await predicate();
        return FailIf(failureCondition, successValue, errorMessageFactory);
    }

    #endregion

    #region FailIf ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, T successValue, IError error)
    {
        var failureCondition = await predicate();
        return FailIf(failureCondition, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, T successValue, string errorMessage)
    {
        var failureCondition = await predicate();
        return FailIf(failureCondition, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var failureCondition = await predicate();
        return FailIf(failureCondition, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var failureCondition = await predicate();
        return FailIf(failureCondition, successValue, errorMessageFactory);
    }

    #endregion

}
