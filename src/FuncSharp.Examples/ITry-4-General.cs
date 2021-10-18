using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp.Examples
{
    public class ITryUsages
    {
        private void TransformingResultValuesWithMap()
        {
            ITry<int, NetworkOperationError> downloadedNumber = Api.DownloadNumberOverNetwork();
            ITry<decimal, NetworkOperationError> castedNumber = downloadedNumber.Map(r => (decimal)r);
            ITry<string, NetworkOperationError> stringifiedNumber = downloadedNumber.Map(r => r.ToString());
        }

        private void TransformingErrorValuesWithMapError()
        {
            ITry<int, NetworkOperationError> multiplicationResult = Api.DownloadNumberOverNetwork();

            // You can use MapError to map for example from exception to another type you use to represent errors. Or map to logging messages.
            ITry<int, string> flooredMultiplicationResult = multiplicationResult.MapError(e => e.ToString());
        }

        private void HandlingNestedTriesWithFlatMap()
        {
            ITry<int, NetworkOperationError> multiplicationResult = Api.DownloadNumberOverNetwork();
            ITry<ITry<int, NetworkOperationError>, NetworkOperationError> resultOfDoubleMultiplication = multiplicationResult.Map(r => Api.TransformNumberOverNetwork(r));

            // This try succeeds only if both tries succeed. However the second lambda is only executed in case the first try is successful.
            ITry<int, NetworkOperationError> flattenedResultOfDoubleMultiplication = multiplicationResult.FlatMap(r => Api.TransformNumberOverNetwork(r));
        }

        private void AggregatingMultipleTriesIntoSingleResult(string name, string age, string heightInCentimeters)
        {
            // You can combine independent itries into a successfully result or a list of errors in case any of the itries fails.
            // All the ITries are evaluated all the time.
            ITry<int, IEnumerable<string>> sumOfThreeNumbers = Try.Aggregate(
                t1: Api.DownloadNumberOverNetwork().MapError(e => new List<string>{ e.ToString() }),
                t2: Api.DownloadNumberOverNetwork().MapError(e => new List<string>{ e.ToString() }),
                t3: Api.DownloadNumberOverNetwork().MapError(e => new List<string>{ e.ToString() }),
                f: (number1, number2, number3) => number1 + number2 + number3
            );

            // Great examples of aggregating Itries can be found when parsing. See what the method does.
            ITry<Person, IEnumerable<PersonParsingError>> parsedPerson = Person.Parse("John Doe", "21", "185");
        }

        private void HandlingCollectionsOfTries(int numberCount)
        {
            IEnumerable<ITry<int, NetworkOperationError>> multiplicationResults = Enumerable.Repeat(Unit.Value, numberCount).Select(_ => Api.DownloadNumberOverNetwork());

            // Contains all the multiplication results if all succeeded. Or all the errors from the ones that failed. (success results are lost in such case)
            ITry<IEnumerable<int>, IEnumerable<NetworkOperationError>> combinedResult = Try.Aggregate(multiplicationResults);
        }

        private void UsingITryValueWithMatch()
        {
            // ITry is a specific case of Coproduct. Match methods are applicable for all coproduct types. Just like ITry and IOption.
            ITry<int, NetworkOperationError> multiplicationResult = Api.DownloadNumberOverNetwork();

            // This overload takes 2 Func parameters. Each of those have to return a value and result is stored in the roundedResult variable.
            string stringifiedValue = multiplicationResult.Match(
                result => result.ToString(),
                _ => "Unfortunately, we failed to obtain a number from the server."
            );

            // This overload accepts 2 optional void lambdas. If lambda isn't provided, nothing happens for that case.
            multiplicationResult.Match(
                result => Console.Write($"Operation successful, result is: {result}."),
                _ => Console.Write("Operation failed, try again.")
            );
            multiplicationResult.Match(result => Console.Write($"Operation successful, result is: {result}."));
            multiplicationResult.Match(ifSecond: _ => Console.Write("Operation failed, try again."));
        }

        private void GettingTryValue()
        {
            ITry<int, NetworkOperationError> multiplicationResult = Api.DownloadNumberOverNetwork();
            ITry<int, Exception> iTryWithExceptionAsError = multiplicationResult.MapError(e => new Exception(e.ToString()));

            // Get method will throw an exception for unsuccessful tries. Using it is an anti-pattern.
            // You should rather use Match to branch your code into individual cases where each case is guaranteed to work.
            int valueOrExceptionThrown1 = iTryWithExceptionAsError.Get();

            // You can also configure the exception that is thrown by mapping the error inside Get directly.
            int valueOrExceptionThrown2 = multiplicationResult.Get(e => new Exception(e.ToString()));
            int valueOrExceptionThrown3 = iTryWithExceptionAsError.Get(ex => new Exception("Error when multiplying", innerException: ex));

            // Because ITry is a coproduct, you can check the value directly. On ITry, there are named properties for this.
            // See IOption usages for more information about them.
            IOption<int> successResult = multiplicationResult.Success;
            IOption<int> successResult2 = multiplicationResult.First;
            IOption<NetworkOperationError> errorResult = multiplicationResult.Error;
            IOption<NetworkOperationError> errorResult2 = multiplicationResult.Second;
        }
    }
}
