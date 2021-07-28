using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.DisplayMaking;
using GameCollection.SharedCode.CardGames.Card;
using GameCollection.SharedCode.CardGames.Deck.DeckMakingBehavior.SetupDeckBehavior;
using GameCollection.SharedCode.CardGames.Deck.DeckMakingBehavior.InstanciateDeckSetupBehavior;

namespace GameCollection.SharedCode.CardGames.Deck
{
    class ClassicDeckMaker : IDeckMaker<ICard>
    {
        ISetupDeckBehavior setupDeckBehavior;

        IDeckSetupInstantiationBehavior<ICard> deckSetupInstantiationBehavior;

        public ClassicDeckMaker(string[] passedCardTypes, string[] passedCardSuits, IDisplayMaker passedDisplayMaker)
        {
            setupDeckBehavior = new ClassicSetupDeckBehavior(passedCardTypes, passedCardSuits);
            deckSetupInstantiationBehavior = new ClassicDeckSetupInstantiationBehavior(passedDisplayMaker);
        }

        public List<ICard> GetDeck()
        {
            string[,] deckSpecifications = setupDeckBehavior.SetupDeck();

            List<ICard> Deck = InstanciateDeckSetup(deckSpecifications);

            return Deck;
        }

        private List<ICard> InstanciateDeckSetup(string[,] deckSetup)
        {
            return deckSetupInstantiationBehavior.InstanciateDeckSetup(deckSetup);
        }
    }
}
