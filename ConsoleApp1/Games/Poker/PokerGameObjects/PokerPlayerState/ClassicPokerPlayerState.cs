using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PlayingEntities;
using GameCollection.Games.Poker.PokerHand.PokerHands;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerState
{
    public class ClassicPokerPlayerState : IClassicPokerPlayerState
    {
        IPlayingEntity playingEntity;

        IPokerHand pokerHand;

        bool HasFolded;

        public ClassicPokerPlayerState(IPlayingEntity passedPlayingEntity, IPokerHand passedPokerHand)
        {
            playingEntity = passedPlayingEntity;

            pokerHand = passedPokerHand;

            HasFolded = false;
        }

        public void AddChips(int passedAmount)
        {
            playingEntity.AddChips(passedAmount);
        }

        public void AddToHand(IPokerCard passedCard)
        {
            pokerHand.Add(passedCard);
        }

        public void AddToHand(List<IPokerCard> passedCards)
        {
            pokerHand.Add(passedCards);
        }

        public List<IPokerCard> EmptyHand()
        {
            return pokerHand.EmptyHand();
        }

        public void Fold()
        {
            HasFolded = true;
        }

        public List<IPokerCard> GetPlayerCards()
        {
            return pokerHand.GetPokerHand();
        }

        public int GetPlayerChipAmount()
        {
            return playingEntity.GetChipAmount();
        }

        public string GetPlayerName()
        {
            return playingEntity.GetName();
        }

        public bool HasPlayerFolded()
        {
            return HasFolded;
        }

        public void RemoveChips(int passedAmount)
        {
            playingEntity.RemoveChips(passedAmount);
        }

        public IPokerCard RemoveFromHand(IPokerCard passedCard)
        {
            return pokerHand.Remove(passedCard);
        }

        public List<IPokerCard> RemoveFromHand(List<IPokerCard> passedCards)
        {
            return pokerHand.Remove(passedCards);
        }

        public IPokerCard RemoveFromHand(string passedCardType, string passedCardSuit)
        {
            return pokerHand.Remove(passedCardType, passedCardSuit);
        }

        public List<IPokerCard> RemoveFromHand(List<(string, string)> passedCardSignatures)
        {
            return pokerHand.Remove(passedCardSignatures);
        }
    }
}
