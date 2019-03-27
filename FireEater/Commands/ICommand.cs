using System.Collections.Generic;

namespace FireEater.Commands
{
    public interface ICommand
    {
        void Execute(Dictionary<string, string> arguments);
    }
}
