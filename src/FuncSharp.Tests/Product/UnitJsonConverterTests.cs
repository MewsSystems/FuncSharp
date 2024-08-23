using System.Text.Json;
using Xunit;

namespace FuncSharp.Tests;

public class UnitJsonConverterTests
{
    private record DummyObjectWithUnit(string PropertyBefore, Unit Unit, string PropertyAfter);

    [Fact]
    public void Serializes_unit_only()
    {
        // Act
        var json = JsonSerializer.Serialize(Unit.Value);

        // Assert
        Assert.Equal("{}", json);
    }

    [Fact]
    public void Deserializes_unit_only()
    {
        // Act
        var value = JsonSerializer.Deserialize<Unit>("{}");

        // Assert
        Assert.Equal(Unit.Value, value);
    }

    [Fact]
    public void Serializes_complex_object_including_unit()
    {
        // Arrange
        var value = new DummyObjectWithUnit("before", Unit.Value, "after");

        // Act
        var json = JsonSerializer.Serialize(value);

        // Assert
        Assert.Equal(@"{""PropertyBefore"":""before"",""Unit"":{},""PropertyAfter"":""after""}", json);
    }

    [Fact]
    public void Deserializes_complex_object_including_unit()
    {
        // Arrange
        var json = @"{""PropertyBefore"":""before"",""Unit"":{},""PropertyAfter"":""after""}";

        // Act
        var value = JsonSerializer.Deserialize<DummyObjectWithUnit>(json);

        // Assert
        Assert.Equal("before", value.PropertyBefore);
        Assert.Equal(Unit.Value, value.Unit);
        Assert.Equal("after", value.PropertyAfter);
    }

    [Fact]
    public void Serializes_try_with_success_as_unit()
    {
        // Arrange
        var value = Try.Success<Unit, string>(Unit.Value);

        // Act
        var json = JsonSerializer.Serialize(value);

        // Assert
        Assert.Equal(@"{""IsSuccess"":true,""Value"":{}}", json);
    }
}