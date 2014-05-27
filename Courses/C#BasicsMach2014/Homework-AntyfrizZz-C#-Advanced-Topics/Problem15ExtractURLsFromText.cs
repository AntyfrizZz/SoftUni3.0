using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a program that extracts and prints all URLs from given text. URL can be in only two formats:

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

class ExtractURLsFromText
{
    static void Main()
    {
        A:

        string input = Console.ReadLine();
        string[] text = input.Split();

        List<string> results = new List<string>();

        foreach (string link in text)
        {
            if (!results.Contains(link) && (link.Length > 6))
            {
                if (link.Substring(0, 7) == "http://" || (link.Substring(0, 4) == "www."))
                {
                    results.Add(link);
                }
            }
        }

        foreach (string link in results)
        {
            Console.WriteLine("{0} ", link);
        }

        goto A;
    }
}