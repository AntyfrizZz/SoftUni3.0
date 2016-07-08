using System;
using _05.Pizza_Calories;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            while (!input[0].Equals("END"))
            {

                switch (input[0])
                {
                    case "Pizza":
                        Pizza pizza = CreatePizza(input);
                        Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():F2} Calories.");
                        break;
                    case "Dough":
                        Dough dough = CreateDough(input);
                        Console.WriteLine($"{dough.GetTotalCalories():F2}");
                        break;
                    case "Topping":
                        Topping topping = CreateTopping(input);
                        Console.WriteLine($"{topping.GetTotalCalories():F2}");
                        break;
                }

                input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static Topping CreateTopping(string[] input)
    {
        var toppingName = input[1];
        var toppingWeight = double.Parse(input[2]);

        var topping = new Topping(toppingName, toppingWeight);

        return topping;
    }

    private static Dough CreateDough(string[] input)
    {
        var doughFlour = input[1];
        var doughBaking = input[2];
        var doughWeigh = double.Parse(input[3]);

        var dough = new Dough(doughFlour, doughBaking, doughWeigh);

        return dough;
    }

    private static Pizza CreatePizza(string[] input)
    {
        var pizzaName = input[1];
        var pizzaToppings = int.Parse(input[2]);

        var pizza = new Pizza(pizzaName, pizzaToppings);

        var doughInfo = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var doughFlour = doughInfo[1];
        var doughBaking = doughInfo[2];
        var doughWeigh = double.Parse(doughInfo[3]);

        var dough = new Dough(doughFlour, doughBaking, doughWeigh);

        pizza.Dough = dough;

        for (int i = 0; i < pizzaToppings; i++)
        {
            var toppingInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var toppingName = toppingInfo[1];
            var toppingWeight = double.Parse(toppingInfo[2]);

            var topping = new Topping(toppingName, toppingWeight);

            pizza.AddTopping(topping);
        }

        return pizza;
    }
}