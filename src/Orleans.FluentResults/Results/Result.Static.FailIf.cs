namespace Orleans.FluentResults;

public partial record Result
{

    #region FailIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result FailIf(bool isFailure, IError error)
    {
        return isFailure ? Fail(error) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result FailIf(bool isFailure, string errorMessage)
    {
        return isFailure ? Fail(errorMessage) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result FailIf(bool isFailure, Func<IError> errorFactory)
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
    public static Result FailIf(bool isFailure, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isFailure ? Fail(errorMessageFactory.Invoke()) : Ok();
    }

    #endregion

    #region FailIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async Task<Result> FailIfAsync(Func<Task<bool>> predicate, IError error)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async Task<Result> FailIfAsync(Func<Task<bool>> predicate, string errorMessage)
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
    public static async Task<Result> FailIfAsync(Func<Task<bool>> predicate, Func<IError> errorFactory)
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
    public static async Task<Result> FailIfAsync(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
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
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> predicate, IError error)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> predicate, string errorMessage)
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
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
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
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<T> FailIf<T>(bool isFailure, IError error)
    {
        return Result<T>.FailIf(isFailure, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<T> FailIf<T>(bool isFailure, string errorMessage)
    {
        return Result<T>.FailIf(isFailure, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf<T>(bool isFailure, Func<IError> errorFactory)
    {
        return Result<T>.FailIf(isFailure, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf<T>(bool isFailure, Func<string> errorMessageFactory)
    {
        return Result<T>.FailIf(isFailure, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, IError error)
    {
        return Result<T>.FailIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, string errorMessage)
    {
        return Result<T>.FailIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, Func<IError> errorFactory)
    {
        return Result<T>.FailIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
    {
        return Result<T>.FailIfAsync(predicate, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, IError error)
    {
        return Result<T>.FailIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        return Result<T>.FailIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, Func<IError> errorFactory)
    {
        return Result<T>.FailIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        return Result<T>.FailIfAsync(predicate, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<T> FailIf<T>(bool isFailure, T successValue, IError error)
    {
        return Result<T>.FailIf(isFailure, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<T> FailIf<T>(bool isFailure, T successValue, string errorMessage)
    {
        return Result<T>.FailIf(isFailure, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf<T>(bool isFailure, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.FailIf(isFailure, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result<T> FailIf<T>(bool isFailure, T successValue, Func<string> errorMessageFactory)
    {
        return Result<T>.FailIf(isFailure, successValue, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, T successValue, IError error)
    {
        return Result<T>.FailIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, T successValue, string errorMessage)
    {
        return Result<T>.FailIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.FailIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        return Result<T>.FailIfAsync(predicate, successValue, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, IError error)
    {
        return Result<T>.FailIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, string errorMessage)
    {
        return Result<T>.FailIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, Func<IError> errorFactory)
    {
        return Result<T>.FailIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> predicate, T successValue, Func<string> errorMessageFactory)
    {
        return Result<T>.FailIfAsync(predicate, successValue, errorMessageFactory);
    }

    #endregion

}
