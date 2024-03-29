﻿using System.Diagnostics.Contracts;

namespace FuncSharp;

/// <summary>
/// This interface serves for generic functionality such as comparing objects, sorting etc. However it bypasses the whole point of an Option - map and Match functions for accessing value.
/// </summary>
public interface IOption
{
    /// <summary>
    /// Returns whether the option is empty (doesn't contain any value).
    /// </summary>
    [Pure]
    bool IsEmpty { get; }

    /// <summary>
    /// Returns whether the option is not empty (contain a value).
    /// </summary>
    [Pure]
    bool NonEmpty { get; }

    /// <summary>
    /// Gets the value inside the option or the default for the type of the option.
    /// </summary>
    [Pure]
    public object Value { get; }
}