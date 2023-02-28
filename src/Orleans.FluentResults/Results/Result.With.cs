namespace Orleans.FluentResults;

public partial record Result
{

    #region With Success

    /// <summary>
    ///     Add a success message
    /// </summary>
    public Result WithSuccess(string successMessage)
    {
        ArgumentNullException.ThrowIfNull(successMessage);
        return WithSuccess(ResultSettings.Current.SuccessFactory(successMessage));
    }

    /// <summary>
    ///     Add a success
    /// </summary>
    public Result WithSuccess(Success success)
    {
        ArgumentNullException.ThrowIfNull(success);
        return WithReason(success);
    }

    /// <summary>
    ///     Add a success
    /// </summary>
    public Result WithSuccess<TSuccess>()
        where TSuccess : Success, new()
    {
        return WithSuccess(new TSuccess());
    }

    /// <summary>
    ///     Add multiple successes
    /// </summary>
    public Result WithSuccesses(IEnumerable<Success> successes)
    {
        ArgumentNullException.ThrowIfNull(successes);
        return WithReasons(successes);
    }

    /// <summary>
    ///     Add multiple success messages
    /// </summary>
    public Result WithSuccesses(IEnumerable<string> successMessages)
    {
        ArgumentNullException.ThrowIfNull(successMessages);
        return WithReasons(successMessages.Select(successMessage => ResultSettings.Current.SuccessFactory(successMessage)));
    }

    #endregion

    #region With Error

    /// <summary>
    ///     Add an error message
    /// </summary>
    public Result WithError(string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return WithError(ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Add an error
    /// </summary>
    public Result WithError(Error error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return WithReason(error);
    }

    /// <summary>
    ///     Add an error
    /// </summary>
    public Result WithError<TError>()
        where TError : Error, new()
    {
        return WithError(new TError());
    }

    /// <summary>
    ///     Add multiple errors
    /// </summary>
    public Result WithErrors(IEnumerable<Error> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return WithReasons(errors);
    }

    /// <summary>
    ///     Add multiple error messages
    /// </summary>
    public Result WithErrors(IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return WithReasons(errorMessages.Select(errorMessage => ResultSettings.Current.ErrorFactory(errorMessage)));
    }

    #endregion

    #region With Reason

    /// <summary>
    ///     Add a reason (success or error)
    /// </summary>
    public Result WithReason(IReason reason)
    {
        ArgumentNullException.ThrowIfNull(reason);
        return new Result(Reasons.Add(reason));
    }

    /// <summary>
    ///     Add multiple reasons (success or error)
    /// </summary>
    public Result WithReasons(IEnumerable<IReason> reasons)
    {
        ArgumentNullException.ThrowIfNull(reasons);
        return new Result(Reasons.AddRange(reasons));
    }

    #endregion

}
