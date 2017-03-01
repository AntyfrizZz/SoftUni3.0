namespace Executor.Contracts.Repository
{
    using System.Collections.Generic;

    public interface IDataFilter
    {
        void PrintFilteredStudents(Dictionary<string, double> studentsFiltered);
    }
}
