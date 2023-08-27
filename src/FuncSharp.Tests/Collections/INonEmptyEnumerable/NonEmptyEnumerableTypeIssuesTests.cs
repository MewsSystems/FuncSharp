using System.Collections.Generic;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable;

/// <summary>
/// NonEmptyEnumerable is working with Spans for performance optimizations. However it can cause a `ArrayTypeMismatchException` when the array is of a different type than expected (due to inheritance of the type inside.)
/// These tests are here to make sure that such collections can also be mapped to NonEmptyEnumerable without throwing an exception.
/// </summary>
public class NonEmptyEnumerableTypeIssuesTests
{
    [Fact]
    public void Array_OfDifferentTypes()
    {
        ReferenceTypeBase[] baseArray = new ReferenceTypeBase[] { new ReferenceTypeBase(14) };
        ReferenceTypeBase[] exactArray = new ReferenceType[] { new ReferenceType(14) };

        OptionAssert.NonEmpty(baseArray.AsNonEmpty());
        OptionAssert.NonEmpty(exactArray.AsNonEmpty());
    }

    [Fact]
    public void ArrayAsIEnumerable_OfDifferentTypes()
    {
        IEnumerable<ReferenceTypeBase> baseArray = new ReferenceTypeBase[] { new ReferenceTypeBase(14) };
        IEnumerable<ReferenceTypeBase> exactArray = new ReferenceType[] { new ReferenceType(14) };

        OptionAssert.NonEmpty(baseArray.AsNonEmpty());
        OptionAssert.NonEmpty(exactArray.AsNonEmpty());
    }

    [Fact]
    public void ListAsIEnumerable_OfDifferentTypes()
    {
        IEnumerable<ReferenceTypeBase> baseArray = new List<ReferenceTypeBase>() { new ReferenceTypeBase(14) };
        IEnumerable<ReferenceTypeBase> exactArray = new List<ReferenceType>() { new ReferenceType(14) };

        OptionAssert.NonEmpty(baseArray.AsNonEmpty());
        OptionAssert.NonEmpty(exactArray.AsNonEmpty());
    }
}