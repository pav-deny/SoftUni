using Raiding.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories.Contracts
{
    public interface IHeroFactory
    {
        IHero CreateHero(string type, string name);
    }
}
