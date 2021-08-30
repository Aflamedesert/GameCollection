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

namespace GameCollection.Tests.DataFactory
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

        public static List<IPokerCard> GetRoyalFlush2()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerFaceCard("Ace", 14, "Diamonds", null),
                new PokerFaceCard("King", 13, "Diamonds", null),
                new PokerFaceCard("Queen", 12, "Diamonds", null),
                new PokerFaceCard("Jack", 11, "Diamonds", null),
                new PokerNumberCard(10, "Diamonds", null)
            };

            return cardList;
        }

        public static List<IPokerCard> GetRoyalFlush3()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerFaceCard("Ace", 14, "Spades", null),
                new PokerFaceCard("King", 13, "Spades", null),
                new PokerFaceCard("Queen", 12, "Spades", null),
                new PokerFaceCard("Jack", 11, "Spades", null),
                new PokerNumberCard(10, "Spades", null)
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

        public static List<IPokerCard> GetStraightFlush2()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(8, "Spades", null),
                new PokerNumberCard(7, "Spades", null),
                new PokerNumberCard(6, "Spades", null),
                new PokerNumberCard(5, "Spades", null),
                new PokerNumberCard(4, "Spades", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetStraightFlush3()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerFaceCard("Queen", 12, "Hearts", null),
                new PokerFaceCard("Jack", 11, "Hearts", null),
                new PokerNumberCard(10, "Hearts", null),
                new PokerNumberCard(9, "Hearts", null),
                new PokerNumberCard(8, "Hearts", null)
            };

            return cardList;
        }

        public static List<IPokerCard> GetFourOfAKind()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(9, "Hearts", null),
                new PokerNumberCard(9, "Diamonds", null),
                new PokerNumberCard(9, "Spades", null),
                new PokerNumberCard(9, "Clubs", null),
                new PokerNumberCard(6, "Hearts", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetFourOfAKind2()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(7, "Hearts", null),
                new PokerNumberCard(7, "Diamonds", null),
                new PokerNumberCard(7, "Spades", null),
                new PokerNumberCard(7, "Clubs", null),
                new PokerNumberCard(6, "Hearts", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetFourOfAKind3()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerFaceCard("Queen", 12, "Hearts", null),
                new PokerNumberCard(10, "Hearts", null),
                new PokerNumberCard(10, "Diamonds", null),
                new PokerNumberCard(10, "Clubs", null),
                new PokerNumberCard(10, "Spades", null)
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

        public static List<IPokerCard> GetFullHouse2()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(6, "Hearts", null),
                new PokerNumberCard(6, "Clubs", null),
                new PokerNumberCard(6, "Spades", null),
                new PokerNumberCard(4, "Hearts", null),
                new PokerNumberCard(4, "Clubs", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetFullHouse3()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerFaceCard("Jack", 11, "Spades", null),
                new PokerFaceCard("Jack", 11, "Hearts", null),
                new PokerNumberCard(10, "Diamonds", null),
                new PokerNumberCard(10, "Clubs", null),
                new PokerNumberCard(10, "Spades", null)
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

        public static List<IPokerCard> GetFlush2()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(5, "Hearts", null),
                new PokerNumberCard(2, "Hearts", null),
                new PokerNumberCard(7, "Hearts", null),
                new PokerNumberCard(6, "Hearts", null),
                new PokerNumberCard(4, "Hearts", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetFlush3()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerFaceCard("Queen", 12, "Hearts", null),
                new PokerFaceCard("Jack", 11, "Hearts", null),
                new PokerNumberCard(10, "Hearts", null),
                new PokerNumberCard(5, "Hearts", null),
                new PokerNumberCard(3, "Hearts", null)
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

        public static List<IPokerCard> GetStraight2()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(7, "Hearts", null),
                new PokerNumberCard(6, "Clubs", null),
                new PokerNumberCard(5, "Clubs", null),
                new PokerNumberCard(4, "Diamonds", null),
                new PokerNumberCard(3, "Diamonds", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetStraight3()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerFaceCard("Queen", 12, "Hearts", null),
                new PokerFaceCard("Jack", 11, "Hearts", null),
                new PokerNumberCard(10, "Diamonds", null),
                new PokerNumberCard(9, "Clubs", null),
                new PokerNumberCard(8, "Clubs", null)
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

        public static List<IPokerCard> GetThreeOfAKind2()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(5, "Hearts", null),
                new PokerNumberCard(5, "Clubs", null),
                new PokerNumberCard(5, "Diamonds", null),
                new PokerNumberCard(7, "Diamonds", null),
                new PokerNumberCard(6, "Diamonds", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetThreeOfAKind3()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerFaceCard("King", 13, "Diamonds", null),
                new PokerFaceCard("King", 13, "Clubs", null),
                new PokerFaceCard("King", 13, "Hearts", null),
                new PokerFaceCard("Jack", 11, "Hearts", null),
                new PokerNumberCard(5, "Hearts", null),
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

        public static List<IPokerCard> GetTwoPair2()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(5, "Hearts", null),
                new PokerNumberCard(5, "Clubs", null),
                new PokerNumberCard(3, "Clubs", null),
                new PokerNumberCard(3, "Diamonds", null),
                new PokerNumberCard(6, "Diamonds", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetTwoPair3()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerFaceCard("Jack", 11, "Clubs", null),
                new PokerFaceCard("King", 13, "Clubs", null),
                new PokerFaceCard("King", 13, "Hearts", null),
                new PokerFaceCard("Jack", 11, "Hearts", null),
                new PokerNumberCard(5, "Hearts", null),
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

        public static List<IPokerCard> GetPair2()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(4, "Hearts", null),
                new PokerNumberCard(4, "Clubs", null),
                new PokerNumberCard(8, "Clubs", null),
                new PokerNumberCard(7, "Diamonds", null),
                new PokerNumberCard(6, "Diamonds", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetPair3()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerFaceCard("Jack", 11, "Clubs", null),
                new PokerFaceCard("King", 13, "Clubs", null),
                new PokerFaceCard("King", 13, "Hearts", null),
                new PokerNumberCard(3, "Hearts", null),
                new PokerNumberCard(5, "Hearts", null),
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

        public static List<IPokerCard> GetHighCard2()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerNumberCard(3, "Hearts", null),
                new PokerNumberCard(8, "Clubs", null),
                new PokerNumberCard(6, "Clubs", null),
                new PokerNumberCard(4, "Diamonds", null),
                new PokerNumberCard(5, "Diamonds", null),
            };

            return cardList;
        }

        public static List<IPokerCard> GetHighCard3()
        {
            List<IPokerCard> cardList = new List<IPokerCard>()
            {
                new PokerFaceCard("Jack", 11, "Clubs", null),
                new PokerFaceCard("King", 13, "Clubs", null),
                new PokerFaceCard("Queen", 12, "Hearts", null),
                new PokerNumberCard(3, "Hearts", null),
                new PokerNumberCard(5, "Hearts", null),
            };

            return cardList;
        }
    }
}
