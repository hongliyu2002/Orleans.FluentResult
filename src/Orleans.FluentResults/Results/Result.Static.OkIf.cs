namespace Orleans.FluentResults;

public partial record Result
{

    #region OkIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result OkIf(bool isSuccess, IError error)
    {
        return isSuccess ? Ok() : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result OkIf(bool isSuccess, string errorMessage)
    {
        return isSuccess ? Ok() : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool isSuccess, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isSuccess ? Ok() : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool isSuccess, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isSuccess ? Ok() : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, IError error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string errorMessage)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, errorMessageFactory);
    }

    #endregion

    #region OkIf ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, IError error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, errorMessageFactory);
    }

    #endregion

    #region OkIf With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result OkIf(bool isSuccess, string successMessage, IError error)
    {
        return isSuccess ? Ok(successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result OkIf(bool isSuccess, string successMessage, string errorMessage)
    {
        return isSuccess ? Ok(successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool isSuccess, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isSuccess ? Ok(successMessage) : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool isSuccess, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isSuccess ? Ok(successMessage) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, IError error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, string errorMessage)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf ValueTask Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, IError error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, string errorMessage)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf<T>(bool isSuccess, IError error)
    {
        return Result<T>.OkIf(isSuccess, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf<T>(bool isSuccess, string errorMessage)
    {
        return Result<T>.OkIf(isSuccess, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool isSuccess, Func<IError> errorFactory)
    {
        return Result<T>.OkIf(isSuccess, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool isSuccess, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIf(isSuccess, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, IError error)
    {
        return Result<T>.OkIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
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
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, IError error)
    {
        return Result<T>.OkIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
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
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf<T>(bool isSuccess, string successMessage, IError error)
    {
        return Result<T>.OkIf(isSuccess, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf<T>(bool isSuccess, string successMessage, string errorMessage)
    {
        return Result<T>.OkIf(isSuccess, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool isSuccess, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIf(isSuccess, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool isSuccess, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIf(isSuccess, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
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
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
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
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf<T>(bool isSuccess, T successValue, IError error)
    {
        return Result<T>.OkIf(isSuccess, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf<T>(bool isSuccess, T successValue, string errorMessage)
    {
        return Result<T>.OkIf(isSuccess, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool isSuccess, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.OkIf(isSuccess, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool isSuccess, T successValue, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIf(isSuccess, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
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
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
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
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf<T>(bool isSuccess, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIf(isSuccess, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf<T>(bool isSuccess, T successValue, string successMessage, string errorMessage)
    {
        return Result<T>.OkIf(isSuccess, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool isSuccess, T successValue, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIf(isSuccess, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool isSuccess, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIf(isSuccess, successValue, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
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
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
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
