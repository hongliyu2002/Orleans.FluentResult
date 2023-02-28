namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public partial record Result<T>
{

    #region Map

    /// <summary>
    ///     Convert result with value to result with another value. Use valueMapper parameter to specify the value transformation logic.
    /// </summary>
    /// <param name="valueMapper"></param>
    /// <returns></returns>
    public Result<T2> Map<T2>(Func<T, T2> valueMapper)
    {
        ArgumentNullException.ThrowIfNull(valueMapper);
        return new Result<T2>(valueMapper(Value), Reasons);
    }

    /// <summary>
    ///     Map all successMessages of the result via successMapper
    /// </summary>
    /// <param name="successMapper"></param>
    /// <returns></returns>
    public Result<T> MapSuccesses(Func<Success, Success> successMapper)
    {
        ArgumentNullException.ThrowIfNull(successMapper);
        return new Result<T>(Value).WithErrors(Errors).WithSuccesses(Successes.Select(successMapper));
    }

    /// <summary>
    ///     Map all errorMessages of the result via errorMapper
    /// </summary>
    /// <param name="errorMapper"></param>
    /// <returns></returns>
    public Result<T> MapErrors(Func<Error, Error> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);
        return new Result<T>(Value).WithErrors(Errors.Select(errorMapper)).WithSuccesses(Successes);
    }

    #endregion

}
