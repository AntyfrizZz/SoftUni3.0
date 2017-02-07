using PizzaMore.Utility;

namespace PizzaMore.ConsoleTest
{
    class Program
    {
        static void Main()
        {
            var cookies = new CookieCollection();

            for (int i = 1; i < 11; i++)
            {
                cookies.AddCookie(new Cookie($"{i}", $"{i + i}"));
            }

            foreach (var item in cookies)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
