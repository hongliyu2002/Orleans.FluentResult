namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region OkIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf(bool condition, IError error)
    {
        return condition ? Ok() : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf(bool condition, string errorMessage)
    {
        return condition ? Ok() : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool condition, Func<IError> errorFactory)
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
    public static Result<T> OkIf(bool condition, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return condition ? Ok() : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, IError error)
    {
        var condition = await predicate();
        return OkIf(condition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string errorMessage)
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
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, Func<IError> errorFactory)
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
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
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
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, IError error)
    {
        var condition = await predicate();
        return OkIf(condition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string errorMessage)
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
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
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
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
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
    public static Result<T> OkIf(bool condition, string successMessage, IError error)
    {
        return condition ? Ok(default!, successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf(bool condition, string successMessage, string errorMessage)
    {
        return condition ? Ok(default!, successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool condition, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return condition ? Ok(default!, successMessage) : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool condition, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return condition ? Ok(default!, successMessage) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, IError error)
    {
        var condition = await predicate();
        return OkIf(condition, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, string errorMessage)
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
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<IError> errorFactory)
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
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
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
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, IError error)
    {
        var condition = await predicate();
        return OkIf(condition, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, string errorMessage)
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
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<IError> errorFactory)
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
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var condition = await predicate();
        return OkIf(condition, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf(bool condition, T successValue, IError error)
    {
        return condition ? Ok(successValue) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf(bool condition, T successValue, string errorMessage)
    {
        return condition ? Ok(successValue) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool condition, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return condition ? Ok(successValue) : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool condition, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return condition ? Ok(successValue) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, IError error)
    {
        var condition = await predicate();
        return OkIf(condition, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string errorMessage)
    {
        var condition = await predicate();
        return OkIf(condition, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var condition = await predicate();
        return OkIf(condition, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var condition = await predicate();
        return OkIf(condition, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, IError error)
    {
        var condition = await predicate();
        return OkIf(condition, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string errorMessage)
    {
        var condition = await predicate();
        return OkIf(condition, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var condition = await predicate();
        return OkIf(condition, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var condition = await predicate();
        return OkIf(condition, successValue, errorMessageFactory);
    }

    #endregion

    #region OkIf With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf(bool condition, T successValue, string successMessage, IError error)
    {
        return condition ? Ok(successValue, successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static Result<T> OkIf(bool condition, T successValue, string successMessage, string errorMessage)
    {
        return condition ? Ok(successValue, successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool condition, T successValue, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return condition ? Ok(successValue, successMessage) : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> OkIf(bool condition, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return condition ? Ok(successValue, successMessage) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region OkIf Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string successMessage, IError error)
    {
        var condition = await predicate();
        return OkIf(condition, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string successMessage, string errorMessage)
    {
        var condition = await predicate();
        return OkIf(condition, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var condition = await predicate();
        return OkIf(condition, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> predicate, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var condition = await predicate();
        return OkIf(condition, successValue, successMessage, errorMessageFactory);
    }

    #endregion

    #region OkIf ValueTask Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string successMessage, IError error)
    {
        var condition = await predicate();
        return OkIf(condition, successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string successMessage, string errorMessage)
    {
        var condition = await predicate();
        return OkIf(condition, successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string successMessage, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var condition = await predicate();
        return OkIf(condition, successValue, successMessage, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter condition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> predicate, T successValue, string successMessage, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var condition = await predicate();
        return OkIf(condition, successValue, successMessage, errorMessageFactory);
    }

    #endregion

}
