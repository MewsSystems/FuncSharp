using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FuncSharp.Examples
{
    public class ITryUsages
    {
        public class ClassWithMultipleProperties
        {
            public ClassWithMultipleProperties(decimal multiplicationResult, decimal additionResult, decimal subtractionResult)
            {
                MultiplicationResult = multiplicationResult;
                AdditionResult = additionResult;
                SubtractionResult = subtractionResult;
            }

            public decimal MultiplicationResult { get; }
            public decimal AdditionResult { get; }
            public decimal SubtractionResult { get; }
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

        private void TransformingResultValuesWithMap(decimal number, decimal multiplier)
        {
            ITry<decimal, NetworkOperationError> multiplicationResult = PerformNetworkOperation(_ => number * multiplier);
            ITry<int, NetworkOperationError> flooredMultiplicationResult = multiplicationResult.Map(r => (int)r);
            ITry<string, NetworkOperationError> stringifiedDivisionResult = multiplicationResult.Map(r => r.ToString());
        }

        private void TransformingErrorValuesWithMapError(decimal number, decimal multiplier)
        {
            ITry<decimal, NetworkOperationError> multiplicationResult = PerformNetworkOperation(_ => number * multiplier);

            // You can use MapError to map for example from exception to another type you use to represent errors. Or map to logging messages.
            ITry<decimal, string> flooredMultiplicationResult = multiplicationResult.MapError(e => e.ToString());
        }

        private void HandlingNestedTriesWithFlatMap(decimal number, decimal firstMultiplier, decimal secondMultiplier)
        {
            ITry<decimal, NetworkOperationError> multiplicationResult = PerformNetworkOperation(_ => number * firstMultiplier);
            ITry<ITry<decimal, NetworkOperationError>, NetworkOperationError> resultOfDoubleMultiplication = multiplicationResult.Map(r => PerformNetworkOperation(_ => r * secondMultiplier));

            // This try succeeds only if both tries succeed. However the second lambda is only executed in case the first try is successful.
            ITry<decimal, NetworkOperationError> flattenedResultOfDoubleMultiplication = multiplicationResult.FlatMap(r => PerformNetworkOperation(_ => r * secondMultiplier));
        }

        private void AggregatingMultipleTriesIntoSingleResult(decimal number, decimal multiplier, decimal numberToAdd, decimal numberToSubtract)
        {
            // You need to start with tries that have a collection as the type of error. So we MapError to a collection of strings here. But it can be a collection of any type.
            // For validations, you would write your validation method, so it already returns IEnumerable as the error type.
            // Try.Aggregate method always executes all tries and then aggregates the success results or the errors. It doesn't stop on first error.
            // You can transform the result into any class you want. This makes it nice and effective way of parsing values and combining the results.
            ITry<ClassWithMultipleProperties, IEnumerable<string>> combinedResult = Try.Aggregate(
                t1: PerformNetworkOperation(_ => number * multiplier).MapError(e => new List<string>{ e.ToString() }),
                t2: PerformNetworkOperation(_ => number + numberToAdd).MapError(e => new List<string>{ e.ToString() }),
                t3: PerformNetworkOperation(_ => number - numberToSubtract).MapError(e => new List<string>{ e.ToString() }),
                f: (multiplicationResult, additionResult, subtractionResult) => new ClassWithMultipleProperties(multiplicationResult, additionResult, subtractionResult)
            );
        }

        private void HandlingCollectionsOfTries(List<decimal> numbers, List<decimal> multipliers)
        {
            IEnumerable<ITry<decimal, NetworkOperationError>> multiplicationResults = numbers.SelectMany(n => multipliers.Select(m => PerformNetworkOperation(_ => n * m))).ToList();

            // Contains all the multiplication results if all succeeded. Or all the errors from the ones that failed. (success results are lost in such case)
            ITry<IEnumerable<decimal>, IEnumerable<NetworkOperationError>> combinedResult = Try.Aggregate(multiplicationResults);
        }

        private void UsingITryValueWithMatch(decimal number, decimal multiplier)
        {
            // ITry is a specific case of Coproduct. Match methods are applicable for all coproduct types. Just like ITry and IOption.
            ITry<decimal, NetworkOperationError> multiplicationResult = PerformNetworkOperation(_ => number * multiplier);

            // This overload takes 2 Func parameters. Each of those have to return a value and result is stored in the roundedResult variable.
            decimal roundedResultOrFourteen = multiplicationResult.Match(
                result => Math.Round(result),
                _ => 14
            );

            // This overload accepts 2 optional void lambdas. If lambda isn't provided, nothing happens for that case.
            multiplicationResult.Match(
                result => Console.Write($"Division successful, result is: {result}."),
                _ => Console.Write("Division failed, must have divided by zero.")
            );
            multiplicationResult.Match(result => Console.Write($"Division successful, result is: {result}."));
            multiplicationResult.Match(ifSecond: _ => Console.Write("Division failed, must have divided by zero."));
        }

        private void GettingTryValue(decimal number, decimal multiplier)
        {
            ITry<decimal, NetworkOperationError> multiplicationResult = PerformNetworkOperation(_ => number * multiplier);
            ITry<decimal, Exception> iTryWithExceptionAsError = multiplicationResult.MapError(e => new Exception(e.ToString()));

            // Get method will throw an exception for unsuccessful tries. Using it is an anti-pattern.
            // You should rather use Match to branch your code into individual cases where each case is guaranteed to work.
            decimal valueOrExceptionThrown1 = iTryWithExceptionAsError.Get();

            // You can also configure the exception that is thrown by mapping the error inside Get directly.
            decimal valueOrExceptionThrown2 = multiplicationResult.Get(e => new Exception(e.ToString()));
            decimal valueOrExceptionThrown3 = iTryWithExceptionAsError.Get(ex => new Exception("Error when multiplying", innerException: ex));

            // Because ITry is a coproduct, you can check the value directly. On ITry, there are named properties for this.
            // See IOption usages for more information about them.
            IOption<decimal> successResult = multiplicationResult.Success;
            IOption<decimal> successResult2 = multiplicationResult.First;
            IOption<NetworkOperationError> errorResult = multiplicationResult.Error;
            IOption<NetworkOperationError> errorResult2 = multiplicationResult.Second;
        }

        public void HandlingExceptionsWithCreate(decimal number, decimal divisor)
        {
            // Catches any exception.
            ITry<decimal> divisionHandlingAllExceptions1 = Try.Create<decimal, Exception>(_ => number / divisor);

            // Only catches a specific exception.
            ITry<decimal> divisionHandlingDividingByZero = Try.Create<decimal, DivideByZeroException>(_ => number / divisor);

            // ITry that doesn't specify the error type has a collection of exceptions by default.
            // It is a collection because then you can aggregate multiple tries and still have the same type.
            ITry<decimal, IEnumerable<Exception>> fullTypeOfVariable = divisionHandlingDividingByZero;
        }

        public void HandlingExceptionsWithCatch(decimal number, decimal divisor)
        {
            // Catches any exception and stores the single exception into the try.
            // This is useful for handling individual errors, but cannot be aggregated.
            ITry<decimal, Exception> divisionHandlingAllExceptions1 = Try.Catch<decimal, Exception>(_ => number / divisor);

            // Only catches a specific exception.
            ITry<decimal, DivideByZeroException> divisionHandlingDividingByZero = Try.Catch<decimal, DivideByZeroException>(_ => number / divisor);

            // Catch also has an overload which allows recovering in case of exception.
            decimal divisionResult = Try.Catch<decimal, DivideByZeroException>(
                _ => number / divisor,
                exception => 0
            );
        }

        private void ITryCreatingExamples(decimal number, decimal divisor)
        {
            ITry<decimal, NetworkOperationError> success = Try.Success<decimal, NetworkOperationError>(number);
            ITry<decimal, NetworkOperationError> error = Try.Error<decimal, NetworkOperationError>(NetworkOperationError.NetworkIssues);

            ITry<decimal> divisionHandlingDividingByZero1 = Try.Create<decimal, DivideByZeroException>(_ => number / divisor);
            ITry<decimal, IEnumerable<Exception>> fullTypeOfTryCreate = divisionHandlingDividingByZero1;
            ITry<decimal, DivideByZeroException> divisionHandlingDividingByZero2 = Try.Catch<decimal, DivideByZeroException>(_ => number / divisor);

            Exception exception = new Exception();
            var option = Option.Empty<decimal>();

            ITry<decimal> successTry = number.ToTry();
            ITry<decimal> errorTry = exception.ToTry<decimal>();
            ITry<decimal> tryFromOption = option.ToTry(_ => new Exception("No value was provided in the option."));
            ITry<decimal, string> tryFromOptionWithErrorType = option.ToTry(_ => "No value was provided in the option.");

            // Generally collections are recommended for validations.
            // It is easy to aggregate validations of multiple values into one ITry of the whole object. And then you either successfully parsed the object or you have the list of errors.
            ITry<decimal, IEnumerable<string>> validationRepresentation = option.ToTry(_ => new [] { "No valid value was provided in the option." });
        }
    }
}
