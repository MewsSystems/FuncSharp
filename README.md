# FuncSharp - Functional C&#35;

### Product Types

Interfaces and helpers that make implementation of product types (http://en.wikipedia.org/wiki/Product_type) and algebraic data types (http://en.wikipedia.org/wiki/Algebraic_data_type) as painless as possible. The class has to implement the `IProduct` interface (define the `ProductValues` property) and gets correct structural hash code, structural equality etc. for free.

```C#
class User : IProduct
{
    public User(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName; LastName = lastName; BirthDate = birthDate;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime BirthDate { get; private set; }

    public IEnumerable<object> ProductValues
    {
        get { yield return FirstName; yield return LastName; yield return BirthDate; }
    }

    public override int GetHashCode() { return this.ProductHashCode(); }
    public override bool Equals(object obj) { return this.ProductEquals(obj); }
    public override string ToString() { return this.ProductToString(); }
}
```

### Unit Type

A direct consequence of the product types is the `Unit` type - a product of zero types. Helps getting rid of the `Action` vs. `Func` duality by using only `Func`s that return `Unit.Instance` instead of `Action`s.

### Vectors

A default implementation of strongly-typed n-dimensional product types. Very similar to .NET `Tuple`s with a few advantages:

- `Vector`s have common superclass.
- Their values are enumerable.
- There's a zero-dimensional vector.
- They support projections.

### Option

The classical functional type known from other languages that represents a value that may or may not be available. Great for avoiding `NullReferenceException`s and handling the two null/non-null cases.

### Interval

A generic representation of an interval of comparable values and operations with such intervals. May seem simple on the first sight, but becomes really handy when you consider all the cases it supports (and you'd have to implement):

- Empty or single-value interval.
- Any combination an interval with open/closed lower/upper bound.
- Lower/Upper bounded with open/closed bound.
- Unbounded interval.

### Typeclasses

Work in progress

- IEquality
- IOrdering
