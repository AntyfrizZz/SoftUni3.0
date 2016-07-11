using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var companyList = new List<Company>();

        var inputLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputLines; i++)
        {
            var companyArgs = Console.ReadLine()
                .Split(new[] { ' ', '|', '-' }, StringSplitOptions.RemoveEmptyEntries);

            companyList.Add(new Company(companyArgs[0], companyArgs[2], int.Parse(companyArgs[1])));
        }

        var sorted = companyList
            .OrderBy(com => com.Name)
            .GroupBy(com => com.Name);

        foreach (var company in sorted)
        {
            var sortedProducts = company
            .GroupBy(prod => prod.Product);

            Console.Write($"{company.Key}: ");

            var tempList = new List<string>();

            foreach (var product in sortedProducts)
            {
                var countt = 0;

                foreach (var count in product)
                {
                    countt += count.Count;
                }

                tempList.Add($"{product.Key}-{countt}");
            }

            Console.WriteLine(string.Join(", ", tempList));
        }
    }
}

class Company
{
    public string Name { get; set; }
    public string Product { get; set; }
    public int Count { get; set; }

    public Company(string name, string product, int count)
    {
        this.Name = name;
        this.Product = product;
        this.Count = count;
    }

    public override string ToString()
    {
        return $"{Product}-{Count}";
    }
}