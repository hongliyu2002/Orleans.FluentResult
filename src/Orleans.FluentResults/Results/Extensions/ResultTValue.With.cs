namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static partial class ResultTExtensions
{

    #region With Value

    /// <summary>
    ///     Set value
    /// </summary>
    public static Result<T> WithValue<T>(this Result<T> result, T value)
    {
        return result with { Value = value };
    }

    #endregion

    #region With Success

    /// <summary>
    ///     Add a success message
    /// </summary>
    public static Result<T> WithSuccess<T>(this Result<T> result, string successMessage)
    {
        ArgumentNullException.ThrowIfNull(successMessage);
        return WithSuccess(result, ResultSettings.Current.SuccessFactory(successMessage));
    }

    /// <summary>
    ///     Add multiple success messages
    /// </summary>
    public static Result<T> WithSuccesses<T>(this Result<T> result, IEnumerable<string> successMessages)
    {
        ArgumentNullException.ThrowIfNull(successMessages);
        return WithReasons(result, successMessages.Select(successMessage => ResultSettings.Current.SuccessFactory(successMessage)));
    }

    /// <summary>
    ///     Add a success
    /// </summary>
    public static Result<T> WithSuccess<T, TSuccess>(this Result<T> result)
        where TSuccess : ISuccess, new()
    {
        return WithSuccess(result, new TSuccess());
    }

    /// <summary>
    ///     Add a success
    /// </summary>
    public static Result<T> WithSuccess<T>(this Result<T> result, ISuccess success)
    {
        ArgumentNullException.ThrowIfNull(success);
        return WithReason(result, success);
    }

    /// <summary>
    ///     Add multiple successes
    /// </summary>
    public static Result<T> WithSuccesses<T>(this Result<T> result, IEnumerable<ISuccess> successes)
    {
        ArgumentNullException.ThrowIfNull(successes);
        return WithReasons(result, successes);
    }

    #endregion

    #region With Error

    /// <summary>
    ///     Add an error message
    /// </summary>
    public static Result<T> WithError<T>(this Result<T> result, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return WithError(result, ResultSettings.Current.ErrorFactory(errorMessage));
    }

    /// <summary>
    ///     Add multiple error messages
    /// </summary>
    public static Result<T> WithErrors<T>(this Result<T> result, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return WithReasons(result, errorMessages.Select(errorMessage => ResultSettings.Current.ErrorFactory(errorMessage)));
    }

    /// <summary>
    ///     Add an error
    /// </summary>
    public static Result<T> WithError<T, TError>(this Result<T> result)
        where TError : IError, new()
    {
        return WithError(result, new TError());
    }

    /// <summary>
    ///     Add an error
    /// </summary>
    public static Result<T> WithError<T>(this Result<T> result, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return WithReason(result, error);
    }

    /// <summary>
    ///     Add multiple errors
    /// </summary>
    public static Result<T> WithErrors<T>(this Result<T> result, IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return WithReasons(result, errors);
    }

    #endregion

    #region With Reason

    /// <summary>
    ///     Add a reason (success or error)
    /// </summary>
    public static Result<T> WithReason<T>(this Result<T> result, IReason reason)
    {
        ArgumentNullException.ThrowIfNull(reason);
        return result with { Reasons = result.Reasons.Add(reason) };
    }

    /// <summary>
    ///     Add multiple reasons (success or error)
    /// </summary>
    public static Result<T> WithReasons<T>(this Result<T> result, IEnumerable<IReason> reasons)
    {
        ArgumentNullException.ThrowIfNull(reasons);
        return result with { Reasons = result.Reasons.AddRange(reasons) };
    }

    #endregion

}
