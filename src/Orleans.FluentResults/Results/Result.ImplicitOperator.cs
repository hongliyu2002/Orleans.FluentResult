namespace Orleans.FluentResults;

public partial record Result
{

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
