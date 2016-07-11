using System;

public class Startup
{
    private static void Main()
    {
        string[] arrows = { ">>>----->>", ">>----->", ">----->" };
        int[] counts = new int[3]; // 0 -> small, 1 -> medium, 2 -> big
        for (int i = 0; i < 4; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0, k = 2; j < arrows.Length; j++, k--)
            {
                string arrow = arrows[j];
                int index = line.IndexOf(arrow);
                while (index > -1)
                {
                    string firstPart = line.Substring(0, index); // before the arrow
                    int lastIndex = index + arrow.Length;
                    string secondPart = line.Substring(lastIndex, line.Length - lastIndex); // after the arrow
                    line = firstPart + "&" + secondPart; // the line becomes -> before arrow + special symbol + after the arrow, the arrow is effectively replaced
                    index = line.IndexOf(arrow); // check if there are more arrows from this type left
                    counts[k]++;
                }
            }
        }

        string binary = Convert.ToString(long.Parse(string.Join("", counts)), 2);
        char[] reversed = binary.ToCharArray();
        Array.Reverse(reversed);

        Console.WriteLine(Convert.ToInt64(binary + string.Join("", reversed), 2));

    }
}