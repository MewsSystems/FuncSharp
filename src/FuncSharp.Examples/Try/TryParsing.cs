using System;
using System.Collections.Generic;

namespace FuncSharp.Examples
{
    public enum PersonParsingError
    {
        NameNotProvided,
        AgeNotANumber,
        AgeNegative,
        AgeTooHigh,
        HeightNotANumber,
        HeightNegative,
        HeightTooHigh
    }

    public class Person
    {
        private Person(string name, int age, decimal heightInCentimeters)
        {
            Name = name;
            Age = age;
            HeightInCentimeters = heightInCentimeters;
        }

        public string Name { get; }
        public int Age { get; }
        public decimal HeightInCentimeters { get; }

        public static Try<Person, IReadOnlyList<PersonParsingError>> Parse(string name, string age, string height)
        {
            // Try.Aggregate method always executes all tries and then aggregates the success results or the errors. It doesn't stop on first error.
            // You can transform the result into any type you want. This makes it nice and effective way of parsing values and combining the results.
            return Try.Aggregate(
                ParseName(name),
                ParseAge(age),
                ParseHeight(height),
                (n, a, h) => new Person(n, a, h)
            );
        }

        private static Try<NonEmptyString, PersonParsingError> ParseName(string name)
        {
            return name.AsNonEmpty().ToTry(_ => PersonParsingError.NameNotProvided);
        }

        private static Try<int, PersonParsingError> ParseAge(string age)
        {
            var numericAge = Try.Catch<int, Exception>(_ => Convert.ToInt32(age));
            var validAge = numericAge.MapError(_ => PersonParsingError.AgeNotANumber);
            var positiveAge = validAge.Where(a => a >= 0, _ => PersonParsingError.AgeNegative);
            var reasonableAge = positiveAge.Where(a => a < 140, _ => PersonParsingError.AgeTooHigh);

            return reasonableAge;
        }

        private static Try<decimal, PersonParsingError> ParseHeight(string height)
        {
            var numericHeight = Try.Catch<decimal, Exception>(_ => Convert.ToDecimal(height));
            var validHeight = numericHeight.MapError(_ => PersonParsingError.HeightNotANumber);
            var positiveHeight = validHeight.Where(h => h >= 0, _ => PersonParsingError.HeightNegative);
            var reasonableHeight = positiveHeight.Where(h => h < 300, _ => PersonParsingError.HeightTooHigh);

            return reasonableHeight;
        }
    }
}
