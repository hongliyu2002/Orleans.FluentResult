namespace Orleans.FluentResults;

public partial record Result<T>
{

    #region Try Action

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static Result<T> Try(Action action, Func<Exception, Error>? catchHandler = null)
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
    public static async Task<Result<T>> TryAsync(Func<Task> action, Func<Exception, Error>? catchHandler = null)
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
    public static async ValueTask<Result<T>> TryAsync(Func<ValueTask> action, Func<Exception, Error>? catchHandler = null)
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

    #region Try Function

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static Result<T> Try(Func<T> func, Func<Exception, Error>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = func();
            return Ok(value);
        }
        catch (Exception ex)
        {
            return Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static async Task<Result<T>> TryAsync(Func<Task<T>> func, Func<Exception, Error>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await func();
            return Ok(value);
        }
        catch (Exception ex)
        {
            return Fail(catchHandler(ex));
        }
    }

    /// <summary>
    ///     Executes the action. If an exception is thrown within the action then this exception is transformed via the catchHandler to an Error object
    /// </summary>
    public static async ValueTask<Result<T>> TryAsync(Func<ValueTask<T>> func, Func<Exception, Error>? catchHandler = null)
    {
        ArgumentNullException.ThrowIfNull(func);
        catchHandler ??= ResultSettings.Current.DefaultTryCatchHandler;
        try
        {
            var value = await func();
            return Ok(value);
        }
        catch (Exception ex)
        {
            return Fail(catchHandler(ex));
        }
    }

    #endregion

}
