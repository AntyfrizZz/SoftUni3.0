namespace Executor.Interfaces
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; }

        IReadOnlyDictionary<string, IStudent> StudentByName { get; }

        void EnrollStudent(IStudent student);
    }
}
