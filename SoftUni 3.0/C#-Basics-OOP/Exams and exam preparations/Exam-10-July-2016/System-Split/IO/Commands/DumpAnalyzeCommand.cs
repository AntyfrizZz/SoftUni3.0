namespace SystemSplit.IO.Commands
{
    class DumpAnalyzeCommand : Command
    {
        public override void Execute()
        {
            SystemInfo.DumpAnalize();
        }
    }
}
