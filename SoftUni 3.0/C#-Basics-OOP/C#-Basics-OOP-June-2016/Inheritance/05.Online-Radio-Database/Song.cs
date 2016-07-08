using OnlineRadioDatabase.Exceptions;

namespace OnlineRadioDatabase
{
    class Song
    {
        #region Fields

        private string artistName;
        private string songName;
        private int minutes;
        private int secunds;

        #endregion Fields

        //===========================

        #region Constructors

        public Song(string artistName, string songName, int minutes, int secunds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Minutes = minutes;
            this.Secunds = secunds;
        }
        #endregion Constructors

        //===========================

        #region Properties

        public string ArtistName
        {
            get { return this.artistName; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                this.artistName = value;
            }
        }

        public string SongName
        {
            get { return this.songName; }
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }

                this.songName = value;
            }
        }

        public int Minutes
        {
            get { return this.minutes; }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }
                this.minutes = value;
            }
        }

        public int Secunds
        {
            get { return this.secunds; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }
                this.secunds = value;
            }
        }

        #endregion Properties

        //===========================

        #region Methods

        #endregion Methods
    }
}
