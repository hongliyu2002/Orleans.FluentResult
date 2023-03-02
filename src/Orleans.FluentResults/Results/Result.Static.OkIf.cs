namespace Orleans.FluentResults;

public partial record Result
{

    #region OkIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result OkIf(bool condition, IError error)
    {
        return condition ? Ok() : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result OkIf(bool condition, string errorMessage)
    {
        return condition ? Ok() : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool condition, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return condition ? Ok() : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool condition, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return condition ? Ok() : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, IError error)
    {
        var condition = await predicate();
        return OkIf(condition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string errorMessage)
    {
        var condition = await predicate();
        return OkIf(condition, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var condition = await predicate();
        return OkIf(condition, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var condition = await predicate();
        return OkIf(condition, errorMessageFactory);
    }

    #endregion

    #region OkIf ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, IError error)
    {
        var condition = await predicate();
        return OkIf(condition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        var condition = await predicate();
        return OkIf(condition, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var condition = await predicate();
        return OkIf(condition, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var condition = await predicate();
        return OkIf(condition, errorMessageFactory);
    }

    #endregion

    #region OkIf With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result OkIf(bool condition, string successMessage, IError error)
    {
        return condition ? Ok(successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result OkIf(bool condition, string successMessage, string errorMessage)
    {
        return condition ? Ok(successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool condition, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return condition ? Ok(successMessage) : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool condition, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return condition ? Ok(successMessage) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, IError error)
    {
        var condition = await predicate();
        return OkIf(condition, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, string errorMessage)
    {
        var condition = await predicate();
        return OkIf(condition, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var condition = await predicate();
        return OkIf(condition, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var condition = await predicate();
        return OkIf(condition, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf ValueTask Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, IError error)
    {
        var condition = await predicate();
        return OkIf(condition, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, string errorMessage)
    {
        var condition = await predicate();
        return OkIf(condition, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var condition = await predicate();
        return OkIf(condition, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var condition = await predicate();
        return OkIf(condition, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf<T>(bool condition, IError error)
    {
        return Result<T>.OkIf(condition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf<T>(bool condition, string errorMessage)
    {
        return Result<T>.OkIf(condition, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool condition, Func<IError> errorFactory)
    {
        return Result<T>.OkIf(condition, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool condition, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIf(condition, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, IError error)
    {
        return Result<T>.OkIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
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
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, IError error)
    {
        return Result<T>.OkIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
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
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf<T>(bool condition, string successMessage, IError error)
    {
        return Result<T>.OkIf(condition, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf<T>(bool condition, string successMessage, string errorMessage)
    {
        return Result<T>.OkIf(condition, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool condition, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIf(condition, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool condition, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIf(condition, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
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
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
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
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf<T>(bool condition, T successValue, IError error)
    {
        return Result<T>.OkIf(condition, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf<T>(bool condition, T successValue, string errorMessage)
    {
        return Result<T>.OkIf(condition, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool condition, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.OkIf(condition, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool condition, T successValue, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIf(condition, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
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
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
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
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf<T>(bool condition, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIf(condition, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf<T>(bool condition, T successValue, string successMessage, string errorMessage)
    {
        return Result<T>.OkIf(condition, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool condition, T successValue, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIf(condition, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf<T>(bool condition, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        return Result<T>.OkIf(condition, successValue, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf Generic Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> OkIfAsync<T>(Func<Task<bool>> predicate, T successValue, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
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
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string successMessage, IError error)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string successMessage, string errorMessage)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> OkIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string successMessage, Func<IError> errorFactory)
    {
        return Result<T>.OkIfAsync(predicate, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
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
