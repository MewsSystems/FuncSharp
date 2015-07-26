using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public class IntervalSet<A> : Product
    {
        private IEnumerable<object> productValues;

        /// <summary>
        /// Creates a new interval set consisting of the specified disjoint intervals.
        /// </summary>
        internal IntervalSet(ITotalOrdering<A> ordering, IEnumerable<Interval<A>> disjointIntervals)
        {
            Ordering = ordering;

            // Check that all intervals belong to the underlying space and that they are disjoint.        
            var orderedIntervals = ordering.GetIntervalOrdering().Order(disjointIntervals.Where(i => i.IsNonEmpty)).ToArray();
            for (var i = 0; i < orderedIntervals.Length; i++)
            {
                Ordering.Check(orderedIntervals[i], () => new ArgumentException("The " + i + "th interval uses different ordering."));

                if (i + 1 < orderedIntervals.Length)
                {
                    if (Ordering.Intersects(orderedIntervals[i], orderedIntervals[i + 1]))
                    {
                        throw new ArgumentException("The intervals have to be disjoint.");
                    }
                }
            }

            Intervals = orderedIntervals;
            productValues = new object[] { Ordering }.Concat(Intervals).ToList();
        }

        /// <summary>
        /// Ordering of the underlying values.
        /// </summary>
        public ITotalOrdering<A> Ordering { get; private set; }

        /// <summary>
        /// Intervals that the interval set consists of.
        /// </summary>
        public IEnumerable<Interval<A>> Intervals { get; private set; }

        /// <summary>
        /// Returns whether the interval set is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return !Intervals.Any(); }
        }

        /// <summary>
        /// Returns whether the interval set is nonempty.
        /// </summary>
        public bool IsNonEmpty
        {
            get { return !IsEmpty; }
        }

        public override IEnumerable<object> ProductValues
        {
            get { return productValues; }
        }

        public override string ToString()
        {
            return "{" + String.Join(", ", Intervals.Select(i => i.ToString())) + "}";
        }
    }
}
