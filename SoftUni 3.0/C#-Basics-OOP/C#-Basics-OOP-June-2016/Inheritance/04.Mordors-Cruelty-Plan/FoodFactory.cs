namespace MordorsCrueltyPlan
{
    using MordorsCrueltyPlan.Foods;

    class FoodFactory
    {
        public static Food MakeFood(string foodWannaBe)
        {
            switch (foodWannaBe.ToLower())
            {
                case "apple":
                    return new Apple();
                case "cram":
                    return new Cram();
                case "honeycake":
                    return new HoneyCake();
                case "lembas":
                    return new Lembas();
                case "melon":
                    return new Melon();
                case "mushrooms":
                    return new Mushrooms();
                default:
                    return new Junk();
            }
        }
    }
}
