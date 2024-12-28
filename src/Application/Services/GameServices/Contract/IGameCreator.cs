using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.GameServices.Contract
{
    public interface IGameCreator
    {
        Task<bool> CreateGameAsync(CreateGameParamsAbstract createGameParams);
    }
}