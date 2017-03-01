namespace _06CustomEnumAttribute
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            if (input.Equals("Rank"))
            {
                var attributes = typeof(CardRanks).GetCustomAttributes(false);

                foreach (TypeAttribute attr in attributes)
                {
                    Console.WriteLine(attr);
                }
            }
            else
            {
                var attributes = typeof(CardSuits).GetCustomAttributes(false);

                foreach (TypeAttribute attr in attributes)
                {
                    Console.WriteLine(attr);
                }
            }
        }
    }
}
