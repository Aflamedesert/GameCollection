using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.DisplayMaking;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.SharedCode.CardGames.Deck.DeckMakingBehavior.InstanciateDeckSetupBehavior
{
    class ClassicDeckSetupInstantiationBehavior : IDeckSetupInstantiationBehavior<ICard>
    {
        IDisplayMaker displayMaker;

        public ClassicDeckSetupInstantiationBehavior(IDisplayMaker passedDisplayMaker)
        {
            displayMaker = passedDisplayMaker;
        }

        public List<ICard> InstanciateDeckSetup(string[,] deckSetup)
        {
            List<ICard> Deck = new List<ICard>();

            int deckSetupLength = deckSetup.GetLength(0);

            for (int i = 0; i < deckSetupLength; i++)
            {
                string cardSuit = deckSetup[i, Constants.CardSuitIndex];

                string cardType = deckSetup[i, Constants.CardTypeIndex];

                string[] cardDisplay = displayMaker.GetDisplay(cardSuit, cardType);

                if (int.TryParse(cardType, out int convertedCardNumber))
                {
                    Deck.Add(new NumberCard(convertedCardNumber, cardSuit, cardDisplay));
                }
                else
                {
                    Deck.Add(new FaceCard(cardType, cardSuit, cardDisplay));
                }
            }

            return Deck;
        }
    }
}
