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

        [Benchmark]
        public void Create_From_Params()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(OnePotato, TwoPotatoes, ThreePotatoes, OnePotato, TwoPotatoes, ThreePotatoes);
        }

        [Benchmark]
        public void Create_From_Head_Plus_IEnumerable()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(OnePotato, Enumerable.Repeat(TwoPotatoes, 5));
        }

        [Benchmark]
        public void Create_From_Head_Plus_EnumeratedIEnumerable()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(OnePotato, Stack);
        }

        [Benchmark]
        public void Create_From_Head_Plus_List()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(OnePotato, List);
        }

        [Benchmark]
        public void Create_From_Head_Plus_ReadonlyList()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(OnePotato, ReadonlyList);
        }

        [Benchmark]
        public void AsNonEmpty()
        {
            IOption<INonEmptyEnumerable<string>> x = List.AsNonEmpty();
        }

        [Benchmark]
        public void Option_Create_From_EmptyEnumerable()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create(Enumerable.Empty<string>());
        }

        [Benchmark]
        public void Option_Create_From_IEnumerable()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create(Enumerable.Repeat(OnePotato, 5));
        }

        [Benchmark]
        public void Option_Create_From_EnumeratedIEnumerable()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create<string>(Stack);
        }

        [Benchmark]
        public void Option_Create_From_List()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create(List);
        }

        [Benchmark]
        public void Option_Create_From_Array()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create(Array);
        }

        [Benchmark]
        public void Option_CreateFlat_From_ParamsOfOptions()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.CreateFlat(OnePotatoOption, Option.Empty<string>(), TwoPotatoesOption, Option.Empty<string>(), ThreePotatoesOption, Option.Empty<string>());
        }

        [Benchmark]
        public void CreateFlat_NonEmpty_Plus_ParamsOfEnumerables()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.CreateFlat(ShortNonEmpty, Array, Stack);
        }

        [Benchmark]
        public void Concat_SingleItem_Plus_ParamsOfEnumerables()
        {
            INonEmptyEnumerable<string> x = OnePotato.Concat(Stack, Array);
        }

        [Benchmark]
        public void Concat_NonEmpty_Plus_ParamsOfItems()
        {
            INonEmptyEnumerable<string> x = ShortNonEmpty.Concat(OnePotato, TwoPotatoes, ThreePotatoes);
        }

        [Benchmark]
        public void Concat_NonEmpty_Plus_ParamsOfEnumerables()
        {
            INonEmptyEnumerable<string> x = ShortNonEmpty.Concat(Stack, Array);
        }

        [Benchmark]
        public void Distinct()
        {
            INonEmptyEnumerable<string> x = NonEmptyWithDuplicates.Distinct();
        }

        [Benchmark]
        public void Distinct_WithFunc()
        {
            INonEmptyEnumerable<string> x = NonEmptyWithDuplicates.Distinct(text => text);
        }

        [Benchmark]
        public void Select()
        {
            INonEmptyEnumerable<string> x = ShortNonEmpty.Select(text => text);
        }

        [Benchmark]
        public void Select_WithIndex()
        {
            INonEmptyEnumerable<string> x = ShortNonEmpty.Select((text, i) => text);
        }

        [Benchmark]
        public void SelectMany()
        {
            INonEmptyEnumerable<string> x = ShortNonEmpty.SelectMany(text => ShortNonEmpty);
        }

        [Benchmark]
        public void Flatten()
        {
            INonEmptyEnumerable<string> x = NestedNonEmpty.Flatten();
        }

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