using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.BettingLoopIncrementors.BettingLoopActions;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.BettingLoopIncrementors
{
    public class ClassicLoopIncrementor<T> : ILoopIncrementor<T>
    {
        List<T> objectList;

        int index;

        int numberOfIncrementsLeft;

        public ClassicLoopIncrementor(List<T> passedObjectList, int passedStartingIndex = 0)
        {
            objectList = passedObjectList;

            index = passedStartingIndex;

            numberOfIncrementsLeft = objectList.Count - 1;
        }

        public int GetCurrentIndex()
        {
            return index;
        }

        public T GetCurrentObject()
        {
            T currentObject = objectList[index];

            return currentObject;
        }

        public void Increment()
        {
            int numberOfObjectsInList = objectList.Count;

            if(index < numberOfObjectsInList)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        public bool isFinished()
        {
            if(numberOfIncrementsLeft > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
