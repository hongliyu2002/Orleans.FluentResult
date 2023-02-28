using System.Collections.Immutable;

namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region Deconstruct

    /// <summary>
    ///     Deconstruct Result
    /// </summary>
    /// <param name="isSuccess"></param>
    /// <param name="isFailed"></param>
    /// <param name="valueOrDefault"></param>
    public void Deconstruct(out bool isSuccess, out bool isFailed, out T? valueOrDefault)
    {
        isSuccess = IsSuccess;
        isFailed = IsFailed;
        valueOrDefault = ValueOrDefault;
    }

    /// <summary>
    ///     Deconstruct Result
    /// </summary>
    /// <param name="isSuccess"></param>
    /// <param name="isFailed"></param>
    /// <param name="valueOrDefault"></param>
    /// <param name="errors"></param>
    public void Deconstruct(out bool isSuccess, out bool isFailed, out T? valueOrDefault, out IImmutableList<Error> errors)
    {
        isSuccess = IsSuccess;
        isFailed = IsFailed;
        valueOrDefault = ValueOrDefault;
        errors = IsFailed ? Errors : ImmutableList<Error>.Empty;
    }

    #endregion

}
