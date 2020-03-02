# FuncSharp - Functional C&#35;

[![Azure DevOps](https://img.shields.io/azure-devops/build/siroky/FuncSharp/1)](https://dev.azure.com/siroky/FuncSharp/_build/latest?definitionId=1)
[![NuGet Downloads](https://img.shields.io/nuget/dt/FuncSharp)](https://www.nuget.org/packages/FuncSharp/)
[![NuGet Version](https://img.shields.io/nuget/v/FuncSharp)](https://www.nuget.org/packages/FuncSharp/)

A C# library with main purpose to reduce boilerplate code and avoid bugs thanks to stronger typing. Utilizes many concepts from functional programming languages that are also applicable in C#.

## Contents

- [Product](#product)
- [Coproduct](#coproduct)
- [Option](#option)
- [Morphism](#morphism)
- [DataCube](#datacube)
- [Order](#order)

### Product

Extensible definition of [product types](http://en.wikipedia.org/wiki/Product_type) with canonical implementation that can be used when implementing custom product types or that can replace standard `Tuple`s which you cannot abstract over, nor enumerate their values. By extending the `Product[N]` from **FuncSharp**, one gets correct structural hash code, structural equality and nice `ToString` method for free. The final implementation of a custom product type is therefore as boilerplate-less as possible.

You can create canonical product instances using the `Product.Create` function. In order to implement a custom product type, you need to inherit the `Product[N]` class where `[N]` stands for arity of the product. A constructor needs to be defined and it is often good practice to define named getters on top of the standard product projections (e.g. `ProductValue1`). But this is not obligatory. Custom product type representing a user can be seen on the following example:

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

Similarly to product types, **FuncSharp** also contains extensible definition and canonical implementation of [coproduct types](http://chadaustin.me/2015/07/sum-types/) (also called sum or union types). They represent a strongly typed alternative, e.g. "value that is either `bool`, `string` or `int`". Their main advantage over standard class hierarchy is, that the usage is compile time checked. So if you decide to add/remove an alternative, all places that use the coproduct value become identified by compiler as an error until you add/remove the case. 

Canonical coproducts can be created using `Coproduct.Create[Nth]` function where `[Nth]` stands for e.g. `First` or `Second` depending on which alternative should be created. Size of the new coproduct is inferred from the type arguments. However type signatures can become pretty big when using the canonical coproducts, so it is recommended to rather define custom coproduct types. Just inherit `Coproduct[N]` where `[N]` stands for arity (count of alternatives) and implement constructors for each alternative. A simplified example how to represent trees using coproduct types and how to calculate leaf count of can be seen on the following snippet:

```cs
class Leaf { }

class Node<A> : Product3<A, Tree<A>, Tree<A>> { /* Constructor, getters for value, left and right subtree. */ }

class Tree<A> : Coproduct2<Node<A>, Leaf>
{
    public Tree(Node<A> node) : base(node) { }
    public Tree(Leaf leaf) : base(leaf) { }
}

int LeafCount<A>(Tree<A> tree)
{
    return tree.Match(
        node => LeafCount(node.Left) + LeafCount(node.Right),
        leaf => 1
    );
}
```

A coproduct of zero types (a choice from no types) is also a well known type, in **FuncSharp** named `Nothing`. This type has no instance and can be used e.g. as a return type of function that always throws an exception. So behavior of the function is encoded in its type signature.

### Option

An `Option<A>` is widely used functional data type known from other languages. It represents a value that may or may not be available. Great for avoiding `NullReferenceException`s and handling the two null/non-null cases. Also in C#, nullable types are somewhat different from references (in case of nullables, you have to use the `Value` getter). The option type nicely unifies this discrepancy.

### Morphism

Simplistic implementation of finite morphisms between two types. Isomorphisms can be used as a concise representation of a bidirectional mapping that is in .NET traditionally represented as a pair of dictionaries.

### DataCube

DataCubes represent sets of data indexed by a multidimensional index. E.g. a two-dimensional data cube is roughly equivalent to `Dictionary<Tuple2<P1, P2>, TValue>`. However data cubes are much more friendlier to work with, they provide nicer API than dictionary and offer many more advanced operations like slicing, aggregations, transformations, filtering etc. As a simple example, consider data structure representing counts of commits each hour and day of week. One may construct it from a collection of commits and represent it in memory as follows:

```cs
var punchCard = new DataCube2<Day, Hour, int>();
foreach (var commit in commits)
{
    punchCard.SetOrElseUpdate(commit.Day, commit.Hour, 1, (sum, _) => sum + 1);
}
var dailyTotals = punchCard.RollUpDimension2((a, b) => a + b); // DataCube1<Day, int>
```

### Order

Defines partial or total order for a type. By implementing the `Less` operation that compares two instances of the type, you get many many useful functions based on that. Starting from finding minimum or maximum in a collection of the instances, it allows you to work with **intervals** bounded by the type instances. And moreover working with **interval sets** which essentially represent a disjoint set of intervals. You can e.g. get an interval set as a result of union of two disjoint intervals.

Generic representation of an interval and interval set may seem simple on the first sight, but becomes really handy when you consider all the cases it supports (and you'd have to implement): empty or single-value interval, any combination a bounded/unbounded interval with open/closed lower/upper bound, and finally unbounded interval. And also interval sets consisting of any combination of the aforementioned intervals. In combination with all the operations on them (`Contains`, `Intersect`, `Union` etc.) it becomes obvious, it's not something anybody would like to implement more than once. Or not even once. However implementing the `Less` operation is trivial and you get the rest for free.
