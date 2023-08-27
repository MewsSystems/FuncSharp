namespace FuncSharp;

public static class IntervalBound
{
    /// <summary>
    /// Creates a new bound with the specified value and type.
    /// </summary>
    public static IntervalBound<A> Create<A>(A bound, IntervalBoundType type)
    {
        return new IntervalBound<A>(bound, type);
    }

    /// <summary>
    /// Creates a new open (exclusive) bound with the specified value.
    /// </summary>
    public static IntervalBound<A> Open<A>(A bound)
    {
        return Create(bound, IntervalBoundType.Open);
    }

    /// <summary>
    /// Creates a new closed (inclusive) bound with the specified value.
    /// </summary>
    public static IntervalBound<A> Closed<A>(A bound)
    {
        return Create(bound, IntervalBoundType.Closed);
    }
}

public class IntervalBound<A> : Product2<A, IntervalBoundType>
{
    /// <summary>
    /// Creates a new bound with the specified value and type.
    /// </summary>
    internal IntervalBound(A bound, IntervalBoundType type)
        : base(bound, type)
    {
    }

    /// <summary>
    /// Value of the interval bound.
    /// </summary>
    public A Value
    {
        get { return ProductValue1; }
    }

    /// <summary>
    /// Type of the internal bound (open, closed).
    /// </summary>
    public IntervalBoundType Type
    {
        get { return ProductValue2; }
    }

    /// <summary>
    /// Returns whether the bound is closed (inclusive).
    /// </summary>
    public bool IsOpen
    {
        get { return Type == IntervalBoundType.Open; }
    }

    /// <summary>
    /// Returns whether the bound is closed (inclusive).
    /// </summary>
    public bool IsClosed
    {
        get { return !IsOpen; }
    }

    public override string ToString()
    {
        return $"{(IsOpen ? "Open" : "Closed")}({Value})";
    }
}