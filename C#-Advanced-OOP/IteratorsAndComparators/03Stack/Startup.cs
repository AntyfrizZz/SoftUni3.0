namespace _03Stack
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var stacky = new Stacky<int>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command.Equals("END"))
                {
                    break;
                }

                try
                {
                    if (command.StartsWith("Push"))
                    {
                        var elements = command.Substring(5)
                            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

                        stacky.Push(elements);
                    }
                    else if (command.Equals("Pop"))
                    {
                        stacky.Pop();
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            foreach (var element in stacky)
            {
                Console.WriteLine(element);
            }

            foreach (var element in stacky)
            {
                Console.WriteLine(element);
            }
        }
    }
}
