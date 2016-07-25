namespace _04WorkForce.Models
{
    public abstract class Employee
    {
        protected Employee(string name, int workingHours)
        {
            this.Name = name;
            this.WorkingHours = workingHours;
        }

        public string Name { get; }

        public int WorkingHours { get; }
    }
}
