namespace _10.Explicit_Interfaces
{
    using System;

    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!input[0].Equals("End"))
            {
                var name = input[0];
                var country = input[1];
                var age = int.Parse(input[2]);

                IPerson person = new Citizen(name, country, age);
                person.GetName();

                IResident resident = new Citizen(name, country, age);
                resident.GetName();

                input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
