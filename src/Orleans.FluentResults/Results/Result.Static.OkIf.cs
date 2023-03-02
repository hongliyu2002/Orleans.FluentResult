namespace Orleans.FluentResults;

public partial record Result
{

    #region OkIf

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
    public static Result OkIf(bool successCondition, IError error)
    {
        return successCondition ? Ok() : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool successCondition, Exception exception)
    {
        return successCondition ? Ok() : Fail(exception);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result OkIf(Func<bool> successPredicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return successPredicate() ? Ok() : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result OkIf(Func<bool> successPredicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return successPredicate() ? Ok() : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result OkIf(Func<bool> successPredicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return successPredicate() ? Ok() : Fail(exception);
    }

    #endregion

    #region OkIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> successPredicate, string errorMessage)
    {
        return OkIf(await successPredicate(), errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> successPredicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return OkIf(await successPredicate(), error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> successPredicate, Exception exception)
    {
        return OkIf(await successPredicate(), exception);
    }

    #endregion

    #region OkIf ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> successPredicate, string errorMessage)
    {
        return OkIf(await successPredicate(), errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> successPredicate, IError error)
    {
        return OkIf(await successPredicate(), error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> successPredicate, Exception exception)
    {
        return OkIf(await successPredicate(), exception);
    }

    #endregion

    #region OkIf Generic

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
    public static Result<T> OkIf<T>(bool successCondition, IError error)
    {
        return Result<T>.OkIf(successCondition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool successCondition, Exception exception)
    {
        return Result<T>.OkIf(successCondition, exception);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(Func<bool> successPredicate, string errorMessage)
    {
        return Result<T>.OkIf(successPredicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(Func<bool> successPredicate, IError error)
    {
        return Result<T>.OkIf(successPredicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(Func<bool> successPredicate, Exception exception)
    {
        return Result<T>.OkIf(successPredicate, exception);
    }

    #endregion

    #region OkIf Generic Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> successPredicate, string errorMessage)
    {
        return Result<T>.OkIfAsync(successPredicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> successPredicate, IError error)
    {
        return Result<T>.OkIfAsync(successPredicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> successPredicate, Exception exception)
    {
        return Result<T>.OkIfAsync(successPredicate, exception);
    }

    #endregion

    #region OkIf Generic ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> successPredicate, string errorMessage)
    {
        return Result<T>.OkIfAsync(successPredicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> successPredicate, IError error)
    {
        return Result<T>.OkIfAsync(successPredicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> successPredicate, Exception exception)
    {
        return Result<T>.OkIfAsync(successPredicate, exception);
    }

    #endregion

    #region OkIf Generic With Value

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
    public static Result<T> OkIf<T>(bool successCondition, T successValue, IError error)
    {
        return Result<T>.OkIf(successCondition, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(bool successCondition, T successValue, Exception exception)
    {
        return Result<T>.OkIf(successCondition, successValue, exception);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(Func<bool> successPredicate, T successValue, string errorMessage)
    {
        return Result<T>.OkIf(successPredicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(Func<bool> successPredicate, T successValue, IError error)
    {
        return Result<T>.OkIf(successPredicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(Func<bool> successPredicate, T successValue, Exception exception)
    {
        return Result<T>.OkIf(successPredicate, successValue, exception);
    }

    #endregion

    #region OkIf Generic Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> successPredicate, T successValue, string errorMessage)
    {
        return Result<T>.OkIfAsync(successPredicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> successPredicate, T successValue, IError error)
    {
        return Result<T>.OkIfAsync(successPredicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> successPredicate, T successValue, Exception exception)
    {
        return Result<T>.OkIfAsync(successPredicate, successValue, exception);
    }

    #endregion

    #region OkIf Generic ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> successPredicate, T successValue, string errorMessage)
    {
        return Result<T>.OkIfAsync(successPredicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> successPredicate, T successValue, IError error)
    {
        return Result<T>.OkIfAsync(successPredicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> successPredicate, T successValue, Exception exception)
    {
        return Result<T>.OkIfAsync(successPredicate, successValue, exception);
    }

    #endregion

    #region OkIf Generic With Value With Success Message

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
    public static Result<T> OkIf<T>(bool successCondition, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIf(successCondition, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(bool successCondition, T successValue, string successMessage, Exception exception)
    {
        return Result<T>.OkIf(successCondition, successValue, successMessage, exception);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(Func<bool> successPredicate, T successValue, string successMessage, string errorMessage)
    {
        return Result<T>.OkIf(successPredicate, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(Func<bool> successPredicate, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIf(successPredicate, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf<T>(Func<bool> successPredicate, T successValue, string successMessage, Exception exception)
    {
        return Result<T>.OkIf(successPredicate, successValue, successMessage, exception);
    }

    #endregion

    #region OkIf Generic Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> successPredicate, T successValue, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(successPredicate, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> successPredicate, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(successPredicate, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> successPredicate, T successValue, string successMessage, Exception exception)
    {
        return Result<T>.OkIfAsync(successPredicate, successValue, successMessage, exception);
    }

    #endregion

    #region OkIf Generic ValueTask Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> successPredicate, T successValue, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(successPredicate, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> successPredicate, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(successPredicate, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> successPredicate, T successValue, string successMessage, Exception exception)
    {
        return Result<T>.OkIfAsync(successPredicate, successValue, successMessage, exception);
    }

    #endregion

}
