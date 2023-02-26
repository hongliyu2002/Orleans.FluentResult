namespace Orleans.FluentResults;

public partial record Result
{

    #region Has Error

    /// <summary>
    ///     Check if the result object contains an error from a specific type
    /// </summary>
    public bool HasError<TError>()
        where TError : Error
    {
        return HasError<TError>(out _);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type
    /// </summary>
    public bool HasError<TError>(out IEnumerable<TError> result)
        where TError : Error
    {
        return HasError(_ => true, out result);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type and with a specific condition
    /// </summary>
    public bool HasError<TError>(Func<TError, bool> filter)
        where TError : Error
    {
        return HasError(filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type and with a specific condition
    /// </summary>
    public bool HasError<TError>(Func<TError, bool> filter, out IEnumerable<TError> result)
        where TError : Error
    {
        ArgumentNullException.ThrowIfNull(filter);
        return ResultHelper.HasError(Errors, filter, out result);
    }

    /// <summary>
    ///     Check if the result object contains an error with a specific condition
    /// </summary>
    public bool HasError(Func<Error, bool> filter)
    {
        return HasError(filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains an error with a specific condition
    /// </summary>
    public bool HasError(Func<Error, bool> filter, out IEnumerable<Error> result)
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
    public bool HasException<TException>(out IEnumerable<Error> result)
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
    public bool HasException<TException>(Func<TException, bool> filter, out IEnumerable<Error> result)
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
        where TSuccess : Success
    {
        return HasSuccess<TSuccess>(_ => true, out _);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type
    /// </summary>
    public bool HasSuccess<TSuccess>(out IEnumerable<TSuccess> result)
        where TSuccess : Success
    {
        return HasSuccess(_ => true, out result);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type and with a specific condition
    /// </summary>
    public bool HasSuccess<TSuccess>(Func<TSuccess, bool> filter)
        where TSuccess : Success
    {
        return HasSuccess(filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type and with a specific condition
    /// </summary>
    public bool HasSuccess<TSuccess>(Func<TSuccess, bool> filter, out IEnumerable<TSuccess> result)
        where TSuccess : Success
    {
        return ResultHelper.HasSuccess(Successes, filter, out result);
    }

    /// <summary>
    ///     Check if the result object contains a success with a specific condition
    /// </summary>
    public bool HasSuccess(Func<Success, bool> filter, out IEnumerable<Success> result)
    {
        return ResultHelper.HasSuccess(Successes, filter, out result);
    }

    /// <summary>
    ///     Check if the result object contains a success with a specific condition
    /// </summary>
    public bool HasSuccess(Func<Success, bool> filter)
    {
        return ResultHelper.HasSuccess(Successes, filter, out _);
    }

    #endregion

}
