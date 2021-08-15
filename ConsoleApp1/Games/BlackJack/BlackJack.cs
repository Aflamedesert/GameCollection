using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.BlackJack.Hands;
using GameCollection.Games.BlackJack.Output;
using GameCollection.Games.BlackJack.Input;
using GameCollection.SharedCode.CardGames.Deck;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.Games.BlackJack
{
    public class BlackJack : IGameInterface
    {
        const int BustLimit = 21;

        IDeck<ICard> deck;

        BlackJackPlayerHand playerHand;

        BlackJackDealerHand dealerHand;

        ConsoleHandler consoleHandler;

        bool isPlaying;

        public BlackJack(IDeck<ICard> passedDeck)
        {
            deck = passedDeck;

            string[] cardBackDisplay = deck.GetCardBackDisplay();

            playerHand = new BlackJackPlayerHand();

            dealerHand = new BlackJackDealerHand(cardBackDisplay);

            InputHandler inputHandler = new InputHandler();

            OutputHandler outputHandler = new OutputHandler();

            DisplayHandler displayHandler = new DisplayHandler(cardBackDisplay, playerHand, dealerHand);

            consoleHandler = new ConsoleHandler(displayHandler, inputHandler, outputHandler);
        }

        public void Play()
        {
            GameLoop();
        }

        private void Restart()
        {
            GameLoop();
        }

        private void Quit()
        {
            consoleHandler.QuitResponse();
            isPlaying = false;
        }

        private void GameLoop()
        {
            int score = 500;

            isPlaying = true;

            consoleHandler.OpeningResponse();

            while((score > 0) && (isPlaying == true))
            {
                score = PlayGame(score);

                if(score > 0)
                {
                    string input;

                    input = consoleHandler.PlayAgainMenu(score);

                    if (input == "2")
                    {
                        Quit();
                    }
                }
                else
                {
                    consoleHandler.GameOverResponse();
                }
            }
        }

        private int PlayGame(int score)
        {
            if (playerHand.isEmpty() == false)
            {
                deck.Discard(playerHand.DiscardHand());
            }

            if (dealerHand.isEmpty() == false)
            {
                deck.Discard(dealerHand.DiscardHand());
            }

            playerHand.Add(deck.Draw(2));

            dealerHand.Add(deck.Draw(2));

            score = PlayRound(score, playerHand, dealerHand);

            return score;
        }

        private int PlayRound(int passedScore, BlackJackPlayerHand passedPlayerHand, BlackJackDealerHand passedDealerHand)
        {
            const int dealerDrawLimit = 17;

            bool isBusted = false;

            bool isStanded = false;

            int bet = Bet(passedScore);

            while ((isBusted == false) && (isStanded == false))
            {
                string input = consoleHandler.RoundMenu(passedScore);

                if (input == "1")
                {
                    Hit(passedPlayerHand);
                }
                else if (input == "2")
                {
                    isStanded = true;
                }

                if (playerHand.GetHandValue() > BustLimit)
                {
                    isBusted = true;
                }
            }

            if ((passedDealerHand.HasAce()) && (passedDealerHand.GetHandValue() < BustLimit))
            {
                passedDealerHand.EvaluateAces();
            }

            dealerHand.ShowFullHand();
            FinalDealerDraw(dealerDrawLimit);
            consoleHandler.DisplayGame();

            if ((passedPlayerHand.HasAce()) && (passedPlayerHand.GetHandValue() < BustLimit))
            {
                passedPlayerHand.EvaluateAces(consoleHandler);
            }
            
            int dealerHandValue = passedDealerHand.GetHandValue();
            int playerHandValue = passedPlayerHand.GetHandValue();

            passedScore = HandleResults(passedScore, bet, playerHandValue, dealerHandValue);

            dealerHand.HideHand();

            return passedScore;
        }

        private int HandleResults(int passedScore, int passedBet, int passedPlayerHandValue, int passedDealerHandValue)
        {
            int victoryAmount = passedScore + passedBet;

            int lossAmount = passedScore - passedBet;

            int blackJackAmount = passedScore + passedBet * 2;

            if ((passedDealerHandValue > BustLimit) && (passedPlayerHandValue > BustLimit))
            {
                consoleHandler.ShowResults("TieBust");
                return passedScore;
            }
            else if (passedPlayerHandValue == passedDealerHandValue)
            {
                consoleHandler.ShowResults("Tie");
                return passedScore;
            }
            else if (passedDealerHandValue > BustLimit)
            {
                consoleHandler.ShowResults("DealerBust");
                return victoryAmount;
            }
            else if (passedPlayerHandValue > BustLimit)
            {
                consoleHandler.ShowResults("PlayerBust");
                return lossAmount;
            }
            else if (passedPlayerHandValue == BustLimit)
            {
                consoleHandler.ShowResults("BlackJack");
                return blackJackAmount;
            }
            
            else if (passedDealerHandValue < passedPlayerHandValue)
            {
                consoleHandler.ShowResults("BeatDealer");
                return victoryAmount;
            }
            else
            {
                consoleHandler.ShowResults("LoseToDealer");
                return lossAmount;
            }
        }

        private void FinalDealerDraw(int passedLimit)
        {
            int dealerHandValue = dealerHand.GetHandValue();

            while(dealerHandValue < passedLimit)
            {
                ICard drawnCard =  Hit(dealerHand);

                string drawnCardType = drawnCard.getType();

                string drawnCardSuit = drawnCard.getSuit();

                consoleHandler.DealerDrawResponse(drawnCardType, drawnCardSuit);

                dealerHandValue = dealerHand.GetHandValue();
            }
        }

        private int Bet(int passedScore)
        {
            const int LowBetLimit = 10;

            int finalBet = consoleHandler.BettingMenu(passedScore, LowBetLimit);

            return finalBet;
        }

        private ICard Hit(IBlackJackHand passedHand)
        {
            ICard drawnCard = deck.Draw();

            passedHand.Add(drawnCard);

            return drawnCard;
        }
    }
}
