using System;
//Write a program to read your age from the console and print how old you will be after 10 years.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/1.%20Introduction-to-Programming-Homework.docx

class AgeAfterYears
{
    static void Main()
    {
        Console.Write("Please write your age: ");
        int CurrentAge = int.Parse(Console.ReadLine());
        int FutureAge = CurrentAge + 10;
        Console.WriteLine("After 10 years you will be " + FutureAge + " years old");
    }
}
