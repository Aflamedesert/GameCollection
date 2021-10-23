﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerState
{
    public interface IBettingRoundStateBehavior
    {
        void AddToAmountBet(int passedAmountToBeAdded);
        int GetCurrentAmountBet();
        void ClearState();
    }
}
