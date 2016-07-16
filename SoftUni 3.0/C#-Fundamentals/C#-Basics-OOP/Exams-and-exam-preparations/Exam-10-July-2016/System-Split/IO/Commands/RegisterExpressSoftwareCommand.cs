namespace SystemSplit.IO.Commands
{
    public class RegisterExpressSoftwareCommand : Command
    {
        private string hardwareComponentName;
        private string name;
        private int capacity;
        private int memory;

        public RegisterExpressSoftwareCommand(string hardwareComponentName, string name, int capacity, int memory)
        {
            this.hardwareComponentName = hardwareComponentName;
            this.name = name;
            this.capacity = capacity;
            this.memory = memory;
        }

        public override void Execute()
        {
            var software = new ExpressSoftware(this.hardwareComponentName, this.name, this.capacity, this.memory);

            SystemInfo.HardwareComponets[this.hardwareComponentName].AddSoftware(software);
        }
    }
}
