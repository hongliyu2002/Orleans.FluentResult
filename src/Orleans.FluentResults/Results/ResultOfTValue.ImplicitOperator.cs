namespace Orleans.FluentResults;

public partial record Result<TValue>
{

    #region Implicit Operator

    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(TValue value)
    {
        return value as Result<TValue> ?? Ok(value);
    }

    /// <summary>
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public static implicit operator Result<object>(Result<TValue> result)
    {
        return result.ToResult<object>();
    }

    // /// <summary>
    // /// </summary>
    // /// <param name="errorMessage"></param>
    // /// <returns></returns>
    // public static implicit operator Result<TValue>(string errorMessage)
    // {
    //     return Fail(errorMessage);
    // }
    //
    // /// <summary>
    // /// </summary>
    // /// <param name="errorMessages"></param>
    // /// <returns></returns>
    // public static implicit operator Result<TValue>(List<string> errorMessages)
    // {
    //     return Fail(errorMessages);
    // }

    /// <summary>
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(Error error)
    {
        return Fail(error);
    }

    /// <summary>
    /// </summary>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(List<Error> errors)
    {
        return Fail(errors);
    }

    /// <summary>
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(Exception exception)
    {
        return Fail(exception);
    }

    /// <summary>
    /// </summary>
    /// <param name="exceptions"></param>
    /// <returns></returns>
    public static implicit operator Result<TValue>(List<Exception> exceptions)
    {
        return Fail(exceptions);
    }

    #endregion

}
