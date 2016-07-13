namespace _08.Military_Elite
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Factory;

    class Startup
    {
        static void Main()
        {
            var soldiers = new List<ISoldier>();

            var input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                soldiers.Add(SoldierFactory.Soldier(input));

                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.Write(soldier);
            }
        }
    }
}
