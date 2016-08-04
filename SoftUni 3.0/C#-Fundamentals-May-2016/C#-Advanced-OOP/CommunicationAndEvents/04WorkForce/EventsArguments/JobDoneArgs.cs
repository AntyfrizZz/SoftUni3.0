namespace _04WorkForce.EventsArguments
{
    using System;
    using Models;

    public class JobDoneArgs : EventArgs
    {
        public JobDoneArgs(Job job)
        {
            this.Job = job;
        }

        public Job Job { get; }
    }
}
