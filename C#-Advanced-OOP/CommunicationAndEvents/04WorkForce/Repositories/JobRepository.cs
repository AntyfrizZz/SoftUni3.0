namespace _04WorkForce.Repositories
{
    using System;
    using System.Collections.Generic;
    using EventsArguments;
    using Models;

    public class JobRepository
    {
        private readonly List<Job> jobs;

        public JobRepository()
        {
            this.jobs = new List<Job>();
        }

        public void AddJob(Job job)
        {
            this.jobs.Add(job);   
        }

        public void FinishedJob(object sender, JobDoneArgs args)
        {
            Console.WriteLine($"Job {args.Job.Name} done!");
            this.jobs.Remove(args.Job);
        }

        public void Update()
        {
            var jobsToUpdate = new List<Job>(this.jobs);

            foreach (var job in jobsToUpdate)
            {
                job.Update();
            }
        }

        public void Status()
        {
            foreach (var job in this.jobs)
            {
                Console.WriteLine(job);
            }
        }
    }
}
