namespace Orleans.FluentResults;

public partial record Result
{

    #region Try Action

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
    public static async Task<Result> TryAsync(Func<Task> action, Func<Exception, IError>? catchHandler = null)
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
    public static async ValueTask<Result> TryAsync(Func<ValueTask> action, Func<Exception, IError>? catchHandler = null)
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

    #region Try Generic Action

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static Result<T> Try<T>(Action action, Func<Exception, IError>? catchHandler = null)
    {
        return Result<T>.Try(action, catchHandler);
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static Task<Result<T>> TryAsync<T>(Func<Task> action, Func<Exception, IError>? catchHandler = null)
    {
        return Result<T>.TryAsync(action, catchHandler);
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static ValueTask<Result<T>> TryAsync<T>(Func<ValueTask> action, Func<Exception, IError>? catchHandler = null)
    {
        return Result<T>.TryAsync(action, catchHandler);
    }

    #endregion

    #region Try Generic Function

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static Result<T> Try<T>(Func<T> func, Func<Exception, IError>? catchHandler = null)
    {
        return Result<T>.Try(func, catchHandler);
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static Task<Result<T>> TryAsync<T>(Func<Task<T>> func, Func<Exception, IError>? catchHandler = null)
    {
        return Result<T>.TryAsync(func, catchHandler);
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static ValueTask<Result<T>> TryAsync<T>(Func<ValueTask<T>> func, Func<Exception, IError>? catchHandler = null)
    {
        return Result<T>.TryAsync(func, catchHandler);
    }

    #endregion

}
