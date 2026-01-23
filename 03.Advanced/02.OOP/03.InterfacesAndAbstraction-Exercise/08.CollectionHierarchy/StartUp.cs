using ExplicitInterfaces.Core;
using ExplicitInterfaces.IO;
using ExplicitInterfaces.IO.Interfaces;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new(reader, writer);
            engine.Run();
        }
    }
}
