namespace VegetableNinja.Interfaces
{
    using System;

    public interface IMatrixPosition : IEquatable<IMatrixPosition>
    {
        int PositionX { get; }

        int PositionY { get; }
    }
}
