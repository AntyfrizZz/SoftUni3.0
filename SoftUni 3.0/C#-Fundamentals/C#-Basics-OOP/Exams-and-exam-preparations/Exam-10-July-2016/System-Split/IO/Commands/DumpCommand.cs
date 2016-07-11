namespace SystemSplit.IO.Commands
{
    using System;

    class DumpCommand : Command
    {
        private string hardwareComponentName;

        public DumpCommand(string hardwareComponentName)
        {
            this.hardwareComponentName = hardwareComponentName;
        }

        public override void Execute()
        {
            if (!SystemInfo.HardwareComponets.ContainsKey(hardwareComponentName))
            {
                throw new InvalidOperationException();
            }

            var hardwareComponent = SystemInfo.HardwareComponets[hardwareComponentName];

            SystemInfo.DumpedHardwareComponets.Add(hardwareComponentName, hardwareComponent);
            SystemInfo.HardwareComponets.Remove(hardwareComponentName);
        }
    }
}
