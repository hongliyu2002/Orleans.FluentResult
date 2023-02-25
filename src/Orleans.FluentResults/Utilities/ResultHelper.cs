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
    public static Result Merge(IEnumerable<IResultBase> results)
    {
        return new Result(results.SelectMany(result => result.Reasons).ToImmutableList());
    }

    /// <summary>
    ///     Merge multiple result objects to one result together
    /// </summary>
    /// <param name="results"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Result<IEnumerable<TValue>> Merge<TValue>(IEnumerable<IResult<TValue>> results)
    {
        var resultsList = results.ToList();
        var mergedResult = new Result<IEnumerable<TValue>>(resultsList.SelectMany(result => result.Reasons).ToImmutableList());
        if (mergedResult.IsFailed)
        {
            return mergedResult;
        }
        return mergedResult.WithValue(resultsList.Select(result => result.Value));
    }

    #endregion

    #region Has Error Exception Success

    /// <summary>
    ///     Check if the result object contains an error from a specific type and with a specific condition
    /// </summary>
    /// <param name="errors"></param>
    /// <param name="predicate"></param>
    /// <param name="result"></param>
    /// <typeparam name="TError"></typeparam>
    /// <returns></returns>
    public static bool HasError<TError>(IEnumerable<IError> errors, Func<TError, bool> predicate, out IEnumerable<TError> result)
        where TError : IError
    {
        var errorsList = errors.ToList();
        var foundErrors = errorsList.OfType<TError>().Where(predicate).ToList();
        if (foundErrors.Any())
        {
            result = foundErrors;
            return true;
        }
        foreach (var error in errorsList)
        {
            if (HasError(error.Reasons, predicate, out var fErrors))
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
    /// <param name="predicate"></param>
    /// <param name="result"></param>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    public static bool HasException<TException>(IEnumerable<IError> errors, Func<TException, bool> predicate, out IEnumerable<IError> result)
        where TException : Exception
    {
        var errorsList = errors.ToList();
        var foundErrors = errorsList.OfType<ExceptionalError>().Where(e => e.Exception is TException rootExceptionOfTException && predicate(rootExceptionOfTException)).ToList();
        if (foundErrors.Any())
        {
            result = foundErrors;
            return true;
        }
        foreach (var error in errorsList)
        {
            if (HasException(error.Reasons, predicate, out var fErrors))
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
    /// <param name="predicate"></param>
    /// <param name="result"></param>
    /// <typeparam name="TSuccess"></typeparam>
    /// <returns></returns>
    public static bool HasSuccess<TSuccess>(IEnumerable<ISuccess> successes, Func<TSuccess, bool> predicate, out IEnumerable<TSuccess> result)
        where TSuccess : ISuccess
    {
        var foundSuccesses = successes.OfType<TSuccess>().Where(predicate).ToList();
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
