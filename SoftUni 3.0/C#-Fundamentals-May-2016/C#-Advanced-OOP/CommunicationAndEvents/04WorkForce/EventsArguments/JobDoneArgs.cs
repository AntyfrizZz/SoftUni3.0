namespace _04WorkForce.EventsArguments
{
    using System;

    public class JobDoneArgs : EventArgs
    {
        public JobDoneArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
