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
        [Fact]
        public void Aggregate_Empty()
        {
            IEnumerable<Exception> enumerable = Enumerable.Empty<Exception>();
            Exception[] array = new Exception[]{};

            OptionAssert.IsEmpty(enumerable.Aggregate());
            OptionAssert.IsEmpty(array.Aggregate());
        }

        [Fact]
        public void Aggregate_Single()
        {
            var singleException = new CustomException("A potato here.");

            IEnumerable<Exception> enumerable = Enumerable.Repeat(singleException, 1);
            CustomException[] array = new []{singleException};
            var nonEmpty = array.AsNonEmpty().Get();

            OptionAssert.NonEmptyWithValue(singleException, enumerable.Aggregate());
            OptionAssert.NonEmptyWithValue(singleException, array.Aggregate());
            Assert.IsType<CustomException>(nonEmpty.Aggregate());
        }

        [Fact]
        public void Aggregate_Multiple()
        {
            IEnumerable<Exception> enumerable = Enumerable.Range(0, 10).Select(i => new CustomException($"{i} potatoes"));
            CustomException[] array = Enumerable.Range(0, 10).Select(i => new CustomException($"{i} potatoes")).ToArray();
            INonEmptyEnumerable<Exception> nonEmpty = array.AsNonEmpty().Get();

            OptionAssert.NonEmptyWithValue(new AggregateException(array), enumerable.Aggregate());
            OptionAssert.NonEmptyWithValue(new AggregateException(array), array.Aggregate());
            Assert.Equal(new AggregateException(array), nonEmpty.Aggregate());
        }
    }
}
