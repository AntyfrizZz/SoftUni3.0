namespace _04Froggy
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var lakeStones = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            
            var lake = new Lake(lakeStones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
