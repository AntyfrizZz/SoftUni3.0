namespace SystemSplit.IO.Commands
{
    class AnalyzeCommand : Command
    {
        public override void Execute()
        {
            SystemInfo.Analize();
        }
    }
}
