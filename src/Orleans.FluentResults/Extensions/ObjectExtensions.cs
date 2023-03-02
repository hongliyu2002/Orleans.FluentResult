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
        // if (value is null)
        // {
        //     return Result<T>.Fail(new ArgumentNullException(nameof(value)));
        // }
        return value switch { Result<T> resultOfT => resultOfT, Result result => result.ToResult<T>(), _ => Result<T>.Ok(value) };
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
