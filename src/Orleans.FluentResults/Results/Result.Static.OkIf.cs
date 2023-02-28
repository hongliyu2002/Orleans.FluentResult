namespace Orleans.FluentResults;

public partial record Result
{

    #region OkIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result OkIf(bool successCondition, IError error)
    {
        return successCondition ? Ok() : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result OkIf(bool successCondition, string errorMessage)
    {
        return successCondition ? Ok() : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool successCondition, Func<IError> errorFactory)
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
    public static Result OkIf(bool successCondition, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return successCondition ? Ok() : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, IError error)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string errorMessage)
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
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, Func<IError> errorFactory)
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
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
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
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, IError error)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string errorMessage)
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
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
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
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
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
    public static Result OkIf(bool successCondition, string successMessage, IError error)
    {
        return successCondition ? Ok(successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result OkIf(bool successCondition, string successMessage, string errorMessage)
    {
        return successCondition ? Ok(successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool successCondition, string successMessage, Func<IError> errorFactory)
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
    public static Result OkIf(bool successCondition, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return successCondition ? Ok(successMessage) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, IError error)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, string errorMessage)
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
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<IError> errorFactory)
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
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
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
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, IError error)
    {
        var successCondition = await predicate();
        return OkIf(successCondition, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, string errorMessage)
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
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<IError> errorFactory)
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
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var successCondition = await predicate();
        return OkIf(successCondition, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(bool successCondition, IError error)
    {
        return Result<T>.OkIf(successCondition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(bool successCondition, string errorMessage)
    {
        return Result<T>.OkIf(successCondition, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool successCondition, Func<IError> errorFactory)
    {
        return Result<T>.OkIf(successCondition, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool successCondition, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIf(successCondition, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, IError error)
    {
        return Result<T>.OkIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIfAsync(predicate, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, IError error)
    {
        return Result<T>.OkIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIfAsync(predicate, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(bool successCondition, string successMessage, IError error)
    {
        return Result<T>.OkIf(successCondition, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(bool successCondition, string successMessage, string errorMessage)
    {
        return Result<T>.OkIf(successCondition, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool successCondition, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIf(successCondition, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool successCondition, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIf(successCondition, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic ValueTask Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(bool successCondition, T successValue, IError error)
    {
        return Result<T>.OkIf(successCondition, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(bool successCondition, T successValue, string errorMessage)
    {
        return Result<T>.OkIf(successCondition, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool successCondition, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.OkIf(successCondition, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool successCondition, T successValue, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIf(successCondition, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(bool successCondition, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIf(successCondition, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(bool successCondition, T successValue, string successMessage, string errorMessage)
    {
        return Result<T>.OkIf(successCondition, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool successCondition, T successValue, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIf(successCondition, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool successCondition, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIf(successCondition, successValue, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic ValueTask Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorMessageFactory);
    }

    #endregion

}
