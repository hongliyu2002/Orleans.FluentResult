﻿namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region OkIf

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, string errorMessage)
    {
        return successCondition ? Ok() : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, IError error)
    {
        return successCondition ? Ok() : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, Exception exception)
    {
        return successCondition ? Ok() : Fail(exception);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(Func<bool> successPredicate, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return successPredicate() ? Ok() : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(Func<bool> successPredicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return successPredicate() ? Ok() : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(Func<bool> successPredicate, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return successPredicate() ? Ok() : Fail(exception);
    }

    #endregion

    #region OkIf Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> successPredicate, string errorMessage, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> successPredicate, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> successPredicate, Exception exception, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), exception);
    }

    #endregion

    #region OkIf ValueTask Async

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> successPredicate, string errorMessage, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> successPredicate, IError error, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> successPredicate, Exception exception, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), exception);
    }

    #endregion

    #region OkIf With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, T successValue, string errorMessage)
    {
        return successCondition ? Ok(successValue) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, T successValue, IError error)
    {
        return successCondition ? Ok(successValue) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, T successValue, Exception exception)
    {
        return successCondition ? Ok(successValue) : Fail(exception);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(Func<bool> successPredicate, T successValue, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return successPredicate() ? Ok(successValue) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(Func<bool> successPredicate, T successValue, IError error)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return successPredicate() ? Ok(successValue) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(Func<bool> successPredicate, T successValue, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return successPredicate() ? Ok(successValue) : Fail(exception);
    }

    #endregion

    #region OkIf Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> successPredicate, T successValue, string errorMessage, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> successPredicate, T successValue, IError error, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> successPredicate, T successValue, Exception exception, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), successValue, exception);
    }

    #endregion

    #region OkIf ValueTask Async With Value

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> successPredicate, T successValue, string errorMessage, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), successValue, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> successPredicate, T successValue, IError error, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), successValue, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> successPredicate, T successValue, Exception exception, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), successValue, exception);
    }

    #endregion

    #region OkIf With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, T successValue, string successMessage, string errorMessage)
    {
        return successCondition ? Ok(successValue, successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, T successValue, string successMessage, IError error)
    {
        return successCondition ? Ok(successValue, successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(bool successCondition, T successValue, string successMessage, Exception exception)
    {
        return successCondition ? Ok(successValue, successMessage) : Fail(exception);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(Func<bool> successPredicate, T successValue, string successMessage, string errorMessage, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return successPredicate() ? Ok(successValue, successMessage) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(Func<bool> successPredicate, T successValue, string successMessage, IError error, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return successPredicate() ? Ok(successValue, successMessage) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static Result<T> OkIf(Func<bool> successPredicate, T successValue, string successMessage, Exception exception, bool configureAwait = true)
    {
        ArgumentNullException.ThrowIfNull(successPredicate);
        return successPredicate() ? Ok(successValue, successMessage) : Fail(exception);
    }

    #endregion

    #region OkIf Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> successPredicate, T successValue, string successMessage, string errorMessage, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> successPredicate, T successValue, string successMessage, IError error, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async Task<Result<T>> OkIfAsync(Func<Task<bool>> successPredicate, T successValue, string successMessage, Exception exception, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), successValue, successMessage, exception);
    }

    #endregion

    #region OkIf ValueTask Async With Value With Success Message

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> successPredicate, T successValue, string successMessage, string errorMessage, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), successValue, successMessage, errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> successPredicate, T successValue, string successMessage, IError error, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), successValue, successMessage, error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter successCondition
    /// </summary>
    public static async ValueTask<Result<T>> OkIfAsync(Func<ValueTask<bool>> successPredicate, T successValue, string successMessage, Exception exception, bool configureAwait = true)
    {
        return OkIf(await successPredicate().ConfigureAwait(configureAwait), successValue, successMessage, exception);
    }

    #endregion

}
