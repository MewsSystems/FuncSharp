using Xunit;

namespace FuncSharp.Tests;

/// <summary>
/// A class with methods for asserting expected states of IOption
/// </summary>
public class OptionAssert
{
    /// <summary>
    /// Checks that an option is empty. If it is not, the assert fails.
    /// </summary>
    /// <param name="option">The option to check for being empty.</param>
    /// <param name="message">Message to display if the assert fails. If null, a generic message with the value of the failed option is used.</param>
    /// <typeparam name="T">Type of the option</typeparam>
    public static void IsEmpty<T>(IOption<T> option, string message = null)
    {
        Assert.True(option.IsEmpty, message ?? $"Option was expected to be empty, but had a value `{option.GetOrDefault()}`.");
    }

    /// <summary>
    /// Checks that an option has a value. If it is empty, the assert fails.
    /// </summary>
    /// <param name="option">The option to check for being empty.</param>
    /// <param name="message">Message to display if the assert fails. If null, a generic message is used.</param>
    /// <typeparam name="T">Type of the option</typeparam>
    public static void NonEmpty<T>(IOption<T> option, string message = null)
    {
        Assert.True(option.NonEmpty, message ?? "Option was expected to have a value, but was empty.");
    }

    /// <summary>
    /// Checks that an option has a specific value. If it is empty or has a different value, the assert fails.
    /// </summary>
    /// <param name="option">The option to check for having a specific value.</param>
    /// <param name="message">Message to display if the assert fails. If null, a generic message is used.</param>
    /// <typeparam name="T">Type of the option</typeparam>
    public static void HasValue<T>(T expected, IOption<T> option, string message = null)
    {
        Assert.True(option.NonEmpty, message ?? "Option was expected to have a value, but was empty.");
        Assert.Equal(expected, option.Get());
    }
}
