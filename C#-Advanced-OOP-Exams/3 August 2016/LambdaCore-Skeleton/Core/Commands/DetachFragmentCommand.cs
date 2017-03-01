namespace LambdaCore_Skeleton.Core.Commands
{
    using System;
    using Attributes;
    using Contracts.Models;
    using Contracts.Repositories;

    public class DetachFragmentCommand : Command
    {
        [Inject]
        private IRepository powerPlantRepository;

        public DetachFragmentCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            IFragment fragment = this.powerPlantRepository.RemoveLastFragment();

            return $"Successfully detached Fragment {fragment.Name} from Core {this.powerPlantRepository.CurrentCoreName()}!";
        }
    }
}
