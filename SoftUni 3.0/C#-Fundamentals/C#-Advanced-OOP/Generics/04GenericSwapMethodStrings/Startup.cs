namespace _04GenericSwapMethodStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var elements = new List<Box<string>>();

            var numberOfLines = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < numberOfLines; i++)
            {
                var element = Console.ReadLine();
                elements.Add(new Box<string>(element));
            }

            var indecies = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstIndex = indecies[0];
            int secondindex = indecies[1];

            Swap(elements, firstIndex, secondindex);

            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        static void Swap<T>(List<Box<T>> elements, int firstIndex, int secondIndex)
        {
            Box<T> temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }
    }
}
