using System;
//Write a program that enters two dates in format dd.MM.yyyy and returns the number of days between them. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

class DifferenceBetweenDates
{
    static void Main()
    {
        A:
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        DateTime secondDate = DateTime.Parse(Console.ReadLine());

        double days = CountDays(firstDate, secondDate);

        Console.WriteLine(days);

        goto A;
    }

    private static double CountDays(DateTime start, DateTime end)
    {
        TimeSpan span = end - start;
        double result = span.TotalDays;

        return result;
    }
}