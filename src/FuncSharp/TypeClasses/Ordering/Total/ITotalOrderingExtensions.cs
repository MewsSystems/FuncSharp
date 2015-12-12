using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class ITotalOrderingExtensions
    {
        /// <summary>
        /// Returns trait data of the ordering.
        /// </summary>
        public static TotalOrderingData<A> GetTraitData<A>(this ITotalOrdering<A> ordering)
        {
            return ordering.GetTraitData(_ =>
            {
                var limitOrderings = new IntervalLimitOrderings<A>(ordering);
                var intervalOrdering = new IntervalOrdering<A>(limitOrderings);
                return new TotalOrderingData<A>(limitOrderings, intervalOrdering);
            });
        }

        /// <summary>
        /// Returns ordering of intervals based on the underlying type.
        /// </summary>
        public static ITotalOrdering<Interval<A>> GetIntervalOrdering<A>(this ITotalOrdering<A> ordering)
        {
            return ordering.GetTraitData().IntervalOrdering;
        }

        /// <summary>
        /// Returns ordering of interval limits based on the underlying type.
        /// </summary>
        public static IntervalLimitOrderings<A> GetLimitOrderings<A>(this ITotalOrdering<A> ordering)
        {
            return ordering.GetTraitData().LimitOrderings;
        }

        /// <summary>
        /// Returns minimum element from the specified elements. Throws an exception if there is no element to determine the minimum from.
        /// </summary>
        public static A Min<A>(this ITotalOrdering<A> ordering, IEnumerable<A> values)
        {
            if (!values.Any())
            {
                throw new InvalidOperationException("Empty collection doesn't have a minimum value.");
            }
            return values.Aggregate((a, b) => ordering.Less(a, b) ? a : b);
        }

        /// <summary>
        /// Returns minimum element from the specified elements. Throws an exception if there is no element to determine the minimum from.
        /// </summary>
        public static A Min<A>(this ITotalOrdering<A> ordering, params A[] values)
        {
            return ordering.Min(values.AsEnumerable());
        }

        /// <summary>
        /// Returns maximum element from the specified elements. Throws an exception if there is no element to determine the maximum from.
        /// </summary>
        public static A Max<A>(this ITotalOrdering<A> ordering, IEnumerable<A> values)
        {
            if (!values.Any())
            {
                throw new InvalidOperationException("Empty collection doesn't have a maximum value.");
            }
            return values.Aggregate((a, b) => ordering.Less(a, b) ? b : a);
        }

        /// <summary>
        /// Returns maximum element from the specified elements. Throws an exception if there is no element to determine the maximum from.
        /// </summary>
        public static A Max<A>(this ITotalOrdering<A> ordering, params A[] values)
        {
            return ordering.Max(values.AsEnumerable());
        }

        /// <summary>
        /// Returns reversed ordering.
        /// </summary>
        public static ITotalOrdering<A> Reverse<A>(this ITotalOrdering<A> ordering)
        {
            return new TotalOrdering<A>(ordering.Greater, ordering.Equal);
        }
    }
}
