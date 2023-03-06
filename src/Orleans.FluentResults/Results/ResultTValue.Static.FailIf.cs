namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region FailIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, string errorMessage)
    {
        return failureCondition ? Fail(errorMessage) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, IError error)
    {
        return failureCondition ? Fail(error) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, Exception exception)
    {
        return failureCondition ? Fail(exception) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(Func<bool> failurePredicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return failurePredicate() ? Fail(errorMessage) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(Func<bool> failurePredicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return failurePredicate() ? Fail(error) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(Func<bool> failurePredicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return failurePredicate() ? Fail(exception) : Ok();
    }

    #endregion

    #region FailIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> failurePredicate, string errorMessage, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> failurePredicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> failurePredicate, Exception exception, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), exception);
    }

    #endregion

    #region FailIf ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> failurePredicate, string errorMessage, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> failurePredicate, IError error, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> failurePredicate, Exception exception, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), exception);
    }

    #endregion

    #region FailIf With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, string errorMessage, T successValue)
    {
        return failureCondition ? Fail(errorMessage) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, IError error, T successValue)
    {
        return failureCondition ? Fail(error) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, Exception exception, T successValue)
    {
        return failureCondition ? Fail(exception) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(Func<bool> failurePredicate, string errorMessage, T successValue)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return failurePredicate() ? Fail(errorMessage) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(Func<bool> failurePredicate, IError error, T successValue)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return failurePredicate() ? Fail(error) : Ok(successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(Func<bool> failurePredicate, Exception exception, T successValue)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return failurePredicate() ? Fail(exception) : Ok(successValue);
    }

    #endregion

    #region FailIf Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> failurePredicate, string errorMessage, T successValue, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), errorMessage, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> failurePredicate, IError error, T successValue, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), error, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> failurePredicate, Exception exception, T successValue, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), exception, successValue);
    }

    #endregion

    #region FailIf ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> failurePredicate, string errorMessage, T successValue, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), errorMessage, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> failurePredicate, IError error, T successValue, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), error, successValue);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> failurePredicate, Exception exception, T successValue, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), exception, successValue);
    }

    #endregion

    #region FailIf With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, string errorMessage, T successValue, string successMessage)
    {
        return failureCondition ? Fail(errorMessage) : Ok(successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, IError error, T successValue, string successMessage)
    {
        return failureCondition ? Fail(error) : Ok(successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(bool failureCondition, Exception exception, T successValue, string successMessage)
    {
        return failureCondition ? Fail(exception) : Ok(successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(Func<bool> failurePredicate, string errorMessage, T successValue, string successMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return failurePredicate() ? Fail(errorMessage) : Ok(successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(Func<bool> failurePredicate, IError error, T successValue, string successMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return failurePredicate() ? Fail(error) : Ok(successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static Result<T> FailIf(Func<bool> failurePredicate, Exception exception, T successValue, string successMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(failurePredicate);
        return failurePredicate() ? Fail(exception) : Ok(successValue, successMessage);
    }

    #endregion

    #region FailIf Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> failurePredicate, string errorMessage, T successValue, string successMessage, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), errorMessage, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> failurePredicate, IError error, T successValue, string successMessage, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), error, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async Task<Result<T>> FailIfAsync(Func<Task<bool>> failurePredicate, Exception exception, T successValue, string successMessage, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), exception, successValue, successMessage);
    }

    #endregion

    #region FailIf ValueTask Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> failurePredicate, string errorMessage, T successValue, string successMessage, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), errorMessage, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> failurePredicate, IError error, T successValue, string successMessage, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), error, successValue, successMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter failureCondition
    /// </summary>
    public static async ValueTask<Result<T>> FailIfAsync(Func<ValueTask<bool>> failurePredicate, Exception exception, T successValue, string successMessage, bool configureAwait = true)
    {
        return FailIf(await failurePredicate().ConfigureAwait(configureAwait), exception, successValue, successMessage);
    }

    #endregion

}
