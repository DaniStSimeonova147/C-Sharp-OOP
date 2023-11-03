using E05.FootballTeamGenerator.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.FootballTeamGenerator.Models
{
   public class Team
    {
        private string name;
        private List<Player> players;

        public Team()
        {
            players = new List<Player>();
        }
        public Team(string name)
            :this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (ExeptionMessages.EmptyNameExeption);
                }

                this.name = value;
            }
        }

        public IReadOnlyCollection<Player> Players => this.players.AsReadOnly();

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string name)
        {
            Player playerToRemove = this.players
                .FirstOrDefault(p => p.Name == name);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExeptionMessages.MissingPlayerExeption, name, this.Name));
            }

            this.players.Remove(playerToRemove);
        }
       
    }
}
