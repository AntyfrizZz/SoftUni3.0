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
                try
                {
                    soldiers.Add(SoldierFactory.Soldier(input));
                }
                catch (Exception)
                {

                }

                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.Write(soldier);
            }
        }
    }
}
