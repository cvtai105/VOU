using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.GameServices.Contract
{
    public abstract class CreateGameParamsAbstract
    {
        public Guid GamePrototypeId { get; set; }
        public string GameType { get; set; } =  null!;
    }
}