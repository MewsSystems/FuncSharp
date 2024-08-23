using System.Text.Json;
using Xunit;

namespace FuncSharp.Tests;

public class TryConverterTests
{
    private sealed record DummySuccess(string SomeProperty);
    private sealed record DummyError(string Message);

    private sealed record ComplexObject(string PropertyBefore, Try<DummySuccess, DummyError> Value, string PropertyAfter);

    [Fact]
    public void Serializes_success_with_primitive_value()
    {
        // Arrange
        var value = Try.Success<int, string>(42);

        // Act
        var json = JsonSerializer.Serialize(value);

        // Assert
        Assert.Equal(@"{""IsSuccess"":true,""Value"":42}", json);
    }

    [Fact]
    public void Deserializes_success_with_primitive_value()
    {
        // Arrange
        var json = @"{""IsSuccess"":true,""Value"":42}";

        // Act
        var value = JsonSerializer.Deserialize<Try<int, string>>(json);

        // Assert
        Assert.True(value.IsSuccess);
        Assert.Equal(42, value.Success.Get());
    }

    [Fact]
    public void Serializes_success_with_reference_type()
    {
        // Arrange
        var value = Try.Success<DummySuccess, string>(new DummySuccess("success!"));

        // Act
        var json = JsonSerializer.Serialize(value);

        // Assert
        Assert.Equal(@"{""IsSuccess"":true,""Value"":{""SomeProperty"":""success!""}}", json);
    }

    [Fact]
    public void Deserializes_success_with_reference_type()
    {
        // Arrange
        var json = @"{""IsSuccess"":true,""Value"":{""SomeProperty"":""success!""}}";

        // Act
        var value = JsonSerializer.Deserialize<Try<DummySuccess, string>>(json);

        // Assert
        Assert.True(value.IsSuccess);
        Assert.Equal(new DummySuccess("success!"), value.Success.Get());
    }

    [Fact]
    public void Serializes_error_with_primitive_value()
    {
        // Arrange
        var value = Try.Error<int, string>("error!");

        // Act
        var json = JsonSerializer.Serialize(value);

        // Assert
        Assert.Equal(@"{""IsSuccess"":false,""Value"":""error!""}", json);
    }

    [Fact]
    public void Serializes_error_with_reference_type()
    {
        // Arrange
        var value = Try.Error<int, DummyError>(new DummyError("error!"));

        // Act
        var json = JsonSerializer.Serialize(value);

        // Assert
        Assert.Equal(@"{""IsSuccess"":false,""Value"":{""Message"":""error!""}}", json);
    }

    [Fact]
    public void Serializes_complex_object_including_try()
    {
        // Arrange
        var value = new ComplexObject("before", Try.Success<DummySuccess, DummyError>(new DummySuccess("success!")), "after");

        // Act
        var json = JsonSerializer.Serialize(value);

        // Assert
        Assert.Equal(@"{""PropertyBefore"":""before"",""Value"":{""IsSuccess"":true,""Value"":{""SomeProperty"":""success!""}},""PropertyAfter"":""after""}", json);
    }

    [Fact]
    public void Deserializes_complex_object_including_try()
    {
        // Arrange
        var json = @"{""PropertyBefore"":""before"",""Value"":{""IsSuccess"":true,""Value"":{""SomeProperty"":""success!""}},""PropertyAfter"":""after""}";

        // Act
        var value = JsonSerializer.Deserialize<ComplexObject>(json);

        // Assert
        Assert.Equal("before", value.PropertyBefore);
        Assert.True(value.Value.IsSuccess);
        Assert.Equal(new DummySuccess("success!"), value.Value.Success.Get());
        Assert.Equal("after", value.PropertyAfter);
    }
}