namespace LambdaCore_Skeleton.Contracts.Core
{
    using Models;

    public interface ICoreFactory
    {
        ICore CreateCore(string type, int durability);
    }
}
