using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Tests.DataFactory
{
    class TestHandPackage
    {
        public List<IPokerCard> RoyalFlush;
        public List<IPokerCard> StraightFlush;
        public List<IPokerCard> FourOfAKind;
        public List<IPokerCard> FullHouse;
        public List<IPokerCard> Flush;
        public List<IPokerCard> Straight;
        public List<IPokerCard> ThreeOfAKind;
        public List<IPokerCard> TwoPair;
        public List<IPokerCard> Pair;
        public List<IPokerCard> HighCard;

        public TestHandPackage(List<IPokerCard> passedRoyalFlush, List<IPokerCard> passedStraightFlush, List<IPokerCard> passedFourOfAKind,
             List<IPokerCard> passedFullHouse, List<IPokerCard> passedFlush, List<IPokerCard> passedStraight, 
             List<IPokerCard> passedThreeOfAKind, List<IPokerCard> passedTwoPair, List<IPokerCard> passedPair, 
             List<IPokerCard> passedHighCard)
        {
            RoyalFlush = passedRoyalFlush;
            StraightFlush = passedStraightFlush;
            FourOfAKind = passedFourOfAKind;
            FullHouse = passedFullHouse;
            Flush = passedFlush;
            Straight = passedStraight;
            ThreeOfAKind = passedThreeOfAKind;
            TwoPair = passedTwoPair;
            Pair = passedPair;
            HighCard = passedHighCard;
        }
    }
}
