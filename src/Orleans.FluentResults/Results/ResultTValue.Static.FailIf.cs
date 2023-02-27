namespace Orleans.FluentResults;

public partial record Result<TValue>
{

    #region FailIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public new static Result<TValue> FailIf(bool isFailure, Error error)
    {
        return isFailure ? Fail(error) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public new static Result<TValue> FailIf(bool isFailure, string errorMessage)
    {
        return isFailure ? Fail(errorMessage) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public new static Result<TValue> FailIf(bool isFailure, Func<Error> errorFactory)
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
    public new static Result<TValue> FailIf(bool isFailure, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isFailure ? Fail(errorMessageFactory.Invoke()) : Ok();
    }

    #endregion

    #region FailIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public new static async Task<Result<TValue>> FailIfAsync(Func<Task<bool>> predicate, Error error)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public new static async Task<Result<TValue>> FailIfAsync(Func<Task<bool>> predicate, string errorMessage)
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
    public new static async Task<Result<TValue>> FailIfAsync(Func<Task<bool>> predicate, Func<Error> errorFactory)
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
    public new static async Task<Result<TValue>> FailIfAsync(Func<Task<bool>> predicate, Func<string> errorMessageFactory)
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
    public new static async ValueTask<Result<TValue>> FailIfAsync(Func<ValueTask<bool>> predicate, Error error)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public new static async ValueTask<Result<TValue>> FailIfAsync(Func<ValueTask<bool>> predicate, string errorMessage)
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
    public new static async ValueTask<Result<TValue>> FailIfAsync(Func<ValueTask<bool>> predicate, Func<Error> errorFactory)
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
    public new static async ValueTask<Result<TValue>> FailIfAsync(Func<ValueTask<bool>> predicate, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, errorMessageFactory);
    }

    #endregion

    #region FailIf With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<TValue> FailIf(bool isFailure, TValue successValue, Error error)
    {
        return isFailure ? Fail(error) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<TValue> FailIf(bool isFailure, TValue successValue, string errorMessage)
    {
        return isFailure ? Fail(errorMessage) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> FailIf(bool isFailure, TValue successValue, Func<Error> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isFailure ? Fail(errorFactory.Invoke()) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> FailIf(bool isFailure, TValue successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isFailure ? Fail(errorMessageFactory.Invoke()) : Ok(successValue);
    }

    #endregion

    #region FailIf Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async Task<Result<TValue>> FailIfAsync(Func<Task<bool>> predicate, TValue successValue, Error error)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async Task<Result<TValue>> FailIfAsync(Func<Task<bool>> predicate, TValue successValue, string errorMessage)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result<TValue>> FailIfAsync(Func<Task<bool>> predicate, TValue successValue, Func<Error> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async Task<Result<TValue>> FailIfAsync(Func<Task<bool>> predicate, TValue successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, errorMessageFactory);
    }

    #endregion

    #region FailIf ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async ValueTask<Result<TValue>> FailIfAsync(Func<ValueTask<bool>> predicate, TValue successValue, Error error)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static async ValueTask<Result<TValue>> FailIfAsync(Func<ValueTask<bool>> predicate, TValue successValue, string errorMessage)
    {
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<TValue>> FailIfAsync(Func<ValueTask<bool>> predicate, TValue successValue, Func<Error> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, errorFactory);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static async ValueTask<Result<TValue>> FailIfAsync(Func<ValueTask<bool>> predicate, TValue successValue, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        var isFailure = await predicate();
        return FailIf(isFailure, successValue, errorMessageFactory);
    }

    #endregion

}
