namespace Buhtig.Core
{
    public interface IDispatcher
    {
        string DispatchAction(IEndpoint endpoint);
    }
}
