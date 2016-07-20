namespace _08PetClinics
{
    using System;
    using System.Collections.Generic;

    public class Pet : IComparable<Pet>
    {
        public static Dictionary<string, Pet> pets = new Dictionary<string, Pet>();

        private readonly string name;
        private readonly int age;
        private readonly string kind;

        public Pet(string name, int age, string kind)
        {
            this.name = name;
            this.age = age;
            this.kind = kind;

            pets.Add(this.name, this);
        }

        public int CompareTo(Pet other)
        {
            var result = string.Compare(this.name, other.name, StringComparison.Ordinal);

            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
            }

            if (result == 0)
            {
                result = string.Compare(this.kind, other.kind, StringComparison.Ordinal);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.name} {this.age} {this.kind}";
        }
    }
}
