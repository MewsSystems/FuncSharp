using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }

    }

    public class ExceptionsAggregateTests
    {
        private static readonly Exception SingleException;
        private static readonly IEnumerable<Exception> Enumerable_Empty;
        private static readonly IEnumerable<Exception> Enumerable_Single;
        private static readonly IEnumerable<Exception> Enumerable_Multiple;

        private static readonly Exception[] Array_Empty;
        private static readonly Exception[] Array_Single;
        private static readonly Exception[] Array_Multiple;

        private static readonly INonEmptyEnumerable<Exception> NonEmpty_Single;
        private static readonly INonEmptyEnumerable<Exception> NonEmpty_Multiple;

        static ExceptionsAggregateTests()
        {
            SingleException = new CustomException("A potato here.");
            Enumerable_Empty = Enumerable.Empty<Exception>();
            Enumerable_Single = Enumerable.Repeat(SingleException, 1);
            Enumerable_Multiple = Enumerable.Range(0, 10).Select(i => new CustomException($"{i} potatoes"));

            Array_Empty = Enumerable_Empty.ToArray();
            Array_Single = Enumerable_Single.ToArray();
            Array_Multiple = Enumerable_Multiple.ToArray();

            NonEmpty_Single = Array_Single.AsNonEmpty().Get();
            NonEmpty_Multiple = Array_Multiple.AsNonEmpty().Get();
        }

        [Fact]
        public void Aggregate_Empty()
        {
            OptionAssert.IsEmpty(Enumerable_Empty.Aggregate());
            OptionAssert.IsEmpty(Array_Empty.Aggregate());
        }

        [Fact]
        public void Aggregate_Single()
        {
            OptionAssert.NonEmptyWithValue(SingleException, Enumerable_Single.Aggregate());
            OptionAssert.NonEmptyWithValue(SingleException, Array_Single.Aggregate());
            Assert.IsType<CustomException>(NonEmpty_Single.Aggregate());
        }

        [Fact]
        public void Aggregate_Multiple()
        {
            OptionAssert.NonEmptyWithValue(new AggregateException(Enumerable_Multiple), Enumerable_Multiple.Aggregate());
            OptionAssert.NonEmptyWithValue(new AggregateException(Array_Multiple), Array_Multiple.Aggregate());
            Assert.IsType<AggregateException>(NonEmpty_Multiple.Aggregate());
        }
    }
}
