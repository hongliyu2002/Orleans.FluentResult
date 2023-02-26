namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public partial record Result
{

    #region Map

    /// <summary>
    ///     Map all successMessages of the result via successMapper
    /// </summary>
    public Result MapSuccesses(Func<Success, Success> successMapper)
    {
        ArgumentNullException.ThrowIfNull(successMapper);
        return new Result().WithErrors(Errors).WithSuccesses(Successes.Select(successMapper));
    }

    /// <summary>
    ///     Map all errorMessages of the result via errorMapper
    /// </summary>
    public Result MapErrors(Func<Error, Error> errorMapper)
    {
        ArgumentNullException.ThrowIfNull(errorMapper);
        return new Result().WithErrors(Errors.Select(errorMapper)).WithSuccesses(Successes);
    }

    #endregion

}
