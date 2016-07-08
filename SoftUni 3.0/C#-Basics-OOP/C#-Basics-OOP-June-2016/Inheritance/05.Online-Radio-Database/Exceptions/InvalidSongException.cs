namespace OnlineRadioDatabase.Exceptions
{
    using System;

    class InvalidSongException : Exception
    {
        private new const string Message = "Invalid song.";

        public InvalidSongException()
            : base(Message)
        {
        }

        public InvalidSongException(string message)
            : base(message)
        {
        }
    }
}