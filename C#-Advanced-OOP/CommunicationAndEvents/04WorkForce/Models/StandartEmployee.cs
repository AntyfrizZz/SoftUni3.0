namespace _04WorkForce.Models
{
    public class StandartEmployee : Employee
    {
        private const int EmployeeWorkingHours = 40;

        public StandartEmployee(string name) 
            : base(name, EmployeeWorkingHours)
        {
        }
    }
}
