using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp.Examples
{
    public class IOptionUsages
    {
        public IOption<decimal> Divide(decimal number, decimal divisor)
        {
            return divisor.ToOption().Where(d => d != 0).Map(d => number / d);
        }

        private void TransformingOptionValuesWithMap(decimal number, decimal divisor)
        {
            IOption<decimal> divisionResult = Divide(number, divisor);
            IOption<decimal> roundedDivisionResult = divisionResult.Map(r => Math.Round(r));
            IOption<string> stringifiedDivisionResult = divisionResult.Map(r => r.ToString());
        }

        private void HandlingCollectionsOfOptions()
        {
            var numbers = new List<int> { 1, 2, 3 };
            var divisors = new List<int> { 1, 2, 3 };
            IEnumerable<IOption<decimal>> divisionResults = numbers.SelectMany(n => divisors.Select(d => Divide(n, d))).ToList();
            IEnumerable<decimal> successfulResults1 = divisionResults.Flatten();
            IEnumerable<decimal> successfulResults2 = divisionResults.Where(r => r.NonEmpty).Select(r => r.Get()); // get throws exception when called on empty option
            int errorResultCount = divisionResults.Count(r => r.IsEmpty);
        }

        private void HandlingNestedOptionsWithFlatMap(decimal number, decimal divisor)
        {
            IOption<decimal> divisionResult = Divide(number, divisor);

            IOption<IOption<decimal>> resultOfDoubleDivision = divisionResult.Map(r => Divide(r, divisor));
            IOption<decimal> flattenedResultOfDoubleDivision = resultOfDoubleDivision.Flatten(); // this option has value if both the inner and the outer option have value.

            IOption<decimal> resultOfDoubleDivisionFlattenedDirectly = divisionResult.FlatMap(r => Divide(r, divisor)); // Flatmap on option is the same as SelectMany on collections. It directly unwraps.
        }

        private void UsingOptionValueWithMatch(decimal number, decimal divisor)
        {
            var divisionResult = Divide(number, divisor);
            // This overload takes 2 Func parameters. Each of those have to return a value and result is stored in the `roundedResult` variable.
            decimal roundedResultOrZero = divisionResult.Match(
                result => Math.Round(result),
                _ => 0
            );

            // This overload accepts 2 optional lambdas. If lambda isn't provided, nothing happens.
            divisionResult.Match(
                result => Console.Write($"Division successful, result is: {result}."),
                _ => Console.Write("Division failed, must have divided by zero.")
            );
            divisionResult.Match(result =>
            {
                // Here you could send result over network only in case the operation succeeds and ignore errors.
            });

            divisionResult.Match(ifSecond: _ =>
            {
                // Here you could only handle error and not do anything if division succeeds.
            });
        }

        private void GettingOptionValue(decimal number, decimal divisor)
        {
            var divisionResult = Divide(number, divisor);

            decimal valueOrExceptionThrown = divisionResult.Get(); // This will throw exception in case of empty option.

            decimal valueOrFallback1 = divisionResult.GetOrZero();
            decimal valueOrFallback2 = divisionResult.GetOrElse(114m);
            decimal valueOrFallback3 = divisionResult.GetOrElse(_ => 114m); // Lazy. Will only run the lambda if it needs to.

            // These two are identical:
            decimal roundedDivisionResult1 = divisionResult.Map(r => Math.Round(r)).GetOrZero();
            decimal roundedDivisionResult2 = divisionResult.Match(
                r => Math.Round(r),
                _ => 0
            );
        }

        private void OptionCreatingExamples()
        {
            IOption<bool> emptyOption1 = Option.Empty<bool>();
            bool? emptyNullableBool = null;
            IOption<bool> emptyOption2 = emptyNullableBool.ToOption();
            IOption<bool> emptyOption3 = Option.Create(emptyNullableBool);

            IOption<bool> valuedOption1 = Option.Valued<bool>(false);
            bool? nullableBool = false;
            IOption<bool> valuedOption2 = nullableBool.ToOption();
            IOption<bool> valuedOption3 = Option.Create(nullableBool);

            // Option.Valued can construct options with null value inside.
            IOption<bool?> valuedOptionWithNullInside1 = Option.Valued(emptyNullableBool);
            IOption<bool?> valuedOptionWithFalse = Option.Valued(nullableBool);
            IOption<object> valuedOptionWithNullInside2 = Option.Valued<object>(null);
        }
    }
}
