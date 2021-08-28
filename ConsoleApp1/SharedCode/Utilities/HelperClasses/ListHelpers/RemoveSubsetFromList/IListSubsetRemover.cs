using System;
using System.Collections.Generic;

namespace GameCollection.SharedCode.Utilities.HelperClasses.ListHelpers.RemoveSubsetFromList
{
    public interface IListSubsetRemover
    {
        List<T> RemoveSubsetFromList<T>(List<T> passedMainList, List<T> passedSubset) where T : class;
    }
}