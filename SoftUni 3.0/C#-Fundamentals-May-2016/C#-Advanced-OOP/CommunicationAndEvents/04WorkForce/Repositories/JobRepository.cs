namespace _04WorkForce.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            Console.WriteLine($"Job {args.Name} done!");
            var job = this.jobs
                .FirstOrDefault(j => j.Name.Equals(args.Name));

            this.jobs.Remove(job);
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
                Console.WriteLine($"Job: {job.Name} Hours Remaining: {job.HoursOfWorkRequired}");
            }
        }
    }
}
