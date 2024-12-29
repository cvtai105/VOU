namespace Application.Interfaces.GameBehaviors
{
    public interface IGameBehaviorsProviderFactory
    {
        IGameBehaviorsProvider GetGameBehavior(string gameType);
    }
}