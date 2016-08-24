namespace LambdaCore_Skeleton.Core.Commands
{
    using Attributes;
    using Contracts.Core;
    using Contracts.Models;
    using Contracts.Repositories;

    public class StatusCommand : Command
    {
        [Inject]
        private IRepository powerPlantRepository;

        public StatusCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            return this.powerPlantRepository.Status();
        }
    }
}
