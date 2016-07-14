namespace _03GenericBoxOfInteger
{
    using System;

    class Startup
    {
        static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var input = int.Parse(Console.ReadLine());
                Console.WriteLine(new Box<int>(input));
            }
        }
    }
}
