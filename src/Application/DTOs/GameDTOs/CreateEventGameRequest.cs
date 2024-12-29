using System.Text.Json.Serialization;

namespace Application.DTOs.GameDTOs
{
    public class CreateEventGameRequest
    {
        [JsonIgnore]
        public Guid? UserId { get; set; }
        public Guid EventId { get; set; }
        public List<CreateGameParamsBase> CreateEventGameParams { get; set; } =[];
    }
}