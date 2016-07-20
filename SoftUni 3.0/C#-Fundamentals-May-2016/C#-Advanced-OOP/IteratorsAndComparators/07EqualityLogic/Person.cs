namespace _07EqualityLogic
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public int Age { get; }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            if (other == null)
            {
                return false;
            }

            if (this.CompareTo(other) == 0)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = this.Age;

            hash = hash * 486187739 + this.Name.GetHashCode();

            return hash;
        }

        public int CompareTo(Person other)
        {
            int result = string.Compare(this.Name, other.Name, StringComparison.Ordinal);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
