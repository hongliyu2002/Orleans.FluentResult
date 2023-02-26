using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
[Immutable]
[GenerateSerializer]
public partial class Result : ResultBase
{
    /// <summary>
    /// </summary>
    public Result()
    {
    }

    /// <summary>
    /// </summary>
    /// <param name="reasons"></param>
    public Result(IImmutableList<IReason> reasons)
        : base(reasons)
    {
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var reasonsString = Reasons.Any() ? $", Reasons='{string.Join("; ", Reasons)}'" : string.Empty;
        return $"Result: IsSuccess='{IsSuccess}'{reasonsString}";
    }

    #region Deconstruct

    /// <summary>
    ///     Deconstruct Result
    /// </summary>
    /// <param name="isSuccess"></param>
    /// <param name="isFailed"></param>
    public void Deconstruct(out bool isSuccess, out bool isFailed)
    {
        isSuccess = IsSuccess;
        isFailed = IsFailed;
    }

    /// <summary>
    ///     Deconstruct Result
    /// </summary>
    /// <param name="isSuccess"></param>
    /// <param name="isFailed"></param>
    /// <param name="errors"></param>
    public void Deconstruct(out bool isSuccess, out bool isFailed, out IImmutableList<IError> errors)
    {
        isSuccess = IsSuccess;
        isFailed = IsFailed;
        errors = IsFailed ? Errors : ImmutableList.Create<IError>();
    }

    #endregion

    #region Implicit Operator

    /// <summary>
    /// </summary>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static implicit operator Result(string errorMessage)
    {
        return Fail(errorMessage);
    }

    /// <summary>
    /// </summary>
    /// <param name="errorMessages"></param>
    /// <returns></returns>
    public static implicit operator Result(List<string> errorMessages)
    {
        return Fail(errorMessages);
    }

    /// <summary>
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public static implicit operator Result(Error error)
    {
        return Fail(error);
    }

    /// <summary>
    /// </summary>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static implicit operator Result(List<Error> errors)
    {
        return Fail(errors);
    }

    /// <summary>
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public static implicit operator Result(Exception exception)
    {
        return Fail(exception);
    }

    /// <summary>
    /// </summary>
    /// <param name="exceptions"></param>
    /// <returns></returns>
    public static implicit operator Result(List<Exception> exceptions)
    {
        return Fail(exceptions);
    }

    #endregion

}
