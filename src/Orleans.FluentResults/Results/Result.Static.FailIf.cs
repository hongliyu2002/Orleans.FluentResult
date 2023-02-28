namespace Orleans.FluentResults;

public partial record Result
{

    #region FailIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result FailIf(bool failureCondition, IError error)
    {
        return failureCondition ? Fail(error) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result FailIf(bool failureCondition, string errorMessage)
    {
        return failureCondition ? Fail(errorMessage) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result FailIf(bool failureCondition, Func<IError> errorFactory)
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
    public static Result FailIf(bool failureCondition, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return failureCondition ? Fail(errorMessageFactory.Invoke()) : Ok();
    }

    #endregion

    #region FailIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result> FailIfAsync(Func<Task<bool>> predicate, IError error)
    {
        var failureCondition = await predicate();
        return FailIf(failureCondition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result> FailIfAsync(Func<Task<bool>> predicate, string errorMessage)
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
    public static async Task<Result> FailIfAsync(Func<Task<bool>> predicate, Func<IError> errorFactory)
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
    public static async Task<Result> FailIfAsync(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
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
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> predicate, IError error)
    {
        var failureCondition = await predicate();
        return FailIf(failureCondition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> predicate, string errorMessage)
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
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
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
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var failureCondition = await predicate();
        return FailIf(failureCondition, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, IError error)
    {
        return Result<T>.FailIf(failureCondition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, string errorMessage)
    {
        return Result<T>.FailIf(failureCondition, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf<T>(bool failureCondition, Func<IError> errorFactory)
    {
        return Result<T>.FailIf(failureCondition, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf<T>(bool failureCondition, Func<string> errorMessageFactory)
    {
        return Result<T>.FailIf(failureCondition, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, IError error)
    {
        return Result<T>.FailIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, string errorMessage)
    {
        return Result<T>.FailIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, Func<IError> errorFactory)
    {
        return Result<T>.FailIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
    {
        return Result<T>.FailIfAsync(predicate, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, IError error)
    {
        return Result<T>.FailIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        return Result<T>.FailIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
    {
        return Result<T>.FailIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        return Result<T>.FailIfAsync(predicate, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, T successValue, IError error)
    {
        return Result<T>.FailIf(failureCondition, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, T successValue, string errorMessage)
    {
        return Result<T>.FailIf(failureCondition, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf<T>(bool failureCondition, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.FailIf(failureCondition, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf<T>(bool failureCondition, T successValue, Func<string> errorMessageFactory)
    {
        return Result<T>.FailIf(failureCondition, successValue, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, T successValue, IError error)
    {
        return Result<T>.FailIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, T successValue, string errorMessage)
    {
        return Result<T>.FailIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.FailIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        return Result<T>.FailIfAsync(predicate, successValue, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, IError error)
    {
        return Result<T>.FailIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string errorMessage)
    {
        return Result<T>.FailIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.FailIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        return Result<T>.FailIfAsync(predicate, successValue, errorMessageFactory);
    }

    #endregion

}
