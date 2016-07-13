using System.Collections.Generic;
using _07.Food_Shortage.Models;

namespace _07.Food_Shortage
{
    using System;

    class Startup
    {
        static void Main()
        {
            var buyers = new Dictionary<string, Human>();
            var totalFoodBought = 0;

            var numberOfHumans = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfHumans; i++)
            {
                var humanInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (humanInfo.Length > 3)
                {
                    var citizen = new Citizen(humanInfo[0], int.Parse(humanInfo[1]), humanInfo[2], humanInfo[3]);
                    buyers.Add(citizen.Name, citizen);
                }
                else
                {
                    var rebel = new Rebel(humanInfo[0], int.Parse(humanInfo[1]), humanInfo[2]);
                    buyers.Add(rebel.Name, rebel);
                }
            }

            var name = Console.ReadLine();

            while (!name.Equals("End"))
            {
                if (buyers.ContainsKey(name))
                {
                    buyers[name].BuyFood();
                }

                name = Console.ReadLine();
            }

            foreach (var buyer in buyers)
            {
                totalFoodBought += buyer.Value.Food;
            }

            Console.WriteLine(totalFoodBought);
        }
    }
}
