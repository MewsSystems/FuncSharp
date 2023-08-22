using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Enumerable = System.Linq.Enumerable;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class NonEmptyEnumerableBenchmarks
    {
        private static readonly string OnePotato = "1 potato";
        private static readonly IOption<string> OnePotatoOption = "1 potato".ToOption();
        private static readonly string TwoPotatoes = "2 potatoes";
        private static readonly IOption<string> TwoPotatoesOption = "2 potatoes".ToOption();
        private static readonly string ThreePotatoes = "3 potatoes";
        private static readonly IOption<string> ThreePotatoesOption = "3 potatoes".ToOption();
        private static readonly string FourPotatoes = "4 potatoes";
        private static readonly IOption<string> FourPotatoesOption = "4 potatoes".ToOption();
        private static readonly string FivePotatoes = "5 potatoes";
        private static readonly IOption<string> FivePotatoesOption = "5 potatoes".ToOption();
        private static readonly string SixPotatoes = "6 potatoes";
        private static readonly IOption<string> SixPotatoesOption = "6 potatoes".ToOption();
        private static readonly string SevenPotatoes = "7 potatoes";
        private static readonly IOption<string> SevenPotatoesOption = "7 potatoes".ToOption();
        private static readonly string EightPotatoes = "8 potatoes";
        private static readonly IOption<string> EightPotatoesOption = "8 potatoes".ToOption();
        private static readonly string NinePotatoes = "9 potatoes";
        private static readonly IOption<string> NinePotatoesOption = "9 potatoes".ToOption();
        private static readonly string TenPotatoes = "10 potatoes";
        private static readonly IOption<string> TenPotatoesOption = "10 potatoes".ToOption();
        private static readonly string[] Array;
        private static readonly List<string> List;
        private static readonly IReadOnlyList<string> ReadonlyList;
        private static readonly Stack<string> Stack;
        private static readonly INonEmptyEnumerable<string> NonEmptyEnumerable;
        private static readonly INonEmptyEnumerable<INonEmptyEnumerable<string>> NestedNonEmptyEnumerable;
        private static readonly INonEmptyEnumerable<string> NonEmptyWithDuplicates;

        static NonEmptyEnumerableBenchmarks()
        {
            Array = new string[] { OnePotato, TwoPotatoes, ThreePotatoes, FourPotatoes, FivePotatoes, SixPotatoes, SevenPotatoes, EightPotatoes, NinePotatoes, TenPotatoes };
            List = new List<string>(Array);
            ReadonlyList = List.AsReadOnly();
            Stack = new Stack<string>(List);
            NonEmptyEnumerable = FuncSharp.NonEmptyEnumerable.Create(List).Get();
            NestedNonEmptyEnumerable = FuncSharp.NonEmptyEnumerable.Create(NonEmptyEnumerable, NonEmptyEnumerable);
            NonEmptyWithDuplicates = FuncSharp.NonEmptyEnumerable.CreateFlat(OnePotato.ToEnumerable(), Enumerable.Repeat(TwoPotatoes, 4), Enumerable.Repeat(ThreePotatoes, 3), FourPotatoes.ToEnumerable(), FivePotatoes.ToEnumerable());
        }

        [Benchmark]
        public void Create_From_Params()
        {
            INonEmptyEnumerable<string> x = FuncSharp.NonEmptyEnumerable.Create(OnePotato, TwoPotatoes, ThreePotatoes, FourPotatoes, FivePotatoes, SixPotatoes, SevenPotatoes, EightPotatoes, NinePotatoes, TenPotatoes);
        }

        [Benchmark]
        public void Create_From_Head_Plus_IEnumerable()
        {
            INonEmptyEnumerable<string> x = FuncSharp.NonEmptyEnumerable.Create(OnePotato, Enumerable.Repeat(TwoPotatoes, 9));
        }

        [Benchmark]
        public void Create_From_Head_Plus_EnumeratedIEnumerable()
        {
            INonEmptyEnumerable<string> x = FuncSharp.NonEmptyEnumerable.Create(OnePotato, Stack);
        }

        [Benchmark]
        public void Create_From_Head_Plus_List()
        {
            INonEmptyEnumerable<string> x = FuncSharp.NonEmptyEnumerable.Create(OnePotato, List);
        }

        [Benchmark]
        public void Create_From_Head_Plus_ReadonlyList()
        {
            INonEmptyEnumerable<string> x = FuncSharp.NonEmptyEnumerable.Create(OnePotato, ReadonlyList);
        }

        [Benchmark]
        public void AsNonEmpty()
        {
            IOption<INonEmptyEnumerable<string>> x = List.AsNonEmpty();
        }

        [Benchmark]
        public void Option_Create_From_IEnumerable()
        {
            IOption<INonEmptyEnumerable<string>> x = FuncSharp.NonEmptyEnumerable.Create(Enumerable.Repeat("1 potato", 10));
        }

        [Benchmark]
        public void Option_Create_From_EnumeratedIEnumerable()
        {
            INonEmptyEnumerable<Stack<string>> x = FuncSharp.NonEmptyEnumerable.Create(Stack);
        }

        [Benchmark]
        public void Option_Create_From_List()
        {
            IOption<INonEmptyEnumerable<string>> x = FuncSharp.NonEmptyEnumerable.Create(List);
        }

        [Benchmark]
        public void Option_Create_From_Array()
        {
            IOption<INonEmptyEnumerable<string>> x = FuncSharp.NonEmptyEnumerable.Create(Array);
        }

        [Benchmark]
        public void Option_CreateFlat_From_ParamsOfOptions()
        {
            IOption<INonEmptyEnumerable<string>> x = FuncSharp.NonEmptyEnumerable.CreateFlat(OnePotatoOption, Option.Empty<string>(), TwoPotatoesOption, Option.Empty<string>(), ThreePotatoesOption, Option.Empty<string>(), FourPotatoesOption, Option.Empty<string>(), FivePotatoesOption, Option.Empty<string>(), SixPotatoesOption, Option.Empty<string>(), SevenPotatoesOption, Option.Empty<string>(), EightPotatoesOption, Option.Empty<string>(), NinePotatoesOption, Option.Empty<string>(), TenPotatoesOption);
        }

        [Benchmark]
        public void CreateFlat_NonEmpty_Plus_ParamsOfEnumerables()
        {
            INonEmptyEnumerable<string> x = FuncSharp.NonEmptyEnumerable.CreateFlat(NonEmptyEnumerable, Array, List, Stack);
        }

        [Benchmark]
        public void Concat_SingleItem_Plus_ParamsOfEnumerables()
        {
            INonEmptyEnumerable<string> x = OnePotato.Concat(Stack, Array, List);
        }

        [Benchmark]
        public void Concat_NonEmpty_Plus_ParamsOfItems()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Concat(OnePotato, TwoPotatoes, ThreePotatoes, FourPotatoes, FivePotatoes);
        }

        [Benchmark]
        public void Concat_NonEmpty_Plus_ParamsOfEnumerables()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Concat(Stack, Array, List);
        }

        [Benchmark]
        public void Distinct()
        {
            INonEmptyEnumerable<string> x = NonEmptyWithDuplicates.Distinct();
        }

        [Benchmark]
        public void Distinct_WithFunc()
        {
            INonEmptyEnumerable<string> x = NonEmptyWithDuplicates.Distinct(text => $"{text}{text}");
        }

        [Benchmark]
        public void Select()
        {
            INonEmptyEnumerable<string> x = NonEmptyWithDuplicates.Select(text => $"{text}{text}");
        }

        [Benchmark]
        public void Select_WithIndex()
        {
            INonEmptyEnumerable<string> x = NonEmptyWithDuplicates.Select((text, i) => $"{text} - {i} - {text}");
        }

        [Benchmark]
        public void SelectMany()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.SelectMany(text => NonEmptyEnumerable);
        }

        [Benchmark]
        public void Flatten()
        {
            INonEmptyEnumerable<string> x = NestedNonEmptyEnumerable.Flatten();
        }

        [Benchmark]
        public void Foreach()
        {
            foreach (var text in NonEmptyWithDuplicates)
            {
                var y = $"{text} - i - {text}";
            }
        }
    }
}