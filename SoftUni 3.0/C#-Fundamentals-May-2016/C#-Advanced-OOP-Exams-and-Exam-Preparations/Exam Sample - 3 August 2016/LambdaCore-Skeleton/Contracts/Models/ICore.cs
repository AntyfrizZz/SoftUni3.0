namespace LambdaCore_Skeleton.Contracts.Models
{
    using Enumerations;

    public interface ICore
    {
        char Name { get; }

        CoreState State { get; }

        void AddFragment(IFragment fragment);

        IFragment RemoveLastFragment();

        int FragmentsCount();

        int Durability();
    }
}
