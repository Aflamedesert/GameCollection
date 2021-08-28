using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.Utilities.Exceptions;

namespace GameCollection.SharedCode.Utilities.HelperClasses.ListHelpers.RemoveSubsetFromList
{
    public class ClassicSubsetRemover : IListSubsetRemover
    {

        public List<T> RemoveSubsetFromList<T>(List<T> passedMainList, List<T> passedSubset) where T : class
        {
            if ((passedMainList == null) || (passedSubset == null))
            {
                throw new ArgumentNullException("ClassicSubsetRemover", "passedMainList or passedSubset is equal to null");
            }

            int numberOfMainListElements = passedMainList.Count;

            int numberOfSubsetElements = passedSubset.Count;

            if ((numberOfMainListElements == 0) || (numberOfSubsetElements == 0))
            {
                throw new ArgumentOutOfRangeException("ClassicSubsetRemover", "passedMainList or passedSubset contains zero elements");
            }

            if (numberOfMainListElements < numberOfSubsetElements)
            {
                throw new UnintendedArgumentSetupException("ClassicSubsetRemover", "passedSubset is greater than passedMainList");
            }

            List<T> mainList = new List<T>(passedMainList);

            List<T> subset = new List<T>(passedSubset);

            foreach (T subsetElement in subset)
            {
                int index = 0;

                while (index < numberOfMainListElements)
                {
                    T currentElement = mainList[index];

                    if (currentElement == subsetElement)
                    {
                        mainList.Remove(subsetElement);
                        numberOfMainListElements--;
                    }
                    else
                    {
                        index++;
                    }
                }
            }

            return mainList;
        }
    }
}
