using System;
using System.Collections.Generic;

class LogsAggregator
{
    static void Main()
    {
        var numberOfLogs = int.Parse(Console.ReadLine());

        var result = new SortedDictionary<string, SortedDictionary<string, int>>();

        for (int i = 0; i < numberOfLogs; i++)
        {
            var logArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var iP = logArgs[0];
            var username = logArgs[1];
            var duration = int.Parse(logArgs[2]);

            if (!result.ContainsKey(username))
            {
                var temp = new SortedDictionary<string, int>();
                temp.Add(iP, duration);

                result.Add(username, temp);
            }
            else
            {
                if (!result[username].ContainsKey(iP))
                {
                    result[username].Add(iP, 0);
                }

                result[username][iP] += duration;
            }
        }

        foreach (var kvp in result)
        {
            var totalDurationPerUser = 0;
            var ipList = new List<string>();

            foreach (var kvpInValue in kvp.Value)
            {
                ipList.Add(kvpInValue.Key);
                totalDurationPerUser += kvpInValue.Value;
            }

            Console.WriteLine("{0}: {1} [{2}]", kvp.Key, totalDurationPerUser, string.Join(", ", ipList));
        }
    }
}
