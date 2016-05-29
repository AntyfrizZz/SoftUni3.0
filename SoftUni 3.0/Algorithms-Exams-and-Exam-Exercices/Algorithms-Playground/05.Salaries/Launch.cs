using System;
using System.Collections.Generic;
using System.Linq;

public class Launch
{
    private static List<int>[] employees;

    public static void Main(string[] args)
    {
        int employeeCount = int.Parse(Console.ReadLine());
        employees = new List<int>[employeeCount];
        for (int i = 0; i < employeeCount; i++)
        {
            employees[i] = new List<int>();
            string input = Console.ReadLine();
            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] == 'Y')
                {
                    employees[i].Add(j);
                }
            }
        }

        var salaries = new Dictionary<int, decimal>();
        for (int employee = 0; employee < employeeCount; employee++)
        {
            CalculateSalary(salaries, employee);
        }

        Console.WriteLine(salaries.Values.Sum());
    }

    private static void CalculateSalary(Dictionary<int, decimal> salaries, int manager)
    {
        if (!salaries.ContainsKey(manager))
        {
            salaries[manager] = 0;
            if (employees[manager].Count > 0)
            {
                foreach (var employee in employees[manager])
                {
                    CalculateSalary(salaries, employee);
                    salaries[manager] += salaries[employee];
                }
            }
            else
            {
                salaries[manager]++;
            }
        }
    }
}
