namespace SystemSplit.IO.Commands
{
    public class AnalyzeCommand : Command
    {
        public override void Execute()
        {
            SystemInfo.Analize();
        }
    }
}
