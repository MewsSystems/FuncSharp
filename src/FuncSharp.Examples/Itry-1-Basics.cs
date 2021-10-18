using System;
using System.Collections.Generic;

namespace FuncSharp.Examples
{
    public class ITryCreationExamples
    {
        public void HandlingExceptionsWithCreate(decimal number, decimal divisor)
        {
            // Catches any exception.
            ITry<decimal> divisionHandlingAllExceptions = Try.Create<decimal, Exception>(_ => number / divisor);

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

            // Only catches a specific exception. Notice that the error type is the specific type of exception, not a collection of exceptions.
            ITry<decimal, DivideByZeroException> divisionHandlingDividingByZero = Try.Catch<decimal, DivideByZeroException>(_ => number / divisor);

            // Catch also has an overload which allows recovering in case of exception.
            decimal divisionResult = Try.Catch<decimal, DivideByZeroException>(
                _ => number / divisor,
                exception => 0
            );
        }

        private void ITryCreatingExamples(decimal number, decimal divisor)
        {
            ITry<int, NetworkOperationError> success = Try.Success<int, NetworkOperationError>(42);
            ITry<int, NetworkOperationError> error = Try.Error<int, NetworkOperationError>(NetworkOperationError.NetworkIssues);

            ITry<decimal, DivideByZeroException> divisionHandlingDividingByZero1 = Try.Catch<decimal, DivideByZeroException>(_ => number / divisor);
            ITry<decimal> divisionHandlingDividingByZero2 = Try.Create<decimal, DivideByZeroException>(_ => number / divisor);
            ITry<decimal, IEnumerable<Exception>> fullTypeOfTryCreate = divisionHandlingDividingByZero2;

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
    }
}
