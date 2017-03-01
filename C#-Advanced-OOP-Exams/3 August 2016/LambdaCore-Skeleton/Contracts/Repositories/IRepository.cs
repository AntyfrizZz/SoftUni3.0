namespace LambdaCore_Skeleton.Contracts.Repositories
{
    using Models;

    public interface IRepository
    {
        string Status();

        void AddCore(ICore unit);

        void RemoveCore(char coreName);

        void SetCurrentCore(char coreName);

        bool IsCurrentCoreSet();

        char CurrentCoreName();

        void AddFragment(IFragment fragment);

        IFragment RemoveLastFragment();
    }
}
