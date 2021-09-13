using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PlayingEntities;
using GameCollection.Games.Poker.PokerGameObjects.PokerTurnSystem;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerGameState;
using GameCollection.SharedCode.CardGames.Deck;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerGameObjects.GameBetting;
using GameCollection.Games.Poker.PokerHand.PokerHands;
using GameCollection.Games.Poker.PokerHand;

namespace GameCollection.Games.Poker.PokerGameObjects.GameObjects
{
    public delegate IHumanPlayerGameInterface HumanPlayerGameStateFactoryMethod();

    public delegate IArtificialPlayerGameInterface ArtificialPlayerGameStateFactoryMethod();

    public class FiveCardDrawGameObject : IPokerGameObject
    {
        List<IPlayingEntity> players;

        IDeck<IPokerCard> deck;

        IPokerHandFactory handFactory;

        IPokerTurnSystem turnSystem;

        IPokerGameBettingSystem gameBettingSystem;

        public FiveCardDrawGameObject(List<IPlayingEntity> passedPlayers, 
            IDeck<IPokerCard> passedPokerDeck, IPokerHandFactory passedPokerHandFactory, IPokerTurnSystem passedTurnSystem, IPokerGameBettingSystem passedGameBettingSystem)
        {
            players = passedPlayers;

            deck = passedPokerDeck;

            handFactory = passedPokerHandFactory;

            turnSystem = passedTurnSystem;

            gameBettingSystem = passedGameBettingSystem;

            SetupPlayerGameStates(passedPlayers, CreateHumanGameInterface, CreateArtificialGameInterface); // temporary solution, probably gonna change this later
        }

        private void SetupPlayerGameStates(List<IPlayingEntity> passedPlayers, 
            HumanPlayerGameStateFactoryMethod humanFactoryMethod, 
            ArtificialPlayerGameStateFactoryMethod artificialFactoryMethod)
            //temporary solution, probably gonna change this later
        {
            if(passedPlayers == null)
            {
                throw new ArgumentNullException("passedPlayers", "passedPlayers cannot equal null");
            }

            int numberOfPlayers = passedPlayers.Count;

            if(numberOfPlayers < 1)
            {
                throw new ArgumentOutOfRangeException("passedPlayers", "passedPlayers must have at least one element");
            }

            foreach(IPlayingEntity player in passedPlayers)
            {
                if(player is IHumanPlayer)
                {
                    IHumanPlayer humanPlayer = player as IHumanPlayer;

                    humanPlayer.SetGameInterface(humanFactoryMethod());
                }
                else if(player is IArtificialPlayer)
                {
                    IArtificialPlayer artificialPlayer = player as IArtificialPlayer;

                    artificialPlayer.SetGameInterface(artificialFactoryMethod());
                }
            }
        }

        private IHumanPlayerGameInterface CreateHumanGameInterface()
        {
            IPokerHand hand = handFactory.CreatePokerHandInstance();

            IHumanPlayerBetter better = gameBettingSystem.GetHumanPlayerBetter();

            return new FiveCardDrawHumanPlayerGameInterface(deck, hand, better);
        }

        private IArtificialPlayerGameInterface CreateArtificialGameInterface()
        {
            IPokerHand hand = handFactory.CreatePokerHandInstance();

            IArtificialPlayerBetter better = gameBettingSystem.GetArtificialPlayerBetter();

            return new FiveCardDrawArtificialPlayerGameInterface(deck, hand, better);
        }

        public void Play()
        {
            const int numberOfRounds = 2;

            AnteUp(players);

            for(int i = 0; i < numberOfRounds; i++)
            {
                List<IPlayingEntity> remainingPlayers = StartBetting(players);

                PlayTurns(players);
            }
        }

        private void AnteUp(List<IPlayingEntity> passedPlayers)
        {
            gameBettingSystem.Ante(passedPlayers);
        }

        private void StartBetting(List<IPlayingEntity> passedPlayers)
        {
            gameBettingSystem.Bet(passedPlayers);
        }

        private void PlayTurns(List<IPlayingEntity> passedPlayers)
        {
            turnSystem.PlayTurns(passedPlayers);
        }
    }
}
