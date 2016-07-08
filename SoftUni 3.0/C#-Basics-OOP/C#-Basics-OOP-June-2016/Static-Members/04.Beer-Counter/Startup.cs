using System;
using System.Linq;

public class BeerCounter
{
    public static int beerInStock;
    public static int beerDrankCount;

    public static void BuyBeer(int bottlesCount)
    {
        beerInStock += bottlesCount;
    }

    public static void DrinkBeer(int bottlesCount)
    {
        beerInStock -= bottlesCount;
        beerDrankCount += bottlesCount;
    }

}

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();


        while (!input.Equals("End"))
        {
            var beers = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            BeerCounter.BuyBeer(beers[0]);
            BeerCounter.DrinkBeer(beers[1]);

            input = Console.ReadLine();
        }

        Console.WriteLine($"{BeerCounter.beerInStock} {BeerCounter.beerDrankCount}");
    }
}