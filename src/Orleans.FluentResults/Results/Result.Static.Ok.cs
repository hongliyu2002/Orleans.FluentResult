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
    public static Result<T> Ok<T>()
    {
        return Result<T>.Ok();
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<T> Ok<T>(string successMessage)
    {
        return Result<T>.Ok(successMessage);
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<T> Ok<T>(T value)
    {
        return Result<T>.Ok(value);
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<T> Ok<T>(T value, string successMessage)
    {
        return Result<T>.Ok(value, successMessage);
    }

    #endregion

}
