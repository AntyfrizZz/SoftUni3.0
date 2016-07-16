namespace SystemSplit.IO.Commands
{
    using System;
    using System.Linq;
    using System.Text;

    public class SystemSplitCommand : Command
    {
        public override void Execute()
        {
            var result = new StringBuilder();

            var ordered = SystemInfo.HardwareComponets.OrderByDescending(v => v.Value.Type);

            foreach (var hardwareComponet in ordered)
            {
                result.AppendLine(hardwareComponet.Value.ToString());
            }

            Console.Write(result);
        }
    }
}
