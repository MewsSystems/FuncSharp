# FuncSharp - Functional C&#35;

A C# library with main purpose to reduce boilerplate code and avoid bugs thanks to stronger typing. Utilizes many concepts from functional programming languages that are also applicable in C#. Download from [NuGet](https://www.nuget.org/packages/FuncSharp/):

```
Install-Package FuncSharp
```

## Contents

- [Data Types](#data-types)
    - [Product](#product)
    - [Coproduct](#coproduct)
    - [Option](#option)
    - [Definite](#definite)
    - [Morphism](#morphism)
    - [DataCube](#datacube)
- [Type Classes](#type-classes)
    - [Equality](#equality)
    - [Enumeration](#enumeration)
    - [Ordering](#ordering)
- [Traits](#traits)

## Data Types

### Product

Extensible definition of [product types](http://en.wikipedia.org/wiki/Product_type) with canonical implementation that can be used when implementing a custom product type or that can replace standard `Tuple`s which you cannot abstract over, nor enumerate their values. By extending the `Product[N]` from **FuncSharp**, one gets correct structural hash code, structural equality and nice `ToString` method for free. The final implementation of a custom product type is therefore as boilerplate-less as possible.

In order to implement a custom product type, you need to inherit the `Product[N]` class where `[N]` stands for arity of the product. A constructor needs to be defined and it is often good to define named getters on top of the standard product projections (e.g. `ProductValue1`). But this is not obligatory. A custom product type representing a user can be seen on the following example:

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

A direct consequence of product types is the `Unit` type that can be understood as a product of zero types. In the world of .NET it becomes particularly useful when abstracting over `Func`tions and `Action`s which aren't compatible. Therefore there are also conversions between `Action`s and `Func`tions returning the `Unit` value.

### Coproduct

Similarly to product types, **FuncSharp** also comes equipped with extensible definition and canonical implementation of [coproduct types](https://en.wikipedia.org/wiki/Tagged_union) (also called sum or union types). They represent a strongly typed alternative, e.g. "value that is either `bool`, `string` or `int`". Their main advantage over standard class hierarchy is, that the usage is compile time checked. So if you decide to add or remove an alternative, all places that use the coproduct type become identified by compiler as a an error. A simplified example how to represent trees using coproduct types and how to calculate leaf count of a tree:

```cs
class Leaf { }
class Node<A> : Product3<A, Leaf, Leaf> { /* Constructor, getters. */ }
class Tree<A> : Coproduct2<Node<A>, Leaf> { /* Constructor. */ }

int LeafCount<A>(Tree<A> tree)
{
    return tree.Match(
        node => LeafCount(node.Left) + LeafCount(node.Right),
        leaf => 1
    );
}
```

A coproduct of zero types (a choice from no types) is also a well known type - in **FuncSharp** named `Nothing`. This type has no instance and can be used e.g. as a return type of function that always throws an exception. So behavior of the function is encoded in its type signature.

### Option

An `IOption<A>` is widely used functional data type known from other languages. It represents a value that may or may not be available. Great for avoiding `NullReferenceException`s and handling the two null/non-null cases. Also in C#, nullable types are somewhat different from references (in case of nullables, you have to use the `Value` getter). The option type nicely unifies this discrepancy.

### Definite

**FuncSharp** also contains type `IDefinite<A>` that states for a value that is known not to be null. Together with `IOption<A>`, you may gradually change class APIs from using just reference types to using only `IOption<A>` and `IDefinite<A>` and therefore avoid repetitive null checks everywhere.

### Morphism

Simplistic implementation of finite morphisms between two types. Isomorphisms can be used as a concise representation of a bidirectional mapping that is in .NET traditionally represented as a pair of dictionaries.

### DataCube

DataCubes represent sets of data indexed by a multidimensional index. E.g. a two-dimensional data cube is roughly equivalent to `Dictionary<Tuple2<P1, P2>, TValue>`. However data cubes are much more friendlier to work with, they provide nicer API than dictionary and offer many more advanced operations like slicing, aggregations, transformations, filtering etc. As a simple example, consider this [punch card](https://github.com/siroky/FuncSharp/graphs/punch-card). One may construct it from a collection of commits and represent it in memory as follows:

```cs
var punchCard = new DataCube2<Day, Hour, int>();
foreach (var commit in commits)
{
    punchCard.SetOrElseUpdate(commit.Day, commit.Hour, 1, (sum, _) => sum + 1);
}
var dailyTotals = punchCard.RollUpDimension2((a, b) => a + b); // DataCube1<Day, int>
```

## Type Classes

Type classes allow a programmer to define functionality for a type outside of that type. It comes handy mainly when the type comes from an external library and therefore it's not possible to make the type implement your interface. Or to have multiple different implementations of the same functionality. You can learn more about the concept (and other interesting stuff) in [Learn You a Haskell for Great Good!](http://learnyouahaskell.com/making-our-own-types-and-typeclasses#typeclasses-102).

### Equality

Defines equality for a type. Many other type classes are based on this one.

### Enumeration

Defines enumeration operation for a type. The only operation is the `Successor` which, given an instance of the type, returns the next instance, whatever it means.

### Ordering

Defines partial or total ordering for a type. By implementing the `Less` operation that compares two instances of the type, you get many many useful functions based on that. Starting from finding minimum or maximum in a collection of the instances, it allows you to work **intervals** bounded by the type instances. And moreover working with **interval sets** which essentially represent a disjoint set of intervals. You can e.g. get an interval set as a result of union of two disjoint intervals.

Generic representation of an interval and interval set may seem simple on the first sight, but becomes really handy when you consider all the cases it supports (and you'd have to implement): empty or single-value interval, any combination a bounded/unbounded interval with open/closed lower/upper bound, and finally unbounded interval. And also interval sets consisting of any combination of the aforementioned intervals. In combination with all the operations on them (`Contains`, `Intersect`, `Union`, `Complement` etc.) it becomes obvious, it's not something anybody would like to implement more than once. Or not even once. However implementing the `Less` operation is trivial and you get the rest for free.

## Traits

A trait can be understood as a plain C# interface enhanced with data and some implementation. It is a well-known pattern how to enhance interfaces with implementation. Simply create extension methods that take the interface type as the first `this` parameter. However it is not possible to create extension properties not fields and that's where **FuncSharp** comes handy. By extending `ITrait<TData>`, your interface becomes capable of data storage and retrieval, so the extension methods do not have to compute everything from scratch.
