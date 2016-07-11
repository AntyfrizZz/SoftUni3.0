namespace VegetableNinja.IO
{
    using System;

    using VegetableNinja.Interfaces;

    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public void Write(string output)
        {
            Console.Write(output);
        }
    }
}
