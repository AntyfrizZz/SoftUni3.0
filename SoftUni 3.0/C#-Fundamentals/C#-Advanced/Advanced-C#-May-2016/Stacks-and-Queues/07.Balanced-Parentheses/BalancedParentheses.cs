using System;
using System.Collections.Generic;

class BalancedParentheses
{
    static void Main()
    {
        var parentheses = Console.ReadLine();

        //Odd count of parentheses
        if (parentheses.Length % 2 != 0)
        {
            Console.WriteLine("NO");
            return;
        }

        var isBalanced = true;

        var openPars = new Stack<char>();

        for (int i = 0; i < parentheses.Length; i++)
        {
            char currentPar = parentheses[i];

            if (currentPar == '(' || currentPar == '[' || currentPar == '{')
            {
                openPars.Push(currentPar);
            }
            else //if closing par
            {
                //if we dont have open one befor it, return
                if (openPars.Count == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }

                char popped = openPars.Pop();

                if (popped == '(')
                {
                    if (currentPar != ')')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (popped == '[')
                {
                    if (currentPar != ']')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (popped == '{')
                {
                    if (currentPar != '}')
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }            
        }

        if (isBalanced)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}