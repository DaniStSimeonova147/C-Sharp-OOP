using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX =
            "Command";
        public string Read(string inputLine)
        {
            string[] commandTokens = inputLine.Split(" ",
                StringSplitOptions.RemoveEmptyEntries);

            string commandName = commandTokens[0] + COMMAND_POSTFIX;

            string[] commandArgs = commandTokens
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly
                .GetCallingAssembly();

            Type[] types = assembly
                .GetTypes();

            Type typeToCreate = types
                .FirstOrDefault(t => t.Name == commandName);

            //if (typeToCreate == null)
            //{
            //    throw new InvalidOperationException
            //        ("Invalid Command Type");
            //}

            Object instance =
                Activator.CreateInstance(typeToCreate);

            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
