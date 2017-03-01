using System;
using System.Collections.Generic;
using System.Linq;

public class Cat
{
    public string name;
    public string breed;
    public int earSize;
    public double furLength;
    public int decibelsOfMeows;

    public Cat(string name, string breed)
    {
        this.name = name;
        this.breed = breed;
        this.earSize = 0;
        this.furLength = 0.00;
        this.decibelsOfMeows = 0;
    }

    public override string ToString()
    {
        if (this.breed.Equals("StreetExtraordinaire"))
        {
            return $"{this.breed} {this.name} {this.decibelsOfMeows}";
        }
        else if (this.breed.Equals("Siamese"))
        {
            return $"{this.breed} {this.name} {this.earSize}";
        }
        else
        {
            return $"{this.breed} {this.name} {this.furLength:F2}";
        }
    }
}


class Startup
{
    static void Main()
    {
        var cats = new List<Cat>();

        var input = Console.ReadLine();

        while (!input.Equals("End"))
        {
            var catInfo = input.Split();

            var catBreed = catInfo[0];
            var catName = catInfo[1];

            var currentCat = new Cat(catName, catBreed);

            if (catBreed.Equals("StreetExtraordinaire"))
            {
                currentCat.decibelsOfMeows = int.Parse(catInfo[2]);
            }
            else if (catBreed.Equals("Siamese"))
            {
                currentCat.earSize = int.Parse(catInfo[2]);
            }
            else if (catBreed.Equals("Cymric"))
            {
                currentCat.furLength = double.Parse(catInfo[2]);
            }

            cats.Add(currentCat);

            input = Console.ReadLine();
        }

        var catsName = Console.ReadLine();

        var curCat = cats
            .First(c => c.name.Equals(catsName));

        Console.WriteLine(curCat);
    }
}