using System;
//You are given n integers (given in a single line, separated by a space). 
//Write a program that checks whether the product of the odd elements is equal to the product of the even elements. 
//Elements are counted from 1 to n, so the first element is odd, the second is even, etc.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class OddAndEvenProduct
{
    static void Main()
    {
        Console.Title = "Problem 10. Odd and Even Product";

        int even = 1;
        int odd = 1;

        string readNumbers = Console.ReadLine();
        string[] numbers = readNumbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < numbers.Length; i++)
        {
            int number = int.Parse(numbers[i]);

            if (i % 2 == 0)
            {
                even *= number;
            }
            else
            {
                odd *= number;
            }
        }

        if (even == odd)
        {
            Console.WriteLine("yes");
            Console.WriteLine("product = " + even);
        }
        else
        {
            Console.WriteLine("no");
            Console.WriteLine("odd_product = " + odd);
            Console.WriteLine("even_product = " + even);
        }
    }
}