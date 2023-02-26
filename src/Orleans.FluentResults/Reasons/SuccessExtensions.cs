namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class SuccessExtensions
{

    #region With Metadata

    /// <summary>
    ///     Set the metadata
    /// </summary>
    public static Success WithMetadata(this Success success, string metadataName, object metadataValue)
    {
        ArgumentNullException.ThrowIfNull(success);
        ArgumentNullException.ThrowIfNull(metadataName);
        ArgumentNullException.ThrowIfNull(metadataValue);
        return success with { Metadata = success.Metadata.SetItem(metadataName, metadataValue) };
    }

    /// <summary>
    ///     Set the metadata
    /// </summary>
    public static Success WithMetadata(this Success success, Dictionary<string, object> metadata)
    {
        ArgumentNullException.ThrowIfNull(success);
        ArgumentNullException.ThrowIfNull(metadata);
        return success with { Metadata = success.Metadata.SetItems(metadata) };
    }

    #endregion

}
