# FuncSharp - Functional C&#35;

A library with main purpose to reduce some boilerplate code from C# programs and introduce stronger typing. Utilizes many concepts from functional programming languages that are also applicable in C#. Download from NuGet:

```
Install-Package FuncSharp
```

## Contents

- [Data Types](#data-types)
    - [Option](#option)
    - [Definite](#definite)
    - [Product](#product)
    - [Sum](#sum)
- [Traits](#traits)
- [Type Classes](#type-classes)
    - [Equality](#equality)
    - [Enumeration](#enumeration)
    - [Ordering](#ordering)

## Data Types

#### Option

An `IOption<A>` is widely used functional data type known from other languages. It represents a value that may or may not be available. Great for avoiding `NullReferenceException`s and handling the two null/non-null cases.

#### Definite

**FuncSharp** also contains type `IDefinite<A>` that states for a value that is known not to be null. Together with `IOption<A>`, you may gradually change class APIs from using just reference types to using only `IOption<A>` and `IDefinite<A>` and therefore avoid repetitive null checks everywhere.

#### Product

Extensible definition of [product types](http://en.wikipedia.org/wiki/Product_type) with canonical implementation that can be used when implementing a custom product type or that can replace standard `Tuple`s which you cannot abstract over, nor enumerate their values. By extending the `Product` from **FuncSharp**, one gets correct structural hash code, structural equality and nice `ToString` method for free. The final implementation of the custom product type should be as boilerplate-less as possible, as can be seen on the following example:

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

#### Sum

Similarly to product types, **FuncSharp** also comes equipped with extensible definition and canonical implementation of sum types (coproduct types). They represent a strongly typed alternative, e.g. either `bool`, `string` or `int` value. Their main advantage over standard class hierarchy is, that the usage is compile time checked. So if you decide to add or remove an alternative, all places that use the sum type become identified by compiler as a an error. One application of this principle can for example be implementation of strongly-typed enums. Adding a new value to the enum would immediately introduce compile time errors, which would force the programmer to fix all places that use the enum.

A sum of zero types (a choice from no types) is also a well known type - in **FuncSharp** named `Nothing`. This type has no instance and can be used e.g. as a return type of function that always throws an exception. So behavior of the function is encoded in its type signature.

## Traits

A trait can be understood as a plain C# interface enahnced with data and some implementation. It is a well-known pattern how to enhance interfaces with implementation. Simply create extension methods that take the interface type as the first `this` parameter. However it is not possible to create extension properties not fields and that's where **FuncSharp** comes handy. By extending `ITrait<TData>`, your interface becomes capable of data storage and retrieval, so the extension methods do not have to compute everything from scratch.

## Type Classes

Type classes allow a programmer to define functionality for a type outside of that type. It comes handy mainly when the type comes from an external library and therefore it's not possible to make the type implement your interface. Or to have multiple different implementations of the same functionality. You can learn more about the concept (and other interesting stuff) in [Learn You a Haskell for Great Good!](http://learnyouahaskell.com/making-our-own-types-and-typeclasses#typeclasses-102).

#### Equality

Defines equality for a type. Many other type classes are based on this one.

#### Enumeration

Defines enumeration operation for a type. The only operation is the `Successor` which, given an instance of the type, returns the next instance, whatever it means.

#### Ordering

Defines partial or total ordering for a type. By implementing the `Less` operation that compares two instances of the type, you get many many useful functions based on that. Starting from finding minimum or maximum in a collection of the instances, it allows you to work **intervals** bounded by the type instances. And moreover working with **interval sets** which essentially represent a disjoint set of intervals. You can e.g. get an interval set as a result of two disjoint intervals.

Generic representation of an interval and interval set may seem simple on the first sight, but becomes really handy when you consider all the cases it supports (and you'd have to implement): empty or single-value interval, any combination a bounded/unbounded interval with open/closed lower/upper bound, and finally unbounded interval. And also interval sets consisting of any combination of the aforementioned intervals. In combination with all the operations on them (`Contains`, `Intersect`, `Union`, `Complement` etc.) it becomes obvious, it's not something anybody would like to implement more than once. Or not even once. However implementing the `Less` operation is trivial and you get the rest for free.
