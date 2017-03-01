namespace _06.Birthday_Celebrations
{
    using Interfaces;

    public class Citizen : IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthdate;
        }

        public string Name { get; }

        public int Age { get; }

        public string Id { get; }

        public string BirthDate { get; }
    }
}
