using Raiding.Core;
using Raiding.Core.Contracts;
using Raiding.Factories;
using Raiding.Factories.Contracts;
using Raiding.IO;
using Raiding.IO.Contracts;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            IHeroFactory factory = new HeroFactory();

            IEngine engine = new Engine(reader, writer, factory);
            engine.Run();
        }
    }
}
