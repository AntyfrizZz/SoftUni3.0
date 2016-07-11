namespace SystemSplit.IO.Commands
{
    using System;

    class DestroyCommand : Command
    {
        private string hardwareComponentName;

        public DestroyCommand(string hardwareComponentName)
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

            SystemInfo.DumpedHardwareComponets.Remove(hardwareComponentName);
        }
    }
}
