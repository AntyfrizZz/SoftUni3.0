namespace _01EventImplementation
{
    using System;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            var input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                dispatcher.Name = input;
                input = Console.ReadLine();
            }
        }
    }
}
