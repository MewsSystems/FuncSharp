using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Enumerable = System.Linq.Enumerable;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class NonEmptyEnumerableBenchmarks
    {
        private static readonly string onePotato = "1 potato";
        private static readonly IOption<string> onePotatoOption = "1 potato".ToOption();
        private static readonly string twoPotatoes = "2 potatoes";
        private static readonly IOption<string> twoPotatoesOption = "2 potatoes".ToOption();
        private static readonly string threePotatoes = "3 potatoes";
        private static readonly IOption<string> threePotatoesOption = "3 potatoes".ToOption();
        private static readonly string fourPotatoes = "4 potatoes";
        private static readonly IOption<string> fourPotatoesOption = "4 potatoes".ToOption();
        private static readonly string fivePotatoes = "5 potatoes";
        private static readonly IOption<string> fivePotatoesOption = "5 potatoes".ToOption();
        private static readonly string sixPotatoes = "6 potatoes";
        private static readonly IOption<string> sixPotatoesOption = "6 potatoes".ToOption();
        private static readonly string sevenPotatoes = "7 potatoes";
        private static readonly IOption<string> sevenPotatoesOption = "7 potatoes".ToOption();
        private static readonly string eightPotatoes = "8 potatoes";
        private static readonly IOption<string> eightPotatoesOption = "8 potatoes".ToOption();
        private static readonly string ninePotatoes = "9 potatoes";
        private static readonly IOption<string> ninePotatoesOption = "9 potatoes".ToOption();
        private static readonly string tenPotatoes = "10 potatoes";
        private static readonly IOption<string> tenPotatoesOption = "10 potatoes".ToOption();
        private static readonly string[] _array;
        private static readonly List<string> _list;
        private static readonly IReadOnlyList<string> _readonlyList;
        private static readonly Stack<string> _stack;
        private static readonly INonEmptyEnumerable<string> _nonEmptyEnumerable;
        private static readonly INonEmptyEnumerable<INonEmptyEnumerable<string>> _nestedNonEmptyEnumerable;
        private static readonly INonEmptyEnumerable<string> _nonEmptyWithDuplicates;

        static NonEmptyEnumerableBenchmarks()
        {
            _array = new string[] { onePotato, twoPotatoes, threePotatoes, fourPotatoes, fivePotatoes, sixPotatoes, sevenPotatoes, eightPotatoes, ninePotatoes, tenPotatoes };
            _list = new List<string>(_array);
            _readonlyList = _list.AsReadOnly();
            _stack = new Stack<string>(_list);
            _nonEmptyEnumerable = NonEmptyEnumerable.Create(_list).Get();
            _nestedNonEmptyEnumerable = NonEmptyEnumerable.Create(_nonEmptyEnumerable, _nonEmptyEnumerable);
            _nonEmptyWithDuplicates = NonEmptyEnumerable.CreateFlat(onePotato.ToEnumerable(), Enumerable.Repeat(twoPotatoes, 4), Enumerable.Repeat(threePotatoes, 3), fourPotatoes.ToEnumerable(), fivePotatoes.ToEnumerable());
        }

        [Benchmark]
        public void Create_From_Params()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(onePotato, twoPotatoes, threePotatoes, fourPotatoes, fivePotatoes, sixPotatoes, sevenPotatoes, eightPotatoes, ninePotatoes, tenPotatoes);
        }

        [Benchmark]
        public void Create_From_Head_Plus_IEnumerable()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(onePotato, Enumerable.Repeat(twoPotatoes, 9));
        }

        [Benchmark]
        public void Create_From_Head_Plus_EnumeratedIEnumerable()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(onePotato, _stack);
        }

        [Benchmark]
        public void Create_From_Head_Plus_List()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(onePotato, _list);
        }

        [Benchmark]
        public void Create_From_Head_Plus_ReadonlyList()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.Create(onePotato, _readonlyList);
        }

        [Benchmark]
        public void AsNonEmpty()
        {
            IOption<INonEmptyEnumerable<string>> x = _list.AsNonEmpty();
        }

        [Benchmark]
        public void Option_Create_From_IEnumerable()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create(Enumerable.Repeat("1 potato", 10));
        }

        [Benchmark]
        public void Option_Create_From_EnumeratedIEnumerable()
        {
            INonEmptyEnumerable<Stack<string>> x = NonEmptyEnumerable.Create(_stack);
        }

        [Benchmark]
        public void Option_Create_From_List()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create(_list);
        }

        [Benchmark]
        public void Option_Create_From_Array()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.Create(_array);
        }

        [Benchmark]
        public void Option_CreateFlat_From_ParamsOfOptions()
        {
            IOption<INonEmptyEnumerable<string>> x = NonEmptyEnumerable.CreateFlat(onePotatoOption, Option.Empty<string>(), twoPotatoesOption, Option.Empty<string>(), threePotatoesOption, Option.Empty<string>(), fourPotatoesOption, Option.Empty<string>(), fivePotatoesOption, Option.Empty<string>(), sixPotatoesOption, Option.Empty<string>(), sevenPotatoesOption, Option.Empty<string>(), eightPotatoesOption, Option.Empty<string>(), ninePotatoesOption, Option.Empty<string>(), tenPotatoesOption);
        }

        [Benchmark]
        public void CreateFlat_NonEmpty_Plus_ParamsOfEnumerables()
        {
            INonEmptyEnumerable<string> x = NonEmptyEnumerable.CreateFlat(_nonEmptyEnumerable, _array, _list, _stack);
        }

        [Benchmark]
        public void Concat_SingleItem_Plus_ParamsOfEnumerables()
        {
            INonEmptyEnumerable<string> x = onePotato.Concat(_stack, _array, _list);
        }

        [Benchmark]
        public void Concat_NonEmpty_Plus_ParamsOfItems()
        {
            INonEmptyEnumerable<string> x = _nonEmptyEnumerable.Concat(onePotato, twoPotatoes, threePotatoes, fourPotatoes, fivePotatoes);
        }

        [Benchmark]
        public void Concat_NonEmpty_Plus_ParamsOfEnumerables()
        {
            INonEmptyEnumerable<string> x = _nonEmptyEnumerable.Concat(_stack, _array, _list);
        }

        [Benchmark]
        public void Distinct()
        {
            INonEmptyEnumerable<string> x = _nonEmptyWithDuplicates.Distinct();
        }

        [Benchmark]
        public void Distinct_WithFunc()
        {
            INonEmptyEnumerable<string> x = _nonEmptyWithDuplicates.Distinct(text => $"{text}{text}");
        }

        [Benchmark]
        public void Select()
        {
            INonEmptyEnumerable<string> x = _nonEmptyWithDuplicates.Select(text => $"{text}{text}");
        }

        [Benchmark]
        public void Select_WithIndex()
        {
            INonEmptyEnumerable<string> x = _nonEmptyWithDuplicates.Select((text, i) => $"{text} - {i} - {text}");
        }

        [Benchmark]
        public void SelectMany()
        {
            INonEmptyEnumerable<string> x = _nonEmptyEnumerable.SelectMany(text => _nonEmptyEnumerable);
        }

        [Benchmark]
        public void Flatten()
        {
            INonEmptyEnumerable<string> x = _nestedNonEmptyEnumerable.Flatten();
        }

        [Benchmark]
        public void Foreach()
        {
            foreach (var text in _nonEmptyWithDuplicates)
            {
                var y = $"{text} - i - {text}";
            }
        }
    }
}