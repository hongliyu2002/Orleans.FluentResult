namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public interface IExceptionalError : IError
{
    /// <summary>
    ///     Exception of the error
    /// </summary>
    Exception Exception { get; }
}
