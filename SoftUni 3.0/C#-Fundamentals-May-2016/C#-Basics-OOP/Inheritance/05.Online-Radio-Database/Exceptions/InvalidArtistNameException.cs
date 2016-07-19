namespace OnlineRadioDatabase.Exceptions
{
    using System;

    class InvalidArtistNameException : InvalidSongException
    {
        private new const string Message = "Artist name should be between 3 and 20 symbols.";

        public InvalidArtistNameException()
            : base(Message)
        {
        }
    }
}
