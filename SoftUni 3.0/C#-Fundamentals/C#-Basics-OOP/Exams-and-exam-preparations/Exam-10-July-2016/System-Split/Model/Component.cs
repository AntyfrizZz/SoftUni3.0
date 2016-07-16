namespace SystemSplit
{
    public abstract class Component
    {
        #region Constructors

        protected Component(string name)
        {
            this.Name = name;
        }

        #endregion Constructors

        #region Properties

        public string Type { get; protected set; }

        public string Name { get; }

        #endregion Properties
    }
}