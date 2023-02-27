namespace Orleans.FluentResults;

public partial record Result<TValue>
{

    #region OkIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public new static Result<TValue> OkIf(bool isSuccess, Error error)
    {
        return isSuccess ? Ok() : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public new static Result<TValue> OkIf(bool isSuccess, string errorMessage)
    {
        return isSuccess ? Ok() : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public new static Result<TValue> OkIf(bool isSuccess, Func<Error> errorFactory)
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
    public new static Result<TValue> OkIf(bool isSuccess, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isSuccess ? Ok() : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public new static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public new static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, string errorMessage)
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
    public new static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, Func<Error> errorFactory)
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
    public new static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
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
    public new static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public new static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, string errorMessage)
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
    public new static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, Func<Error> errorFactory)
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
    public new static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
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
    public new static Result<TValue> OkIf(bool isSuccess, string successMessage, Error error)
    {
        return isSuccess ? Ok(successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public new static Result<TValue> OkIf(bool isSuccess, string successMessage, string errorMessage)
    {
        return isSuccess ? Ok(successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public new static Result<TValue> OkIf(bool isSuccess, string successMessage, Func<Error> errorFactory)
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
    public new static Result<TValue> OkIf(bool isSuccess, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isSuccess ? Ok(successMessage) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public new static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public new static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, string errorMessage)
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
    public new static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<Error> errorFactory)
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
    public new static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
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
    public new static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public new static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, string errorMessage)
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
    public new static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<Error> errorFactory)
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
    public new static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
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
    public static Result<TValue> OkIf(bool isSuccess, TValue successValue, Error error)
    {
        return isSuccess ? Ok(successValue) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<TValue> OkIf(bool isSuccess, TValue successValue, string errorMessage)
    {
        return isSuccess ? Ok(successValue) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> OkIf(bool isSuccess, TValue successValue, Func<Error> errorFactory)
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
    public static Result<TValue> OkIf(bool isSuccess, TValue successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isSuccess ? Ok(successValue) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, TValue successValue, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, TValue successValue, string errorMessage)
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
    public static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, TValue successValue, Func<Error> errorFactory)
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
    public static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, TValue successValue, Func<string> errorMessageFactory)
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
    public static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, TValue successValue, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, TValue successValue, string errorMessage)
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
    public static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, TValue successValue, Func<Error> errorFactory)
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
    public static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, TValue successValue, Func<string> errorMessageFactory)
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
    public static Result<TValue> OkIf(bool isSuccess, TValue successValue, string successMessage, Error error)
    {
        return isSuccess ? Ok(successValue, successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<TValue> OkIf(bool isSuccess, TValue successValue, string successMessage, string errorMessage)
    {
        return isSuccess ? Ok(successValue, successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> OkIf(bool isSuccess, TValue successValue, string successMessage, Func<Error> errorFactory)
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
    public static Result<TValue> OkIf(bool isSuccess, TValue successValue, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isSuccess ? Ok(successValue, successMessage) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, TValue successValue, string successMessage, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, TValue successValue, string successMessage, string errorMessage)
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
    public static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, TValue successValue, string successMessage, Func<Error> errorFactory)
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
    public static async Task<Result<TValue>> OkIfAsync(Func<Task<bool>> predicate, TValue successValue, string successMessage, Func<string> errorMessageFactory)
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
    public static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, TValue successValue, string successMessage, Error error)
    {
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, TValue successValue, string successMessage, string errorMessage)
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
    public static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, TValue successValue, string successMessage, Func<Error> errorFactory)
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
    public static async ValueTask<Result<TValue>> OkIfAsync(Func<ValueTask<bool>> predicate, TValue successValue, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isSuccess = await predicate();
        return OkIf(isSuccess, successValue, successMessage, errorMessageFactory);
    }

    #endregion

}
