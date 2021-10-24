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

        public static ITry<Person, IEnumerable<PersonParsingError>> Parse(string name, string age, string heightInCentimeters)
        {
            // You need to start with tries that have a collection as the type of error. So we MapError to a collection of strings here. But it can be a collection of any type.
            // For validations, you would write your validation method, so it already returns IEnumerable as the error type and use MapError inside the method.
            // Try.Aggregate method always executes all tries and then aggregates the success results or the errors. It doesn't stop on first error.
            // You can transform the result into any type you want. This makes it nice and effective way of parsing values and combining the results.

            ITry<string, IEnumerable<PersonParsingError>> parsedName = name.ToNonEmptyOption().ToTry(_ => new [] { PersonParsingError.NameNotProvided });
            ITry<int, IEnumerable<PersonParsingError>> parsedAge = ParseAge(age);
            ITry<decimal, IEnumerable<PersonParsingError>> parsedHeight =  ParseHeight(heightInCentimeters);

            // You can aggregate more than 3 tries, just saving space here.
            return Try.Aggregate(
                parsedName,
                parsedAge,
                parsedHeight,
                f: (n, a, h) => new Person(n, a, h)
            );
        }

        private static ITry<int, IEnumerable<PersonParsingError>> ParseAge(string age)
        {
            var ageAsValidNumber = Try.Catch<int, Exception>(_ => Convert.ToInt32(age)).MapError(_ => new [] { PersonParsingError.AgeNotANumber });
            var notNegativeAge = ageAsValidNumber.FlatMap(
                a => a.ToOption().Where(aa => aa >= 0).ToTry(_ => new [] { PersonParsingError.AgeNegative })
            );
            var parsedAge = notNegativeAge.FlatMap(
                a => a.ToOption().Where(aa => aa < 140).ToTry(_ => new [] { PersonParsingError.AgeTooHigh })
            );
            return parsedAge;
        }

        private static ITry<decimal, IEnumerable<PersonParsingError>> ParseHeight(string heightInCentimeters)
        {
            var convertedHeight = Try.Catch<decimal, Exception>(_ => Convert.ToDecimal(heightInCentimeters));
            var heightAsValidNumber = convertedHeight.MapError(_ => new [] { PersonParsingError.HeightNotANumber });
            var notNegativeHeight = heightAsValidNumber.FlatMap(
                a => a.ToOption().Where(aa => aa >= 0).ToTry(_ => new [] { PersonParsingError.HeightNegative })
            );
            var parsedHeight = notNegativeHeight.FlatMap(
                a => a.ToOption().Where(aa => aa < 140).ToTry(_ => new [] { PersonParsingError.HeightTooHigh })
            );
            return parsedHeight;
        }
    }
}
