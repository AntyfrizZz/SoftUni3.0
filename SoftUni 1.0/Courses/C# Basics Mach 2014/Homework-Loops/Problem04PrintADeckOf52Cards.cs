using System;
//Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers).
//The cards should be printed using the classical notation (like 5♠, A♥, 9♣ and K♦). The card faces should start from 2 to A.
//Print each card face in its four possible suits: clubs, diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class PrintADeckOf52Cards
{
    static void Main()
    {
        Console.Title = "Problem 4.	Print a Deck of 52 Cards";

        char spades = '\x2663';            
        char diamonds = '\x2666';
        char hearts = '\x2665';
        char club = '\x2660';

        for (int i = 2; i < 15; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i < 11)
                {
                    Console.Write("{0,-2}", i);

                    switch (j)
                    {
                        case 0:
                            Console.Write("{0,-1} ", spades);
                            break;
                        case 1:
                            Console.Write("{0,-1} ", diamonds);
                            break;
                        case 2:
                            Console.Write("{0,-1} ", hearts);
                            break;
                        case 3:
                            Console.Write("{0,-1} ", club);
                            break;
                    }         
                }
                else if (i == 11)
                {
                    string jack = "J";
                    Console.Write("{0,-2}", jack);

                    switch (j)
                    {
                        case 0:
                            Console.Write("{0,-1} ", spades);
                            break;
                        case 1:
                            Console.Write("{0,-1} ", diamonds);
                            break;
                        case 2:
                            Console.Write("{0,-1} ", hearts);
                            break;
                        case 3:
                            Console.Write("{0,-1} ", club);
                            break;
                    }         
                }                    
                else if (i == 12)
                {
                    string queen = "Q";
                    Console.Write("{0,-2}", queen);

                    switch (j)
                    {
                        case 0:
                            Console.Write("{0,-1} ", spades);
                            break;
                        case 1:
                            Console.Write("{0,-1} ", diamonds);
                            break;
                        case 2:
                            Console.Write("{0,-1} ", hearts);
                            break;
                        case 3:
                            Console.Write("{0,-1} ", club);
                            break;
                    }
                }
                else if (i == 13)
                {
                    string king = "K";
                    Console.Write("{0,-2}", king);

                    switch (j)
                    {
                        case 0:
                            Console.Write("{0,-1} ", spades);
                            break;
                        case 1:
                            Console.Write("{0,-1} ", diamonds);
                            break;
                        case 2:
                            Console.Write("{0,-1} ", hearts);
                            break;
                        case 3:
                            Console.Write("{0,-1} ", club);
                            break;
                    }
                }
                else
                {
                    string ace = "A";
                    Console.Write("{0,-2}", ace);

                    switch (j)
                    {
                        case 0:
                            Console.Write("{0,-1} ", spades);
                            break;
                        case 1:
                            Console.Write("{0,-1} ", diamonds);
                            break;
                        case 2:
                            Console.Write("{0,-1} ", hearts);
                            break;
                        case 3:
                            Console.Write("{0,-1} ", club);
                            break;
                    }
                }                    
            }
            Console.WriteLine();
        }
    }
}