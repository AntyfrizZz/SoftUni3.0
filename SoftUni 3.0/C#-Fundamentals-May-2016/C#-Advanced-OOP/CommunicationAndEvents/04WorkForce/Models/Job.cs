namespace _04WorkForce.Models
{
    using EventsArguments;

    public delegate void JobDoneEventHandler(object sender, JobDoneArgs args);

    public class Job
    {
        private readonly Employee employee;

        public Job(string name, int hoursOfWorkRequired, Employee employee)
        {
            this.Name = name;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
            this.employee = employee;
        }

        public event JobDoneEventHandler JobDone;

        public string Name { get; }

        public int HoursOfWorkRequired { get; private set; }

        public void Update()
        {
            this.HoursOfWorkRequired -= this.employee.WorkingHours;

            if (this.HoursOfWorkRequired <= 0)
            {
                this.OnJobDone(new JobDoneArgs(this.Name));
            }
        }

        public void OnJobDone(JobDoneArgs args)
        {
            this.JobDone?.Invoke(this, args);
        }
    }
}
