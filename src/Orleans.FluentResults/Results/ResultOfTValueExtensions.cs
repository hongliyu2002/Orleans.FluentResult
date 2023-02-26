namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultOfTValueExtensions
{

    #region To Result

    /// <summary>
    ///     Convert result with value to result without value
    /// </summary>
    public static Result<TValue> ToResult<TValue>(this Result<TValue> result)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result with {};
    }

    #endregion

    #region With Value

    /// <summary>
    ///     Set value
    /// </summary>
    public static Result<TValue> WithValue<TValue>(this Result<TValue> result, TValue value)
    {
        ArgumentNullException.ThrowIfNull(result);
        return result with { Value = value };
    }

    #endregion

    #region With Success

    /// <summary>
    ///     Add a success message
    /// </summary>
    public static Result<TValue> WithSuccess<TValue>(this Result<TValue> result, string successMessage)
    {
        ArgumentNullException.ThrowIfNull(successMessage);
        return WithSuccess(result, ResultSettings.Current.SuccessFactory(successMessage));
    }

    /// <summary>
    ///     Add a success
    /// </summary>
    public static Result<TValue> WithSuccess<TValue>(this Result<TValue> result, ISuccess success)
    {
        ArgumentNullException.ThrowIfNull(success);
        return WithReason(result, success);
    }

    /// <summary>
    ///     Add a success
    /// </summary>
    public static Result<TValue> WithSuccess<TValue, TSuccess>(this Result<TValue> result)
        where TSuccess : ISuccess, new()
    {
        return WithSuccess(result, new TSuccess());
    }

    /// <summary>
    ///     Add multiple successes
    /// </summary>
    /// <param name="result"></param>
    /// <param name="successes"></param>
    /// <returns></returns>
    public static Result<TValue> WithSuccesses<TValue>(this Result<TValue> result, IEnumerable<ISuccess> successes)
    {
        ArgumentNullException.ThrowIfNull(successes);
        return WithReasons(result, successes);
    }

    /// <summary>
    ///     Add multiple success messages
    /// </summary>
    public static Result<TValue> WithSuccesses<TValue>(this Result<TValue> result, IEnumerable<string> successMessages)
    {
        ArgumentNullException.ThrowIfNull(successMessages);
        return WithReasons(result, successMessages.Select(successMessage => ResultSettings.Current.SuccessFactory(successMessage)));
    }

    #endregion

    #region With Error

    /// <summary>
    ///     Add an error message
    /// </summary>
    public static Result<TValue> WithError<TValue>(this Result<TValue> result, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return WithError(result, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Add an error
    /// </summary>
    public static Result<TValue> WithError<TValue>(this Result<TValue> result, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return WithReason(result, error);
    }

    /// <summary>
    ///     Add an error
    /// </summary>
    public static Result<TValue> WithError<TValue, TError>(this Result<TValue> result)
        where TError : IError, new()
    {
        return WithError(result, new TError());
    }

    /// <summary>
    ///     Add multiple errors
    /// </summary>
    public static Result<TValue> WithErrors<TValue>(this Result<TValue> result, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return WithReasons(result, errors);
    }

    /// <summary>
    ///     Add multiple error messages
    /// </summary>
    public static Result<TValue> WithErrors<TValue>(this Result<TValue> result, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return WithReasons(result, errorMessages.Select(errorMessage => ResultSettings.Current.ErrorFactory(errorMessage)));
    }

    #endregion

    #region With Reason

    /// <summary>
    ///     Add a reason (success or error)
    /// </summary>
    public static Result<TValue> WithReason<TValue>(this Result<TValue> result, IReason reason)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(reason);
        return result with { Reasons = result.Reasons.Add(reason) };
    }

    /// <summary>
    ///     Add multiple reasons (success or error)
    /// </summary>
    public static Result<TValue> WithReasons<TValue>(this Result<TValue> result, IEnumerable<IReason> reasons)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(reasons);
        return result with { Reasons = result.Reasons.AddRange(reasons) };
    }

    #endregion

    #region Map

    /// <summary>
    ///     Map all successMessages of the result via successMapper
    /// </summary>
    /// <param name="result"></param>
    /// <param name="successMapper"></param>
    /// <returns></returns>
    public static Result<TValue> MapSuccesses<TValue>(this Result<TValue> result, Func<ISuccess, ISuccess> successMapper)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(successMapper);
        return new Result<TValue>().WithErrors(result.Errors)
                                   .WithSuccesses(result.Successes.Select(successMapper));
    }

    /// <summary>
    ///     Map all errorMessages of the result via errorMapper
    /// </summary>
    /// <param name="result"></param>
    /// <param name="errorMapper"></param>
    /// <returns></returns>
    public static Result<TValue> MapErrors<TValue>(this Result<TValue> result, Func<IError, IError> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(errorMapper);
        if (result.IsSuccess)
        {
            return result with {};
        }
        return new Result<TValue>().WithErrors(result.Errors.Select(errorMapper))
                                   .WithSuccesses(result.Successes);
    }

    #endregion

}
