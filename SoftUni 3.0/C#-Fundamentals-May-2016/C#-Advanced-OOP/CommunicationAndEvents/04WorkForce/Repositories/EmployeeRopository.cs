namespace _04WorkForce.Repositories
{
    using System.Collections.Generic;
    using Models;

    public class EmployeeRopository
    {
        private readonly Dictionary<string, Employee> employees;

        public EmployeeRopository()
        {
            this.employees = new Dictionary<string, Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            this.employees.Add(employee.Name, employee);
        }

        public Employee GetEmployee(string name)
        {
            return this.employees[name];
        }
    }
}
