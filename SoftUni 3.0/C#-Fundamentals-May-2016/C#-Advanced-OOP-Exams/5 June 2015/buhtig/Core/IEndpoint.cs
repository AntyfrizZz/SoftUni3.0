namespace Buhtig.Core
{
    using System.Collections.Generic;

    public interface IEndpoint
    {
        string ActionName { get; }

        IDictionary<string, string> ActionParameters { get; }
    }
}
