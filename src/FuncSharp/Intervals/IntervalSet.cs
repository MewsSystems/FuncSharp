using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp;

public class IntervalSet<A>
{
    /// <summary>
    /// Creates a new interval set consisting of the specified disjoint intervals.
    /// </summary>
    internal IntervalSet(IEnumerable<Interval<A>> intervals)
    {
        Intervals = intervals;
    }

    /// <summary>
    /// Intervals that the interval set consists of.
    /// </summary>
    public IEnumerable<Interval<A>> Intervals { get; }

    public override string ToString()
    {
        return "{" + String.Join(", ", Intervals.Select(i => i.ToString())) + "}";
    }

    public override int GetHashCode()
    {
        return Intervals.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is IntervalSet<A> other)
        {
            return Intervals.SequenceEqual(other.Intervals);
        }
        return false;
    }
}