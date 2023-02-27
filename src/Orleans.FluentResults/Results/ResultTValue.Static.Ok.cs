using System.Collections.Immutable;

namespace Orleans.FluentResults;

public partial record Result<TValue>
{

    #region Ok

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<TValue> Ok()
    {
        return new Result<TValue>();
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<TValue> Ok(string successMessage)
    {
        return new Result<TValue>(ImmutableList<IReason>.Empty.Add(ResultSettings.Current.SuccessFactory(successMessage)));
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<TValue> Ok(TValue value)
    {
        return new Result<TValue>(value);
    }

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<TValue> Ok(TValue value, string successMessage)
    {
        return new Result<TValue>(value, ImmutableList<IReason>.Empty.Add(ResultSettings.Current.SuccessFactory(successMessage)));
    }

    #endregion

}
