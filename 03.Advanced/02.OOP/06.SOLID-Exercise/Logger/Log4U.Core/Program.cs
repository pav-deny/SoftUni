using Log4U.Core.Loggers;

namespace Log4U.Core
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Logger logger = new Logger();

            logger.Critical("23/11/2025 12:13", "Oh no");
        }
    }
}
