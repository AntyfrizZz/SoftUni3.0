using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Startup
{
    static void Main()
    {
        var employees = new List<Employee>();
        var resultForPrint = new StringBuilder();

        var lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            var employeeArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var newEmployee = new Employee(
                employeeArgs[0],
                decimal.Parse(employeeArgs[1]),
                employeeArgs[2],
                employeeArgs[3]);


            if (employeeArgs.Length > 4)
            {
                if (employeeArgs[4].Contains("@"))
                {
                    newEmployee.email = employeeArgs[4];
                }
                else
                {
                    newEmployee.age = int.Parse(employeeArgs[4]);
                }
            }

            if (employeeArgs.Length > 5)
            {
                if (employeeArgs[5].Contains("@"))
                {
                    newEmployee.email = employeeArgs[5];
                }
                else
                {
                    newEmployee.age = int.Parse(employeeArgs[5]);
                }
            }

            employees.Add(newEmployee);
        }

        var result = employees
             .GroupBy(e => e.department)
             .Select(e => new
             {
                 Department = e.Key,
                 AverageSalary = e.Average(emp => emp.salary),
                 Employees = e.OrderByDescending(emp => emp.salary)
             })
             .OrderByDescending(e => e.AverageSalary)
             .FirstOrDefault();

        resultForPrint.AppendLine($"Highest Average Salary: {result.Department}");
        foreach (var employee in result.Employees)
        {
            resultForPrint.AppendLine($"{employee.name} {employee.salary:F2} {employee.email} {employee.age}");
        }

        Console.Write(resultForPrint);
    }
}