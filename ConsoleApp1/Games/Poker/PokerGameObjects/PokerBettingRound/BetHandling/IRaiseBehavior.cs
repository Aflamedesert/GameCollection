﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingRound.BetHandling
{
    public interface IRaiseBehavior
    {
        void Raise(int passedRaiseAmount);
    }
}
