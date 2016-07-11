namespace VegetableNinja.IO
{
    using System;

    using VegetableNinja.Interfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
