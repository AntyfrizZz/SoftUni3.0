namespace LambdaCore_Skeleton.Contracts.Core
{
    using Models;

    public interface IFragmentFactory
    {
        IFragment CreateFragment(string type, string name, int pressure);
    }
}
