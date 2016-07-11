namespace VegetableNinja.Interfaces
{
    using System.Collections.Generic;

    public interface IDatabase
    {
        IEnumerable<INinja> Ninjas { get; }

        IEnumerable<IVegetable> Vegetables { get; }

        IEnumerable<IBlankSpace> GrowingVegetables { get; }

        IEnumerable<IEnumerable<IGameObject>> GameField { get; }

        void AddNinja(INinja ninja);

        void AddVegetable(IVegetable vegetable);

        void RemoveVegetable(IVegetable vegetable);

        void AddGrowingVegetable(IBlankSpace growingVegetable);

        void SetGameFieldObject(IMatrixPosition position, IGameObject gameObject);

        void SeedField(IList<string> inputMatrix, string firstNinjaName, string secondNinjaName);

        INinja GetOtherPlayer(string currentPlayerName);
    }
}
