using System;
using System.Collections.Generic;
using System.Linq;

class UserLogs
{
    static void Main()
    {
        var input = Console.ReadLine();

        var result = new SortedDictionary<string, Dictionary<string, int>>();

        while (input != "end")
        {
            var inputArgs = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var ip = inputArgs[0]
                .Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1];
            var username = inputArgs[2]
                .Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1];            

            if (!result.ContainsKey(username))
            {
                var newIP = new Dictionary<string, int>();
                newIP.Add(ip, 1);

                result.Add(username, newIP);
            }
            else
            {
                if (!result[username].ContainsKey(ip))
                {
                    result[username].Add(ip, 1);
                }
                else
                {
                    result[username][ip]++;
                }                
            }

            input = Console.ReadLine();
        }

        foreach (var kvp in result)
        {
            Console.WriteLine("{0}:", kvp.Key);

            var messageCount = new List<string>();

            foreach (var kvpInValue in kvp.Value)
            {
                messageCount.Add(kvpInValue.Key + " => " + kvpInValue.Value);
            }

            Console.WriteLine(string.Join(", ", messageCount) + ".");
        }
    }
}
