namespace Orleans.FluentResults;

public static partial class ResultExtensions
{

    #region Has Error

    /// <summary>
    ///     Check if the result object contains an error from a specific type
    /// </summary>
    public static bool HasError<TError>(this Result result)
        where TError : IError
    {
        return HasError<TError>(result, out _);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type
    /// </summary>
    public static bool HasError<TError>(this Result result, out IEnumerable<TError> foundErrors)
        where TError : IError
    {
        return HasError(result, _ => true, out foundErrors);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type and with a specific condition
    /// </summary>
    public static bool HasError<TError>(this Result result, Func<TError, bool> filter)
        where TError : IError
    {
        return HasError(result, filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type and with a specific condition
    /// </summary>
    public static bool HasError<TError>(this Result result, Func<TError, bool> filter, out IEnumerable<TError> foundErrors)
        where TError : IError
    {
        ArgumentNullException.ThrowIfNull(filter);
        return ResultHelper.HasError(result.Errors, filter, out foundErrors);
    }

    /// <summary>
    ///     Check if the result object contains an error with a specific condition
    /// </summary>
    public static bool HasError(this Result result, Func<IError, bool> filter)
    {
        return HasError(result, filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains an error with a specific condition
    /// </summary>
    public static bool HasError(this Result result, Func<IError, bool> filter, out IEnumerable<IError> foundErrors)
    {
        ArgumentNullException.ThrowIfNull(filter);
        return ResultHelper.HasError(result.Errors, filter, out foundErrors);
    }

    #endregion

    #region Has Exception

    /// <summary>
    ///     Check if the result object contains an exception from a specific type
    /// </summary>
    public static bool HasException<TException>(this Result result)
        where TException : Exception
    {
        return HasException<TException>(result, out _);
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type
    /// </summary>
    public static bool HasException<TException>(this Result result, out IEnumerable<IError> foundErrors)
        where TException : Exception
    {
        return HasException<TException>(result, _ => true, out foundErrors);
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type and with a specific condition
    /// </summary>
    public static bool HasException<TException>(this Result result, Func<TException, bool> filter)
        where TException : Exception
    {
        return HasException(result, filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type and with a specific condition
    /// </summary>
    public static bool HasException<TException>(this Result result, Func<TException, bool> filter, out IEnumerable<IError> foundErrors)
        where TException : Exception
    {
        ArgumentNullException.ThrowIfNull(filter);
        return ResultHelper.HasException(result.Errors, filter, out foundErrors);
    }

    #endregion

    #region Has Success

    /// <summary>
    ///     Check if the result object contains a success from a specific type
    /// </summary>
    public static bool HasSuccess<TSuccess>(this Result result)
        where TSuccess : ISuccess
    {
        return HasSuccess<TSuccess>(result, _ => true, out _);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type
    /// </summary>
    public static bool HasSuccess<TSuccess>(this Result result, out IEnumerable<TSuccess> foundSuccesses)
        where TSuccess : ISuccess
    {
        return HasSuccess(result, _ => true, out foundSuccesses);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type and with a specific condition
    /// </summary>
    public static bool HasSuccess<TSuccess>(this Result result, Func<TSuccess, bool> filter)
        where TSuccess : ISuccess
    {
        return HasSuccess(result, filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type and with a specific condition
    /// </summary>
    public static bool HasSuccess<TSuccess>(this Result result, Func<TSuccess, bool> filter, out IEnumerable<TSuccess> foundSuccesses)
        where TSuccess : ISuccess
    {
        return ResultHelper.HasSuccess(result.Successes, filter, out foundSuccesses);
    }

    /// <summary>
    ///     Check if the result object contains a success with a specific condition
    /// </summary>
    public static bool HasSuccess(this Result result, Func<ISuccess, bool> filter, out IEnumerable<ISuccess> foundSuccesses)
    {
        return ResultHelper.HasSuccess(result.Successes, filter, out foundSuccesses);
    }

    /// <summary>
    ///     Check if the result object contains a success with a specific condition
    /// </summary>
    public static bool HasSuccess(this Result result, Func<ISuccess, bool> filter)
    {
        return ResultHelper.HasSuccess(result.Successes, filter, out _);
    }

    #endregion

}
