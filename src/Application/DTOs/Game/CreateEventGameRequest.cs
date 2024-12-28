using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.GameServices.Contract;

namespace Application.DTOs.Game
{
    public class CreateEventGameRequest
    {
        public Guid? BrandId { get; set; }
        public Guid EventId { get; set; }
        public List<CreateGameParamsAbstract> CreateEventGameParams { get; set; } =[];
    }
}