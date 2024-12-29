using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Helpers;


internal class IgnoreIdOnDeserializeConverter : JsonConverter<Guid>{
    public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Skip the value during deserialization
        reader.Skip();
        return default;
    }

    public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
    {
        // Include the value during serialization
        writer.WriteStringValue(value);
    }
}