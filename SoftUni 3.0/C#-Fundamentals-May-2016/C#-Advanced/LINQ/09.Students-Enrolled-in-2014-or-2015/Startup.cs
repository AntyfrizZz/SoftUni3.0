using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        var inputLine = Console.ReadLine();

        while (inputLine != "END")
        {
            int facNumber = int.Parse(inputLine
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);

            if (facNumber % 10 == 5 || facNumber % 10 == 4)
            {
                inputLine
                    .Skip(7)
                    .ToList()
                    .ForEach(s => Console.Write(s));
                Console.WriteLine();
            }

            inputLine = Console.ReadLine();
        }
    }
}