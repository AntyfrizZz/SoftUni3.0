namespace _04WorkForce
{
    using System;
    using Models;
    using Repositories;

    public class Startup
    {
        public static void Main()
        {
            var jobs = new JobRepository();
            var employees = new EmployeeRopository();

            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!input[0].Equals("End"))
            {
                switch (input[0])
                {
                    case "Job":
                        {
                            var jobName = input[1];
                            var jobHoursRequired = int.Parse(input[2]);
                            var employee = employees.GetEmployee(input[3]);

                            var job = new Job(jobName, jobHoursRequired, employee);
                            job.JobDone += jobs.FinishedJob;
                            jobs.AddJob(job);
                        }

                        break;
                    case "StandartEmployee":
                        {
                            var employeeName = input[1];
                            var employee = new StandartEmployee(employeeName);
                            employees.AddEmployee(employee);
                        }

                        break;
                    case "PartTimeEmployee":
                        {
                            var employeeName = input[1];
                            var employee = new PartTimeEmployee(employeeName);
                            employees.AddEmployee(employee);
                        }

                        break;
                    case "Pass":
                        jobs.Update();
                        break;
                    case "Status":
                        jobs.Status();
                        break;
                }

                input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
