namespace LambdaCore_Skeleton.Core.Commands
{
    using Attributes;
    using Contracts.Core;
    using Contracts.Models;
    using Contracts.Repositories;

    public class CreateCoreCommand : Command
    {
        [Inject]
        private ICoreFactory coreFactory;

        [Inject]
        private IRepository powerPlantRepository;

        public CreateCoreCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var coreType = this.Data[1];
            var coreDurability = int.Parse(this.Data[2]);

            ICore coreToAdd = this.coreFactory.CreateCore(coreType, coreDurability);
            this.powerPlantRepository.AddCore(coreToAdd);

            return $"Successfully created Core {coreToAdd.Name}!";
        }
    }
}
