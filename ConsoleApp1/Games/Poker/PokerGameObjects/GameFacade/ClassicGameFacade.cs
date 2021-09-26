using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PlayingEntities;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerGameState;
using GameCollection.SharedCode.CardGames.Deck;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerGameObjects.GameBetting;
using GameCollection.Games.Poker.PokerHand.PokerHands;
using GameCollection.Games.Poker.PokerHand;
using GameCollection.Games.Poker.PokerGameEvaluation;
using GameCollection.Games.Poker.PokerGameObjects.PokerGameCore;
using GameCollection.Games.Poker.PokerGameObjects.StandardMessages;

namespace GameCollection.Games.Poker.PokerGameObjects.GameFacade
{
    public delegate IHumanPlayerGameInterface HumanPlayerGameStateFactoryMethod();

    public delegate IArtificialPlayerGameInterface ArtificialPlayerGameStateFactoryMethod();

    public class ClassicGameFacade : IPokerGameFacade
    {
        List<IPlayingEntity> players;

        IDeck<IPokerCard> deck;

        IPokerHandFactory handFactory;

        IPokerGameCore gameCore;

        IPokerGameBettingSystem gameBettingSystem;

        IPokerGameEvaluator gameEvaluator;

        IGameFacadeMessager messager;

        public ClassicGameFacade(List<IPlayingEntity> passedPlayers,
            IDeck<IPokerCard> passedPokerDeck, IPokerHandFactory passedPokerHandFactory,
            IPokerGameCore passedGameCore, IPokerGameBettingSystem passedGameBettingSystem,
            IPokerGameEvaluator passedGameEvaluator, IGameFacadeMessager passedMessager)
        {
            players = passedPlayers;

            deck = passedPokerDeck;

            handFactory = passedPokerHandFactory;

            gameCore = passedGameCore;

            gameBettingSystem = passedGameBettingSystem;

            gameEvaluator = passedGameEvaluator;

            messager = passedMessager;

            SetupPlayerGameStates(passedPlayers, CreateHumanGameInterface, CreateArtificialGameInterface); // temporary solution, probably gonna change this later
        }

        private void SetupPlayerGameStates(List<IPlayingEntity> passedPlayers,
            HumanPlayerGameStateFactoryMethod humanFactoryMethod,
            ArtificialPlayerGameStateFactoryMethod artificialFactoryMethod)
        //temporary solution, probably gonna change this later
        {
            if (passedPlayers == null)
            {
                throw new ArgumentNullException("passedPlayers", "passedPlayers cannot equal null");
            }

            int numberOfPlayers = passedPlayers.Count;

            if (numberOfPlayers < 1)
            {
                throw new ArgumentOutOfRangeException("passedPlayers", "passedPlayers must have at least one element");
            }

            foreach (IPlayingEntity player in passedPlayers)
            {
                if (player is IHumanPlayer)
                {
                    IHumanPlayer humanPlayer = player as IHumanPlayer;

                    humanPlayer.SetGameInterface(humanFactoryMethod());
                }
                else if (player is IArtificialPlayer)
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

        public IEndGameOption Play()
        {
            messager.WelcomeMessage();

            AnteUp(players);

            List<IPlayingEntity> possibleWinners = PlayGame();

            HandleResults(possibleWinners);

            IEndGameOption endGameOption = messager.EndGameOptionsMessage();

            return endGameOption;
        }

        private void AnteUp(List<IPlayingEntity> passedPlayers)
        {
            gameBettingSystem.Ante(passedPlayers);
        }

        private List<IPlayingEntity> PlayGame()
        {
            return gameCore.PlayGame(players);
        }

        private void HandleResults(List<IPlayingEntity> passedPlayers)
        {
            IPlayingEntity winner = gameEvaluator.GetWinner(passedPlayers);

            int wonChips = gameBettingSystem.EmptyPot();

            string winnerName = winner.GetName();

            messager.WinnerMessage(winnerName, wonChips);
        }
    }
}
