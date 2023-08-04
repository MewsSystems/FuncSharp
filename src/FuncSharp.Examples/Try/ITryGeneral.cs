using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp.Examples
{
    public class ITryGeneral
    {
        private void TransformingSuccessWithMap()
        {
            Try<int, NetworkOperationError> number = Api.GetNumber();
            Try<decimal, NetworkOperationError> castedNumber = number.Map(r => (decimal)r);
            Try<string, NetworkOperationError> stringifiedNumber = number.Map(r => r.ToString());
        }

        private void TransformingErrorWithMapError()
        {
            Try<int, NetworkOperationError> number = Api.GetNumber();

            // You can use MapError to map for example from exception to another type you use to represent errors. Or map to logging messages.
            Try<int, string> flooredMultiplicationResult = number.MapError(e => e.ToString());
        }

        private void HandlingNestedTriesWithFlatMap()
        {
            Try<int, NetworkOperationError> number = Api.GetNumber();
            Try<Try<int, NetworkOperationError>, NetworkOperationError> doubleNumber = number.Map(r => Api.DoubleNumber(r));

            // This try succeeds only if both tries succeed. However the second lambda is only executed in case the first try is successful.
            Try<int, NetworkOperationError> doubleNumberFlattened = number.FlatMap(r => Api.DoubleNumber(r));
        }

        private void RetrievingValues()
        {
            // A try is a specific case of coproduct. Match methods are applicable for all coproduct types.
            Try<int, NetworkOperationError> number = Api.GetNumber();

            // Match is the preferred way how to retrieve values of tries (and coproducts in general). It is typesafe and future proof.
            // This overload takes two functions. Each of those have to return a value and result is stored in the stringifiedNumber variable.
            string stringifiedNumber = number.Match(
                result => result.ToString(),
                _ => "Unfortunately, we failed to obtain a number from the server."
            );

            // This overload accepts two optional functions. If either of them isn't provided, nothing happens for that case.
            number.Match(
                n => Console.Write($"Operation successful, result is: {n}."),
                _ => Console.Write("Operation failed, try again.")
            );
            number.Match(n => Console.Write($"Operation successful, result is: {n}."));
            number.Match(ifSecond: _ => Console.Write("Operation failed, try again."));

            // Get method will throw an exception for unsuccessful tries that have exception as the error. Using it is an anti-pattern.
            // You should rather use Match to branch your code into individual cases where each case is guaranteed to work.
            // This might be needed on the boundary with some other framework where you have to work with exceptions.
            Try<int, InvalidOperationException> numberWithException = number.MapError(e => new InvalidOperationException());
            int numberValue1 = numberWithException.Get();

            // You can also configure the exception that is thrown by mapping the error inside Get directly.
            int numberValue2 = number.Get(e => new InvalidOperationException());
            int numberValue3 = numberWithException.Get(ex => new Exception("Error when retrieving number", innerException: ex));

            // Because try is a coproduct, you can check the value directly. On try, there are named properties for this.
            IOption<int> successResult1 = number.Success;
            IOption<int> successResult2 = number.First;
            IOption<NetworkOperationError> errorResult = number.Error;
            IOption<NetworkOperationError> errorResult2 = number.Second;
        }

        private void AggregatingMultipleTriesIntoSingleResult()
        {
            // You can combine independent tries into a single value or a list of errors in case any of the tries is erroneous.
            Try<int, NetworkOperationError> number1 = Api.GetNumber();
            Try<int, NetworkOperationError> number2 = Api.GetNumber();
            Try<int, NetworkOperationError> number3 = Api.GetNumber();
            Try<int, IEnumerable<NetworkOperationError>> sumOfThreeNumbers = Try.Aggregate(
                t1: number1,
                t2: number2,
                t3: number3,
                success: (n1, n2, n3) => n1 + n2 + n3
            );

            // Great examples of aggregating tries can also be found when parsing. See what the Person.Parse method does.
            Try<Person, IEnumerable<PersonParsingError>> mom = Person.Parse("Jane Doe", "24", "185");
            Try<Person, IEnumerable<PersonParsingError>> dad = Person.Parse("John Doe", "29", "185");
            Try<Person, IEnumerable<PersonParsingError>> son = Person.Parse("Jimmy Doe", "1", "75");
            Try<(Person Dad, Person Mom, Person Son), IEnumerable<PersonParsingError>> family = Try.Aggregate(
                t1: mom,
                t2: dad,
                t3: son,
                success: (m, d, s) => (Dad: d, Mom: m, Son: s)
            );
        }

        private void AggregatingCollectionOfTries(int numberCount)
        {
            IEnumerable<Try<int, NetworkOperationError>> numbers = Enumerable.Range(0, numberCount).Select(_ => Api.GetNumber());

            // Contains all the numbers if their retrieval succeeded. Or all the errors from the ones that failed. Success results are lost in such case.
            Try<IEnumerable<int>, IEnumerable<NetworkOperationError>> combinedResult = Try.Aggregate(numbers);
        }
    }
}
