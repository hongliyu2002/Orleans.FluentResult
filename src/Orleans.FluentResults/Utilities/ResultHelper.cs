namespace Orleans.FluentResults;

/// <summary>
/// </summary>
internal static class ResultHelper
{

    /// <summary>
    ///     Check if the result object contains an error from a specific type and with a specific condition
    /// </summary>
    /// <param name="errors"></param>
    /// <param name="filter"></param>
    /// <param name="result"></param>
    /// <typeparam name="TError"></typeparam>
    /// <returns></returns>
    public static bool HasError<TError>(IEnumerable<IError> errors, Func<TError, bool> filter, out IEnumerable<TError> result)
        where TError : IError
    {
        var errorsList = errors.ToList();
        var foundErrors = errorsList.OfType<TError>().Where(filter).ToList();
        if (foundErrors.Any())
        {
            result = foundErrors;
            return true;
        }
        foreach (var error in errorsList)
        {
            if (HasError(error.Reasons, filter, out var fErrors))
            {
                result = fErrors;
                return true;
            }
        }
        result = Array.Empty<TError>();
        return false;
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type and with a specific condition
    /// </summary>
    /// <param name="errors"></param>
    /// <param name="filter"></param>
    /// <param name="result"></param>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    public static bool HasException<TException>(IEnumerable<IError> errors, Func<TException, bool> filter, out IEnumerable<IError> result)
        where TException : Exception
    {
        var errorsList = errors.ToList();
        var foundErrors = errorsList.OfType<ExceptionalError>().Where(e => e.Exception is TException rootExceptionOfTException && filter(rootExceptionOfTException)).ToList();
        if (foundErrors.Any())
        {
            result = foundErrors;
            return true;
        }
        foreach (var error in errorsList)
        {
            if (HasException(error.Reasons, filter, out var fErrors))
            {
                result = fErrors;
                return true;
            }
        }
        result = Array.Empty<IError>();
        return false;
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type and with a specific condition
    /// </summary>
    /// <param name="successes"></param>
    /// <param name="filter"></param>
    /// <param name="result"></param>
    /// <typeparam name="TSuccess"></typeparam>
    /// <returns></returns>
    public static bool HasSuccess<TSuccess>(IEnumerable<ISuccess> successes, Func<TSuccess, bool> filter, out IEnumerable<TSuccess> result)
        where TSuccess : ISuccess
    {
        var foundSuccesses = successes.OfType<TSuccess>().Where(filter).ToList();
        if (foundSuccesses.Any())
        {
            result = foundSuccesses;
            return true;
        }
        result = Array.Empty<TSuccess>();
        return false;
    }
}
