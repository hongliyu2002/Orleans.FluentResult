namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region OkIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf(bool isSuccess, Error error)
    {
        return isSuccess ? Ok() : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf(bool isSuccess, string errorMessage)
    {
        return isSuccess ? Ok() : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool isSuccess, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isSuccess ? Ok() : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool isSuccess, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isSuccess ? Ok() : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string errorMessage)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
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
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
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
    public static Result<T> OkIf(bool isSuccess, string successMessage, Error error)
    {
        return isSuccess ? Ok(successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf(bool isSuccess, string successMessage, string errorMessage)
    {
        return isSuccess ? Ok(successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool isSuccess, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isSuccess ? Ok(successMessage) : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool isSuccess, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isSuccess ? Ok(successMessage) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, string errorMessage)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
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
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, string errorMessage)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf(bool isSuccess, T successValue, Error error)
    {
        return isSuccess ? Ok(successValue) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf(bool isSuccess, T successValue, string errorMessage)
    {
        return isSuccess ? Ok(successValue) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool isSuccess, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isSuccess ? Ok(successValue) : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool isSuccess, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isSuccess ? Ok(successValue) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string errorMessage)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string errorMessage)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf(bool isSuccess, T successValue, string successMessage, Error error)
    {
        return isSuccess ? Ok(successValue, successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<T> OkIf(bool isSuccess, T successValue, string successMessage, string errorMessage)
    {
        return isSuccess ? Ok(successValue, successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool isSuccess, T successValue, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isSuccess ? Ok(successValue, successMessage) : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool isSuccess, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isSuccess ? Ok(successValue, successMessage) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string successMessage, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string successMessage, string errorMessage)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf ValueTask Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string successMessage, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string successMessage, string errorMessage)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, successMessage, errorMessageFactory);
    }

    #endregion

}
