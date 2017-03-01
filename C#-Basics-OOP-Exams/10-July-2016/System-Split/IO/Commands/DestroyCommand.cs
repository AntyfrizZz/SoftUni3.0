namespace SystemSplit.IO.Commands
{
    using System;

    public class DestroyCommand : Command
    {
        private string hardwareComponentName;

        public DestroyCommand(string hardwareComponentName)
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

            SystemInfo.DumpedHardwareComponets.Remove(this.hardwareComponentName);
        }
    }
}
