namespace _05.Border_Control
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; }

        public int Age { get; }

        public string Id { get; }
    }
}
