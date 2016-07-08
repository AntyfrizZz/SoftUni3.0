using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bag;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bag = new List<Product>();
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }
    public decimal Money
    {
        get { return this.money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public List<Product> Bag => this.bag;

    public void BuyProduct(Product product)
    {
        if (product.Price > this.money)
        {
            throw new InvalidOperationException($"{this.name} can't afford {product.Name}");
        }

        this.money -= product.Price;
        this.bag.Add(product);
    }
}

public class Product
{
    private string name;
    private decimal price;

    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }

            this.name = value;
        }
    }

    public decimal Price
    {
        get
        {
            return this.price;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        return this.name;
    }
}

class Startup
{
    static void Main()
    {
        var peopleCotainer = new Dictionary<string, Person>();
        var productContainer = new Dictionary<string, Product>();

        var people = Console.ReadLine()
            .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            foreach (var currentPerson in people)
            {
                var tokens = currentPerson.Split('=');
                var name = tokens[0];
                var money = decimal.Parse(tokens[1]);

                var person = new Person(name, money);
                peopleCotainer.Add(name, person);
            }

            var products = Console.ReadLine()
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var currentProduct in products)
            {
                var tokens = currentProduct.Split('=');
                var name = tokens[0];
                var price = decimal.Parse(tokens[1]);

                var product = new Product(name, price);
                productContainer.Add(name, product);
            }

            var command = Console.ReadLine();

            while (!command.Equals("END"))
            {
                var tokens = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var personName = tokens[0];
                var productName = tokens[1];

                try
                {
                    var person = peopleCotainer[personName];
                    var product = productContainer[productName];
                    person.BuyProduct(product);

                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
            }

            foreach (string person in peopleCotainer.Keys)
            {
                var items = string.Join(", ", peopleCotainer[person].Bag);
                var result = !peopleCotainer[person].Bag.Any() ? "Nothing bought" : items;

                Console.WriteLine($"{person} - {result}");
            }
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}