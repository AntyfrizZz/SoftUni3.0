using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//We have a report that holds dates, web site URLs and load times (in seconds) in the same format like in the examples below. 
//Your tasks is to calculate the average load time for each URL. Print the URLs in the same order as they first appear in the input report. 
//Print the output in the format given below. Use double floating-point precision. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

class AverageLoadTimeCalculator
{
    static void Main()
    {
        string line = Console.ReadLine();
        Dictionary<string, double> sites = new Dictionary<string, double>();
        Dictionary<string, int> counters = new Dictionary<string, int>();
        int counter = 1;
        while (line != string.Empty)
        {
            string[] list = line.Split(' ');
            string link = list[2];
            double loadTime = double.Parse(list[3]);

            if (!sites.Keys.Contains(link))
            {
                sites[link] = loadTime; counters.Add(link, 1);
            }
            else
            {
                counters[link] += 1;
                sites[link] = sites[link] + loadTime;
            }

            line = Console.ReadLine();
        }
        foreach (string link in sites.Keys)
        {
            Console.WriteLine("{0} = {1:F7}", link, sites[link] / counters[link]);
        }          
    }
}