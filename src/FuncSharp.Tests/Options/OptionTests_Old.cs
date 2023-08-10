using Xunit;

namespace FuncSharp.Tests.Options
{
    /// <summary>
    /// Will be replaced by individual class per method. Each method should be tested with both manual unit tests and generative tests.
    /// </summary>
    public class OptionTests_Old
    {
        [Fact]
        public void OrElse()
        {
            Assert.Equal(Option.Valued(42), 42.ToOption().OrElse(_ => 53.ToOption()));
            Assert.Equal(Option.Valued(42), Option.Empty<int>().OrElse(_ => 42.ToOption()));
        }

        [Fact]
        public void GetOrElse()
        {
            Assert.Equal(42, 42.ToOption().GetOrElse(_ => 123));
            Assert.Equal(123, Option.Empty<int>().GetOrElse(_ => 123));
        }

        [Fact]
        public void GetOrZero()
        {
            Assert.Equal(42, 42.ToOption().GetOrZero());
            Assert.Equal(0, Option.Empty<int>().GetOrZero());

            Assert.Equal(14, Unit.Value.ToOption().GetOrZero(_ => 14));
            Assert.Equal(0, Option.Empty<Unit>().GetOrZero(_ => 14));
        }

        [Fact]
        public void GetOrZero_Decimal()
        {
            Assert.Equal(42m, 42m.ToOption().GetOrZero());
            Assert.Equal(0m, Option.Empty<decimal>().GetOrZero());

            Assert.Equal(14, Unit.Value.ToOption().GetOrZero(_ => 14m));
            Assert.Equal(0, Option.Empty<Unit>().GetOrZero(_ => 14m));
        }

        [Fact]
        public void GetOrFalse()
        {
            Assert.True(true.ToOption().GetOrFalse());
            Assert.False(Option.Empty<bool>().GetOrFalse());

            Assert.True(Unit.Value.ToOption().GetOrFalse(_ => true));
            Assert.False(Option.Empty<Unit>().GetOrFalse(_ => true));
        }

        [Fact]
        public void GetOrNull()
        {
            Assert.NotNull(Unit.Value.ToOption().GetOrNull());
            Assert.Null(Option.Empty<Unit>().GetOrNull());

            Assert.Equal("asd", Unit.Value.ToOption().GetOrNull(_ => "asd"));
            Assert.Null(Option.Empty<Unit>().GetOrNull(_ => "asd"));
        }

        [Fact]
        public void ToNullable()
        {
            Assert.Equal(84, 42.ToOption().ToNullable(v => (int?)v * 2));
            Assert.Equal(84, 42.ToOption().ToNullable(v => v * 2));
            Assert.Null(42.ToOption().ToNullable(v => (int?)null));

            Assert.Equal(14, "".ToOption().ToNullable(v => (int?)14));
            Assert.Equal(14, "".ToOption().ToNullable(v => 14));
            Assert.Null("".ToOption().ToNullable(v => (int?)null));


            Assert.Null(Option.Empty<int>().ToNullable(v => (int?)14));
            Assert.Null(Option.Empty<int>().ToNullable(v => 14));
            Assert.Null(Option.Empty<int>().ToNullable(v => (int?)null));
            Assert.Null(Option.Empty<string>().ToNullable(v => 14));
            Assert.Null(Option.Empty<string>().ToNullable(v => (int?)null));
        }

        [Fact]
        public void Linq()
        {
            var sum =
                from x in 1.ToOption()
                from y in 2.ToOption()
                from z in 3.ToOption()
                select x + y + z;

            Assert.Equal(6.ToOption(), sum);

            var emptySum =
                from x in 1.ToOption()
                from y in Option.Empty<int>()
                select x + y;

            Assert.Equal(Option.Empty<int>(), emptySum);

            var filteredSum =
                from x in 1.ToOption()
                from y in 2.ToOption()
                where x > 100
                select x + y;

            Assert.Equal(Option.Empty<int>(), filteredSum);
        }
    }
}
