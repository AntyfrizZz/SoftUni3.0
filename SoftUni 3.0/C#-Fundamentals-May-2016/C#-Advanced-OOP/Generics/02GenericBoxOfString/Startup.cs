namespace _02GenericBoxOfString
{
    using System;

    class Startup
    {
        static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var input = Console.ReadLine();
                Console.WriteLine(new Box<string>(input));
            }
        }
    }
}
