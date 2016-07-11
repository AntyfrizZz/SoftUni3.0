namespace OnlineRadioDatabase.Exceptions
{
    using System;

    class InvalidSongSecondsException : InvalidSongException
    {
        private new const string Message = "Song seconds should be between 0 and 59.";

        public InvalidSongSecondsException()
            : base(Message)
        {
        }
    }
}
