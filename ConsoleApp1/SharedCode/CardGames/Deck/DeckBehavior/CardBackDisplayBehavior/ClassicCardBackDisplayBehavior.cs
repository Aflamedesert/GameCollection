using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.DeckBehavior.CardBackDisplayBehavior
{
    public class ClassicCardBackDisplayBehavior : ICardBackDisplayBehavior
    {
        string[] cardBackDisplay;

        public ClassicCardBackDisplayBehavior(string[] passedCardBackDisplay)
        {
            cardBackDisplay = passedCardBackDisplay;
        }

        public string[] getCardBackDisplay()
        {
            return cardBackDisplay;
        }
    }
}
