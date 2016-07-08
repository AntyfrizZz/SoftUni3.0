using System;

class Startup
{
    static void Main()
    {
        var firstNum = Console.ReadLine().TrimStart(new char[] { '0' });
        var secondNum = Console.ReadLine().TrimStart(new char[] { '0' });

        if (firstNum.Length < secondNum.Length)
        {
            firstNum = firstNum.PadLeft(secondNum.Length, '0');
        }
        if (secondNum.Length < firstNum.Length)
        {
            secondNum = secondNum.PadLeft(firstNum.Length, '0');
        }

        var inMind = 0;
        var result = string.Empty;

        for (int i = firstNum.Length - 1; i >= 0; i--)
        {
            var temp = int.Parse(firstNum[i].ToString()) + int.Parse(secondNum[i].ToString()) + inMind;

            if (temp < 10)
            {
                result += temp.ToString();
                inMind = 0;
            }
            else
            {
                result += (temp % 10).ToString();
                inMind = temp / 10;
            }
        }

        if (inMind != 0)
        {
            result += inMind.ToString();
        }


        Console.WriteLine(Reverse(result));
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
