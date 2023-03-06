namespace Orleans.FluentResults;

public partial record Result
{

    #region FailIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result FailIf(bool failureCondition, string errorMessage)
    {
        return failureCondition ? Fail(errorMessage) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result FailIf(bool failureCondition, IError error)
    {
        return failureCondition ? Fail(error) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    /// <remarks>
    ///     IError is lazily evaluated.
    /// </remarks>
    public static Result FailIf(bool failureCondition, Exception exception)
    {
        return failureCondition ? Fail(exception) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result FailIf(Func<bool> failurePredicate, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return failurePredicate() ? Fail(errorMessage) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result FailIf(Func<bool> failurePredicate, IError error)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return failurePredicate() ? Fail(error) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result FailIf(Func<bool> failurePredicate, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return failurePredicate() ? Fail(exception) : Ok();
    }

    #endregion

    #region FailIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result> FailIfAsync(Func<Task<bool>> failurePredicate, string errorMessage, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result> FailIfAsync(Func<Task<bool>> failurePredicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result> FailIfAsync(Func<Task<bool>> failurePredicate, Exception exception, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), exception);
    }

    #endregion

    #region FailIf ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> failurePredicate, string errorMessage, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> failurePredicate, IError error, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result> FailIfAsync(Func<ValueTask<bool>> failurePredicate, Exception exception, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), exception);
    }

    #endregion

    #region FailIf Generic

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, string errorMessage)
    {
        return Result<T>.FailIf(failureCondition, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, IError error)
    {
        return Result<T>.FailIf(failureCondition, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, Exception exception)
    {
        return Result<T>.FailIf(failureCondition, exception);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(Func<bool> failurePredicate, string errorMessage)
    {
        return Result<T>.FailIf(failurePredicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(Func<bool> failurePredicate, IError error)
    {
        return Result<T>.FailIf(failurePredicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(Func<bool> failurePredicate, Exception exception)
    {
        return Result<T>.FailIf(failurePredicate, exception);
    }

    #endregion

    #region FailIf Generic Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> failurePredicate, string errorMessage, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> failurePredicate, IError error, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> failurePredicate, Exception exception, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, exception);
    }

    #endregion

    #region FailIf Generic ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> failurePredicate, string errorMessage, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> failurePredicate, IError error, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> failurePredicate, Exception exception, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, exception);
    }

    #endregion

    #region FailIf Generic With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, string errorMessage, T successValue)
    {
        return Result<T>.FailIf(failureCondition, errorMessage, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, IError error, T successValue)
    {
        return Result<T>.FailIf(failureCondition, error, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, Exception exception, T successValue)
    {
        return Result<T>.FailIf(failureCondition, exception, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(Func<bool> failurePredicate, string errorMessage, T successValue)
    {
        return Result<T>.FailIf(failurePredicate, errorMessage, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(Func<bool> failurePredicate, IError error, T successValue)
    {
        return Result<T>.FailIf(failurePredicate, error, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(Func<bool> failurePredicate, Exception exception, T successValue)
    {
        return Result<T>.FailIf(failurePredicate, exception, successValue);
    }

    #endregion

    #region FailIf Generic Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> failurePredicate, string errorMessage, T successValue, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, errorMessage, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> failurePredicate, IError error, T successValue, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, error, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> failurePredicate, Exception exception, T successValue, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, exception, successValue);
    }

    #endregion

    #region FailIf Generic ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> failurePredicate, string errorMessage, T successValue, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, errorMessage, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> failurePredicate, IError error, T successValue, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, error, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> failurePredicate, Exception exception, T successValue, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, exception, successValue);
    }

    #endregion

    #region FailIf Generic With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, string errorMessage, T successValue, string successMessage)
    {
        return Result<T>.FailIf(failureCondition, errorMessage, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, IError error, T successValue, string successMessage)
    {
        return Result<T>.FailIf(failureCondition, error, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(bool failureCondition, Exception exception, T successValue, string successMessage)
    {
        return Result<T>.FailIf(failureCondition, exception, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(Func<bool> failurePredicate, string errorMessage, T successValue, string successMessage, bool configureAwait = true)
    {
        return Result<T>.FailIf(failurePredicate, errorMessage, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(Func<bool> failurePredicate, IError error, T successValue, string successMessage, bool configureAwait = true)
    {
        return Result<T>.FailIf(failurePredicate, error, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf<T>(Func<bool> failurePredicate, Exception exception, T successValue, string successMessage, bool configureAwait = true)
    {
        return Result<T>.FailIf(failurePredicate, exception, successValue, successMessage);
    }

    #endregion

    #region FailIf Generic Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> failurePredicate, string errorMessage, T successValue, string successMessage, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, errorMessage, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> failurePredicate, IError error, T successValue, string successMessage, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, error, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Task<Result<T>> FailIfAsync<T>(Func<Task<bool>> failurePredicate, Exception exception, T successValue, string successMessage, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, exception, successValue, successMessage);
    }

    #endregion

    #region FailIf Generic ValueTask Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> failurePredicate, string errorMessage, T successValue, string successMessage, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, errorMessage, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> failurePredicate, IError error, T successValue, string successMessage, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, error, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static ValueTask<Result<T>> FailIfAsync<T>(Func<ValueTask<bool>> failurePredicate, Exception exception, T successValue, string successMessage, bool configureAwait = true)
    {
        return Result<T>.FailIfAsync(failurePredicate, exception, successValue, successMessage);
    }

    #endregion

}
