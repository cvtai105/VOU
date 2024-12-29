using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Services.GamePrototypeServices
{
    public interface IGamePrototypeServices
    {
        Task<bool> UpdateGamePrototypeStatusAsync(Guid gamePrototypeId, string status);
        Task<List<GamePrototype>> GetActiveGamePrototypesAsync ();
        Task<List<GamePrototype>> GetGamePrototypesAsync();
    }
}