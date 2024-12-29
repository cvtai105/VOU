using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Exceptions;
using Application.Services.GameServices.Contract;
using Application.Services.GameServices.QuizzGameService;
using Application.Services.GameServices.ShakeGameServices;

namespace Application.Services.GameServices.Converter;

public class CreateGameParamsConverter  : JsonConverter<CreateGameParamsBase>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeof(CreateGameParamsBase).IsAssignableFrom(typeToConvert);
    }

    public override CreateGameParamsBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDoc = JsonDocument.ParseValue(ref reader))
        {
            //if the property isn't there, let it blow up
            switch (jsonDoc.RootElement.GetProperty("type").GetString())
            {
                case "Shake":
                    return jsonDoc.RootElement.Deserialize<CreateShakeGameParams>(options) ?? throw new DeserializeCreateGameParamsException("");
                case "Quiz":
                    return jsonDoc.RootElement.Deserialize<CreateQuizzGameParams>(options) ?? throw new DeserializeCreateGameParamsException("");
                //warning: If you're not using the JsonConverter attribute approach,
                //make a copy of options without this converter
                default:
                    throw new JsonException("'Type' doesn't match a known derived type");
            }

        }
    }

    public override void Write(Utf8JsonWriter writer, CreateGameParamsBase person, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)person, options);
        //warning: If you're not using the JsonConverter attribute approach,
        //make a copy of options without this converter
    }
}