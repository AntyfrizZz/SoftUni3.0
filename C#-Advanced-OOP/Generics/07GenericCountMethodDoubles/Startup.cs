namespace _07GenericCountMethodDoubles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var elements = new List<Box<double>>();

            var numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var element = double.Parse(Console.ReadLine());
                elements.Add(new Box<double>(element));
            }

            var comparableElement = new Box<double>(double.Parse(Console.ReadLine()));

            Console.WriteLine(CountGreaterElements(elements, comparableElement));
        }

        static int CountGreaterElements<T>(List<Box<T>> elements, Box<T> comparableElement)
            where T : IComparable
        {
            return elements.Count(e => e.Value.CompareTo(comparableElement.Value) > 0);
        }

    }
}
