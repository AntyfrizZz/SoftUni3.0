using System;
using System.Collections.Generic;
//Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal number, the sum and the average of all numbers 
//(displayed with 2 digits after the decimal point). The input starts by the number n (alone in a line) followed by n lines, each holding an integer number. 
//The output is like in the examples below. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class MinMaxSumAndAverageOfNNumbers
{
    static void Main()
    {
        Console.Title = "Problem 3.	Min, Max, Sum and Average of N Numbers";

        Console.Write("Enter the number of the integers: ");
        string inputNumString = Console.ReadLine();
        int inputNum = Convert.ToInt32(inputNumString);
        decimal inputNumDcml = Convert.ToDecimal(inputNumString);
        

        while (inputNum < 1)
        {
            Console.Write("Please enter a positive integer: ");
            inputNum = int.Parse(Console.ReadLine());
        }

        List<int> numbers = new List<int>(inputNum);

        for (int i = 0; i < inputNum; i++)
        {
            Console.Write("Enter the next whole number of sequence: ");
            inputNumString = Console.ReadLine();
            numbers.Add(int.Parse(inputNumString));
        }

        int numMin = int.MaxValue;
        int numMax = int.MinValue;
        int sumOfAllNumbers = 0;
        
        foreach (var number in numbers)
        {
            numMin = Math.Min(numMin, number);
            numMax = Math.Max(numMax, number);
            sumOfAllNumbers += number;
        }

        decimal averageNumbers = sumOfAllNumbers / inputNumDcml;

        Console.WriteLine("min = {0}", numMin);
        Console.WriteLine("max = {0}", numMax);
        Console.WriteLine("sum = {0}", sumOfAllNumbers);
        Console.WriteLine("avg = {0:F2}", averageNumbers);
    }
}