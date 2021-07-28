using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Administration;
using GameCollection.SharedCode.CardGames.DisplayMaking;
using GameCollection.SharedCode.CardGames.Deck;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.Games.BlackJack
{
    class BlackJackFactory : IGameFactory
    {
        string[] optionsList;

        public BlackJackFactory()
        {
            optionsList = new string[]
            {
                "Classic BlackJack",
                "Quit"
            };
        }

        public string[] getOptionsList()
        {
            return optionsList;
        }

        public IGameInterface SelectGame(string input)
        {
            return SelectGame(Convert.ToInt32(input));
        }

        public IGameInterface SelectGame(int input)
        {
            if(input == 1)
            {
                string[] cardTypes = new string[]
                {
                    "Ace",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8",
                    "9",
                    "10",
                    "Jack",
                    "Queen",
                    "King"
                };

                string[] cardSuits = new string[]
                {
                    "Clubs",
                    "Spades",
                    "Diamonds",
                    "Hearts"
                };

                string[] cardFrame = new string[]
                {
                    " ________ ",
                    "|X       |",
                    "|        |",
                    "|   T    |",
                    "|        |",
                    "|_______X|"
                };

                string[] cardBackDisplay = new string[]
                {
                    " ________ ",
                    "|X  XX  X|",
                    "|X  XX  X|",
                    "|X  XX  X|",
                    "|X  XX  X|",
                    "|X__XX__X|"
                };

                const char TypeSurrogate = 'T';

                const char SuitSurrogate = 'X';

                ClassicDisplayMaker displayMaker = new ClassicDisplayMaker(cardFrame, SuitSurrogate, TypeSurrogate);

                ClassicDeckMaker deckMaker = new ClassicDeckMaker(cardTypes, cardSuits, displayMaker);

                List<ICard> cardList = deckMaker.GetDeck();

                ClassicDeckOfCards<ICard> Deck = new ClassicDeckOfCards<ICard>(cardList, cardBackDisplay);

                BlackJack ClassicBlackJack = new BlackJack(Deck);

                return ClassicBlackJack;
            }
            else
            {
                return null;
            }
        }
    }
}
