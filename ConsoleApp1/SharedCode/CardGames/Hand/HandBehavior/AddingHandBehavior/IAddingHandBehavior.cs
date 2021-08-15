using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Hand.HandBehavior.AddingHandBehavior
{
    public interface IAddingHandBehavior<T>
    {
        void Add(List<T> passedCards);
        void Add(T passedCard);
    }
}
