namespace VegetableNinja.Interfaces
{
    public interface IGameObject
    {
        IMatrixPosition Position { get; }

        char CharValue { get; }
    }
}
