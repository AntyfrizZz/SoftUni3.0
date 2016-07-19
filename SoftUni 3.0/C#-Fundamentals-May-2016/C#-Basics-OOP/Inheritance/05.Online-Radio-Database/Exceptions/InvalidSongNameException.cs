namespace OnlineRadioDatabase.Exceptions
{
    using System;

    class InvalidSongNameException : InvalidSongException
    {
        private new const string Message = "Song name should be between 3 and 30 symbols.";

        public InvalidSongNameException()
            : base(Message)
        {
        }
    }
}
