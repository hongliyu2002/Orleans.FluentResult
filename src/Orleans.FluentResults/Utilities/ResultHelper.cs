using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
internal static class ResultHelper
{

    #region Merge

    /// <summary>
    ///     Merge multiple result objects to one result together
    /// </summary>
    /// <param name="results"></param>
    /// <returns></returns>
    public static Result Merge(IEnumerable<Result> results)
    {
        return new Result(results.SelectMany(result => result.Reasons).ToImmutableList());
    }

    /// <summary>
    ///     Merge multiple result objects to one result together
    /// </summary>
    /// <param name="results"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Result<IEnumerable<T>> Merge<T>(IEnumerable<Result<T>> results)
    {
        var resultsList = results.ToList();
        return new Result<IEnumerable<T>>(resultsList.Select(result => result.Value), resultsList.SelectMany(result => result.Reasons).ToImmutableList());
    }

    #endregion

    #region Has Error Exception Success

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
        result = Array.Empty<Error>();
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

    #endregion

}
