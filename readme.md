# FuncSharp - Functional C&#35;

<p align="center">
    <a href="https://mews.com">
        <img alt="Mews" height="100px" src="https://user-images.githubusercontent.com/435787/129971779-2c64348e-05a3-49d0-b026-91913ffd68dc.png">
    </a>
</p>

[![Build](https://img.shields.io/github/actions/workflow/status/MewsSystems/FuncSharp/build-and-test.yml?branch=master&label=build%20and%20tests)](https://github.com/MewsSystems/FuncSharp/actions/workflows/build-and-test.yml)
[![Build](https://img.shields.io/github/actions/workflow/status/MewsSystems/FuncSharp/publish.yml?branch=master&label=publish)](https://github.com/MewsSystems/FuncSharp/actions/workflows/publish.yml)
[![License](https://img.shields.io/github/license/MewsSystems/FuncSharp)](https://github.com/MewsSystems/FuncSharp/blob/master/license.txt)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Mews.FuncSharp)](https://www.nuget.org/packages/Mews.FuncSharp/)
[![NuGet Version](https://img.shields.io/nuget/v/Mews.FuncSharp)](https://www.nuget.org/packages/Mews.FuncSharp/)

FuncSharp is a C# library with main purpose to introduce more advanced functional programming concepts that are currently not availabile in C# natively. As on outcome, it helps **reducing boilerplate** code, making code **more readable** and **avoiding bugs** thanks to stronger typing. It utilizes many concepts from other functional programming languages like Haskell or Scala, that are also applicable in C#.

Core of the library is formed by **algebraic data types** (ADTs), namely `Product` and `Coproduct`. Get familiar with them first and make sure you understand concepts of algebraic data modeling. Just those two types, on their own, can be pretty helpful when used in your applications. Everything else this library offers is built on top of the ADTs and is an application of ADT principles to solve some real life use-cases. You can find practical examples in the [`FuncSharp.Examples`](https://github.com/MewsSystems/FuncSharp/tree/master/src/FuncSharp.Examples) project.

## Algebraic Data Types

There are basic types in C# like `string`, `int`, `bool`, `DateTime` or others. But how to create more types? The standard approach is to define a new class and "wrap" some of the already available types into it. That's the idiomatic way how to do that in C#, however it has some limitations when it comes to abstraction. Without reflection, you cannot easily iterate over all the properties of a class. Or create a method that accepts classes with 3 properties and whose first property is a string. That's where algebraic data types come into picture by offering alternative ways how to form types. To be specific, 2 ways:

- Product (also known as "and type" or "tuple") represents **multiple values of other types** in a single type. For example financial amount can be understood as a product of decimal value **and** string currency code. Written algebraically `decimal AND string`, using FuncSharp code `IProduct2<decimal, string>`. That's nothing surprising and it does not differ from standard tuples in C#.
- Coproduct (also known as "or type", "sum type" or "disjoint union") represents **exactly one of multiple other types**. For example an API call result can be understood as a coproduct of either successful string response **or** integer error code. In algebraic language `string OR int`, in FuncSharp `ICoproduct2<string, int>`. An equivalent in C# would be an abstract class (Animal) with two subclasses (Cat, Dog), however it wouldn't be type-safe and it has other drawbacks.

The nice part about ADTs is that you can combine the types recursively, however deep you want. And build up very complex types using these two basic operations. There are many good posts about ADTs, you can check out the [Haskell primer on algebraic data types](http://learnyouahaskell.com/making-our-own-types-and-typeclasses#algebraic-data-types), how ADTs are implemented in [other programming languages](https://blog.softwaremill.com/algebraic-data-types-in-four-languages-858788043d4e) or great [explanation of coproducts and their advantages](http://chadaustin.me/2015/07/sum-types/).

### Product

FuncSharp provides custom product types that can replace standard `Tuple`s which you cannot abstract over, nor enumerate their values. They come equipped with correct structural hash code, structural equality and nice `ToString` method for free. The final implementation of a custom product type is therefore as boilerplate-less as possible. In order to implement a custom product type,  you need to inherit the `Product[N]` class from **FuncSharp** where `[N]` stands for arity of the product. A constructor needs to be defined and it is often good practice to define named getters on top of the standard product value getters (e.g. `ProductValue1`). But this is not obligatory. Custom product type representing a point in 2-deminsional space can be seen on following example:

```C#
public class Point2D : Product2<float, float>
{
    public Point2D(float x, float y)
        : base(x, y)
    {
    }

    public float X { get { return ProductValue1; } }
    public float Y { get { return ProductValue2; } }
}
```

You can check more extensive example, together with usage, in the [`Product.cs`](https://github.com/MewsSystems/FuncSharp/tree/master/src/FuncSharp.Examples/Product/Product.cs) example. A direct consequence of product types is the `Unit` type that can be understood as a product of zero types. In the world of .NET it becomes particularly useful when abstracting over `Func`tions and `Action`s which aren't compatible. Therefore there are also conversions between `Action`s and `Func`tions returning the `Unit` value.

### Coproduct

Main advantage of coproducts that FuncSharp offers, compared to standard class hierarchy, is that the usage is compile time checked. So if you decide to add/remove another type to/from coproduct, all places that use the coproduct value become identified by compiler as an error until you add/remove the case. Coproducts can be created using `Coproduct.Create[Nth]` function where `[Nth]` stands for e.g. `First` or `Second` depending on which alternative should be created. Size of the new coproduct is inferred from the type arguments. However type signatures can become pretty big when doing this, also it's good in general to name things well, so it is recommended to rather define custom coproduct types. Just inherit `Coproduct[N]` where `[N]` stands for arity (count of alternatives) and implement constructors for each alternative. A simplified example how to represent trees using coproduct type can be seen on the following snippet:

```cs
public class Tree<A> : Coproduct2<Node<A>, Leaf>
{
    public Tree(Node<A> node) : base(node) { }
    public Tree(Leaf leaf) : base(leaf) { }
}
```

More extensive example can be found in the [`Coproduct.cs`](https://github.com/MewsSystems/FuncSharp/tree/master/src/FuncSharp.Examples/Coproduct/Coproduct.cs) file. A coproduct of zero types (a choice from no types) is also a well known type, in **FuncSharp** named `Nothing`. This type has no instance and can be used e.g. as a return type of function that always throws an exception. So behavior of the function is encoded in its type signature.

## Additional Helpful Types

### Option

An `IOption<A>` is widely used functional data type known from other languages. It represents a value that may or may not be available. Great for avoiding `NullReferenceException`s and handling the two null/non-null cases. Also in C#, nullable types are somewhat different from references (in case of nullables, you have to use the `Value` getter). The option type nicely unifies this discrepancy. Lot of examples how to use options is in [`IOption.cs`](https://github.com/MewsSystems/FuncSharp/blob/master/src/FuncSharp.Examples/Option/IOption.cs) file.

Currently, we're replacing `IOption<A>` with `ValueOption<A>`, so that the option itself is a struct and cannot be null. That prevents bugs when people check the option for being null instead of the value. [Examples](https://github.com/MewsSystems/FuncSharp/blob/master/src/FuncSharp.Examples/Option/ValueOption.cs) have been updated.

### Try

In order to handle errors or exceptions, FuncSharp features `ITry<A, E>` that represents a result of an operation that can end with either success or error. It explicitly communicates all the possible outcomes on type level, unlike exceptions where you have to read a documentation to understand how a method can end. An extensive set of examples can be found in the following files:

- [Basics](https://github.com/MewsSystems/FuncSharp/blob/master/src/FuncSharp.Examples/Try/ITryBasics.cs) - Basic concepts.
- [Exception Handling](https://github.com/MewsSystems/FuncSharp/blob/master/src/FuncSharp.Examples/Try/ITryExceptionHandling.cs) - How to turn a standard API that uses exceptions to strongly typed one, using the try type.
- [Parsing](https://github.com/MewsSystems/FuncSharp/blob/master/src/FuncSharp.Examples/Try/ITryParsing.cs) - How to safely parse unsafe incoming data.
- [General Usage](https://github.com/MewsSystems/FuncSharp/blob/master/src/FuncSharp.Examples/Try/ITryGeneral.cs) - Putting it all together, a few advanced concepts.

### Morphism

Simplistic implementation of finite morphisms between two types. Isomorphisms can be used as a concise representation of a bidirectional mapping that is in .NET traditionally represented as a pair of dictionaries.

### DataCube

DataCubes represent sets of data indexed by a multidimensional index. E.g. a two-dimensional data cube is roughly equivalent to `Dictionary<Tuple2<P1, P2>, TValue>`. However data cubes are much more friendlier to work with, they provide nicer API than dictionary and offer many more advanced operations like slicing, aggregations, transformations, filtering etc.

### Order

Defines partial or total order for a type. By implementing the `Less` operation that compares two instances of the type, you get many many useful functions based on that. Starting from finding minimum or maximum in a collection of the instances, it allows you to work with **intervals** bounded by the type instances. And moreover working with **interval sets** which essentially represent a disjoint set of intervals. You can e.g. get an interval set as a result of union of two disjoint intervals.

Generic representation of an interval and interval set may seem simple on the first sight, but becomes really handy when you consider all the cases it supports (and you'd have to implement): empty or single-value interval, any combination a bounded/unbounded interval with open/closed lower/upper bound, and finally unbounded interval. And also interval sets consisting of any combination of the aforementioned intervals. In combination with all the operations on them (`Contains`, `Intersect`, `Union` etc.) it becomes obvious, it's not something anybody would like to implement more than once. Or not even once. However implementing the `Less` operation is trivial and you get the rest for free.
