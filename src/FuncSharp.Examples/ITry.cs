using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FuncSharp.Examples
{
    public class ITryUsages
    {
        public class Person
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get; }
            public int Age { get; }
        }

        public enum PersonParsingError
        {
            NameNotProvided,
            AgeNotANumber,
            AgeNegative,
            AgeTooHigh
        }

        public enum NetworkOperationError
        {
            ServerError,
            ConnectionTimedOut,
            NetworkIssues
        }

        public ITry<T, NetworkOperationError> PerformNetworkOperation<T>(Func<Unit, T> operation)
        {
            var connectionErrorStatuses = new List<WebExceptionStatus>
            {
                WebExceptionStatus.ConnectFailure,
                WebExceptionStatus.ConnectionClosed,
                WebExceptionStatus.SecureChannelFailure,
                WebExceptionStatus.NameResolutionFailure
            };

            try
            {
                return Try.Success<T, NetworkOperationError>(operation(Unit.Value));
            }
            catch (TaskCanceledException)
            {
                return Try.Error<T, NetworkOperationError>(NetworkOperationError.ConnectionTimedOut);
            }
            catch (WebException e) when (e.Response.As<HttpWebResponse>().Map(r => (int)r.StatusCode > 500 && (int)r.StatusCode < 599).GetOrFalse())
            {
                return Try.Error<T, NetworkOperationError>(NetworkOperationError.ServerError);
            }
            catch (WebException e) when (connectionErrorStatuses.Contains(e.Status))
            {
                return Try.Error<T, NetworkOperationError>(NetworkOperationError.NetworkIssues);
            }
            // Notice that general Exception is not handled. We're handling the exceptions we expect, so the signature makes sense.
            // The purpose of ITry is not covering every exception. But that methods should show what are the expected outputs and make the call site handle all of them.
        }

        private void TransformingResultValuesWithMap()
        {
            ITry<int, NetworkOperationError> downloadedNumber = PerformNetworkOperation(_ => DownloadNumberOverNetwork());
            ITry<decimal, NetworkOperationError> castedNumber = downloadedNumber.Map(r => (decimal)r);
            ITry<string, NetworkOperationError> stringifiedNumber = downloadedNumber.Map(r => r.ToString());
        }

        private void TransformingErrorValuesWithMapError()
        {
            ITry<int, NetworkOperationError> multiplicationResult = PerformNetworkOperation(_ => DownloadNumberOverNetwork());

            // You can use MapError to map for example from exception to another type you use to represent errors. Or map to logging messages.
            ITry<int, string> flooredMultiplicationResult = multiplicationResult.MapError(e => e.ToString());
        }

        private void HandlingNestedTriesWithFlatMap()
        {
            ITry<int, NetworkOperationError> multiplicationResult = PerformNetworkOperation(_ => DownloadNumberOverNetwork());
            ITry<ITry<int, NetworkOperationError>, NetworkOperationError> resultOfDoubleMultiplication = multiplicationResult.Map(r => PerformNetworkOperation(_ => TransformNumberOverNetwork(r)));

            // This try succeeds only if both tries succeed. However the second lambda is only executed in case the first try is successful.
            ITry<int, NetworkOperationError> flattenedResultOfDoubleMultiplication = multiplicationResult.FlatMap(r => PerformNetworkOperation(_ => TransformNumberOverNetwork(r)));
        }

        private void AggregatingMultipleTriesIntoSingleResult(string name, string age, string heightInCentimeters)
        {
            // You need to start with tries that have a collection as the type of error. So we MapError to a collection of strings here. But it can be a collection of any type.
            // For validations, you would write your validation method, so it already returns IEnumerable as the error type and use MapError inside the method.
            // Try.Aggregate method always executes all tries and then aggregates the success results or the errors. It doesn't stop on first error.
            // You can transform the result into any class you want. This makes it nice and effective way of parsing values and combining the results.
            ITry<string, IEnumerable<PersonParsingError>> parsedName = name.ToNonEmptyOption().ToTry(_ => new [] { PersonParsingError.NameNotProvided });

            // Notice that you can chain validations using FlatMap and then pass it into Aggregate.
            var ageAsValidNumber = Try.Catch<int, Exception>(_ => Convert.ToInt32(age)).MapError(_ => PersonParsingError.AgeNotANumber);
            var notNegativeAge = ageAsValidNumber.FlatMap(
                a => a.ToOption().Where(aa => aa >= 0).ToTry(_ => PersonParsingError.AgeNegative)
            );
            var validAge = notNegativeAge.FlatMap(
                a => a.ToOption().Where(aa => aa < 140).ToTry(_ => PersonParsingError.AgeTooHigh)
            );
            ITry<int, IEnumerable<PersonParsingError>> parsedAge = validAge.MapError(e => new [] { e });

            // You can aggregate more than 2 tries, just saving space here.
            ITry<Person, IEnumerable<PersonParsingError>> parsedPerson = Try.Aggregate(
                parsedName,
                parsedAge,
                f: (n, a) => new Person(n, a)
            );

            // You could also combine multiple network requests into a successfully initialized object for example.
            ITry<int, IEnumerable<string>> sumOfThreeNumbers = Try.Aggregate(
                t1: PerformNetworkOperation(_ => DownloadNumberOverNetwork()).MapError(e => new List<string>{ e.ToString() }),
                t2: PerformNetworkOperation(_ => DownloadNumberOverNetwork()).MapError(e => new List<string>{ e.ToString() }),
                t3: PerformNetworkOperation(_ => DownloadNumberOverNetwork()).MapError(e => new List<string>{ e.ToString() }),
                f: (number1, number2, number3) => number1 + number2 + number3
            );
        }

        private void HandlingCollectionsOfTries(int numberCount)
        {
            IEnumerable<ITry<int, NetworkOperationError>> multiplicationResults = Enumerable.Repeat(Unit.Value, numberCount).Select(_ => PerformNetworkOperation(u => DownloadNumberOverNetwork()));

            // Contains all the multiplication results if all succeeded. Or all the errors from the ones that failed. (success results are lost in such case)
            ITry<IEnumerable<int>, IEnumerable<NetworkOperationError>> combinedResult = Try.Aggregate(multiplicationResults);
        }

        private void UsingITryValueWithMatch()
        {
            // ITry is a specific case of Coproduct. Match methods are applicable for all coproduct types. Just like ITry and IOption.
            ITry<int, NetworkOperationError> multiplicationResult = PerformNetworkOperation(_ => DownloadNumberOverNetwork());

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
            ITry<int, NetworkOperationError> multiplicationResult = PerformNetworkOperation(_ => DownloadNumberOverNetwork());
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

        public void HandlingExceptionsWithCreate(decimal number, decimal divisor)
        {
            // Catches any exception.
            ITry<int> divisionHandlingAllExceptions1 = Try.Create<int, Exception>(_ => DownloadNumberOverNetwork());

            // Only catches a specific exception.
            ITry<int> divisionHandlingDividingByZero = Try.Create<int, TaskCanceledException>(_ => DownloadNumberOverNetwork());

            // ITry that doesn't specify the error type has a collection of exceptions by default.
            // It is a collection because then you can aggregate multiple tries and still have the same type.
            ITry<int, IEnumerable<Exception>> fullTypeOfVariable = divisionHandlingDividingByZero;
        }

        public void HandlingExceptionsWithCatch()
        {
            // Catches any exception and stores the single exception into the try.
            // This is useful for handling individual errors, but cannot be aggregated.
            ITry<int, Exception> divisionHandlingAllExceptions1 = Try.Catch<int, Exception>(_ => DownloadNumberOverNetwork());

            // Only catches a specific exception. Notice that the error type is the specific type of exception.
            ITry<int, TaskCanceledException> divisionHandlingDividingByZero = Try.Catch<int, TaskCanceledException>(_ => DownloadNumberOverNetwork());

            // Catch also has an overload which allows recovering in case of exception.
            int divisionResult = Try.Catch<int, DivideByZeroException>(
                _ => DownloadNumberOverNetwork(),
                exception => 42
            );
        }

        private void ITryCreatingExamples()
        {
            ITry<int, NetworkOperationError> success = Try.Success<int, NetworkOperationError>(42);
            ITry<int, NetworkOperationError> error = Try.Error<int, NetworkOperationError>(NetworkOperationError.NetworkIssues);

            ITry<int> divisionHandlingDividingByZero1 = Try.Create<int, DivideByZeroException>(_ => DownloadNumberOverNetwork());
            ITry<int, IEnumerable<Exception>> fullTypeOfTryCreate = divisionHandlingDividingByZero1;
            ITry<int, DivideByZeroException> divisionHandlingDividingByZero2 = Try.Catch<int, DivideByZeroException>(_ => DownloadNumberOverNetwork());

            Exception exception = new Exception();
            var option = Option.Empty<int>();

            ITry<int> successTry = 42.ToTry();
            ITry<int> errorTry = exception.ToTry<int>();
            ITry<int> tryFromOption = option.ToTry(_ => new Exception("No value was provided in the option."));
            ITry<int, string> tryFromOptionWithErrorType = option.ToTry(_ => "No value was provided in the option.");

            // Generally collections are recommended for validations.
            // It is easy to aggregate validations of multiple values into one ITry of the whole object. And then you either successfully parsed the object or you have the list of errors.
            ITry<int, IEnumerable<string>> validationRepresentation = option.ToTry(_ => new [] { "No valid value was provided in the option." });
        }

        private int DownloadNumberOverNetwork()
        {
            return new Random().Next();
        }
        private int TransformNumberOverNetwork(int value)
        {
            return new Random().Next();
        }
    }
}
