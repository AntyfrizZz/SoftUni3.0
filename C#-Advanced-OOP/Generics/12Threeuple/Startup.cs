namespace _12Threeuple
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
            var city = peopleDemo[3];

            var person = new Threeuple<string, string, string>(fullName, address, city);
            Console.WriteLine(person);

            var beerDemo = Console.ReadLine().Split();

            var beerName = beerDemo[0];
            var beerLiters = int.Parse(beerDemo[1]);
            var state = beerDemo[2] == "drunk";

            var beer = new Threeuple<string, int, bool>(beerName, beerLiters, state);
            Console.WriteLine(beer);

            var sampleTupleInput = Console.ReadLine().Split();

            var sampleInt = sampleTupleInput[0];
            var sampleDouble = double.Parse(sampleTupleInput[1]);
            var bank = sampleTupleInput[2];

            var numbersDemo = new Threeuple<string, double, string>(sampleInt, sampleDouble, bank);
            Console.WriteLine(numbersDemo);
        }
    }
}
