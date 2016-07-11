using System;

class Startup
{
    static string result = string.Empty;

    static void Main()
    {
        var firstNum = Console.ReadLine().TrimStart(new char[] { '0' });
        var secondNum = Console.ReadLine().TrimStart(new char[] { '0' });

        if (firstNum == "")
        {
            Console.WriteLine("0");
            return;
        }
        if (secondNum == "")
        {
            Console.WriteLine("0");
            return;
        }

        if (secondNum == "1")
        {
            Console.WriteLine(firstNum);
            return;
        }

        result = firstNum;

        for (int i = 1; i < int.Parse(secondNum); i++)
        {
            Sum(firstNum);
        }

        Console.WriteLine(result);
    }


    private static void Sum(string number)
    {
        if (number.Length < result.Length)
        {
            number = number.PadLeft(result.Length, '0');
        }

        var inMind = 0;
        var sum = string.Empty;

        for (int i = number.Length - 1; i >= 0; i--)
        {
            var temp = int.Parse(number[i].ToString()) + int.Parse(result[i].ToString()) + inMind;

            if (temp < 10)
            {
                sum += temp.ToString();
                inMind = 0;
            }
            else
            {
                sum += (temp % 10).ToString();
                inMind = temp / 10;
            }
        }

        if (inMind != 0)
        {
            sum += inMind.ToString();
        }


        result = Reverse(sum);
    }

    private static string Multiply(int multiplier, string number)
    {
        var inMind = 0;
        var temporaryResult = string.Empty;

        for (int i = number.Length - 1; i >= 0; i--)
        {
            var temp = multiplier * int.Parse(number[i].ToString()) + inMind;

            if (temp < 10)
            {
                temporaryResult += temp.ToString();
                inMind = 0;
            }
            else
            {
                temporaryResult += (temp % 10).ToString();
                inMind = temp / 10;
            }
        }

        if (inMind != 0)
        {
            temporaryResult += inMind.ToString();
        }

        return Reverse(temporaryResult);
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

}
