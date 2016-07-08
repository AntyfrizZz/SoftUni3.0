using System;
using System.Text;
using System.Text.RegularExpressions;

class Problem03
{
    static void Main()
    {
        var validMessage = true;
        var result = new StringBuilder();

        var message = Console.ReadLine();

        while (!message.Equals("Over!"))
        {
            var count = int.Parse(Console.ReadLine());

            var pattern = $"(.*)([a-zA-Z]{{{count}}})(.*)";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(message);

            foreach (Match match in matches)
            {
                foreach (var character in match.Groups[1].Value)
                {
                    if (!char.IsDigit(character))
                    {
                        validMessage = false;
                        break;
                    }
                }

                if (validMessage)
                {
                    foreach (var character in match.Groups[3].Value)
                    {
                        if (char.IsLetter(character))
                        {
                            validMessage = false;
                            break;
                        }
                    }
                }

                if (validMessage)
                {
                    var messageText = match.Groups[2].Value;
                    var messageDigits = match.Groups[1].Value;

                    if (match.Groups.Count == 4)
                    {
                        foreach (var character in match.Groups[3].Value)
                        {
                            if (char.IsDigit(character))
                            {
                                messageDigits += character;
                            }
                            else
                            {
                                break;
                            }
                        }


                    }

                    result.Append($"{messageText} == ");
                    foreach (var digit in messageDigits)
                    {
                        if (int.Parse(digit.ToString()) < messageText.Length)
                        {
                            result.Append(messageText[int.Parse(digit.ToString())]);
                        }
                        else
                        {
                            result.Append(" ");
                        }
                    }

                    result.AppendLine();
                }

                validMessage = true;
            }

            message = Console.ReadLine();
        }

        Console.Write(result);
    }
}