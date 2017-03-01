namespace _07.Food_Shortage
{
    public abstract class Human : IBuyable
    {
        protected Human(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }

        public int Age { get; }
        public int Food { get; protected set; }

        public abstract void BuyFood();
    }
}
