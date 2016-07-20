namespace _09LinkedListTraversal
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var listy = new LinkerinoListerino<int>();

            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (commandInfo[0])
                {
                    case "Add":
                        listy.Add(int.Parse(commandInfo[1]));
                        break;
                    case "Remove":
                        listy.Remove(int.Parse(commandInfo[1]));
                        break;
                }
            }

            Console.WriteLine(listy.Count);
            Console.WriteLine(string.Join(" ", listy));
        }
    }
}
