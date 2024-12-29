using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Application.Services.GameServices.Contract;

namespace Application.DTOs.Game
{
    public class CreateEventGameRequest
    {
        [JsonIgnore]
        public Guid? UserId { get; set; }
        public Guid EventId { get; set; }
        public List<CreateGameParamsBase> CreateEventGameParams { get; set; } =[];
    }
}