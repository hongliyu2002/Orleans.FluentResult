namespace Orleans.FluentResults;

public static partial class ResultTValueExtensions
{

    #region Has Error

    /// <summary>
    ///     Check if the result object contains an error from a specific type
    /// </summary>
    public static bool HasError<T, TError>(this Result<T> result)
        where TError : IError
    {
        return HasError<T, TError>(result, out _);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type
    /// </summary>
    public static bool HasError<T, TError>(this Result<T> result, out IEnumerable<TError> foundErrors)
        where TError : IError
    {
        return HasError(result, _ => true, out foundErrors);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type and with a specific condition
    /// </summary>
    public static bool HasError<T, TError>(this Result<T> result, Func<TError, bool> filter)
        where TError : IError
    {
        return HasError(result, filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type and with a specific condition
    /// </summary>
    public static bool HasError<T, TError>(this Result<T> result, Func<TError, bool> filter, out IEnumerable<TError> foundErrors)
        where TError : IError
    {
        ArgumentNullException.ThrowIfNull(filter);
        return ResultHelper.HasError(result.Errors, filter, out foundErrors);
    }

    /// <summary>
    ///     Check if the result object contains an error with a specific condition
    /// </summary>
    public static bool HasError<T>(this Result<T> result, Func<IError, bool> filter)
    {
        return HasError(result, filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains an error with a specific condition
    /// </summary>
    public static bool HasError<T>(this Result<T> result, Func<IError, bool> filter, out IEnumerable<IError> foundErrors)
    {
        ArgumentNullException.ThrowIfNull(filter);
        return ResultHelper.HasError(result.Errors, filter, out foundErrors);
    }

    #endregion

    #region Has Exception

    /// <summary>
    ///     Check if the result object contains an exception from a specific type
    /// </summary>
    public static bool HasException<T, TException>(this Result<T> result)
        where TException : Exception
    {
        return HasException<T, TException>(result, out _);
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type
    /// </summary>
    public static bool HasException<T, TException>(this Result<T> result, out IEnumerable<IError> foundErrors)
        where TException : Exception
    {
        return HasException<T, TException>(result, _ => true, out foundErrors);
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type and with a specific condition
    /// </summary>
    public static bool HasException<T, TException>(this Result<T> result, Func<TException, bool> filter)
        where TException : Exception
    {
        return HasException(result, filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type and with a specific condition
    /// </summary>
    public static bool HasException<T, TException>(this Result<T> result, Func<TException, bool> filter, out IEnumerable<IError> foundErrors)
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
    public static bool HasSuccess<T, TSuccess>(this Result<T> result)
        where TSuccess : ISuccess
    {
        return HasSuccess<T, TSuccess>(result, _ => true, out _);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type
    /// </summary>
    public static bool HasSuccess<T, TSuccess>(this Result<T> result, out IEnumerable<TSuccess> foundSuccesses)
        where TSuccess : ISuccess
    {
        return HasSuccess(result, _ => true, out foundSuccesses);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type and with a specific condition
    /// </summary>
    public static bool HasSuccess<T, TSuccess>(this Result<T> result, Func<TSuccess, bool> filter)
        where TSuccess : ISuccess
    {
        return HasSuccess(result, filter, out _);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type and with a specific condition
    /// </summary>
    public static bool HasSuccess<T, TSuccess>(this Result<T> result, Func<TSuccess, bool> filter, out IEnumerable<TSuccess> foundSuccesses)
        where TSuccess : ISuccess
    {
        return ResultHelper.HasSuccess(result.Successes, filter, out foundSuccesses);
    }

    /// <summary>
    ///     Check if the result object contains a success with a specific condition
    /// </summary>
    public static bool HasSuccess<T>(this Result<T> result, Func<ISuccess, bool> filter, out IEnumerable<ISuccess> foundSuccesses)
    {
        return ResultHelper.HasSuccess(result.Successes, filter, out foundSuccesses);
    }

    /// <summary>
    ///     Check if the result object contains a success with a specific condition
    /// </summary>
    public static bool HasSuccess<T>(this Result<T> result, Func<ISuccess, bool> filter)
    {
        return ResultHelper.HasSuccess(result.Successes, filter, out _);
    }

    #endregion

}
