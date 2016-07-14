namespace _11Tuple
{
    using System;

    class Startup
    {
        static void Main()
        {
            var peopleDemo = Console.ReadLine().Split();

            var firstName = peopleDemo[0];
            var lastName = peopleDemo[1];

            var fullName = firstName + " " + lastName;
            var address = peopleDemo[2];

            var person = new Tuple<string, string>(fullName, address);
            Console.WriteLine(person);

            var beerDemo = Console.ReadLine().Split();

            var beerName = beerDemo[0];
            var beerLiters = int.Parse(beerDemo[1]);

            var beer = new Tuple<string, int>(beerName, beerLiters);
            Console.WriteLine(beer);

            var sampleTupleInput = Console.ReadLine().Split();

            var sampleInt = int.Parse(sampleTupleInput[0]);
            var sampleDouble = double.Parse(sampleTupleInput[1]);

            var numbersDemo = new Tuple<int, double>(sampleInt, sampleDouble);
            Console.WriteLine(numbersDemo);
        }
    }
}
