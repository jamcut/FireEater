using System;
using System.Collections.Generic;
using FireEater.Commands;

namespace FireEater
{
    public class CommandCollection
    {
        private readonly Dictionary<string, Func<ICommand>> _availableCommands = new Dictionary<string, Func<ICommand>>();

        public CommandCollection()
        {
           _availableCommands.Add(AddRule.CommandName, () => new AddRule());
           _availableCommands.Add(DeleteRule.CommandName, () => new DeleteRule());
           _availableCommands.Add(DisableNotifications.CommandName, () =>new DisableNotifications());
           _availableCommands.Add(DisableRule.CommandName, () => new DisableRule());
           _availableCommands.Add(EnableNotifications.CommandName, () => new EnableNotifications());
           _availableCommands.Add(EnableRule.CommandName, () => new EnableRule());
           _availableCommands.Add(Enumerate.CommandName, () => new Enumerate());
           _availableCommands.Add(ListRule.CommandName, () => new ListRule());
           _availableCommands.Add(ListRules.CommandName, () => new ListRules());
        }

        public bool ExecuteCommand(string commandName, Dictionary<string, string> arguments)
        {
            bool commandWasFound;

            if (string.IsNullOrEmpty(commandName) || _availableCommands.ContainsKey(commandName) == false)
            {
                commandWasFound = false;
            }
            else
            {
                var command = _availableCommands[commandName].Invoke();
                command.Execute(arguments);

                commandWasFound = true;
            }

            return commandWasFound;
        }

    }
}