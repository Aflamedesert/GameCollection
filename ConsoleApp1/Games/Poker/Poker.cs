using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Deck;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker
{
    class Poker : IGameInterface
    {
        IDeck<IPokerCard> deck;

        public Poker(IDeck<IPokerCard> passedDeck)
        {
            deck = passedDeck;
        }

        public void Play()
        {
            int cash = 500;

            GameLoop(cash);
        }

        private void GameLoop(int passedCash)
        {

        }

        /*private int PlayPokerGame(int passedCash)
        {
            
        }*/
    }
}
