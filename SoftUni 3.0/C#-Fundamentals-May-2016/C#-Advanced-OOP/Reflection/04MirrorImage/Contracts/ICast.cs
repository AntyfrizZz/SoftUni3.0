namespace _04MirrorImage.Contracts
{
    using System;

    public interface ICast
    {
        int Id { get; }

        event EventHandler CastFireballEvent;

        event EventHandler CastReflectionEvent;

        void CastFireball(object sender, EventArgs eventArgs);

        void CastReflection(object sender, EventArgs eventArgs);
    }
}
