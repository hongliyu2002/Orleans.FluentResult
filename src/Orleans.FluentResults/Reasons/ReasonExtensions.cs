namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class ReasonExtensions
{

    #region Has Metadata

    /// <summary>
    /// </summary>
    /// <param name="reason"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool HasMetadataKey(this IReason reason, string key)
    {
        ArgumentNullException.ThrowIfNull(reason);
        ArgumentNullException.ThrowIfNull(key);
        return reason.Metadata.ContainsKey(key);
    }

    /// <summary>
    /// </summary>
    /// <param name="reason"></param>
    /// <param name="key"></param>
    /// <param name="valueFilter"></param>
    /// <returns></returns>
    public static bool HasMetadata(this IReason reason, string key, Func<object, bool> valueFilter)
    {
        ArgumentNullException.ThrowIfNull(reason);
        ArgumentNullException.ThrowIfNull(key);
        ArgumentNullException.ThrowIfNull(valueFilter);
        return reason.Metadata.TryGetValue(key, out var actualValue) && valueFilter(actualValue);
    }

    #endregion

}
