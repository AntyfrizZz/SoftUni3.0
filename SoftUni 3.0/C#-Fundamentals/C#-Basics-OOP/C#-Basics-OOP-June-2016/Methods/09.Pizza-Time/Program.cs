using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Pizza
{
    public static SortedDictionary<int, List<string>> pizzasByGroup = new SortedDictionary<int, List<string>>();

    public string name;
    public int group;

    public Pizza(string name, int @group)
    {
        this.name = name;
        this.group = group;
    }

    public static SortedDictionary<int, List<string>> GroupPizzas(string pizzas)
    {
        var pizzasDict = new SortedDictionary<int, List<string>>();

        var inputPizzas = pizzas
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var pizza in inputPizzas)
        {
            var pizzaGroup = string.Empty;
            var pizzaName = string.Empty;

            var startName = false;

            for (int i = 0; i < pizza.Length; i++)
            {
                if (char.IsDigit(pizza[i]) && startName == false)
                {
                    pizzaGroup += pizza[i];
                }
                else
                {
                    pizzaName += pizza[i];
                    startName = true;
                }
            }

            if (!pizzasDict.ContainsKey(int.Parse(pizzaGroup)))
            {
                pizzasDict.Add(int.Parse(pizzaGroup), new List<string>());
            }

            pizzasDict[int.Parse(pizzaGroup)].Add(pizzaName);
        }

        return pizzasDict;

    }
}

class Program
{
    static void Main()
    {
        MethodInfo[] methods = typeof(Pizza).GetMethods();
        bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("SortedDictionary`2"));
        if (!containsMethod)
        {
            throw new Exception();
        }

        var input = Console.ReadLine();

        var result = Pizza.GroupPizzas(input);


        foreach (var pizza in result)
        {
            Console.WriteLine($"{pizza.Key} - {string.Join(", ", pizza.Value)}");
        }




    }
}