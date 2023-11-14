using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;

            switch (type)
            {
                case "Trap":
                    card = new TrapCard(name);
                    break;

                case "Magic":
                    card = new MagicCard(name);
                    break;

                default:
                    break;
            }

            return card;
            //Type cardType = Assembly.GetCallingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(t => t.Name == type);

            //ICard card = (ICard)Activator.CreateInstance(cardType, name);

            //return card;
        }
    }
}
