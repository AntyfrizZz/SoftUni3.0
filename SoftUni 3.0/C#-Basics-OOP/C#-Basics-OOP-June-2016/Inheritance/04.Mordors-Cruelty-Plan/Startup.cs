namespace MordorsCrueltyPlan
{
    using System;

    class Startup
    {
        static void Main()
        {
            var inputLine = Console.ReadLine()
                .Split(new[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            var mood = 0;

            foreach (var food in inputLine)
            {
                mood += FoodFactory.MakeFood(food).GetPoints();
            }

            Console.WriteLine(mood);
            Console.WriteLine(MoodFactory.GetMood(mood).GetMood());

        }
    }
}