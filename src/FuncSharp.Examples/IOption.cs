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

        private void HandlingNestedOptionsWithFlatMap(decimal number, decimal firstDivisor, decimal secondDivisor)
        {
            IOption<decimal> divisionResult = Divide(number, firstDivisor);
            IOption<IOption<decimal>> resultOfDoubleDivision = divisionResult.Map(r => Divide(r, secondDivisor));

            // This option has value if both the inner and the outer option have value.
            IOption<decimal> flattenedResultOfDoubleDivision1 = resultOfDoubleDivision.Flatten();

            // Same can be done with 1 call.
            IOption<decimal> flattenedResultOfDoubleDivision2 = divisionResult.FlatMap(r => Divide(r, secondDivisor));
        }

        private void UsingOptionValueWithMatch(decimal number, decimal divisor)
        {
            var divisionResult = Divide(number, divisor);

            // This overload takes 2 Func parameters. Each of those have to return a value and result is stored in the roundedResult variable.
            decimal roundedResultOrFourteen = divisionResult.Match(
                result => Math.Round(result),
                _ => 14
            );

            // This overload accepts 2 optional void lambdas. If lambda isn't provided, nothing happens for that case.
            divisionResult.Match(
                result => Console.Write($"Division successful, result is: {result}."),
                _ => Console.Write("Division failed, must have divided by zero.")
            );
            divisionResult.Match(result => Console.Write($"Division successful, result is: {result}."));
            divisionResult.Match(ifSecond: _ => Console.Write("Division failed, must have divided by zero."));
        }

        private void GettingOptionValue(decimal number, decimal divisor)
        {
            var divisionResult = Divide(number, divisor);

            // Get method will throw an exception in case of empty option. Using it is an anti-pattern.
            // You should rather use Match to branch your code into individual cases where each case is guaranteed to work.
            decimal valueOrExceptionThrown = divisionResult.Get();

            decimal valueOrFallback1 = divisionResult.GetOrZero();
            decimal valueOrFallback2 = divisionResult.GetOrElse(114m);
            decimal valueOrFallback3 = divisionResult.GetOrElse(_ => 114m); // Lazy. Will only run the lambda if it needs to.

            // These two are identical. Just Map creates one extra instance of Option for no reason.
            decimal roundedDivisionResult1 = divisionResult.Map(r => Math.Round(r)).GetOrZero();
            decimal roundedDivisionResult2 = divisionResult.Match(
                r => Math.Round(r),
                _ => 0
            );
        }

        private void HandlingCollectionsOfOptions(List<int> numbers, List<int> divisors)
        {
            IEnumerable<IOption<decimal>> divisionResults = numbers.SelectMany(n => divisors.Select(d => Divide(n, d))).ToList();

            // These two lines produce equal results. But flatten is more readable and generally using Get is an anti-pattern as it is not safe.
            IEnumerable<decimal> successfulResults1 = divisionResults.Flatten();

            // Get method throws exception when called on empty option
            IEnumerable<decimal> successfulResults2 = divisionResults.Where(r => r.NonEmpty).Select(r => r.Get());

            int errorResultCount = divisionResults.Count(r => r.IsEmpty);
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

            // Option.Valued can construct options with null value inside. Therefore it can cause confusion and is an anti-pattern.
            IOption<bool?> valuedOptionWithNullInside1 = Option.Valued(emptyNullableBool);
            IOption<bool?> valuedOptionWithFalse = Option.Valued(nullableBool);
            IOption<object> valuedOptionWithNullInside2 = Option.Valued<object>(null);

            // Instead, you can use option of an option. For example when updating a value of a nullable property.
            // Outer option defines whether we're changing value, inner option holds the value to assign.
            IOption<IOption<bool>> notUpdating = Option.Empty<IOption<bool>>();
            IOption<IOption<bool>> settingToTrue1 = true.ToOption().ToOption();
            IOption<IOption<bool>> settingToTrue2 = Option.Create(true.ToOption());
            IOption<IOption<bool>> settingToTrue3 = Option.Create(Option.Create(true));
            IOption<IOption<bool>> settingToNull1 = Option.Empty<bool>().ToOption();
            IOption<IOption<bool>> settingToNull2 = Option.Create(Option.Empty<bool>());
        }
    }
}
