using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FuncSharp.Examples
{
    public enum NetworkOperationError
    {
        ServerError,
        ConnectionTimedOut,
        NetworkIssues
    }

    public static class Api
    {
        public static ITry<int, NetworkOperationError> GetNumber()
        {
            // This method serves as an example use-case for handling value of ITries, instead of random next, there should be some network call.
            return PerformNetworkOperation(_ => new Random().Next());
        }

        public static ITry<int, NetworkOperationError> DoubleNumber(int value)
        {
            // This method serves as an example use-case for handling value of ITries, instead of multiplication, there should be some network call.
            return PerformNetworkOperation(_ => value * 2);
        }

        private static ITry<T, NetworkOperationError> PerformNetworkOperation<T>(Func<Unit, T> operation)
        {
            var connectionErrorStatuses = new[]
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
    }
}
