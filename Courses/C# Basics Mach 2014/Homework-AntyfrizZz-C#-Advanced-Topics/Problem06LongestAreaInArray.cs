using System;
//Write a program to find the longest area of equal elements in array of strings. 
//You first should read an integer n and n strings (each at a separate line), then 
//find and print the longest sequence of equal elements (first its length, then its 
//elements). If multiple sequences have the same maximal length, print the leftmost 
//of them. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

public class LongestArea
{
    public static void Main()
    {
        Console.Write("Enter n: ");
        int ellements = int.Parse(Console.ReadLine());
        string[] input = new string[ellements];

        for (int i = 0; i < ellements; i++)
        {
            input[i] = Console.ReadLine();
        }

        string currntString = input[0];
        int currLength = 1;
        int bestLength = currLength;

        for (int i = 0; i < input.Length - 1; i++)
        {
            if (input[i] == input[i + 1])
            {
                currLength++;
            }

            else
            {
                currLength = 1;
            }

            if (bestLength < currLength)
            {
                bestLength = currLength;
                currntString = input[i];
            }
        }
        Console.WriteLine(bestLength);
        for (int i = 0; i < bestLength; i++)
        {
            Console.WriteLine(currntString);
        }
    }
}