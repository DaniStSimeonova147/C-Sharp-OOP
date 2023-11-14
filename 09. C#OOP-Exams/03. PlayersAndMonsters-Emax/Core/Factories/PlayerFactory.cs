using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;

            switch (type)
            {
                case "Advanced":
                    player = new Advanced(new CardRepository(), username);
                    break;

                case "Beginner":
                    player = new Beginner(new CardRepository(), username);
                    break;

                default:
                    break;
            }

            return player;

            //Type playerType = Assembly.GetCallingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(t => t.Name == type);

            //IPlayer player = (IPlayer)Activator.CreateInstance(playerType, username);

            //return player;

        }
    }
}
