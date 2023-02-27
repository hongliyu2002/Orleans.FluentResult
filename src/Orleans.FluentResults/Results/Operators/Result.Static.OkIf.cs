namespace Orleans.FluentResults;

public partial record Result
{

    #region OkIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result OkIf(bool isSuccess, Error error)
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
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool isSuccess, Func<Error> errorFactory)
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
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, Error error)
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
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, Func<Error> errorFactory)
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
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, Error error)
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
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, Func<Error> errorFactory)
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
    public static Result OkIf(bool isSuccess, string successMessage, Error error)
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
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool isSuccess, string successMessage, Func<Error> errorFactory)
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
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Error error)
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
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<Error> errorFactory)
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
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Error error)
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
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<Error> errorFactory)
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
    public static Result<TValue> OkIf<TValue>(bool isSuccess, Error error)
    {
        return Result<TValue>.OkIf(isSuccess, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, string errorMessage)
    {
        return Result<TValue>.OkIf(isSuccess, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, Func<Error> errorFactory)
    {
        return Result<TValue>.OkIf(isSuccess, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, Func<string> errorMessageFactory)
    {
        return Result<TValue>.OkIf(isSuccess, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, Error error)
    {
        return Result<TValue>.OkIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, string errorMessage)
    {
        return Result<TValue>.OkIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, Func<Error> errorFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, Error error)
    {
        return Result<TValue>.OkIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        return Result<TValue>.OkIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, Func<Error> errorFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, string successMessage, Error error)
    {
        return Result<TValue>.OkIf(isSuccess, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, string successMessage, string errorMessage)
    {
        return Result<TValue>.OkIf(isSuccess, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, string successMessage, Func<Error> errorFactory)
    {
        return Result<TValue>.OkIf(isSuccess, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<TValue>.OkIf(isSuccess, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, string successMessage, Error error)
    {
        return Result<TValue>.OkIfAsync(predicate, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, string successMessage, string errorMessage)
    {
        return Result<TValue>.OkIfAsync(predicate, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, string successMessage, Func<Error> errorFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic ValueTask Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, string successMessage, Error error)
    {
        return Result<TValue>.OkIfAsync(predicate, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, string successMessage, string errorMessage)
    {
        return Result<TValue>.OkIfAsync(predicate, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, string successMessage, Func<Error> errorFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, TValue successValue, Error error)
    {
        return Result<TValue>.OkIf(isSuccess, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, TValue successValue, string errorMessage)
    {
        return Result<TValue>.OkIf(isSuccess, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, TValue successValue, Func<Error> errorFactory)
    {
        return Result<TValue>.OkIf(isSuccess, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, TValue successValue, Func<string> errorMessageFactory)
    {
        return Result<TValue>.OkIf(isSuccess, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, TValue successValue, Error error)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, TValue successValue, string errorMessage)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, TValue successValue, Func<Error> errorFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, TValue successValue, Func<string> errorMessageFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue successValue, Error error)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue successValue, string errorMessage)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue successValue, Func<Error> errorFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue successValue, Func<string> errorMessageFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, TValue successValue, string successMessage, Error error)
    {
        return Result<TValue>.OkIf(isSuccess, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, TValue successValue, string successMessage, string errorMessage)
    {
        return Result<TValue>.OkIf(isSuccess, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, TValue successValue, string successMessage, Func<Error> errorFactory)
    {
        return Result<TValue>.OkIf(isSuccess, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> OkIf<TValue>(bool isSuccess, TValue successValue, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<TValue>.OkIf(isSuccess, successValue, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, TValue successValue, string successMessage, Error error)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, TValue successValue, string successMessage, string errorMessage)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, TValue successValue, string successMessage, Func<Error> errorFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Task<Result<TValue>> OkIfAsync<TValue>(Func<Task<bool>> predicate, TValue successValue, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic ValueTask Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue successValue, string successMessage, Error error)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue successValue, string successMessage, string errorMessage)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue successValue, string successMessage, Func<Error> errorFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<TValue>> OkIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue successValue, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<TValue>.OkIfAsync(predicate, successValue, successMessage, errorMessageFactory);
    }

    #endregion

}
