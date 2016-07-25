namespace _04WorkForce.Models
{
    public class PartTimeEmployee : Employee
    {
        private const int EmployeeWorkingHours = 20;

        public PartTimeEmployee(string name) 
            : base(name, EmployeeWorkingHours)
        {
        }
    }
}
