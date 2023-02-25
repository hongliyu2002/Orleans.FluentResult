namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class ErrorExtensions
{

    #region With Metadata

    /// <summary>
    ///     Set the metadata
    /// </summary>
    public static IError WithMetadata(this IError error, string metadataName, object metadataValue)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentException.ThrowIfNullOrEmpty(metadataName);
        ArgumentNullException.ThrowIfNull(metadataValue);
        return new Error(error.Message, error.Metadata.SetItem(metadataName, metadataValue), error.Reasons);
    }

    /// <summary>
    ///     Set the metadata
    /// </summary>
    public static IError WithMetadata(this IError error, Dictionary<string, object> metadata)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(metadata);
        return new Error(error.Message, error.Metadata.SetItems(metadata), error.Reasons);
    }

    #endregion

    #region Cause By

    /// <summary>
    ///     Set the root cause of the error
    /// </summary>
    public static IError CausedBy(this IError error, IError otherError)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(otherError);
        return new Error(error.Message, error.Metadata, error.Reasons.Add(otherError));
    }

    /// <summary>
    ///     Set the root cause of the error
    /// </summary>
    public static IError CausedBy(this IError error, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(exception);
        return new Error(error.Message, error.Metadata, error.Reasons.Add(ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)));
    }

    /// <summary>
    ///     Set the root cause of the error
    /// </summary>
    public static IError CausedBy(this IError error, string message, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentException.ThrowIfNullOrEmpty(message);
        ArgumentNullException.ThrowIfNull(exception);
        return new Error(error.Message, error.Metadata, error.Reasons.Add(ResultSettings.Current.ExceptionalErrorFactory(message, exception)));
    }

    /// <summary>
    ///     Set the root cause of the error
    /// </summary>
    public static IError CausedBy(this IError error, string message)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentException.ThrowIfNullOrEmpty(message);
        return new Error(error.Message, error.Metadata, error.Reasons.Add(ResultSettings.Current.ErrorFactory(message)));
    }

    /// <summary>
    ///     Set the root cause of the error
    /// </summary>
    public static IError CausedBy(this IError error, IEnumerable<IError> otherErrors)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(otherErrors);
        return new Error(error.Message, error.Metadata, error.Reasons.AddRange(otherErrors));
    }

    /// <summary>
    ///     Set the root cause of the error
    /// </summary>
    public static IError CausedBy(this IError error, IEnumerable<string> messages)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(messages);
        return new Error(error.Message, error.Metadata, error.Reasons.AddRange(messages.Select(errorMessage => ResultSettings.Current.ErrorFactory(errorMessage))));
    }

    #endregion

}
