using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.BlackJack.Output;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.Games.BlackJack.Hands
{
    class BlackJackPlayerHand : AbstractBlackJackHand
    {
        public BlackJackPlayerHand(List<ICard> passedStartingHand = null) : base(passedStartingHand)
        {
            //runs the abstract parent class's construtor, passing it the optional starting hand
        }

        public void EvaluateAces(ConsoleHandler passedConsoleHandler)
        {
            const int AceHighChoice = 11;

            const int AceLowChoice = 1;

            handValue = GetHandValue();

            int numberOfAces = acesList.Count();

            int numberOfUnEvaluatedAces = numberOfAces;

            for(int i = 0; i < numberOfAces; i++)
            {
                FaceCard currentAce = acesList[i];

                string currentAceSuit = currentAce.getSuit();

                numberOfUnEvaluatedAces--;

                int input = passedConsoleHandler.AceValueMenu(numberOfUnEvaluatedAces, currentAceSuit);

                if (input == AceHighChoice)
                {
                    handValue -= AceLowChoice;

                    handValue += AceHighChoice;
                }
            }

            acesList.Clear();
        }

        public override List<string[]> GetHandDisplays()
        {
            List<string[]> handDisplays = new List<string[]>();

            for (int i = 0; i < hand.Count; i++)
            {
                ICard currentCard = hand[i];

                string[] currentCardDisplay = currentCard.getDisplay();

                handDisplays.Add(currentCardDisplay);
            }

            return handDisplays;
        }
    }
}
