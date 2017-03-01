namespace _08CustomList
{
    using System;

    class Startup
    {
        static void Main()
        {
            var collection = new MyList<string>();

            var command = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!command[0].Equals("END"))
            {
                switch (command[0])
                {
                    case "Add":
                        collection.Add(command[1]);
                        break;
                    case "Remove":
                        collection.Remove(int.Parse(command[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(collection.Contains(command[1]));
                        break;
                    case "Swap":
                        collection.Swap(int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "Greater":
                        int count = collection.CountGreaterThan(command[1]);
                        Console.WriteLine(count);
                        break;
                    case "Max":
                        Console.WriteLine(collection.Max());
                        break;
                    case "Min":
                        Console.WriteLine(collection.Min());
                        break;
                    case "Print":
                        collection.Print();
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
