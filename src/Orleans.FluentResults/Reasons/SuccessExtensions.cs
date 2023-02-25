namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class SuccessExtensions
{

    #region With Metadata

    /// <summary>
    ///     Set the metadata
    /// </summary>
    public static ISuccess WithMetadata(this ISuccess success, string metadataName, object metadataValue)
    {
        ArgumentNullException.ThrowIfNull(success);
        ArgumentException.ThrowIfNullOrEmpty(metadataName);
        ArgumentNullException.ThrowIfNull(metadataValue);
        return new Success(success.Message, success.Metadata.SetItem(metadataName, metadataValue));
    }

    /// <summary>
    ///     Set the metadata
    /// </summary>
    public static ISuccess WithMetadata(this ISuccess success, Dictionary<string, object> metadata)
    {
        ArgumentNullException.ThrowIfNull(success);
        ArgumentNullException.ThrowIfNull(metadata);
        return new Success(success.Message, success.Metadata.SetItems(metadata));
    }

    #endregion

}
