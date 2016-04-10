using System;
using System.Globalization;
using System.Threading;
//A beer time is after 1:00 PM and before 3:00 AM. Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12],
//a minute in range [00…59] and AM / PM designator) and prints “beer time” or “non-beer time” according to the definition above or “invalid time” if 
//the time cannot be parsed. Note that you may need to learn how to parse dates and times.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/5.%20Conditional-Statements-Homework.docx

class BeerTime
{
    static void Main()
    {
        Console.Title = "Problem 10.* Beer Time";

        CultureInfo enUS = new CultureInfo("en-US");

        DateTime time;
        DateTime startTime = DateTime.Parse("01:00 PM");
        DateTime endTime = DateTime.Parse("03:00 AM");
        string dateString = Console.ReadLine();

        if (DateTime.TryParseExact(dateString, "hh:mm tt", enUS, DateTimeStyles.None, out time))
        {
            if (time >= startTime || time <= endTime)
            {
                Console.WriteLine("beer time");
            }
            else
            {
                Console.WriteLine("non-beer time");
            }
        }
        else
        {
            Console.WriteLine("invalid time");
        }
    }
}