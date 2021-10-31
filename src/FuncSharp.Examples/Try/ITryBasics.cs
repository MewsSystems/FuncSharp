using System;
using System.Collections.Generic;

namespace FuncSharp.Examples
{
    public static class ITryBasics
    {
        private static void CreatingTryDirectly()
        {
            // Note that we explicitly specify types of variables in the following examples. However, in practice, we use var.
            // Creates an ITry with successful result while specifying type of an error.
            ITry<int, NetworkOperationError> success = Try.Success<int, NetworkOperationError>(42);

            // Creates an ITry with erroneous result while specifying type of a success.
            ITry<int, NetworkOperationError> error = Try.Error<int, NetworkOperationError>(NetworkOperationError.NetworkIssues);

            // Creating a successful ITry while specifying type of an error.
            ITry<int, Exception> successTry = 42.ToTry<int, Exception>();

            // Creating an erronous ITry directly from exception while specifying type of a success.
            ITry<int, Exception> errorTry = new Exception().ToTry<int, Exception>();

            // Converting an option to try.
            var option = Option.Empty<int>();
            ITry<int, Exception> tryFromOption = option.ToTry(_ => new Exception("No value was provided in the option."));
            ITry<int, string> tryFromOptionWithErrorType = option.ToTry(_ => "No value was provided in the option.");

            // Generally collections are recommended for validations.
            // It is easy to aggregate validations of multiple values into one ITry of the whole object.
            // And then you either get the successfully parsed object or you have the list of errors.
            ITry<int, IEnumerable<string>> validationRepresentation = option.ToTry(_ => new[] { "No valid value was provided in the option." });
        }

        public static void HandlingExceptionsWithCatch(decimal number, decimal divisor)
        {
            // Catches any exception and stores the single exception into the try.
            // This is useful for handling individual errors, but cannot be aggregated.
            ITry<decimal, Exception> divisionHandlingAllExceptions = Try.Catch<decimal, Exception>(_ => number / divisor);

            // Only catches a specific exception. Notice that the error type is the specific type of exception, not a collection of exceptions.
            ITry<decimal, DivideByZeroException> divisionHandlingDividingByZero = Try.Catch<decimal, DivideByZeroException>(_ => number / divisor);

            // Catch also has an overload which allows recovering in case of exception. Serves as standard try/catch, but returns a value.
            decimal divisionResult = Try.Catch<decimal, DivideByZeroException>(
                _ => number / divisor,
                exception => 0
            );
        }
    }
}
