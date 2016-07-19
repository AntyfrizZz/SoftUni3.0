using System;

namespace _08.Military_Elite.Models
{
    using System.Collections.Generic;

    using Interfaces;

    public class Private : IPrivate
    {
        public static List<Private> privates = new List<Private>();

        public Private(string id, string firstName, string lastname, decimal salary)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.Lastname = lastname;
            this.Salary = salary;

            privates.Add(this);
        }

        public string Id { get; }

        public string FirstName { get; }

        public string Lastname { get; }

        public decimal Salary { get; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.Lastname} Id: {this.Id} Salary: {this.Salary:F2}{Environment.NewLine}";
        }
    }
}
