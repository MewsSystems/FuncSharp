using System;
using System.Collections.Generic;

namespace FuncSharp.Examples
{
    public static class TryBasics
    {
        private static void CreatingTryDirectly()
        {
            // Note that we explicitly specify types of variables in the following examples. However, in practice, we use var.
            // Creates an Try with successful result while specifying type of an error.
            Try<int, NetworkOperationError> success = Try.Success<int, NetworkOperationError>(42);

            // Creates a Try with erroneous result while specifying type of a success.
            Try<int, NetworkOperationError> error = Try.Error<int, NetworkOperationError>(NetworkOperationError.NetworkIssues);

            // Creating a successful Try while specifying type of an error.
            Try<int, Exception> successTry = 42.ToTry<int, Exception>();

            // Creating an erroneous Try directly from exception while specifying type of a success.
            Try<int, Exception> errorTry = new Exception().ToTry<int, Exception>();

            // Converting an option to try.
            var option = Option.Empty<int>();
            Try<int, Exception> tryFromOption = option.ToTry(_ => new Exception("No value was provided in the option."));
            Try<int, string> tryFromOptionWithErrorType = option.ToTry(_ => "No value was provided in the option.");

            // Generally collections are recommended for validations.
            // It is easy to aggregate validations of multiple values into one Try of the whole object.
            // And then you either get the successfully parsed object or you have the list of errors.
            Try<int, string[]> validationRepresentation = option.ToTry(_ => new[] { "No valid value was provided in the option." });
        }

        public static void HandlingExceptionsWithCatch(decimal number, decimal divisor)
        {
            // Catches any exception and stores the single exception into the try.
            // This is useful for handling individual errors, but cannot be aggregated.
            Try<decimal, Exception> divisionHandlingAllExceptions = Try.Catch<decimal, Exception>(_ => number / divisor);

            // Only catches a specific exception. Notice that the error type is the specific type of exception, not a collection of exceptions.
            Try<decimal, DivideByZeroException> divisionHandlingDividingByZero = Try.Catch<decimal, DivideByZeroException>(_ => number / divisor);

            // Catch also has an overload which allows recovering in case of exception. Serves as standard try/catch, but returns a value.
            decimal divisionResult = Try.Catch<decimal, DivideByZeroException>(
                _ => number / divisor,
                exception => 0
            );
        }
    }
}
