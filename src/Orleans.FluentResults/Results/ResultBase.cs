using System.Collections.Immutable;

namespace Orleans.FluentResults;

/// <summary>
/// </summary>
[Immutable]
[GenerateSerializer]
public abstract class ResultBase : IResultBase
{
    /// <summary>
    ///     Creates a new instance of <see cref="ResultBase" />
    /// </summary>
    protected ResultBase()
    {
        Reasons = ImmutableList.Create<IReason>();
    }

    /// <summary>
    ///     Creates a new instance of <see cref="ResultBase" />
    /// </summary>
    /// <param name="reasons"></param>
    protected ResultBase(IImmutableList<IReason> reasons)
    {
        ArgumentNullException.ThrowIfNull(reasons);
        Reasons = reasons;
    }

    /// <inheritdoc />
    public bool IsFailed =>
        Reasons.OfType<IError>()
               .Any();
    /// <inheritdoc />
    public bool IsSuccess => !IsFailed;

    /// <inheritdoc />
    [Id(0)]
    public IImmutableList<IReason> Reasons { get; }
    /// <inheritdoc />
    public IImmutableList<IError> Errors =>
        Reasons.OfType<IError>()
               .ToImmutableList();
    /// <inheritdoc />
    public IImmutableList<ISuccess> Successes =>
        Reasons.OfType<ISuccess>()
               .ToImmutableList();

    #region Has Error

    /// <summary>
    ///     Check if the result object contains an error from a specific type
    /// </summary>
    public bool HasError<TError>()
        where TError : IError
    {
        return HasError<TError>(out _);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type
    /// </summary>
    public bool HasError<TError>(out IEnumerable<TError> result)
        where TError : IError
    {
        return HasError(_ => true, out result);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type and with a specific condition
    /// </summary>
    public bool HasError<TError>(Func<TError, bool> predicate)
        where TError : IError
    {
        return HasError(predicate, out _);
    }

    /// <summary>
    ///     Check if the result object contains an error from a specific type and with a specific condition
    /// </summary>
    public bool HasError<TError>(Func<TError, bool> predicate, out IEnumerable<TError> result)
        where TError : IError
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return ResultHelper.HasError(Errors, predicate, out result);
    }

    /// <summary>
    ///     Check if the result object contains an error with a specific condition
    /// </summary>
    public bool HasError(Func<IError, bool> predicate)
    {
        return HasError(predicate, out _);
    }

    /// <summary>
    ///     Check if the result object contains an error with a specific condition
    /// </summary>
    public bool HasError(Func<IError, bool> predicate, out IEnumerable<IError> result)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return ResultHelper.HasError(Errors, predicate, out result);
    }

    #endregion

    #region Has Exception

    /// <summary>
    ///     Check if the result object contains an exception from a specific type
    /// </summary>
    public bool HasException<TException>()
        where TException : Exception
    {
        return HasException<TException>(out _);
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type
    /// </summary>
    public bool HasException<TException>(out IEnumerable<IError> result)
        where TException : Exception
    {
        return HasException<TException>(_ => true, out result);
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type and with a specific condition
    /// </summary>
    public bool HasException<TException>(Func<TException, bool> predicate)
        where TException : Exception
    {
        return HasException(predicate, out _);
    }

    /// <summary>
    ///     Check if the result object contains an exception from a specific type and with a specific condition
    /// </summary>
    public bool HasException<TException>(Func<TException, bool> predicate, out IEnumerable<IError> result)
        where TException : Exception
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return ResultHelper.HasException(Errors, predicate, out result);
    }

    #endregion

    #region Has Success

    /// <summary>
    ///     Check if the result object contains a success from a specific type
    /// </summary>
    public bool HasSuccess<TSuccess>()
        where TSuccess : ISuccess
    {
        return HasSuccess<TSuccess>(_ => true, out _);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type
    /// </summary>
    public bool HasSuccess<TSuccess>(out IEnumerable<TSuccess> result)
        where TSuccess : ISuccess
    {
        return HasSuccess(_ => true, out result);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type and with a specific condition
    /// </summary>
    public bool HasSuccess<TSuccess>(Func<TSuccess, bool> predicate)
        where TSuccess : ISuccess
    {
        return HasSuccess(predicate, out _);
    }

    /// <summary>
    ///     Check if the result object contains a success from a specific type and with a specific condition
    /// </summary>
    public bool HasSuccess<TSuccess>(Func<TSuccess, bool> predicate, out IEnumerable<TSuccess> result)
        where TSuccess : ISuccess
    {
        return ResultHelper.HasSuccess(Successes, predicate, out result);
    }

    /// <summary>
    ///     Check if the result object contains a success with a specific condition
    /// </summary>
    public bool HasSuccess(Func<ISuccess, bool> predicate, out IEnumerable<ISuccess> result)
    {
        return ResultHelper.HasSuccess(Successes, predicate, out result);
    }

    /// <summary>
    ///     Check if the result object contains a success with a specific condition
    /// </summary>
    public bool HasSuccess(Func<ISuccess, bool> predicate)
    {
        return ResultHelper.HasSuccess(Successes, predicate, out _);
    }

    #endregion
}
