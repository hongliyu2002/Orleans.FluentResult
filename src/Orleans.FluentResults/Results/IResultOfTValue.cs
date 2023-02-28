namespace Orleans.FluentResults;

/// <inheritdoc />
/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IResult<out T> : IResult
{
    /// <summary>
    ///     Get the original value regardless the status is failed or success.
    /// </summary>
    T Value { get; }

    /// <summary>
    ///     Get the Value. If result is failed then a default value is returned. Opposite see property Value.
    /// </summary>
    T? ValueOrDefault { get; }
}
