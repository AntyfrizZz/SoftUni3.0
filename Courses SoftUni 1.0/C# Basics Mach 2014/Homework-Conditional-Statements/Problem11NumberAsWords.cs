using System;
//Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/5.%20Conditional-Statements-Homework.docx

class NumberAsWords
{
    static void Main()
    {
        Console.Title = "Problem 11.* Number as Words";

        Console.Write("Please enter a number (0 - 999)");
        int inputNumber = int.Parse(Console.ReadLine());

        while ((inputNumber > 999) || (inputNumber < 0))
        {
            Console.Write("Please enter a number (0 - 999)");
            inputNumber = int.Parse(Console.ReadLine());
        }

        int ones = inputNumber % 10;
        int tens = (inputNumber / 10) % 10;
        int hundreds = (inputNumber / 100) % 10;

        if ((ones == 0) && (tens == 0) && (hundreds == 0))
        {
            Console.WriteLine("Zero");
        }
        else
	    {	
            switch (hundreds)
            {
                case 1:
                    Console.Write("One hundred");
                    break;
                case 2:
                    Console.Write("Two hundred");
                    break;
                case 3:
                    Console.Write("Three hundred");
                    break;
                case 4:
                    Console.Write("Four hundred");
                    break;
                case 5:
                    Console.Write("Five hundred");
                    break;
                case 6:
                    Console.Write("Six hundred");
                    break;
                case 7:
                    Console.Write("Seven hundred");
                    break;
                case 8:
                    Console.Write("Eight hundred");
                    break;
                case 9:
                    Console.Write("Nine hundred");
                    break;
                default:
                    break;
            }

            if ((hundreds != 0) && (ones != 0))
            {
                Console.Write(" and ");
            }
            else if ((hundreds != 0) && (tens != 0))
            {
                Console.Write(" and ");
            }

            switch (tens)
            {
                case 1:
                    if (ones == 1)
                    {
                        Console.WriteLine("eleven");
                    }
                    else if (ones == 2)
	                {
                        Console.WriteLine("twelve");
	                }
                    else if (ones == 3)
	                {
                        Console.WriteLine("thirteen");
	                }
                    else if (ones == 4)
	                {
                        Console.WriteLine("fourteen");
	                }
                    else if (ones == 5)
	                {
                        Console.WriteLine("fifteen");
	                }
                    else if (ones == 6)
	                {
                        Console.WriteLine("sixteen");
	                }
                    else if (ones == 7)
	                {
                        Console.WriteLine("seventeen");
	                }
                    else if (ones == 8)
	                {
                        Console.WriteLine("eighteen ");
	                }
                    else if (ones == 9)
	                {
                        Console.WriteLine("nineteen");
	                }
                    else if (ones == 0)
                    {
                        Console.WriteLine("ten");
                    }
                    break;
                case 2:
                    Console.Write("twenty ");
                    break;
                case 3:
                    Console.Write("thirty ");
                    break;
                case 4:
                    Console.Write("fourty ");
                    break;
                case 5:
                    Console.Write("fifty ");
                    break;
                case 6:
                    Console.Write("sixty ");
                    break;
                case 7:
                    Console.Write("seventy ");
                    break;
                case 8:
                    Console.Write("eighty ");
                    break;
                case 9:
                    Console.Write("ninety ");
                    break;            
             }

            if (tens != 1)
            {
                switch (ones)
                {
                    case 1:
                        Console.WriteLine("one");
                        break;
                    case 2:
                        Console.WriteLine("two");
                        break;
                    case 3:
                        Console.WriteLine("three");
                        break;
                    case 4:
                        Console.WriteLine("four");
                        break;
                    case 5:
                        Console.WriteLine("five");
                        break;
                    case 6:
                        Console.WriteLine("six");
                        break;
                    case 7:
                        Console.WriteLine("seven");
                        break;
                    case 8:
                        Console.WriteLine("eight");
                        break;
                    case 9:
                        Console.WriteLine("nine");
                        break;
                }
            }
        }
    }
}