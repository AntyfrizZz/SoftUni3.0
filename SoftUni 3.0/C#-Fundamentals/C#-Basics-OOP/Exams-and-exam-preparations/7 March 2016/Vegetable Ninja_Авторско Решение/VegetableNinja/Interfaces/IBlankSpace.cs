namespace VegetableNinja.Interfaces
{
    using VegetableNinja.Enumerations;

    public interface IBlankSpace : IGameObject
    {
        int GrowthTime { get; }

        VegetableType VegetableHolder { get; }

        void Grow();
    }
}
