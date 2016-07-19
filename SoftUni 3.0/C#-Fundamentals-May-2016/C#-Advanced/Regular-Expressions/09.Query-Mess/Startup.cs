using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine().Trim();

        var pattern = "(?<key>[^&\\?\\n]+)=(?<value>[^&\\n]+)";
        Regex rgx = new Regex(pattern);

        var sb = new StringBuilder();

        while (input != "END")
        {

            Regex regRepl = new Regex(@"\+");
            input = regRepl.Replace(input, " ");
            regRepl = new Regex("%20");
            input = regRepl.Replace(input, " ");
            regRepl = new Regex(@"\s+");
            input = regRepl.Replace(input, " ");
            regRepl = new Regex(@"\s*=\s*");
            input = regRepl.Replace(input, "=");
            regRepl = new Regex(@"\s*&\s*");
            input = regRepl.Replace(input, "&");

            Dictionary<string, string> result = new Dictionary<string, string>();

            MatchCollection matches = rgx.Matches(input);

            foreach (Match item in matches)
            {
                if (result.ContainsKey(item.Groups["key"].ToString()))
                {
                    result[item.Groups["key"].ToString().Trim()] = result[item.Groups["key"].ToString().Trim()] + ", " + item.Groups["value"].ToString().Trim();
                }
                else
                {
                    result.Add(item.Groups["key"].ToString().Trim(), item.Groups["value"].ToString().Trim());
                }
            }

            foreach (KeyValuePair<string, string> kvp in result)
            {
                sb.Append(kvp.Key + "=[" + kvp.Value + "]");
            }

            sb.AppendLine();

            input = Console.ReadLine();
        }

        Console.Write(sb);
    }
}
