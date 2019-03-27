using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireEater.Commands
{
    public class ListRules : ICommand
    {
        public static string CommandName => "list-rules";

        public void Execute(Dictionary<string, string> arguments)
        {
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWPolicy2"));
            INetFwRules currentRules = fwPolicy2.Rules;

            Console.WriteLine("[*] Enumerating firewall rules");
            foreach (INetFwRule rule in currentRules)
            {
                Console.WriteLine("\n\tName: {0}", rule.Name);
                Console.WriteLine("\tDescription: {0}", rule.Description);
            }
        }
    }
}
