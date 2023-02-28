using System.Collections.Immutable;

namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region Fail

    /// <summary>
    ///     Creates a failed result with the given error message. Internally an error object from the error factory is created.
    /// </summary>
    public static Result<T> Fail(string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return new Result<T>(ImmutableList<IReason>.Empty.Add(ResultSettings.Current.ErrorFactory(errorMessage)));
    }

    /// <summary>
    ///     Creates a failed result with the given error messages. Internally a list of error objects from the error factory is created.
    /// </summary>
    public static Result<T> Fail(IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return new Result<T>(ImmutableList<IReason>.Empty.AddRange(errorMessages.Select(ResultSettings.Current.ErrorFactory)));
    }

    /// <summary>
    ///     Creates a failed result with the given error
    /// </summary>
    public static Result<T> Fail(IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return new Result<T>(ImmutableList<IReason>.Empty.Add(error));
    }

    /// <summary>
    ///     Creates a failed result with the given errors.
    /// </summary>
    public static Result<T> Fail(IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return new Result<T>(ImmutableList<IReason>.Empty.AddRange(errors));
    }

    /// <summary>
    ///     Creates a failed result with the given exception
    /// </summary>
    public static Result<T> Fail(Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return new Result<T>(ImmutableList<IReason>.Empty.Add(ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    /// <summary>
    ///     Creates a failed result with the given exceptions.
    /// </summary>
    public static Result<T> Fail(IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return new Result<T>(ImmutableList<IReason>.Empty.AddRange(exceptions.Select(exception => ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception))));
    }

    #endregion

}
