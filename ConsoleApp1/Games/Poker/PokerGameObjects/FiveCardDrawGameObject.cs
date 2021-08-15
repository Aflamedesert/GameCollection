using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PlayingEntities;
using GameCollection.SharedCode.CardGames.Deck;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHand;
using GameCollection.Games.Poker.PokerHandSorting;
using GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.Betting.PlayerBetter;
using GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.Betting.GameBetter;
using GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.State;

namespace GameCollection.Games.Poker.PokerGameObjects
{
    public class FiveCardDrawGameObject : IPokerGameObject
    {
        List<PlayerPackage> playerObjects;

        IGameBetter pot;

        IDeck<IPokerCard> deck;

        IPokerHandSorter sorter;

        int startingChips;

        int anteAmount;

        public FiveCardDrawGameObject(IDeck<IPokerCard> passedDeck, IPokerHandSorter passedSorter, int passedStartingChips, int passedAnteAmount)
        {
            playerObjects = new List<PlayerPackage>();

            pot = new ClassicGameBetter();

            deck = passedDeck;

            sorter = passedSorter;

            startingChips = passedStartingChips;

            anteAmount = passedAnteAmount;
        }

        public void LinkPlayerToStateObject(List<IPlayingEntity> passedPlayers)
        {
            foreach(IPlayingEntity player in passedPlayers)
            {
                LinkPlayerToStateObject(player);
            }
        }

        public void LinkPlayerToStateObject(IPlayingEntity passedPlayer)
        {
            if(passedPlayer.HasStateObject() == false)
            {
                IPokerHand newHand = new ClassicPokerHand(sorter);

                IPlayerBetter newPlayerBetter = new ClassicPlayerBetter(pot, startingChips, anteAmount);

                IPlayerState newStateObject = new ClassicPlayerState(deck, newHand, newPlayerBetter);

                passedPlayer.SetStateObject(newStateObject);

                PlayerPackage newPlayerPackage = new PlayerPackage(passedPlayer, newStateObject, newPlayerBetter);

                playerObjects.Add(newPlayerPackage);
            }
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        private void GameLoop()
        {

        }
    }
}
