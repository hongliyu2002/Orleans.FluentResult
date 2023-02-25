namespace Orleans.FluentResults;

public partial class Result
{

    #region Ok

    /// <summary>
    ///     Creates a success result
    /// </summary>
    public static Result Ok()
    {
        return new Result();
    }

    #endregion

    #region Merge

    /// <summary>
    ///     Merge multiple result objects to one result object together
    /// </summary>
    public static Result Merge(params IResultBase[] results)
    {
        ArgumentNullException.ThrowIfNull(results);
        return ResultHelper.Merge(results);
    }

    #endregion

    #region Fail

    /// <summary>
    ///     Creates a failed result with the given error
    /// </summary>
    public static Result Fail(IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return new Result().WithError(error);
    }

    /// <summary>
    ///     Creates a failed result with the given error message. Internally an error object from the error factory is created.
    /// </summary>
    public static Result Fail(string message)
    {
        ArgumentNullException.ThrowIfNull(message);
        return new Result().WithError(ResultSettings.Current.ErrorFactory(message));
    }

    /// <summary>
    ///     Creates a failed result with the given error messages. Internally a list of error objects from the error factory is created
    /// </summary>
    public static Result Fail(IEnumerable<string> messages)
    {
        ArgumentNullException.ThrowIfNull(messages);
        return new Result().WithErrors(messages.Select(ResultSettings.Current.ErrorFactory));
    }

    /// <summary>
    ///     Creates a failed result with the given errors.
    /// </summary>
    public static Result Fail(IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return new Result().WithErrors(errors);
    }

    #endregion

    #region Ok If

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result OkIf(bool isSuccess, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return isSuccess ? Ok() : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result OkIf(bool isSuccess, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return isSuccess ? Ok() : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool isSuccess, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isSuccess ? Ok() : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result OkIf(bool isSuccess, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isSuccess ? Ok() : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region Fail If

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result FailIf(bool isFailure, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return isFailure ? Fail(error) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result FailIf(bool isFailure, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return isFailure ? Fail(errorMessage) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result FailIf(bool isFailure, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isFailure ? Fail(errorFactory.Invoke()) : Ok();
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result FailIf(bool isFailure, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isFailure ? Fail(errorMessageFactory.Invoke()) : Ok();
    }

    #endregion

    #region Try

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static Result Try(Action action, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            action();
            return Ok();
        }
        catch (Exception ex)
        {
            return Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static async Task<Result> Try(Func<Task> action, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            await action();
            return Ok();
        }
        catch (Exception ex)
        {
            return Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static async ValueTask<Result> Try(Func<ValueTask> action, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            await action();
            return Ok();
        }
        catch (Exception ex)
        {
            return Fail(catchHandler(ex));
        }
    }

    #endregion

}
