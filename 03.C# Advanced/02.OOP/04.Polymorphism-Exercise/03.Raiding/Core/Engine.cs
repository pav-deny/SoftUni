using Raiding.Core.Contracts;
using Raiding.Factories.Contracts;
using Raiding.IO.Contracts;
using Raiding.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory factory;

        private readonly List<IHero> raidGroup;

        public Engine(IReader reader, IWriter writer, IHeroFactory factory)
        {
            this.reader = reader;
            this.writer = writer;
            this.factory = factory;

            raidGroup = new List<IHero>();
        }

        public void Run()
        {
            int n = int.Parse(reader.ReadLine());

            for (int i  = 0; i < n; i++)
            {
                try
                {
                    string name = reader.ReadLine();
                    string type = reader.ReadLine();

                    IHero hero = factory.CreateHero(type, name);
                    raidGroup.Add(hero);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                    i--;
                }
            }

            int bossPower = int.Parse(reader.ReadLine());
            int heroesPower = 0;

            foreach (IHero hero in raidGroup)
            {
                writer.WriteLine(hero.CastAbility());
                heroesPower += hero.Power;
            }

            if (heroesPower >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}
