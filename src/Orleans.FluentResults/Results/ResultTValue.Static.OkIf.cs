namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region OkIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, IError error)
    {
        return successCondition ? Ok() : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, string errorMessage)
    {
        return successCondition ? Ok() : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool successCondition, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return successCondition ? Ok() : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool successCondition, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return successCondition ? Ok() : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, IError error)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string errorMessage)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, errorMessageFactory);
    }

    #endregion

    #region OkIf ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, IError error)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, errorMessageFactory);
    }

    #endregion

    #region OkIf With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, string successMessage, IError error)
    {
        return successCondition ? Ok(successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, string successMessage, string errorMessage)
    {
        return successCondition ? Ok(successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool successCondition, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return successCondition ? Ok(successMessage) : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool successCondition, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return successCondition ? Ok(successMessage) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, IError error)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, string errorMessage)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf ValueTask Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, IError error)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, string errorMessage)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, T successValue, IError error)
    {
        return successCondition ? Ok(successValue) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, T successValue, string errorMessage)
    {
        return successCondition ? Ok(successValue) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool successCondition, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return successCondition ? Ok(successValue) : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool successCondition, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return successCondition ? Ok(successValue) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, IError error)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string errorMessage)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, IError error)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string errorMessage)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, T successValue, string successMessage, IError error)
    {
        return successCondition ? Ok(successValue, successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, T successValue, string successMessage, string errorMessage)
    {
        return successCondition ? Ok(successValue, successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool successCondition, T successValue, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return successCondition ? Ok(successValue, successMessage) : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool successCondition, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return successCondition ? Ok(successValue, successMessage) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string successMessage, IError error)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string successMessage, string errorMessage)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf ValueTask Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string successMessage, IError error)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string successMessage, string errorMessage)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successValue, successMessage, errorMessageFactory);
    }

    #endregion

}
