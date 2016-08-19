namespace AirConditionerTester.IO
{
    using Commands;

    public interface IInjector
    {
        void Inject(IExecutable command);
    }
}
