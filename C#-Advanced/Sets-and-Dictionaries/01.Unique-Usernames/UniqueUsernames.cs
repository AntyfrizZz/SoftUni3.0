using System;
using System.Collections.Generic;

class UniqueUsernames
{
    static void Main(string[] args)
    {
        var userNamesCount = int.Parse(Console.ReadLine());
                
        var userNames = new HashSet<string>();

        for (int i = 0; i < userNamesCount; i++)
        {
            string input = Console.ReadLine();
            userNames.Add(input);
        }

        //Console.WriteLine(userNames.Count);

        foreach (var item in userNames)
        {
            Console.WriteLine(item);
        }
    }
}

