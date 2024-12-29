using System.Text.Json.Serialization;
using Application.Helpers.Converter;

namespace Application.DTOs.GameDTOs
{
    [JsonConverter(typeof(CreateGameParamsConverter))]
    public abstract class CreateGameParamsBase
    {
        public Guid GamePrototypeId { get; set; }

        [JsonIgnore]
        public Guid EventId { get; set; }
        public string Type { get; set; } =  null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    internal partial class GameParamsConverter
    {
    }
}