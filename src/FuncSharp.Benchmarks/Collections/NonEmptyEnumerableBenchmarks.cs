using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Enumerable = System.Linq.Enumerable;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class NonEmptyEnumerableBenchmarks
    {
        private const string OnePotato = "1 potato";
        private static readonly IOption<string> OnePotatoOption = OnePotato.ToOption();
        private const string TwoPotatoes = "2 potatoes";
        private static readonly IOption<string> TwoPotatoesOption = TwoPotatoes.ToOption();
        private const string ThreePotatoes = "3 potatoes";
        private static readonly IOption<string> ThreePotatoesOption = ThreePotatoes.ToOption();
        private static readonly string[] Array;
        private static readonly List<string> List;
        private static readonly IReadOnlyList<string> ReadonlyList;
        private static readonly Stack<string> Stack;
        private static readonly INonEmptyEnumerable<string> ShortNonEmpty;
        private static readonly INonEmptyEnumerable<string> NonEmptyWithDuplicates;
        private static readonly INonEmptyEnumerable<INonEmptyEnumerable<string>> NestedNonEmpty;

        static NonEmptyEnumerableBenchmarks()
        {
            Array = new[] { OnePotato, TwoPotatoes, ThreePotatoes };
            List = new List<string>(Array);
            ReadonlyList = List.AsReadOnly();
            Stack = new Stack<string>(List);
            ShortNonEmpty = NonEmptyEnumerable.Create(OnePotato, TwoPotatoes);
            NonEmptyWithDuplicates = NonEmptyEnumerable.CreateFlat(OnePotato.ToEnumerable(), Enumerable.Repeat(TwoPotatoes, 2), Enumerable.Repeat(ThreePotatoes, 2));
            NestedNonEmpty = NonEmptyEnumerable.Create(ShortNonEmpty, ShortNonEmpty);
        }

        // Last Result - 22.8.2023 - 11.0 ns - 96 B
        [Benchmark]
        public void Create_From_Params()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(OnePotato, TwoPotatoes, ThreePotatoes, OnePotato, TwoPotatoes, ThreePotatoes);
        }

        // Last Result - 22.8.2023 - 34.5 ns - 136 B
        [Benchmark]
        public void Create_From_Head_Plus_IEnumerable()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(OnePotato, Enumerable.Repeat(TwoPotatoes, 5));
        }

        // Last Result - 22.8.2023 - 70.7 ns - 176 B
        [Benchmark]
        public void Create_From_Head_Plus_EnumeratedIEnumerable()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(OnePotato, Stack);
        }

        // Last Result - 22.8.2023 - 3.7 ns - 32 B
        [Benchmark]
        public void Create_From_Head_Plus_List()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(OnePotato, List);
        }

        // Last Result - 22.8.2023 - 3.7 ns - 32 B
        [Benchmark]
        public void Create_From_Head_Plus_ReadonlyList()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(OnePotato, ReadonlyList);
        }

        // Last Result - 22.8.2023 - 24.8 ns - 104 B
        [Benchmark]
        public void AsNonEmpty()
        {
            IOption<INonEmptyEnumerable<string>> x = List.AsNonEmpty();
        }

        // Last Result - 22.8.2023 - 15.7 ns - 0 B
        [Benchmark]
        public void Option_Create_From_EmptyEnumerable()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create(Enumerable.Empty<string>());
        }

        // Last Result - 22.8.2023 - 56.5 ns - 224 B
        [Benchmark]
        public void Option_Create_From_IEnumerable()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create(Enumerable.Repeat(OnePotato, 5));
        }

        // Last Result - 22.8.2023 - 95.9 ns - 248 B
        [Benchmark]
        public void Option_Create_From_EnumeratedIEnumerable()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create<string>(Stack);
        }

        // Last Result - 22.8.2023 - 20.4 ns - 104 B
        [Benchmark]
        public void Option_Create_From_List()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create(List);
        }

        // Last Result - 22.8.2023 - 11.2 ns - 104 B
        [Benchmark]
        public void Option_Create_From_Array()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create(Array);
        }

        // Last Result - 22.8.2023 - 241.7 ns - 528 B
        [Benchmark]
        public void Option_CreateFlat_From_ParamsOfOptions()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.CreateFlat(OnePotatoOption, Option.Empty<string>(), TwoPotatoesOption, Option.Empty<string>(), ThreePotatoesOption, Option.Empty<string>());
        }

        // Last Result - 22.8.2023 - 318.2 ns - 704 B
        [Benchmark]
        public void CreateFlat_NonEmpty_Plus_ParamsOfEnumerables()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.CreateFlat(ShortNonEmpty, Array, Stack);
        }

        // Last Result - 22.8.2023 - 157.7 ns - 392 B
        [Benchmark]
        public void Concat_SingleItem_Plus_ParamsOfEnumerables()
        {
            INonEmptyEnumerable<string> x = OnePotato.Concat(Stack, Array);
        }

        // Last Result - 22.8.2023 - 82.7 ns - 248 B
        [Benchmark]
        public void Concat_NonEmpty_Plus_ParamsOfItems()
        {
            INonEmptyEnumerable<string> x = ShortNonEmpty.Concat(OnePotato, TwoPotatoes, ThreePotatoes);
        }

        // Last Result - 22.8.2023 - 248.3 ns - 576 B
        [Benchmark]
        public void Concat_NonEmpty_Plus_ParamsOfEnumerables()
        {
            INonEmptyEnumerable<string> x = ShortNonEmpty.Concat(Stack, Array);
        }

        // Last Result - 22.8.2023 - 153.6 ns - 440 B
        [Benchmark]
        public void Distinct()
        {
            INonEmptyEnumerable<string> x = NonEmptyWithDuplicates.Distinct();
        }

        // Last Result - 22.8.2023 - 205.0 ns - 496 B
        [Benchmark]
        public void Distinct_WithFunc()
        {
            INonEmptyEnumerable<string> x = NonEmptyWithDuplicates.Distinct(text => text);
        }

        // Last Result - 22.8.2023 - 31.5 ns - 112 B
        [Benchmark]
        public void Select()
        {
            INonEmptyEnumerable<string> x = ShortNonEmpty.Select(text => text);
        }

        // Last Result - 22.8.2023 - 80.5 ns - 320 B
        [Benchmark]
        public void Select_WithIndex()
        {
            INonEmptyEnumerable<string> x = ShortNonEmpty.Select((text, i) => text);
        }

        // Last Result - 22.8.2023 - 227.9 ns -552 B
        [Benchmark]
        public void SelectMany()
        {
            INonEmptyEnumerable<string> x = ShortNonEmpty.SelectMany(text => ShortNonEmpty);
        }

        // Last Result - 22.8.2023 - 233.8 ns - 552 B
        [Benchmark]
        public void Flatten()
        {
            INonEmptyEnumerable<string> x = NestedNonEmpty.Flatten();
        }

        // Last Result - 22.8.2023 - 49.3 ns - 80 B
        [Benchmark]
        public void Foreach()
        {
            foreach (var text in NonEmptyWithDuplicates)
            {
                var y = text;
            }
        }
    }
}