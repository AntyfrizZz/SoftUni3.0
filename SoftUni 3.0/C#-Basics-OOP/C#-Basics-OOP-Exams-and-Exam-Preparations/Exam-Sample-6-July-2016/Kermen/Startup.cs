using Kermen.Factory;

namespace Kermen
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var households = new List<Household>();
            var result = new StringBuilder();
            var payday = 0;

            var inputLine = Console.ReadLine();

            while (!inputLine.Equals("Democracy"))
            {
                payday++;

                if (!inputLine.Equals("EVN") && !inputLine.Equals("EVN bill"))
                {
                    try
                    {
                        var houseHold = HouseholdFactory.MakeHousehold(inputLine);
                        households.Add(houseHold);
                    }
                    catch (Exception)
                    {
                        
                    }
                    
                }

                if (payday % 3 == 0)
                {
                    GetSalary(households);
                }

                switch (inputLine)
                {
                    case "EVN":
                        PrintConsumption(households, result);
                        break;
                    case "EVN bill":
                        PayBills(households);
                        break;
                }

                inputLine = Console.ReadLine();
            }

            result.AppendLine($"Total population: {households.Sum(h => h.NumberOfPeopleInHH())}");

            Console.Write(result);
        }

        private static void GetSalary(List<Household> households)
        {
            foreach (var household in households)
            {
                household.GetSalary();
            }
        }

        private static void PayBills(List<Household> households)
        {
            for (int i = households.Count - 1; i >= 0; i--)
            {
                if (!households[i].PayBills())
                {
                    households.RemoveAt(i);
                }
            }
        }

        private static void PrintConsumption(List<Household> households, StringBuilder result)
        {
            decimal totalConsumption = 0;

            foreach (var household in households)
            {
                totalConsumption += household.Consumption();
            }

            result.AppendLine($"Total consumption: {totalConsumption}");
        }
    }
}
