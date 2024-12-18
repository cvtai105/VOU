using Domain.Entities;
using MediatR;

namespace Domain.Events
{
    public class GameEndEvent : INotification
    {
        public GameEndEvent(Game game)
        {
            Obj = game;
        }
        public Game Obj { get; }
    }
}