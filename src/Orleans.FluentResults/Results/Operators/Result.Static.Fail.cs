using System.Collections.Immutable;

namespace Orleans.FluentResults;

public partial record Result
{

    #region Fail

    /// <summary>
    ///     Creates a failed result with the given error message. Internally an error object from the error factory is created.
    /// </summary>
    public static Result Fail(string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return new Result(ImmutableList<IReason>.Empty.Add(ResultSettings.Current.ErrorFactory(errorMessage)));
    }

    /// <summary>
    ///     Creates a failed result with the given error messages. Internally a list of error objects from the error factory is created
    /// </summary>
    public static Result Fail(IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return new Result(ImmutableList<IReason>.Empty.AddRange(errorMessages.Select(ResultSettings.Current.ErrorFactory)));
    }

    /// <summary>
    ///     Creates a failed result with the given error
    /// </summary>
    public static Result Fail(Error error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return new Result(ImmutableList<IReason>.Empty.Add(error));
    }

    /// <summary>
    ///     Creates a failed result with the given errors.
    /// </summary>
    public static Result Fail(IEnumerable<Error> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return new Result(ImmutableList<IReason>.Empty.AddRange(errors));
    }

    /// <summary>
    ///     Creates a failed result with the given exception
    /// </summary>
    public static Result Fail(Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return new Result(ImmutableList<IReason>.Empty.Add(ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    /// <summary>
    ///     Creates a failed result with the given exceptions.
    /// </summary>
    public static Result Fail(IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return new Result(ImmutableList<IReason>.Empty.AddRange(exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception))));
    }

    #endregion

    #region Fail Generic

    /// <summary>
    ///     Creates a failed result with the given error message. Internally an error object from the error factory is created.
    /// </summary>
    public static Result<TValue> Fail<TValue>(string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return new Result<TValue>(ImmutableList<IReason>.Empty.Add(ResultSettings.Current.ErrorFactory(errorMessage)));
    }

    /// <summary>
    ///     Creates a failed result with the given error messages. Internally a list of error objects from the error factory is created.
    /// </summary>
    public static Result<TValue> Fail<TValue>(IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return new Result<TValue>(ImmutableList<IReason>.Empty.AddRange(errorMessages.Select(ResultSettings.Current.ErrorFactory)));
    }

    /// <summary>
    ///     Creates a failed result with the given error
    /// </summary>
    public static Result<TValue> Fail<TValue>(Error error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return new Result<TValue>(ImmutableList<IReason>.Empty.Add(error));
    }

    /// <summary>
    ///     Creates a failed result with the given errors.
    /// </summary>
    public static Result<TValue> Fail<TValue>(IEnumerable<Error> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return new Result<TValue>(ImmutableList<IReason>.Empty.AddRange(errors));
    }

    /// <summary>
    ///     Creates a failed result with the given exception
    /// </summary>
    public static Result<TValue> Fail<TValue>(Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return new Result<TValue>(ImmutableList<IReason>.Empty.Add(ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    /// <summary>
    ///     Creates a failed result with the given exceptions.
    /// </summary>
    public static Result<TValue> Fail<TValue>(IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return new
            Result<TValue>(ImmutableList<IReason>.Empty.AddRange(exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception))));
    }

    #endregion

}
