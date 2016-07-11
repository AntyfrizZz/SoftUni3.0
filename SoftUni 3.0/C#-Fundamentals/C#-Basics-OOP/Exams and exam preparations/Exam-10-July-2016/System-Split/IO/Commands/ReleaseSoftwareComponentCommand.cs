namespace SystemSplit.IO.Commands
{
    using System;

    class ReleaseSoftwareComponentCommand : Command
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

            SystemInfo.HardwareComponets[hardwareComponentName].RemoveSoftware(this.softwarename);

        }
    }
}
