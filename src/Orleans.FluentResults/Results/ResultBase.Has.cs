namespace Orleans.FluentResults;

public abstract partial class ResultBase
{

    #region Has Error

    /// <summary>
    ///     Check if the result object contains an error from a specific type
    /// </summary>
    public bool HasError<TError>()
        where TError : IError
    {
        return HasError<TError>(out _);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type
    /// </summary>
    public bool HasError<TError>(out IEnumerable<TError> result)
        where TError : IError
    {
        return HasError(_ => true, out result);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type and with a specific condition
    /// </summary>
    public bool HasError<TError>(Func<TError, bool> filter)
        where TError : IError
    {
        return HasError(filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type and with a specific condition
    /// </summary>
    public bool HasError<TError>(Func<TError, bool> filter, out IEnumerable<TError> result)
        where TError : IError
    {
        ArgumentNullException.ThrowIfNull(filter);
        return ResultHelper.HasError(Errors, filter, out result);
    }

    /// <summary>
    ///     Check if the result object contains an error with a specific condition
    /// </summary>
    public bool HasError(Func<IError, bool> filter)
    {
        return HasError(filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains an error with a specific condition
    /// </summary>
    public bool HasError(Func<IError, bool> filter, out IEnumerable<IError> result)
    {
        ArgumentNullException.ThrowIfNull(filter);
        return ResultHelper.HasError(Errors, filter, out result);
    }

    #endregion

    #region Has Exception

    /// <summary>
    ///     Check if the result object contains an exception from a specific type
    /// </summary>
    public bool HasException<TException>()
        where TException : Exception
    {
        return HasException<TException>(out _);
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type
    /// </summary>
    public bool HasException<TException>(out IEnumerable<IError> result)
        where TException : Exception
    {
        return HasException<TException>(_ => true, out result);
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type and with a specific condition
    /// </summary>
    public bool HasException<TException>(Func<TException, bool> filter)
        where TException : Exception
    {
        return HasException(filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type and with a specific condition
    /// </summary>
    public bool HasException<TException>(Func<TException, bool> filter, out IEnumerable<IError> result)
        where TException : Exception
    {
        ArgumentNullException.ThrowIfNull(filter);
        return ResultHelper.HasException(Errors, filter, out result);
    }

    #endregion

    #region Has Success

    /// <summary>
    ///     Check if the result object contains a success from a specific type
    /// </summary>
    public bool HasSuccess<TSuccess>()
        where TSuccess : ISuccess
    {
        return HasSuccess<TSuccess>(_ => true, out _);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type
    /// </summary>
    public bool HasSuccess<TSuccess>(out IEnumerable<TSuccess> result)
        where TSuccess : ISuccess
    {
        return HasSuccess(_ => true, out result);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type and with a specific condition
    /// </summary>
    public bool HasSuccess<TSuccess>(Func<TSuccess, bool> filter)
        where TSuccess : ISuccess
    {
        return HasSuccess(filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type and with a specific condition
    /// </summary>
    public bool HasSuccess<TSuccess>(Func<TSuccess, bool> filter, out IEnumerable<TSuccess> result)
        where TSuccess : ISuccess
    {
        return ResultHelper.HasSuccess(Successes, filter, out result);
    }

    /// <summary>
    ///     Check if the result object contains a success with a specific condition
    /// </summary>
    public bool HasSuccess(Func<ISuccess, bool> filter, out IEnumerable<ISuccess> result)
    {
        return ResultHelper.HasSuccess(Successes, filter, out result);
    }

    /// <summary>
    ///     Check if the result object contains a success with a specific condition
    /// </summary>
    public bool HasSuccess(Func<ISuccess, bool> filter)
    {
        return ResultHelper.HasSuccess(Successes, filter, out _);
    }

    #endregion

}
