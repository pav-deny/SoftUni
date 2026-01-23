using Raiding.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Warrior : IHero
    {
        public Warrior(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public int Power => 100;

        public string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
