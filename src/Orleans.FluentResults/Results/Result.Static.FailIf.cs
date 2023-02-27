namespace Orleans.FluentResults;

public partial record Result
{

    #region FailIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result FailIf(bool isFailure, Error error)
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
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result FailIf(bool isFailure, Func<Error> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isFailure ? Fail(errorFactory.Invoke()) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
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
    public static async Task<Result> FailIfAsync(Func<Task<bool>> predicate, Error error)
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
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result> FailIfAsync(Func<Task<bool>> predicate, Func<Error> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
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
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> predicate, Error error)
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
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> predicate, Func<Error> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
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
    public static Result<TValue> FailIf<TValue>(bool isFailure, Error error)
    {
        return Result<TValue>.FailIf(isFailure, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<TValue> FailIf<TValue>(bool isFailure, string errorMessage)
    {
        return Result<TValue>.FailIf(isFailure, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> FailIf<TValue>(bool isFailure, Func<Error> errorFactory)
    {
        return Result<TValue>.FailIf(isFailure, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> FailIf<TValue>(bool isFailure, Func<string> errorMessageFactory)
    {
        return Result<TValue>.FailIf(isFailure, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Task<Result<TValue>> FailIfAsync<TValue>(Func<Task<bool>> predicate, Error error)
    {
        return Result<TValue>.FailIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Task<Result<TValue>> FailIfAsync<TValue>(Func<Task<bool>> predicate, string errorMessage)
    {
        return Result<TValue>.FailIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Task<Result<TValue>> FailIfAsync<TValue>(Func<Task<bool>> predicate, Func<Error> errorFactory)
    {
        return Result<TValue>.FailIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Task<Result<TValue>> FailIfAsync<TValue>(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
    {
        return Result<TValue>.FailIfAsync(predicate, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static ValueTask<Result<TValue>> FailIfAsync<TValue>(Func<ValueTask<bool>> predicate, Error error)
    {
        return Result<TValue>.FailIfAsync(predicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static ValueTask<Result<TValue>> FailIfAsync<TValue>(Func<ValueTask<bool>> predicate, string errorMessage)
    {
        return Result<TValue>.FailIfAsync(predicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<TValue>> FailIfAsync<TValue>(Func<ValueTask<bool>> predicate, Func<Error> errorFactory)
    {
        return Result<TValue>.FailIfAsync(predicate, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<TValue>> FailIfAsync<TValue>(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        return Result<TValue>.FailIfAsync(predicate, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<TValue> FailIf<TValue>(bool isFailure, TValue successValue, Error error)
    {
        return Result<TValue>.FailIf(isFailure, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<TValue> FailIf<TValue>(bool isFailure, TValue successValue, string errorMessage)
    {
        return Result<TValue>.FailIf(isFailure, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> FailIf<TValue>(bool isFailure, TValue successValue, Func<Error> errorFactory)
    {
        return Result<TValue>.FailIf(isFailure, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> FailIf<TValue>(bool isFailure, TValue successValue, Func<string> errorMessageFactory)
    {
        return Result<TValue>.FailIf(isFailure, successValue, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Task<Result<TValue>> FailIfAsync<TValue>(Func<Task<bool>> predicate, TValue successValue, Error error)
    {
        return Result<TValue>.FailIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Task<Result<TValue>> FailIfAsync<TValue>(Func<Task<bool>> predicate, TValue successValue, string errorMessage)
    {
        return Result<TValue>.FailIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Task<Result<TValue>> FailIfAsync<TValue>(Func<Task<bool>> predicate, TValue successValue, Func<Error> errorFactory)
    {
        return Result<TValue>.FailIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Task<Result<TValue>> FailIfAsync<TValue>(Func<Task<bool>> predicate, TValue successValue, Func<string> errorMessageFactory)
    {
        return Result<TValue>.FailIfAsync(predicate, successValue, errorMessageFactory);
    }

    #endregion

    #region FailIf Generic ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static ValueTask<Result<TValue>> FailIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue successValue, Error error)
    {
        return Result<TValue>.FailIfAsync(predicate, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static ValueTask<Result<TValue>> FailIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue successValue, string errorMessage)
    {
        return Result<TValue>.FailIfAsync(predicate, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<TValue>> FailIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue successValue, Func<Error> errorFactory)
    {
        return Result<TValue>.FailIfAsync(predicate, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static ValueTask<Result<TValue>> FailIfAsync<TValue>(Func<ValueTask<bool>> predicate, TValue successValue, Func<string> errorMessageFactory)
    {
        return Result<TValue>.FailIfAsync(predicate, successValue, errorMessageFactory);
    }

    #endregion

}
