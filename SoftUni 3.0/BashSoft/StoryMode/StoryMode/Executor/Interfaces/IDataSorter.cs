namespace Executor.Interfaces
{
    using System.Collections.Generic;

    public interface IDataSorter
    {
        void PrintSortedStudents(Dictionary<string, double> studentsSorted);
    }
}
