using Raiding.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Paladin : IHero
    {
        public Paladin(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public int Power => 100;

        public string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
