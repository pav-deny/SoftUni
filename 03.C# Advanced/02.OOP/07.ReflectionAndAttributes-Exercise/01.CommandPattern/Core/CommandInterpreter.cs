using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = tokens[0];

            string[] commandArgs = tokens.Skip(1).ToArray();

            Type commandType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == $"{commandName}Command");

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            string result = command.Execute(commandArgs);
            return result;
        }
    }
}
