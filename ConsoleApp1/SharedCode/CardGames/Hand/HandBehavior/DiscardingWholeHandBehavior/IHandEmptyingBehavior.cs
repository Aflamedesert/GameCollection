﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Hand.HandBehavior.DiscardingWholeHandBehavior
{
    interface IHandEmptyingBehavior<T>
    {
        List<T> EmptyHand();
    }
}
