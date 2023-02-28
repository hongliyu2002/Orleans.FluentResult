namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region Implicit Operator

    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Result<T>(T value)
    {
        return value.ToResult();
    }

    /// <summary>
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public static implicit operator Result<T>(Result result)
    {
        return result.ToResult<T>();
    }

    /// <summary>
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public static implicit operator Result<object>(Result<T> result)
    {
        return result.ToResult<object>();
    }

    /// <summary>
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public static implicit operator Result(Result<T> result)
    {
        return result.ToResult();
    }

    // /// <summary>
    // /// </summary>
    // /// <param name="errorMessage"></param>
    // /// <returns></returns>
    // public static implicit operator Result<T>(string errorMessage)
    // {
    //     return Fail(errorMessage);
    // }
    //
    // /// <summary>
    // /// </summary>
    // /// <param name="errorMessages"></param>
    // /// <returns></returns>
    // public static implicit operator Result<T>(List<string> errorMessages)
    // {
    //     return Fail(errorMessages);
    // }

    /// <summary>
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public static implicit operator Result<T>(Error error)
    {
        return Fail(error);
    }

    /// <summary>
    /// </summary>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static implicit operator Result<T>(List<Error> errors)
    {
        return Fail(errors);
    }

    /// <summary>
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public static implicit operator Result<T>(Exception exception)
    {
        return Fail(exception);
    }

    /// <summary>
    /// </summary>
    /// <param name="exceptions"></param>
    /// <returns></returns>
    public static implicit operator Result<T>(List<Exception> exceptions)
    {
        return Fail(exceptions);
    }

    #endregion

}
