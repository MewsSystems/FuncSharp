using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class EqualityTests
    {
        public EqualityTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        internal void Equality()
        {
            // Equal value of same type
            Assert.Equivalent(Option.Valued(14), Option.Valued(14));
            Assert.Equivalent(Option.Valued(-6), Option.Valued(-6));
            Assert.Equivalent(Option.Valued(Unit.Value), Option.Valued(Unit.Value));
            Assert.Equivalent(Option.Valued(new ReferenceType(28167)), Option.Valued(new ReferenceType(28167)));
            Assert.Equivalent(Option.Valued("ASDF123Q"), Option.Valued("ASDF123Q"));

            // Empty option of same type
            Assert.Equivalent(Option.Empty<int>(), Option.Empty<int>());
            Assert.Equivalent(Option.Empty<ReferenceType>(), Option.Empty<ReferenceType>());

            // When using covariance, the type of the option is actually different, therefore equality is false.
            Assert.NotEqual<IOption<ReferenceTypeBase>>(Option.Empty<ReferenceType>(), Option.Empty<ReferenceTypeBase>());

            // Different type.
            Assert.NotEqual<object>(Option.Valued<int>(1), Option.Valued<long>(1));
            Assert.NotEqual<object>(Option.Empty<int>(), Option.Empty<decimal>());
            Assert.NotEqual<object>(Option.Empty<decimal>(), Option.Empty<ReferenceType>());
            Assert.NotEqual<object>(Option.Empty<ReferenceType>(), Option.Empty<string>());

            // Empty and non-empty
            Assert.NotEqual(Option.Empty<int?>(), Option.Valued((int?)null));
            Assert.NotEqual(Option.Empty<int>(), Option.Valued(0));
            Assert.NotEqual(Option.Empty<int>(), Option.Valued(1));
            Assert.NotEqual(Option.Empty<string>(), Option.Valued<string>(null));
            Assert.NotEqual(Option.Empty<string>(), Option.Valued("ASDF"));
            Assert.NotEqual(Option.Empty<ReferenceType>(), Option.Valued(new ReferenceType(14)));
            Assert.NotEqual(Option.Empty<ReferenceType>(), Option.Valued<ReferenceTypeBase>(null));

            // Empty option and non-empty of different type
            Assert.NotEqual<object>(Option.Empty<int>(), Option.Valued<ReferenceTypeBase>(null));
            Assert.NotEqual<object>(Option.Empty<ReferenceType>(), Option.Valued(1));
            Assert.NotEqual<object>(Option.Empty<ReferenceType>(), Option.Valued("ASDF"));

            // Both non-empty, but different values.
            Assert.NotEqual(Option.Valued(14), Option.Valued(-6));
            Assert.NotEqual(Option.Valued(-6), Option.Valued(0));
            Assert.NotEqual(Option.Valued(new ReferenceType(28167)), Option.Valued(new ReferenceType(-5)));
            Assert.NotEqual(Option.Valued(new ReferenceType(28167)), Option.Valued<ReferenceType>(null));
            Assert.NotEqual(Option.Valued("ASDF123Q"), Option.Valued("Other string"));
            Assert.NotEqual(Option.Valued("ASDF123Q"), Option.Valued<string>(null));
        }

        [Property]
        internal void Equality_int(IOption<int> first, IOption<int> second)
        {
            AssertEquality(first, second);
        }

        [Property]
        internal void Equality_decimal(IOption<decimal> first, IOption<decimal> second)
        {
            AssertEquality(first, second);
        }

        [Property]
        internal void Equality_double(IOption<double> first, IOption<double> second)
        {
            AssertEquality(first, second);
        }

        [Property]
        internal void Equality_bool(IOption<bool> first, IOption<bool> second)
        {
            AssertEquality(first, second);
        }

        [Property]
        internal void Equality_ReferenceType(IOption<ReferenceType> first, IOption<ReferenceType> second)
        {
            AssertEquality(first, second);
        }

        private void AssertEquality<T>(IOption<T> first, IOption<T> second)
        {
            Assert.Equivalent(first, first);
            Assert.Equivalent(second, second);

            var shouldBeEqual = first.NonEmpty == second.NonEmpty && Equals(first.GetOrDefault(), second.GetOrDefault());
            Assert.Equivalent(shouldBeEqual, first.Equals(second));
        }
    }
}
