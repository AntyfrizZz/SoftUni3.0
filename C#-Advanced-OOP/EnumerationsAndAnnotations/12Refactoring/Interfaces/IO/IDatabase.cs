namespace _12Refactoring.Interfaces.IO
{
    public interface IDatabase<T>
    {
        void Add(T weapon);

        T Get(string name);
    }
}
