﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerGameState
{
    public interface IDrawBehavior
    {
        void Draw();
        void Draw(int numberOfCardDraws);
    }
}