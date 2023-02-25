namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Result<TValue> ToResult<TValue>(this TValue value)
    {
        return new Result<TValue>(value);
    }
    
    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="label"></param>
    /// <returns></returns>
    internal static string ToLabelValueStringOrEmpty(this object? value, string label)
    {
        if (value == null)
        {
            return string.Empty;
        }
        var valueText = value.ToString();
        return valueText == string.Empty ? string.Empty : $"{label}='{valueText}'";
    }
}
