namespace _02Collection
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var listElements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            listElements.RemoveAt(0);

            ListyIterator<string> listy = new ListyIterator<string>(listElements);

            var command = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!command[0].Equals("END"))
            {
                try
                {
                    switch (command[0])
                    {
                        case "Move":
                            Console.WriteLine(listy.Move() ? "True" : "False");
                            break;
                        case "Print":
                            Console.WriteLine(listy.Print());
                            break;
                        case "HasNext":
                            Console.WriteLine(listy.HasNext() ? "True" : "False");
                            break;
                        case "PrintAll":
                            Console.WriteLine(listy.PrintAll());
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }


                command = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
