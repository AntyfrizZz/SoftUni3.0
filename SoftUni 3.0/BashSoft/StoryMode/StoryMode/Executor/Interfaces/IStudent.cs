namespace Executor.Interfaces
{
    using System.Collections.Generic;

    public interface IStudent
    {
        string UserName { get; }

        IReadOnlyDictionary<string, ICourse> EnrolledCourses { get; }

        IReadOnlyDictionary<string, double> MarksByCourseName { get; }

        void EnrollInCourse(ICourse course);

        void SetMarkOnCourse(string courseName, params int[] scores);

        string GetMarkForCourse(string courseName);
    }
}
