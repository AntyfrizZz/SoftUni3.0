namespace SystemSplit.IO.Commands
{
    public class DumpAnalyzeCommand : Command
    {
        public override void Execute()
        {
            SystemInfo.DumpAnalize();
        }
    }
}
