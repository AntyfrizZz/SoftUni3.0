using System;
//Write a program that applies bonus score to given score in the range [1…9] by the following rules:
//•	If the score is between 1 and 3, the program multiplies it by 10.
//•	If the score is between 4 and 6, the program multiplies it by 100.
//•	If the score is between 7 and 9, the program multiplies it by 1000.
//•	If the score is 0 or more than 9, the program prints “invalid score”.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/5.%20Conditional-Statements-Homework.docx

    class Program
    {
        static void Main()
        {
            Console.Title = "Problem 2.	Bonus Score";

            Console.Write("score: ");
            double score = double.Parse(Console.ReadLine());

            if (1 <= score & score <= 3)
            {
                score *= 10;
                Console.WriteLine(score);
            }
            else if (4 <= score & score <= 6)
            {
                score *= 100;
                Console.WriteLine(score);
            }
            else if (7 <= score & score <= 9)
            {
                score *= 1000;
                Console.WriteLine(score);
            }
            else if (score <= 0 | 9 <= score)
            {
                Console.WriteLine("Invalid score");
            }
        }
    }