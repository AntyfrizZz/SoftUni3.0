using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Football_Team_Generator
{
    public class FootballTeam
    {
        #region Fields

        private string name;
        private Dictionary<string, Player> players;

        #endregion Fields


        //===========================

        #region Constructors

        public FootballTeam(string name)
        {
            this.Name = name;
            this.players = new Dictionary<string, Player>();
        }

        #endregion Constructors

        //===========================

        #region Properties

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A {nameof(this.name)} should not be empty.");
                }

                this.name = value;
            }
        }

        public int Rating { get; private set; }

        #endregion Properties

        //===========================

        #region Methods

        public void RemovePlayer(string player)
        {
            if (!players.ContainsKey(player))
            {
                throw new InvalidOperationException($"Player {player} is not in {this.name} team.");
            }

            this.Rating -= players[player].SkillLevel;
            players.Remove(player);

        }

        public void AddPlayer(Player player)
        {
            players.Add(player.Name, player);
            this.Rating += player.SkillLevel;
        }

        public int GetRating()
        {
            return this.Rating;
        }

        public override string ToString()
        {
            return $"{this.Name} - {GetRating()}";
        }

        #endregion Methods
    }
}
