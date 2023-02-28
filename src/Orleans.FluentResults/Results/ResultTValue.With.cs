namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region With Value

    /// <summary>
    ///     Set value
    /// </summary>
    public Result<T> WithValue(T value)
    {
        return this with { Value = value };
    }

    #endregion

    #region With Success

    /// <summary>
    ///     Add a success message
    /// </summary>
    public Result<T> WithSuccess(string successMessage)
    {
        ArgumentNullException.ThrowIfNull(successMessage);
        return WithSuccess(ResultSettings.Current.SuccessFactory(successMessage));
    }

    /// <summary>
    ///     Add a success
    /// </summary>
    public Result<T> WithSuccess(Success success)
    {
        ArgumentNullException.ThrowIfNull(success);
        return WithReason(success);
    }

    /// <summary>
    ///     Add a success
    /// </summary>
    public Result<T> WithSuccess<TSuccess>()
        where TSuccess : Success, new()
    {
        return WithSuccess(new TSuccess());
    }

    /// <summary>
    ///     Add multiple successes
    /// </summary>
    public Result<T> WithSuccesses(IEnumerable<Success> successes)
    {
        ArgumentNullException.ThrowIfNull(successes);
        return WithReasons(successes);
    }

    /// <summary>
    ///     Add multiple success messages
    /// </summary>
    public Result<T> WithSuccesses(IEnumerable<string> successMessages)
    {
        ArgumentNullException.ThrowIfNull(successMessages);
        return WithReasons(successMessages.Select(successMessage => ResultSettings.Current.SuccessFactory(successMessage)));
    }

    #endregion

    #region With Error

    /// <summary>
    ///     Add an error message
    /// </summary>
    public Result<T> WithError(string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return WithError(ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Add an error
    /// </summary>
    public Result<T> WithError(Error error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return WithReason(error);
    }

    /// <summary>
    ///     Add an error
    /// </summary>
    public Result<T> WithError<TError>()
        where TError : Error, new()
    {
        return WithError(new TError());
    }

    /// <summary>
    ///     Add multiple errors
    /// </summary>
    public Result<T> WithErrors(IEnumerable<Error> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return WithReasons(errors);
    }

    /// <summary>
    ///     Add multiple error messages
    /// </summary>
    public Result<T> WithErrors(IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return WithReasons(errorMessages.Select(errorMessage => ResultSettings.Current.ErrorFactory(errorMessage)));
    }

    #endregion

    #region With Reason

    /// <summary>
    ///     Add a reason (success or error)
    /// </summary>
    public Result<T> WithReason(IReason reason)
    {
        ArgumentNullException.ThrowIfNull(reason);
        return this with { Reasons = Reasons.Add(reason) };
    }

    /// <summary>
    ///     Add multiple reasons (success or error)
    /// </summary>
    public Result<T> WithReasons(IEnumerable<IReason> reasons)
    {
        ArgumentNullException.ThrowIfNull(reasons);
        return this with { Reasons = Reasons.AddRange(reasons) };
    }

    #endregion

}
