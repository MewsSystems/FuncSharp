using System;
using System.Collections.Generic;
using FsCheck;

namespace FuncSharp.Tests;

internal static class GeneratorHelpers
{
    /// <summary>
    /// Generates random value from the collection of items.
    /// It has weird signature because with params, C# thinks we're calling the IEnumerable when we provide only 1 item.
    /// </summary>
    internal static Gen<T> ChooseFrom<T>(T first, T second, params T[] other)
    {
        var values = new List<T> { first, second };
        values.AddRange(other);
        return ChooseFrom(values);
    }

    /// <summary>
    /// Generates random value from the collection of items.
    /// </summary>
    internal static Gen<T> ChooseFrom<T>(IEnumerable<T> values)
    {
        return Gen.Elements(values);
    }

    /// <summary>
    /// Generates an empty option in 20% of the cases. Percentage can be configured by the double parameter.
    /// </summary>
    internal static Gen<IOption<T>> SometimesEmpty<T>(this Gen<T> generator, double emptyChance = 0.3)
    {
        if (emptyChance <= 0 || emptyChance >= 1)
        {
            throw new ArgumentException("EmptyChance must be between 0 and 1.");
        }

        return generator.SelectMany(val => Gen.Choose(0, 1000).Select(i =>
        {
            if (i > emptyChance * 100)
                return val.ToOption();
            else
                return Option.Empty<T>();
        }));
    }
}
