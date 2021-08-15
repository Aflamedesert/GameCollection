using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.Games.BlackJack.Hands
{
    public class BlackJackDealerHand : AbstractBlackJackHand
    {
        bool fullHandShown;

        string[] cardBackDisplay;

        public BlackJackDealerHand(string[] passedDisplayBack, List<ICard> passedStartingHand = null) : base(passedStartingHand)
        {
            cardBackDisplay = passedDisplayBack;

            fullHandShown = false;
        }

        public void EvaluateAces()
        {
            int numberOfAces = acesList.Count;

            if(numberOfAces > 0)
            {
                const int AceHighValue = 11;

                const int AceLowValue = 1;

                const int BustLimit = 21;

                int currentHandValue = GetHandValue();

                currentHandValue = RemoveAceSurrogates(currentHandValue, AceLowValue);

                int lowestPossibleAddition = AceLowValue * numberOfAces;

                int lowestPossibleOutcome = currentHandValue + lowestPossibleAddition;

                if (lowestPossibleOutcome >= BustLimit)
                {
                    currentHandValue += lowestPossibleAddition;
                }
                else
                {
                    int currentLowestAddition = lowestPossibleAddition;

                    for (int i = 0; i < numberOfAces; i++)
                    {
                        currentLowestAddition -= AceLowValue;

                        int currentLowHandValue = currentLowestAddition + currentHandValue;

                        int currentTestValue = currentLowHandValue + AceHighValue;

                        if ((currentTestValue) < BustLimit)
                        {
                            currentHandValue = currentTestValue;
                        }
                        else
                        {
                            currentHandValue = currentLowHandValue + AceLowValue;
                            break;
                        }
                    }
                }

                handValue = currentHandValue;

                acesList.Clear();
            }
        }

        private int RemoveAceSurrogates(int passedHandValue, int passedAceSurrogateValue)
        {
            int numberOfAces = acesList.Count;

            for(int i = 0; i < numberOfAces; i++)
            {
                passedHandValue -= passedAceSurrogateValue;
            }

            return passedHandValue;
        }

        public override List<string[]> GetHandDisplays()
        {
            const int firstIndex = 0;

            List<string[]> handDisplays = new List<string[]>();

            for (int i = firstIndex; i < hand.Count; i++)
            {
                ICard currentCard = hand[i];

                string[] currentCardDisplay;

                if ((i == firstIndex) && (fullHandShown == false))
                {
                    currentCardDisplay = cardBackDisplay;
                }
                else
                {
                    currentCardDisplay = currentCard.getDisplay();
                }

                handDisplays.Add(currentCardDisplay);
            }

            return handDisplays;
        }

        public void ShowFullHand()
        {
            fullHandShown = true;
        }

        public void HideHand()
        {
            fullHandShown = false;
        }
    }
}
