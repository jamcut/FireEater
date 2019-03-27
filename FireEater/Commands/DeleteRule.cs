using NetFwTypeLib;
using System;
using System.Collections.Generic;

namespace FireEater.Commands
{
    public class DeleteRule : ICommand
    {
        public static string CommandName => "delete-rule";

        public void Execute(Dictionary<string, string> arguments)
        {
            string ruleName = string.Empty;

            if (arguments.ContainsKey("/rulename"))
            {
                ruleName = arguments["/rulename"];
            }
            else
            {
                Console.WriteLine("[-] The \"deleterule\" command requires the \"/rulename\" argument");
                Environment.Exit(0);
            }

            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWPolicy2"));
            INetFwRules fwRules = fwPolicy2.Rules;
            try
            {
                fwRules.Remove(ruleName);
            }
            catch (Exception e)
            {
                Console.WriteLine("[-] Error removing rule \"{0}\":", ruleName);
                Console.WriteLine(e.Message);
            }
        }
    }
}
