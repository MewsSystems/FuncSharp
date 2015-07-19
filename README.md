# FuncSharp - Functional C&#35;

#### Product Types

Extensible definition of [product types](http://en.wikipedia.org/wiki/Product_type) with canonical implementation that can be used when implementing a custom product type or that can replace stanard `Tuple`s which you cannot abstract over, nor enumerate their values. By extending the `Product` from **FuncSharp**, one gets correct structural hash code, structural equality and nice `ToString` method for free. The final implementation of the custom product type should be as boilerplate-less as possible, as can be seen on the following example:

```C#
class User : Product3<string, string, DateTime>
{
    public User(string firstName, string lastName, DateTime birthDate)
        : base(firstName, lastName, birthDate) { }

    public string FirstName { get { return ProductValue1; } }
    public string LastName { get { return ProductValue2; } }
    public DateTime BirthDate { get { return ProductValue3; } }
}
```

A direct consequence of product types is the `Unit` type that can be understood as a product of zero types. In the world of .NET it becomes particulary useful when abstracting over `Func`tions and `Action`s which aren't compatible. Therefore **FuncSharp** contains conversions between `Action`s and `Func`tions returning the `Unit` value.

#### Sum Types

Similarly to product types, **FuncSharp** also comes equipped with extensible definition and canonical implementation of sum types (coproduct types). They represent a strongly typed alternative, e.g. either `bool`, `string` or `int` value. Their main advantage over standard class hierarchy is, that the usage is compile time checked. So if you decide to add or remove an alternative, all places that use the sum type become identified by compiler as a an error. One application of this principle can for example be implementation of strongly-typed enums. Adding a new value to the enum would immediately introduce compile time errors, which would force the programmer to fix all places that use the enum.

A sum of zero types (a choice from no types) is also a well known type - in **FuncSharp** named `Nothing`. This type has no instance and can be used e.g. as a return type of function that always throws an exception. So behavior of the function is encoded in its signature.

#### Option & Definite

An `IOption<A>` is widely used functional data type known from other languages. It represents a value that may or may not be available. Great for avoiding `NullReferenceException`s and handling the two null/non-null cases. **FuncSharp** also contains type `IDefinite<A>` that states for a value that is known not to be null. Together, you may use both to gradually change class APIs from using just reference types to using only `IOption` and `IDefinite`.

#### Interval

A generic representation of an interval of comparable values and operations with such intervals. May seem simple on the first sight, but becomes really handy when you consider all the cases it supports (and you'd have to implement): empty or single-value interval, any combination a bounded/unbounded interval with open/closed lower/upper bound, and finally unbounded interval.

### Typeclasses

Work in progress

- IEquality
- IOrdering
