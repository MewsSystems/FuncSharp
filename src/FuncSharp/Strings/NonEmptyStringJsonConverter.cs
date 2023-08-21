using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FuncSharp
{
    public class NonEmptyStringJsonConverter : JsonConverter<NonEmptyString>
    {
        public override NonEmptyString Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return reader.GetString().AsNonEmpty().GetOrNull();
        }

        public override void Write(
            Utf8JsonWriter writer,
            NonEmptyString value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Value);
        }
    }
}