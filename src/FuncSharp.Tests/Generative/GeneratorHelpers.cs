using System;
using System.Collections.Generic;
using System.Linq;
using FsCheck;

namespace FuncSharp.Tests.Generative;

internal static class GeneratorExtensions
{
    /// <summary>
    /// Generates an empty option in 30% of the cases. Percentage can be configured by the double parameter.
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
    
    /// <summary>
    /// Generates a collection of values from a given generator.
    /// </summary>
    internal static Gen<List<T>> ToList<T>(this Gen<T> generator)
    {
        return Gen.ArrayOf(generator).Select(array => array.ToList());

    }
}
