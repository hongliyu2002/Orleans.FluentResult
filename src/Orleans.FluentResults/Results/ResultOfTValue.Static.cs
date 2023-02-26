﻿using System.Collections.Immutable;

namespace Orleans.FluentResults;

public partial class Result<TValue>
{

    #region Ok

    /// <summary>
    ///     Creates a success result with the given value
    /// </summary>
    public static Result<TValue> Ok(TValue value)
    {
        return new Result<TValue>(value);
    }

    #endregion

    #region Merge

    /// <summary>
    ///     Merge multiple result objects to one result object together. Return one result with a list of merged values.
    /// </summary>
    public static Result<IEnumerable<TValue>> Merge(params IResult<TValue>[] results)
    {
        ArgumentNullException.ThrowIfNull(results);
        return ResultHelper.Merge(results);
    }

    #endregion

    #region Fail

    /// <summary>
    ///     Creates a failed result with the given error message. Internally an error object from the error factory is created.
    /// </summary>
    public new static Result<TValue> Fail(string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return new Result<TValue>(ImmutableList<IReason>.Empty.Add(ResultSettings.Current.ErrorFactory(errorMessage)));
    }

    /// <summary>
    ///     Creates a failed result with the given error messages. Internally a list of error objects from the error factory is created.
    /// </summary>
    public new static Result<TValue> Fail(IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(errorMessages);
        return new Result<TValue>(ImmutableList<IReason>.Empty.AddRange(errorMessages.Select(ResultSettings.Current.ErrorFactory)));
    }

    /// <summary>
    ///     Creates a failed result with the given error
    /// </summary>
    public new static Result<TValue> Fail(IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return new Result<TValue>(ImmutableList<IReason>.Empty.Add(error));
    }

    /// <summary>
    ///     Creates a failed result with the given errors.
    /// </summary>
    public new static Result<TValue> Fail(IEnumerable<IError> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        return new Result<TValue>(ImmutableList<IReason>.Empty.AddRange(errors));
    }

    /// <summary>
    ///     Creates a failed result with the given exception
    /// </summary>
    public new static Result<TValue> Fail(Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        return new Result<TValue>(ImmutableList<IReason>.Empty.Add(new ExceptionalError(exception)));
    }

    /// <summary>
    ///     Creates a failed result with the given exceptions.
    /// </summary>
    public new static Result<TValue> Fail(IEnumerable<Exception> exceptions)
    {
        ArgumentNullException.ThrowIfNull(exceptions);
        return new Result<TValue>(ImmutableList<IReason>.Empty.AddRange(exceptions.Select(ex => new ExceptionalError(ex))));
    }

    #endregion

    #region Ok If

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<TValue> OkIf(TValue value, bool isSuccess, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return isSuccess ? Ok(value) : Fail(error);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    public static Result<TValue> OkIf(TValue value, bool isSuccess, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return isSuccess ? Ok(value) : Fail(errorMessage);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> OkIf(TValue value, bool isSuccess, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isSuccess ? Ok(value) : Fail(errorFactory.Invoke());
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isSuccess
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> OkIf(TValue value, bool isSuccess, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isSuccess ? Ok(value) : Fail(errorMessageFactory.Invoke());
    }

    #endregion

    #region Fail If

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<TValue> FailIf(TValue value, bool isFailure, IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return isFailure ? Fail(error) : Ok(value);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    public static Result<TValue> FailIf(TValue value, bool isFailure, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);
        return isFailure ? Fail(errorMessage) : Ok(value);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> FailIf(TValue value, bool isFailure, Func<IError> errorFactory)
    {
        ArgumentNullException.ThrowIfNull(errorFactory);
        return isFailure ? Fail(errorFactory.Invoke()) : Ok(value);
    }

    /// <summary>
    ///     Create a success/failed result depending on the parameter isFailure
    /// </summary>
    /// <remarks>
    ///     Error is lazily evaluated.
    /// </remarks>
    public static Result<TValue> FailIf(TValue value, bool isFailure, Func<string> errorMessageFactory)
    {
        ArgumentNullException.ThrowIfNull(errorMessageFactory);
        return isFailure ? Fail(errorMessageFactory.Invoke()) : Ok(value);
    }

    #endregion

    #region Try

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static Result<TValue> Try(Func<TValue> action, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            return Ok(action());
        }
        catch (Exception ex)
        {
            return Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static async Task<Result<TValue>> Try(Func<Task<TValue>> action, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            return Ok(await action());
        }
        catch (Exception ex)
        {
            return Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static async ValueTask<Result<TValue>> Try(Func<ValueTask<TValue>> action, Func<Exception, IError>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(action);
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            return Ok(await action());
        }
        catch (Exception ex)
        {
            return Fail(catchHandler(ex));
        }
    }

    #endregion

}
