using System.Linq;

namespace _05.Border_Control
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            var identifiable = new List<IIdentifiable>();

            var input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                var entrantDetails = input.Split();

                if (entrantDetails.Length > 2)
                {
                    var citizen = new Citizen(entrantDetails[0], int.Parse(entrantDetails[1]), entrantDetails[2]);
                    identifiable.Add(citizen);
                }
                else
                {
                    var robot = new Robot(entrantDetails[0], entrantDetails[1]);
                    identifiable.Add(robot);
                }

                input = Console.ReadLine();
            }

            var fakeId = Console.ReadLine();

            var detained = identifiable
                .Where(i => i.Id.EndsWith(fakeId));

            foreach (var fake in detained)
            {
                Console.WriteLine(fake.Id);
            }
        }
    }
}
