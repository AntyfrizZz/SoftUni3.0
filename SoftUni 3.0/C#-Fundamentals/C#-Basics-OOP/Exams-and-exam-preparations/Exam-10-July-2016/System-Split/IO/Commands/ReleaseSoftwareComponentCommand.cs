namespace SystemSplit.IO.Commands
{
    using System;

    public class ReleaseSoftwareComponentCommand : Command
    {
        private string hardwareComponentName;
        private string softwarename;

        public ReleaseSoftwareComponentCommand(string hardwareComponentName, string softwarename)
        {
            this.hardwareComponentName = hardwareComponentName;
            this.softwarename = softwarename;
        }

        public override void Execute()
        {
            if (!SystemInfo.HardwareComponets.ContainsKey(this.hardwareComponentName))
            {
                throw new InvalidOperationException();
            }

            SystemInfo.HardwareComponets[this.hardwareComponentName].RemoveSoftware(this.softwarename);
        }
    }
}
