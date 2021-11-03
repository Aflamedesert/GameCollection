using GameCollection.Games.Poker.PlayingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem;
using GameCollection.Games.Poker.PokerGameObjects.PokerCardActionSystem;
using GameCollection.Games.Poker.PokerGameEvaluation;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;
using GameCollection.Games.Poker.PokerGameObjects.PokerDisplay;
using GameCollection.Games.Poker.PokerGameObjects.PokerPot;
using GameCollection.Games.Poker.PokerGameObjects.PokerAnteHandler;
using GameCollection.Games.Poker.PokerGameObjects.PokerStartingHandHandler;
using GameCollection.Games.Poker.PokerGameObjects.PokerNotificationSystem;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerGameCore
{
    public class ClassicPokerGameCore<T> : IPokerGameCore<T> where T : IGetCardsInHandBehavior, IChipHandlingBehavior, IGetPlayerNameBehavior
    {
        List<T> playersInGame;

        int numberOfRounds;

        IAnteHandler<T> anteHandler;

        IStartingHandHandler<T> startingHandHandler;

        IPokerBettingSystem<T> bettingSystem;

        IPokerCardActionSystem<T> cardActionSystem;

        IPokerGameEvaluator<T> gameEvaluator;

        IPokerDisplay<T> gameDisplay;

        IPokerNotificationSystem standardMessages;

        IPokerPot gamePot;

        public ClassicPokerGameCore(List<T> passedPlayerInterfaces, int passedNumberOfRounds,
            IAnteHandler<T> passedAnteHandler,
            IStartingHandHandler<T> passedStartingHandHandler,
            IPokerBettingSystem<T> passedBettingSystem, 
            IPokerCardActionSystem<T> passedCardActionSystem, 
            IPokerGameEvaluator<T> passedGameEvaluator, 
            IPokerDisplay<T> passedDisplay, 
            IPokerNotificationSystem passedStandardMessages, 
            IPokerPot passedPot)
        {
            playersInGame = passedPlayerInterfaces;

            numberOfRounds = passedNumberOfRounds;

            anteHandler = passedAnteHandler;

            startingHandHandler = passedStartingHandHandler;

            bettingSystem = passedBettingSystem;

            cardActionSystem = passedCardActionSystem;

            gameEvaluator = passedGameEvaluator;

            gameDisplay = passedDisplay;

            standardMessages = passedStandardMessages;

            gamePot = passedPot;
        }

        public void StartGame()
        {
            SetupGame(playersInGame);

            for(int i = 0; i < numberOfRounds; i++)
            {
                int currentRoundNumber = i + 1;

                playersInGame = PlayRound(playersInGame, currentRoundNumber);
            }

            FinalRound(playersInGame);

            List<T> winners = EvaluateResults(playersInGame);

            HandleResults(winners);
        }

        private void SetupGame(List<T> passedPlayers)
        {
            anteHandler.Ante(passedPlayers);

            startingHandHandler.DealStartingHand(passedPlayers);
        }

        private List<T> PlayRound(List<T> passedPlayers, int currentRoundNumber)
        {
            List<T> remainingPlayers;

            if(bettingSystem is ISetCurrentBettingRoundNumberBehavior)
            {
                ISetCurrentBettingRoundNumberBehavior settableBettingSystem = bettingSystem as ISetCurrentBettingRoundNumberBehavior;
                settableBettingSystem.SetCurrentRoundNumber(currentRoundNumber);
            }

            if(cardActionSystem is ISetCurrentCardActionRoundNumberBehavior)
            {
                ISetCurrentCardActionRoundNumberBehavior settableCardActionSystem = cardActionSystem as ISetCurrentCardActionRoundNumberBehavior;
                settableCardActionSystem.SetCurrentRoundNumber(currentRoundNumber);
            }

            remainingPlayers = bettingSystem.ExecuteBettingRound(passedPlayers);

            cardActionSystem.ExecuteCardActionRound(passedPlayers);

            return remainingPlayers;
        }

        private void FinalRound(List<T> passedPlayers)
        {
            bettingSystem.ExecuteBettingRound(passedPlayers);

            gameDisplay.RevealAllPlayers();
        }

        private List<T> EvaluateResults(List<T> passedPlayers)
        {
            List<T> winners;

            winners = gameEvaluator.GetWinner(passedPlayers);

            return winners;
        }

        private void HandleResults(List<T> passedWinningPlayers)
        {
            int numberOfWinners = passedWinningPlayers.Count;

            if(numberOfWinners == 1)
            {
                T winner = passedWinningPlayers[Constants.FirstIndex];

                HandleWin(winner);
            }
            else
            {
                HandleTie(passedWinningPlayers);
            }
        }

        private void HandleWin(T passedWinner)
        {
            int chipsWon = gamePot.EmptyPot();

            passedWinner.AddChipsToPlayer(chipsWon);

            standardMessages.WinnerMessage(passedWinner.GetPlayerName(), chipsWon);
        }

        private void HandleTie(List<T> passedTiedPlayers)
        {
            List<(string playerName, int chipsWon)> outputSignatures = new List<(string playerName, int chipsWon)>();

            int numberOfTiedPlayers = passedTiedPlayers.Count;

            int chipsInPot = gamePot.EmptyPot();

            int dividedChips = chipsInPot / numberOfTiedPlayers;

            foreach(T player in passedTiedPlayers)
            {
                player.AddChipsToPlayer(dividedChips);

                outputSignatures.Add((player.GetPlayerName(), dividedChips));
            }

            standardMessages.TieMessage(outputSignatures);
        }
    }
}
