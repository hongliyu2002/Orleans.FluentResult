using System.Collections.Immutable;

namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region Ok

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<T> Ok()
    {
        return new Result<T>();
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<T> Ok(string successMessage)
    {
        return new Result<T>(ImmutableList<IReason>.Empty.Add(ResultSettings.Current.SuccessFactory(successMessage)));
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<T> Ok(T value)
    {
        return new Result<T>(value);
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<T> Ok(T value, string successMessage)
    {
        return new Result<T>(value, ImmutableList<IReason>.Empty.Add(ResultSettings.Current.SuccessFactory(successMessage)));
    }

    #endregion

}
