namespace _03.Ferrari
{
    using System;

    public class Startup
    {
        static void Main()
        {
            var driverName = Console.ReadLine();

            var ferrary = new Ferrari(driverName);

            Console.WriteLine(ferrary);
        }
    }
}
