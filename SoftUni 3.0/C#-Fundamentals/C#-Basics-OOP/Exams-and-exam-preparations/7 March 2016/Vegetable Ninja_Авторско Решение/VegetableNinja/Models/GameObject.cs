namespace VegetableNinja.Models
{
    using VegetableNinja.Exceptions;
    using VegetableNinja.Interfaces;

    public abstract class GameObject : IGameObject
    {
        private IMatrixPosition position;

        private char charValue;

        protected GameObject(IMatrixPosition position, char charValue)
        {
            this.Position = position;
            this.CharValue = charValue;
        }

        public IMatrixPosition Position
        {
            get
            {
                return this.position;
            }

            protected set
            {
                this.position = value;
            }
        }

        public char CharValue
        {
            get
            {
                return this.charValue;
            }

            private set
            {
                this.charValue = value;
            }
        }
    }
}
