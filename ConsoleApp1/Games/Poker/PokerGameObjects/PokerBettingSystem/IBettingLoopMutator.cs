namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem
{
    public interface IBettingLoopMutator
    {
        void ChangeToCallableLoop();
        void ChangeToCheckableLoop();
    }
}