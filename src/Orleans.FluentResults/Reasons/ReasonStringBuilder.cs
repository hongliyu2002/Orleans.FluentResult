namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public class ReasonStringBuilder
{
    private readonly List<string> _infos = new();
    private string _reasonType = string.Empty;

    /// <summary>
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public ReasonStringBuilder WithReasonType(Type type)
    {
        _reasonType = type.Name;
        return this;
    }

    /// <summary>
    /// </summary>
    /// <param name="label"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public ReasonStringBuilder WithInfo(string label, string value)
    {
        var infoString = value.ToLabelValueStringOrEmpty(label);
        if (!string.IsNullOrEmpty(infoString))
        {
            _infos.Add(infoString);
        }
        return this;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public string Build()
    {
        var reasonInfoText = _infos.Any() ? $" with {string.Join(", ", _infos)}" : string.Empty;
        return $"{_reasonType}{reasonInfoText}";
    }
}
