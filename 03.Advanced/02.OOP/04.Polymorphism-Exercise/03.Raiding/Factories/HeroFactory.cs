using Raiding.Factories.Contracts;
using Raiding.Models;
using Raiding.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string type, string name)
        {
            IHero hero;

            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;

                case "Paladin":
                    hero = new Paladin(name);
                    break;

                case "Rogue":
                    hero = new Rogue(name);
                    break;

                case "Warrior":
                    hero = new Warrior(name);
                    break;

                default:
                    throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }
}
