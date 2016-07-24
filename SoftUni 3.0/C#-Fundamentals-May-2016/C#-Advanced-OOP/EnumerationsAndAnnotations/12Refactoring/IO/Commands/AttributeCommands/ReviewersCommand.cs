namespace _12Refactoring.IO.Commands.AttributeCommands
{
    using Attributes;
    using Factories.WeaponFactory.Weapons;

    public class ReviewersCommand : Command
    {
        public override void Execute()
        {
            var attributes = typeof(Weapon).GetCustomAttributes(false);

            foreach (ClassInfoAttribute info in attributes)
            {
                OutputWriter.WriteMessageOnNewLine($"Reviewers: {string.Join(", ", info.Reviewers)}");
            }
        }
    }
}
