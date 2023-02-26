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
    ///     Add a success
    /// </summary>
    public static Result WithSuccess(this Result result, Success success)
    {
        ArgumentNullException.ThrowIfNull(success);
        return WithReason(result, success);
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
    ///     Add multiple successes
    /// </summary>
    /// <param name="result"></param>
    /// <param name="successes"></param>
    /// <returns></returns>
    public static Result WithSuccesses(this Result result, IEnumerable<Success> successes)
    {
        ArgumentNullException.ThrowIfNull(successes);
        return WithReasons(result, successes);
    }

    /// <summary>
    ///     Add multiple success messages
    /// </summary>
    public static Result WithSuccesses(this Result result, IEnumerable<string> successMessages)
    {
        ArgumentNullException.ThrowIfNull(successMessages);
        return WithReasons(result, successMessages.Select(successMessage => ResultSettings.Current.SuccessFactory(successMessage)));
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
    ///     Add an error
    /// </summary>
    public static Result WithError(this Result result, Error error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return WithReason(result, error);
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
    ///     Add multiple errors
    /// </summary>
    public static Result WithErrors(this Result result, IEnumerable<Error> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return WithReasons(result, errors);
    }

    /// <summary>
    ///     Add multiple error messages
    /// </summary>
    public static Result WithErrors(this Result result, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return WithReasons(result, errorMessages.Select(errorMessage => ResultSettings.Current.ErrorFactory(errorMessage)));
    }

    #endregion

    #region With Reason

    /// <summary>
    ///     Add a reason (success or error)
    /// </summary>
    public static Result WithReason(this Result result, IReason reason)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(reason);
        return result with { Reasons = result.Reasons.Add(reason) };
    }

    /// <summary>
    ///     Add multiple reasons (success or error)
    /// </summary>
    public static Result WithReasons(this Result result, IEnumerable<IReason> reasons)
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
    public static Result MapSuccesses(this Result result, Func<Success, Success> successMapper)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(successMapper);
        return new Result().WithErrors(result.Errors).WithSuccesses(result.Successes.Select(successMapper));
    }

    /// <summary>
    ///     Map all errorMessages of the result via errorMapper
    /// </summary>
    /// <param name="result"></param>
    /// <param name="errorMapper"></param>
    /// <returns></returns>
    public static Result MapErrors(this Result result, Func<Error, Error> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(errorMapper);
        return new Result().WithErrors(result.Errors.Select(errorMapper)).WithSuccesses(result.Successes);
    }

    #endregion

}
