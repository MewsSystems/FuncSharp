using Xunit;

namespace FuncSharp.Tests.Strings;

public class NonEmptyStringTests
{
    [Fact]
    public void OptionEqualityTest()
    {
        IOption<NonEmptyString> valued1 = Option.Valued(NonEmptyString.CreateUnsafe("ASDF123"));
        IOption<string> valued2 = Option.Valued("ASDF123");
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

        IOption<NonEmptyString> empty1 = Option.Empty<NonEmptyString>();
        IOption<string> empty2 = Option.Empty<string>();
        Assert.True(empty1.Equals(empty2));
        Assert.True(empty2.Equals(empty1));
        Assert.True(object.Equals(empty1, empty2));
        Assert.True(object.Equals(empty2, empty1));

        IOption<NonEmptyString> valuedWithNull1 = Option.Valued<NonEmptyString>(null);
        IOption<string> valuedWithNull2 = Option.Valued<string>(null);
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
        Assert.True(text == nonEmptyString);
        Assert.True(nonEmptyString == text);
        Assert.True(text.Equals(nonEmptyString));
        Assert.True(nonEmptyString.Equals(text));
        Assert.True(text.SafeEquals(nonEmptyString));
        Assert.True(nonEmptyString.SafeEquals(text));
        Assert.False(object.Equals(text, nonEmptyString)); // Unfortunately string doesn't override the default Equals method to compare with IEquatable<string> therefore this is false.
        Assert.True(object.Equals(nonEmptyString, text));

        string differentString = "Text14";
        NonEmptyString differentNonEmptyString = NonEmptyString.CreateUnsafe("Totally different text here.");
        Assert.False(differentNonEmptyString.Equals(differentString));
        Assert.False(differentString.Equals(differentNonEmptyString));
        Assert.False(differentNonEmptyString == differentString);
        Assert.False(differentString == differentNonEmptyString);
        Assert.False(differentNonEmptyString.SafeEquals(differentString));
        Assert.False(differentString.SafeEquals(differentNonEmptyString));
        Assert.False(object.Equals(differentNonEmptyString, differentString));
        Assert.False(object.Equals(differentString, differentNonEmptyString));

        NonEmptyString null1 = null;
        string null2 = null;
        Assert.True(null1.SafeEquals(null2));
        Assert.True(null2.SafeEquals(null1));
        Assert.True(null1 == null2);
        Assert.True(null2 == null1);
        Assert.True(object.Equals(null1, null2));
        Assert.True(object.Equals(null2, null1));

#pragma warning restore xUnit2010
    }
}