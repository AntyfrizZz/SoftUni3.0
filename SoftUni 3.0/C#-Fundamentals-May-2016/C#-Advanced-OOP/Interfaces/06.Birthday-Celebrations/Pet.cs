namespace _06.Birthday_Celebrations
{
    using Interfaces;

    public class Pet : IBirthable
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; }

        public string BirthDate { get; }
    }
}
