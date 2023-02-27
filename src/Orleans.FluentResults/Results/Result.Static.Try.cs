namespace Orleans.FluentResults;

public partial record Result
{

    #region Try Action

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static Result Try(Action action, Func<Exception, Error>? catchHandler = null)
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
    public static async Task<Result> TryAsync(Func<Task> action, Func<Exception, Error>? catchHandler = null)
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
    public static async ValueTask<Result> TryAsync(Func<ValueTask> action, Func<Exception, Error>? catchHandler = null)
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
    public static Result<TValue> Try<TValue>(Action action, Func<Exception, Error>? catchHandler = null)
    {
        return Result<TValue>.Try(action, catchHandler);
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static Task<Result<TValue>> TryAsync<TValue>(Func<Task> action, Func<Exception, Error>? catchHandler = null)
    {
        return Result<TValue>.TryAsync(action, catchHandler);
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static ValueTask<Result<TValue>> TryAsync<TValue>(Func<ValueTask> action, Func<Exception, Error>? catchHandler = null)
    {
        return Result<TValue>.TryAsync(action, catchHandler);
    }

    #endregion

    #region Try Generic Function

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static Result<TValue> Try<TValue>(Func<TValue> func, Func<Exception, Error>? catchHandler = null)
    {
        return Result<TValue>.Try(func, catchHandler);
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static Task<Result<TValue>> TryAsync<TValue>(Func<Task<TValue>> func, Func<Exception, Error>? catchHandler = null)
    {
        return Result<TValue>.TryAsync(func, catchHandler);
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static ValueTask<Result<TValue>> TryAsync<TValue>(Func<ValueTask<TValue>> func, Func<Exception, Error>? catchHandler = null)
    {
        return Result<TValue>.TryAsync(func, catchHandler);
    }

    #endregion

}
