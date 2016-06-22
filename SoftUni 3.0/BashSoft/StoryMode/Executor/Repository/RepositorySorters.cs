using System;
using System.Collections.Generic;
using System.Linq;

namespace Executor
{
    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData,
            string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {    
                PrintStudents(wantedData.OrderBy(x => x.Value.Sum())
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value)); 
            }
            else if (comparison == "descending")
            {  
                PrintStudents(wantedData.OrderByDescending(x => x.Value.Sum())
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {                               
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private static void PrintStudents(Dictionary<string, List<int>> studentsSorted)
        {
            foreach (KeyValuePair<string, List<int>> keyValuePair in studentsSorted)
            {
                OutputWriter.PrintStudent(keyValuePair);
            }
        }
    }
}
