using System.Text.Json.Serialization;
using Domain.Entities;

namespace Application.DTOs.GameDTOs
{
    public class GetRewardRequest
    {
        public Guid GameId { get; set; }   
        public string GameType { get; set; } = null!;
        [JsonIgnore]
        public Guid PlayerId { get; set; }
    }
}