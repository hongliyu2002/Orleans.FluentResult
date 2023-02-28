namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class ErrorExtensions
{

    #region With Metadata

    /// <summary>
    ///     Set the metadata
    /// </summary>
    public static Error WithMetadata(this Error error, string metadataName, object metadataValue)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(metadataName);
        ArgumentNullException.ThrowIfNull(metadataValue);
        return error with { Metadata = error.Metadata.SetItem(metadataName, metadataValue) };
        // return error with { Metadata = error.Metadata.Add(metadataName, metadataValue) };
    }

    /// <summary>
    ///     Set the metadata
    /// </summary>
    public static Error WithMetadata(this Error error, Dictionary<string, object> metadata)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(metadata);
        return error with { Metadata = error.Metadata.SetItems(metadata) };
        // return error with { Metadata = error.Metadata.AddRange(metadata) };
    }

    #endregion

    #region Cause By

    /// <summary>
    ///     Set the root cause of the error
    /// </summary>
    public static Error CausedBy(this Error error, Error causedBy)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(causedBy);
        return error with { Reasons = error.Reasons.Add(causedBy) };
    }

    /// <summary>
    ///     Set the root cause of the error
    /// </summary>
    public static Error CausedBy(this Error error, IEnumerable<IError> causedBys)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(causedBys);
        return error with { Reasons = error.Reasons.AddRange(causedBys) };
    }

    /// <summary>
    ///     Set the root cause of the error
    /// </summary>
    public static Error CausedBy(this Error error, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(exception);
        return error with { Reasons = error.Reasons.Add(ResultSettings.Current.ExceptionalErrorFactory(exception.Message, exception)) };
    }

    /// <summary>
    ///     Set the root cause of the error
    /// </summary>
    public static Error CausedBy(this Error error, string errorMessage, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(errorMessage);
        ArgumentNullException.ThrowIfNull(exception);
        return error with { Reasons = error.Reasons.Add(ResultSettings.Current.ExceptionalErrorFactory(errorMessage, exception)) };
    }

    /// <summary>
    ///     Set the root cause of the error
    /// </summary>
    public static Error CausedBy(this Error error, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(errorMessage);
        return error with { Reasons = error.Reasons.Add(ResultSettings.Current.ErrorFactory(errorMessage)) };
    }

    /// <summary>
    ///     Set the root cause of the error
    /// </summary>
    public static Error CausedBy(this Error error, IEnumerable<string> errorMessages)
    {
        ArgumentNullException.ThrowIfNull(error);
        ArgumentNullException.ThrowIfNull(errorMessages);
        return error with { Reasons = error.Reasons.AddRange(errorMessages.Select(errorMessage => ResultSettings.Current.ErrorFactory(errorMessage))) };
    }

    #endregion

}
