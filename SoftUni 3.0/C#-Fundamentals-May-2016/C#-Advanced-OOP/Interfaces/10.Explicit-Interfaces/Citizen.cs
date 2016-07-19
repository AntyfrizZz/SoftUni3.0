namespace _10.Explicit_Interfaces
{
    using System;

    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        public string Name { get; }

        public string Country { get; }

        public int Age { get; }

        void IPerson.GetName()
        {
            Console.WriteLine(this.Name);
        }

        void IResident.GetName()
        {
            Console.WriteLine("Mr/Ms/Mrs " + this.Name);
        }
    }
}
