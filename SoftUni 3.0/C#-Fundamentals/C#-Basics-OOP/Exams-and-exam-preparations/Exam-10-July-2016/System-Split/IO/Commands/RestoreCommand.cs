namespace SystemSplit.IO.Commands
{
    using System;

    public class RestoreCommand : Command
    {
        private string hardwareComponentName;

        public RestoreCommand(string hardwareComponentName)
        {
            this.hardwareComponentName = hardwareComponentName;
        }

        public override void Execute()
        {
            if (!SystemInfo.DumpedHardwareComponets.ContainsKey(this.hardwareComponentName))
            {
                throw new InvalidOperationException();
            }

            var hardwareComponent = SystemInfo.DumpedHardwareComponets[this.hardwareComponentName];

            SystemInfo.HardwareComponets.Add(this.hardwareComponentName, hardwareComponent);
            SystemInfo.DumpedHardwareComponets.Remove(this.hardwareComponentName);
        }
    }
}
