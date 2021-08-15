using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.DeckMakingBehavior.SetupDeckBehavior
{
    public class ClassicSetupDeckBehavior : ISetupDeckBehavior
    {
        string[] cardTypes;

        string[] cardSuits;

        string[,] deckSetup;

        public ClassicSetupDeckBehavior(string[] passedCardTypes, string[] passedCardSuits)
        {
            cardTypes = passedCardTypes;
            cardSuits = passedCardSuits;

            deckSetup = null;
        }

        public string[,] SetupDeck()
        {
            if(deckSetup == null)
            {
                deckSetup = CreateNewDeckSetup(cardTypes, cardSuits);
            }

            return deckSetup;
        }

        public string[,] CreateNewDeckSetup(string[] passedCardTypes, string[] passedCardSuits)
        {
            const int cardTypeIndex = 0;

            const int cardSuitIndex = 1;

            const int cardAttributeNumber = 2;

            int rawCardNumber = passedCardTypes.Length * passedCardSuits.Length;

            string[,] deckStrings = new string[rawCardNumber, cardAttributeNumber];

            int currentIndex = 0;

            for (int i = 0; i < passedCardTypes.Length; i++)
            {
                string cardType = passedCardTypes[i];

                for (int x = 0; x < passedCardSuits.Length; x++)
                {
                    string cardSuit = passedCardSuits[x];

                    deckStrings[currentIndex, cardTypeIndex] = cardType;
                    deckStrings[currentIndex, cardSuitIndex] = cardSuit;
                    currentIndex++;
                }
            }

            return deckStrings;
        }
    }
}
