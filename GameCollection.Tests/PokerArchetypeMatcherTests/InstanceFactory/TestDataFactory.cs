using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerFactories;
using GameCollection.Games.Poker.PokerArchetypeHandling;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers;
using GameCollection.Games.Poker.PokerHandPatternChecking;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Tests.PokerArchetypeMatcherTests.InstanceFactory
{
    static class TestDataFactory
    {
        public static List<IPokerCard> GetRoyalFlush()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerFaceCard("Ace", 14, "Hearts", null),
                new PokerFaceCard("King", 13, "Hearts", null),
                new PokerFaceCard("Queen", 12, "Hearts", null),
                new PokerFaceCard("Jack", 11, "Hearts", null),
                new PokerNumberCard(10, "Hearts", null)
            };

            return cardList;
        }

        public static List<IPokerCard> GetStraightFlush()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(10, "Hearts", null),
                new PokerNumberCard(9, "Hearts", null),
                new PokerNumberCard(8, "Hearts", null),
                new PokerNumberCard(7, "Hearts", null),
                new PokerNumberCard(6, "Hearts", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetFourOfAKind()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(10, "Hearts", null),
                new PokerNumberCard(10, "Diamonds", null),
                new PokerNumberCard(10, "Spades", null),
                new PokerNumberCard(10, "Clubs", null),
                new PokerNumberCard(6, "Hearts", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetFullHouse()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(10, "Hearts", null),
                new PokerNumberCard(10, "Clubs", null),
                new PokerNumberCard(10, "Spades", null),
                new PokerNumberCard(3, "Hearts", null),
                new PokerNumberCard(3, "Clubs", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetFlush()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(2, "Hearts", null),
                new PokerNumberCard(7, "Hearts", null),
                new PokerNumberCard(5, "Hearts", null),
                new PokerNumberCard(9, "Hearts", null),
                new PokerNumberCard(3, "Hearts", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetStraight()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(10, "Hearts", null),
                new PokerNumberCard(9, "Clubs", null),
                new PokerNumberCard(8, "Clubs", null),
                new PokerNumberCard(7, "Diamonds", null),
                new PokerNumberCard(6, "Diamonds", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetThreeOfAKind()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(10, "Hearts", null),
                new PokerNumberCard(10, "Clubs", null),
                new PokerNumberCard(10, "Diamonds", null),
                new PokerNumberCard(7, "Diamonds", null),
                new PokerNumberCard(6, "Diamonds", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetTwoPair()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(10, "Hearts", null),
                new PokerNumberCard(10, "Clubs", null),
                new PokerNumberCard(7, "Clubs", null),
                new PokerNumberCard(7, "Diamonds", null),
                new PokerNumberCard(6, "Diamonds", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetPair()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(10, "Hearts", null),
                new PokerNumberCard(10, "Clubs", null),
                new PokerNumberCard(8, "Clubs", null),
                new PokerNumberCard(7, "Diamonds", null),
                new PokerNumberCard(6, "Diamonds", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetHighCard()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(10, "Hearts", null),
                new PokerNumberCard(9, "Clubs", null),
                new PokerNumberCard(7, "Clubs", null),
                new PokerNumberCard(3, "Diamonds", null),
                new PokerNumberCard(2, "Diamonds", null),
            };

            return cardList;
        }
    }
}
