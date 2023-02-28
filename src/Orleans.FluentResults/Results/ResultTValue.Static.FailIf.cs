namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region FailIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<T> FailIf(bool isFailure, IError error)
    {
        return isFailure ? Fail(error) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<T> FailIf(bool isFailure, string errorMessage)
    {
        return isFailure ? Fail(errorMessage) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf(bool isFailure, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isFailure ? Fail(errorFactory.Invoke()) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf(bool isFailure, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isFailure ? Fail(errorMessageFactory.Invoke()) : Ok();
    }

    #endregion

    #region FailIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, IError error)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, string errorMessage)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, errorMessageFactory);
    }

    #endregion

    #region FailIf ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, IError error)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, errorMessageFactory);
    }

    #endregion

    #region FailIf With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<T> FailIf(bool isFailure, T successValue, IError error)
    {
        return isFailure ? Fail(error) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<T> FailIf(bool isFailure, T successValue, string errorMessage)
    {
        return isFailure ? Fail(errorMessage) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf(bool isFailure, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isFailure ? Fail(errorFactory.Invoke()) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf(bool isFailure, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isFailure ? Fail(errorMessageFactory.Invoke()) : Ok(successValue);
    }

    #endregion

    #region FailIf Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, T successValue, IError error)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, T successValue, string errorMessage)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, errorMessageFactory);
    }

    #endregion

    #region FailIf ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, T successValue, IError error)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, T successValue, string errorMessage)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, errorMessageFactory);
    }

    #endregion

}
