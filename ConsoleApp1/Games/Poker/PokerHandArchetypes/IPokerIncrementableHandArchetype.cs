﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandArchetypes
{
    interface IPokerIncrementableHandArchetype : IPokerHandArchetype, IPokerIncrementable
    {
        //only serves to combine the two inherited interfaces
    }
}
