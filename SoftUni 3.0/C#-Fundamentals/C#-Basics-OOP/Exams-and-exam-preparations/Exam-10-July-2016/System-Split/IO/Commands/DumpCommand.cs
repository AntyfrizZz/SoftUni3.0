namespace SystemSplit.IO.Commands
{
    using System;

    public class DumpCommand : Command
    {
        private string hardwareComponentName;

        public DumpCommand(string hardwareComponentName)
        {
            this.hardwareComponentName = hardwareComponentName;
        }

        public override void Execute()
        {
            if (!SystemInfo.HardwareComponets.ContainsKey(this.hardwareComponentName))
            {
                throw new InvalidOperationException();
            }

            var hardwareComponent = SystemInfo.HardwareComponets[this.hardwareComponentName];

            SystemInfo.DumpedHardwareComponets.Add(this.hardwareComponentName, hardwareComponent);
            SystemInfo.HardwareComponets.Remove(this.hardwareComponentName);
        }
    }
}
