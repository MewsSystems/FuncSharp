using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FuncSharp;

public sealed class TryConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
        {
            return false;
        }

        if (typeToConvert.GetGenericTypeDefinition() != typeof(Try<,>))
        {
            return false;
        }

        return true;
    }

    public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options)
    {
        Type[] typeArguments = type.GetGenericArguments();
        Type successType = typeArguments[0];
        Type errorType = typeArguments[1];

        JsonConverter converter = (JsonConverter)Activator.CreateInstance(
            typeof(TryConverter<,>).MakeGenericType(successType, errorType),
            BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: [options],
            culture: null)!;

        return converter;
    }

    private class TryConverter<TSuccess, TError>(JsonSerializerOptions options) : JsonConverter<Try<TSuccess, TError>>
    {
        private const string IsSuccessPropertyName = "IsSuccess";
        private const string ValuePropertyName = "Value";

        private readonly JsonConverter<TSuccess> _successConverter = (JsonConverter<TSuccess>)options.GetConverter(typeof(TSuccess));
        private readonly JsonConverter<TError> _errorConverter = (JsonConverter<TError>)options.GetConverter(typeof(TError));

        private readonly Type _successType = typeof(TSuccess);
        private readonly Type _errorType = typeof(TError);

        public override Try<TSuccess, TError> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException($"Not a {JsonTokenType.StartObject}");
            }

            ReadPropertyName(ref reader, options, IsSuccessPropertyName);

            reader.Read();
            var isSuccess = reader.GetBoolean();

            ReadPropertyName(ref reader, options, ValuePropertyName);

            reader.Read();
            Try<TSuccess, TError>? tryInstance;

            if (isSuccess)
            {
                var success = _successConverter.Read(ref reader, _successType, options);
                tryInstance = new Try<TSuccess, TError>(success);
            }
            else
            {
                var error = _errorConverter.Read(ref reader, _errorType, options);
                tryInstance = new Try<TSuccess, TError>(error);
            }

            reader.Read();
            return tryInstance.Value;
        }

        private static void ReadPropertyName(ref Utf8JsonReader reader, JsonSerializerOptions options, string expectedPropertyName)
        {
            reader.Read();
            var propertyName = reader.GetString();
            if (propertyName != (options.PropertyNamingPolicy?.ConvertName(expectedPropertyName) ?? expectedPropertyName))
            {
                throw new JsonException($"Not a {expectedPropertyName} property");
            }
        }

        public override void Write(
            Utf8JsonWriter writer,
            Try<TSuccess, TError> tryMe,
            JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteBoolean(options.PropertyNamingPolicy?.ConvertName("IsSuccess") ?? "IsSuccess", tryMe.IsSuccess);

            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName("Value") ?? "Value");

            if (tryMe.IsSuccess)
            {
                _successConverter.Write(writer, tryMe.Success.Get(), options);
            }
            else
            {
                _errorConverter.Write(writer, tryMe.Error.Get(), options);
            }

            writer.WriteEndObject();
        }
    }
}