namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultExtensions
{

    #region With Success

    /// <summary>
    ///     Add a success message
    /// </summary>
    public static Result WithSuccess(this Result result, string successMessage)
    {
        ArgumentNullException.ThrowIfNull(successMessage);
        return WithSuccess(result, ResultSettings.Current.SuccessFactory(successMessage));
    }

    /// <summary>
    ///     Add multiple success messages
    /// </summary>
    public static Result WithSuccesses(this Result result, IEnumerable<string> successMessages)
    {
        ArgumentNullException.ThrowIfNull(successMessages);
        return WithReasons(result, successMessages.Select(successMessage => ResultSettings.Current.SuccessFactory(successMessage)));
    }

    /// <summary>
    ///     Add a success
    /// </summary>
    public static Result WithSuccess<TSuccess>(this Result result)
        where TSuccess : Success, new()
    {
        return WithSuccess(result, new TSuccess());
    }

    /// <summary>
    ///     Add a success
    /// </summary>
    public static Result WithSuccess(this Result result, Success success)
    {
        ArgumentNullException.ThrowIfNull(success);
        return WithReason(result, success);
    }

    /// <summary>
    ///     Add multiple successes
    /// </summary>
    public static Result WithSuccesses(this Result result, IEnumerable<Success> successes)
    {
        ArgumentNullException.ThrowIfNull(successes);
        return WithReasons(result, successes);
    }

    #endregion

    #region With Error

    /// <summary>
    ///     Add an error message
    /// </summary>
    public static Result WithError(this Result result, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return WithError(result, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Add multiple error messages
    /// </summary>
    public static Result WithErrors(this Result result, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return WithReasons(result, errorMessages.Select(errorMessage => ResultSettings.Current.ErrorFactory(errorMessage)));
    }

    /// <summary>
    ///     Add an error
    /// </summary>
    public static Result WithError<TError>(this Result result)
        where TError : Error, new()
    {
        return WithError(result, new TError());
    }

    /// <summary>
    ///     Add an error
    /// </summary>
    public static Result WithError(this Result result, Error error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return WithReason(result, error);
    }

    /// <summary>
    ///     Add multiple errors
    /// </summary>
    public static Result WithErrors(this Result result, IEnumerable<Error> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return WithReasons(result, errors);
    }

    #endregion

    #region With Reason

    /// <summary>
    ///     Add a reason (success or error)
    /// </summary>
    public static Result WithReason(this Result result, IReason reason)
    {
        ArgumentNullException.ThrowIfNull(reason);
        return new Result(result.Reasons.Add(reason));
    }

    /// <summary>
    ///     Add multiple reasons (success or error)
    /// </summary>
    public static Result WithReasons(this Result result, IEnumerable<IReason> reasons)
    {
        ArgumentNullException.ThrowIfNull(reasons);
        return new Result(result.Reasons.AddRange(reasons));
    }

    #endregion

}
