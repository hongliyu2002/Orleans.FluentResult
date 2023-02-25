﻿namespace Orleans.FluentResults;

/// <summary>
/// </summary>
/// <typeparam name="TValue"></typeparam>
public interface IResult<out TValue> : IResultBase
{
    /// <summary>
    ///     Get the Value.
    /// </summary>
    TValue Value { get; }

    /// <summary>
    ///     Get the Value. If result is failed then a default value is returned. Opposite see property Value.
    /// </summary>
    TValue? ValueOrDefault { get; }
}