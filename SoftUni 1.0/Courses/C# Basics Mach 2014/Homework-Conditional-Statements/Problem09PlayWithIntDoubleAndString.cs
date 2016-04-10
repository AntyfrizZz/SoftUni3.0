using System;
//Write a program that, depending on the user’s choice, inputs an int, double or string variable. If the variable is int or double, the program increases it by one.
//If the variable is a string, the program appends "*" at the end. Print the result at the console. Use switch statement. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/5.%20Conditional-Statements-Homework.docx

class PlayWithIntDoubleAndString
{
    static void Main()
    {
        Console.Title = "Problem 9.	Play with Int, Double and String";

        Console.WriteLine("Please choose a type: ");
        Console.WriteLine("1 --> int");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");
        int inputNumber = int.Parse(Console.ReadLine());

        while ((inputNumber < 1) || (inputNumber > 3))
        {
            Console.WriteLine("Please choose a type: ");
            Console.WriteLine("1 --> int");
            Console.WriteLine("2 --> double");
            Console.WriteLine("3 --> string");
            inputNumber = int.Parse(Console.ReadLine());
        }

        switch (inputNumber)
        {
            case 1:
                Console.Write("Please enter an int: ");
                int intNumber = int.Parse(Console.ReadLine());
                intNumber += 1;
                Console.WriteLine(intNumber);
                break;
            case 2:
                Console.Write("Please enter a double: ");
                double dblNumber = double.Parse(Console.ReadLine());
                dblNumber += 1;
                Console.WriteLine(dblNumber);
                break;
            case 3:
                Console.Write("Please enter a string: ");
                string someString = Console.ReadLine();
                Console.WriteLine("{0}*", someString);
                break;
        }
    }
}