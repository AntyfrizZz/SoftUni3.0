namespace _05ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class Person : IComparable<Person>
    {
        private static List<Person> people = new List<Person>();

        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;

            people.Add(this);
        }


        public int CompareTo(Person other)
        {
            if (this.name.Equals(other.name) &&
                this.age == other.age &&
                this.town.Equals(other.town))
            {
                return 1;
            }

            return 0;
        }

        public static string FindDuplicate(int index)
        {
            var duplicateCount = 0;
            var currentPerson = people[index - 1];

            foreach (var person in people)
            {
                if (person.CompareTo(currentPerson) == 1)
                {
                    duplicateCount++;
                }
            }

            if (duplicateCount == 1)
            {
                return "No matches";
            }

            return $"{duplicateCount} {people.Count - duplicateCount} {people.Count}";

        }
    }
}
