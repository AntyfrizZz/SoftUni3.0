using System;

class Startup
{
    static void Main()
    {
        var length = int.Parse(Console.ReadLine());
        var text = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Predicate<string> neededLength = n => n.Length <= length;

        foreach (var word in text)
        {
            if (neededLength(word))
            {
                Console.WriteLine(word);
            }
        }

    }
}