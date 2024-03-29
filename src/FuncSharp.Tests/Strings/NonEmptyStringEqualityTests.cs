﻿using Xunit;

namespace FuncSharp.Tests.Strings;

public class NonEmptyStringTests
{
    [Fact]
    public void OptionEqualityTest()
    {
        Option<NonEmptyString> valued1 = Option.Valued(NonEmptyString.CreateUnsafe("ASDF123"));
        Option<string> valued2 = Option.Valued("ASDF123");
        Assert.True(valued1.Equals(valued2));
        Assert.True(valued2.Equals(valued1));
        Assert.True(object.Equals(valued1, valued2));
        Assert.True(object.Equals(valued2, valued1));

        var differentStringOption = Option.Valued("Text14");
        var differentNonEmptyStringOption = Option.Valued(NonEmptyString.CreateUnsafe("Totally different text here."));
        Assert.False(differentNonEmptyStringOption.Equals(differentStringOption));
        Assert.False(differentStringOption.Equals(differentNonEmptyStringOption));
        Assert.False(object.Equals(differentNonEmptyStringOption, differentStringOption));
        Assert.False(object.Equals(differentStringOption, differentNonEmptyStringOption));

        Option<NonEmptyString> empty1 = Option.Empty<NonEmptyString>();
        Option<string> empty2 = Option.Empty<string>();
        Assert.True(empty1.Equals(empty2));
        Assert.True(empty2.Equals(empty1));
        Assert.True(object.Equals(empty1, empty2));
        Assert.True(object.Equals(empty2, empty1));

        Option<NonEmptyString> valuedWithNull1 = Option.Valued<NonEmptyString>(null);
        Option<string> valuedWithNull2 = Option.Valued<string>(null);
        Assert.True(valuedWithNull1.Equals(valuedWithNull2));
        Assert.True(valuedWithNull2.Equals(valuedWithNull1));
        Assert.True(object.Equals(valuedWithNull1, valuedWithNull2));
        Assert.True(object.Equals(valuedWithNull2, valuedWithNull1));
    }

    [Fact]
    public void EqualityTest()
    {
#pragma warning disable xUnit2010

        string text = "ASDF123";
        NonEmptyString nonEmptyString = NonEmptyString.CreateUnsafe("ASDF123");
        NonEmptyString nonEmptyStringWithSameValue = NonEmptyString.CreateUnsafe("ASDF123");
        Assert.True(text == nonEmptyString);
        Assert.False(text != nonEmptyString);
        Assert.True(nonEmptyString == text);
        Assert.False(nonEmptyString != text);
        Assert.True(nonEmptyString == nonEmptyStringWithSameValue);
        Assert.False(nonEmptyString != nonEmptyStringWithSameValue);

        Assert.True(text.Equals(nonEmptyString));
        Assert.True(nonEmptyString.Equals(text));
        Assert.True(nonEmptyString.Equals(nonEmptyStringWithSameValue));

        Assert.False(object.Equals(text, nonEmptyString)); // Unfortunately string doesn't override the default Equals method to compare with IEquatable<string> therefore this is false.
        Assert.True(object.Equals(nonEmptyString, text));
        Assert.True(object.Equals(nonEmptyString, nonEmptyStringWithSameValue));

        string differentString = "Text14";
        NonEmptyString differentNonEmptyString = NonEmptyString.CreateUnsafe("Totally different text here.");
        NonEmptyString differentNonEmptyString2 = NonEmptyString.CreateUnsafe("And completely different again.");

        Assert.False(differentString == differentNonEmptyString);
        Assert.True(differentString != differentNonEmptyString);
        Assert.False(differentNonEmptyString == differentString);
        Assert.True(differentNonEmptyString != differentString);
        Assert.False(differentNonEmptyString == differentNonEmptyString2);
        Assert.True(differentNonEmptyString != differentNonEmptyString2);

        Assert.False(differentString.Equals(differentNonEmptyString));
        Assert.False(differentNonEmptyString.Equals(differentString));
        Assert.False(differentNonEmptyString.Equals(differentNonEmptyString2));

        Assert.False(object.Equals(differentString, differentNonEmptyString));
        Assert.False(object.Equals(differentNonEmptyString, differentString));
        Assert.False(object.Equals(differentNonEmptyString, differentNonEmptyString2));

        NonEmptyString null1 = null;
        string null2 = null;
        Assert.True(null1 == null2);
        Assert.True(null2 == null1);
        Assert.True(object.Equals(null1, null2));
        Assert.True(object.Equals(null2, null1));

#pragma warning restore xUnit2010
    }
}