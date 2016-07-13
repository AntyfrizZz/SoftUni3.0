namespace _06.Birthday_Celebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    class Startup
    {
        static void Main()
        {
            var birthable = new List<IBirthable>();

            var input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                var entrantDetails = input.Split();

                if (entrantDetails[0].Equals("Citizen"))
                {
                    var citizen = new Citizen(entrantDetails[1], int.Parse(entrantDetails[2]), entrantDetails[3], entrantDetails[4]);
                    birthable.Add(citizen);
                }
                else if (entrantDetails[0].Equals("Pet"))
                {
                    var pet = new Pet(entrantDetails[1], entrantDetails[2]);
                    birthable.Add(pet);
                }

                input = Console.ReadLine();
            }

            var year = Console.ReadLine();

            var detained = birthable
                .Where(i => i.BirthDate.EndsWith(year));

            foreach (var fake in detained)
            {
                Console.WriteLine(fake.BirthDate);
            }
        }
    }
}
