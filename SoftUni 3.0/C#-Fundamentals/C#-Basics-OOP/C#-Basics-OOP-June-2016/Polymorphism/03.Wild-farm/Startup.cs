namespace WildFarm
{
    using System;

    using Animals;
    using Foods;

    class Startup
    {
        static void Main()
        {
            var animalInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!animalInfo[0].Equals("End"))
            {
                var foodInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var animalName = animalInfo[1];
                var animalWeight = double.Parse(animalInfo[2]);
                var animalLivingRegion = animalInfo[3];

                var foodType = foodInfo[0];
                var foodQuantity = int.Parse(foodInfo[1]);

                Food food;
                if (foodType.Equals("Vegetable"))
                {
                    food = new Vegetable(foodQuantity);
                }
                else
                {
                    food = new Meat(foodQuantity);
                }

                switch (animalInfo[0])
                {
                    case "Cat":
                        var catBreed = animalInfo[4];

                        var cat = new Cat(animalName, animalWeight, animalLivingRegion, catBreed);
                        cat.MakeSound();
                        cat.Eat(food);
                        Console.WriteLine(cat);
                        break;
                    case "Tiger":
                        var tiger = new Tiger(animalName, animalWeight, animalLivingRegion);
                        tiger.MakeSound();
                        tiger.Eat(food);
                        Console.WriteLine(tiger);
                        break;
                    case "Zebra":
                        var zebra = new Zebra(animalName, animalWeight, animalLivingRegion);
                        zebra.MakeSound();
                        zebra.Eat(food);
                        Console.WriteLine(zebra);
                        break;
                    case "Mouse":
                        var mouse = new Mouse(animalName, animalWeight, animalLivingRegion);
                        mouse.MakeSound();
                        mouse.Eat(food);
                        Console.WriteLine(mouse);
                        break;
                }

                animalInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
