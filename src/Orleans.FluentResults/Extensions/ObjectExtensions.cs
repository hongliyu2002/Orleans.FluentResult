namespace Orleans.FluentResults;

/// <summary>
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Result<T> ToResult<T>(this T value)
    {
        if (value is Result<T> resultOfT)
        {
            return resultOfT;
        }
        if (value is Result result)
        {
            return result.ToResult<T>();
        }
        return new Result<T>(value);
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
