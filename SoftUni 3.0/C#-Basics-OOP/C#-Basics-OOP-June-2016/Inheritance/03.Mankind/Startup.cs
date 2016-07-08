
namespace Mankind
{
    using System;

    class Startup
    {
        static void Main()
        {
            Student student = null;
            Worker worker = null;
            try
            {
                var studentInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var studentFirstName = studentInfo[0];
                var studentLastName = studentInfo[1];
                var studentFacultyNumber = studentInfo[2];

                student = new Student(studentFirstName, studentLastName, studentFacultyNumber);

                var workerInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var workerFirstName = workerInfo[0];
                var workertLastName = workerInfo[1];
                var workerSalary = decimal.Parse(workerInfo[2]);
                var workerHoursPerDay = decimal.Parse(workerInfo[3]);

                worker = new Worker(workerFirstName, workertLastName, workerSalary, workerHoursPerDay);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            if (student != null && worker != null)
            {
                Console.Write(student);
                Console.WriteLine();
                Console.Write(worker);
            }
        }
    }
}
