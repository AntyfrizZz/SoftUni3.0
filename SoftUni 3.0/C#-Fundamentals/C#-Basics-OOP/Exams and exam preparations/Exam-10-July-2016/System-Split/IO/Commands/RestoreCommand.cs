namespace SystemSplit.IO.Commands
{
    using System;

    class RestoreCommand : Command
    {
        private string hardwareComponentName;

        public RestoreCommand(string hardwareComponentName)
        {
            this.hardwareComponentName = hardwareComponentName;
        }

        public override void Execute()
        {
            if (!SystemInfo.DumpedHardwareComponets.ContainsKey(hardwareComponentName))
            {
                throw new InvalidOperationException();
            }

            var hardwareComponent = SystemInfo.DumpedHardwareComponets[hardwareComponentName];

            SystemInfo.HardwareComponets.Add(hardwareComponentName, hardwareComponent);
            SystemInfo.DumpedHardwareComponets.Remove(hardwareComponentName);
        }
    }
}
