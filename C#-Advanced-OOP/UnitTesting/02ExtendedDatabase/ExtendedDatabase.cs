namespace _02ExtendedDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtendedDatabase
    {
        private const int DefaultCapacity = 16;
        private Person[] elements;
        private int currentIndex;

        public ExtendedDatabase(IEnumerable<Person> elements)
        {
            this.Elements = elements.ToArray();
        }

        public Person[] Elements
        {
            get
            {
                List<Person> numbers = new List<Person>();
                for (int i = 0; i < this.currentIndex; i++)
                {
                    numbers.Add(this.elements[i]);
                }

                return numbers.ToArray();
            }
            private set
            {
                if (value.Length > 16 || value.Length < 1)
                {
                    throw new InvalidOperationException();
                }

                this.elements = new Person[DefaultCapacity];
                int bufferIndex = 0;

                foreach (Person element in value)
                {
                    this.elements[bufferIndex++] = element;
                }

                this.currentIndex = value.Length;
            }
        }

        public int Capacity => DefaultCapacity;

        public int Count => this.currentIndex;

        public void Add(Person element)
        {
            if (this.currentIndex == DefaultCapacity)
            {
                throw new InvalidOperationException("Cannot add more elements in the database.");
            }
            if (this.Elements.FirstOrDefault(p => p.Id == element.Id) != null)
            {
                throw new InvalidOperationException("Person with that id is already in the database.");
            }
            if (this.Elements.FirstOrDefault(p => p.Username == element.Username) != null)
            {
                throw new InvalidOperationException("Person with that username is already in the database.");
            }
            this.elements[this.currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty database!");
            }

            this.elements[this.currentIndex] = default(Person);
            this.currentIndex--;
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id must be a positive number!");
            }

            Person person = this.Elements.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                throw new InvalidOperationException("User with id: " + id + " was not found!");
            }

            return person;
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }

            Person person = this.Elements.FirstOrDefault(x => x.Username == username);
            if (person == null)
            {
                throw new InvalidOperationException("User with username: " + username + " was not found!");
            }

            return person;
        }
    }

}
