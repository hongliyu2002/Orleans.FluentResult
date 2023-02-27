using System.Collections.Immutable;

namespace Orleans.FluentResults;

public partial record Result
{

    #region Ok

    /// <summary>
    ///     Creates a success result
    /// </summary>
    public static Result Ok()
    {
        return new Result();
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result Ok(string successMessage)
    {
        return new Result(ImmutableList<IReason>.Empty.Add(ResultSettings.Current.SuccessFactory(successMessage)));
    }

    #endregion

    #region Ok Generic

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<TValue> Ok<TValue>()
    {
        return Result<TValue>.Ok();
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<TValue> Ok<TValue>(string successMessage)
    {
        return Result<TValue>.Ok(successMessage);
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<TValue> Ok<TValue>(TValue value)
    {
        return Result<TValue>.Ok(value);
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<TValue> Ok<TValue>(TValue value, string successMessage)
    {
        return Result<TValue>.Ok(value, successMessage);
    }

    #endregion

}
