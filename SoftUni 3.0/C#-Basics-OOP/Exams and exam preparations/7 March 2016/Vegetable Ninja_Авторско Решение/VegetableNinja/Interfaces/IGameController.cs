namespace VegetableNinja.Interfaces
{
    public interface IGameController
    {
        IDatabase Database { get; }

        INinja WinnerNinja { get; }

        void ProcessInput(string inputLine);

        void InitialiseGameData(string firstNinjaName);
    }
}
