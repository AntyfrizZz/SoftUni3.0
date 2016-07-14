namespace _01GenericBox
{
    using System;

    class Startup
    {
        static void Main()
        {
            Console.WriteLine(new Box<int>(123123));
            Console.WriteLine(new Box<string>("life in a box"));
        }
    }
}
