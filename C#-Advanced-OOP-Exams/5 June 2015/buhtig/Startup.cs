namespace Buhtig
{
    using System.Globalization;
    using System.Threading;
    using Core;

    public class Startup
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = new Engine();
            engine.Run();
        }
    }
}
