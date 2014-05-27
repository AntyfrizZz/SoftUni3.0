using System;
//Classical play cards use the following signs to designate the card face: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A.
//Write a program that enters a string and prints “yes” if it is a valid card sign or “no” otherwise.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/5.%20Conditional-Statements-Homework.docx

class CheckForAPlayCard
{
    static void Main()
    {
        Console.Title = "Problem 3.	Check for a Play Card";

        Console.Write("Please enter a character: ");
        string character = Console.ReadLine();

        switch (character)
        {
            case "2": 
                Console.WriteLine("Yes");
                break;
            case "3": 
                Console.WriteLine("Yes");
                break;
            case "4": 
                Console.WriteLine("Yes");
                break;
            case "5": 
                Console.WriteLine("Yes");
                break;
            case "6": 
                Console.WriteLine("Yes");
                break;
            case "7": 
                Console.WriteLine("Yes");
                break;
            case "8": 
                Console.WriteLine("Yes");
                break;
            case "9": 
                Console.WriteLine("Yes");
                break;
            case "10": 
                Console.WriteLine("Yes");
                break;
            case "A": 
                Console.WriteLine("Yes");
                break;
            case "J": 
                Console.WriteLine("Yes");
                break;
            case "Q": 
                Console.WriteLine("Yes");
                break;
            case "K": 
                Console.WriteLine("Yes");
                break;
            default: 
                Console.WriteLine("No"); ;
                break;
        }
    }
}