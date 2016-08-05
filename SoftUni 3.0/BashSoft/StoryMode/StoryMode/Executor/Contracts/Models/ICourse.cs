namespace Executor.Contracts.Models
{
    using System;
    using System.Collections.Generic;

    public interface ICourse : IComparable<ICourse>
    {
        string Name { get; }

        IReadOnlyDictionary<string, IStudent> StudentByName { get; }

        void EnrollStudent(IStudent student);
    }
}
