using NetFwTypeLib;
using System;
using System.Collections.Generic;

namespace FireEater.Commands
{
    public class DisableRule : ICommand
    {
        public static string CommandName => "disable-rule";

        public void Execute(Dictionary<string, string> arguments)
        {
            string ruleName = string.Empty;
            string fwProfile = string.Empty;

            if (arguments.ContainsKey("/rulename"))
            {
                ruleName = arguments["/rulename"];
            }
            else
            {
                Console.WriteLine("[-] The \"disablerule\" command requires the \"/rulename\" argument");
                Environment.Exit(0);
            }

            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWPolicy2"));
            INetFwRules fwRules = fwPolicy2.Rules;
            foreach (INetFwRule3 rule in fwRules)
            {
                if (rule.Name == ruleName)
                {
                    if (rule.Enabled == false)
                    {
                        Console.WriteLine("[*] Rule \"{0}\" is already disabled.", ruleName);
                    }
                    else
                    {
                        Console.WriteLine("[*] Attempting to disable rule \"{0}\"", ruleName);
                        try
                        {
                            rule.Enabled = false;
                            Console.WriteLine("[+] Success!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("[-] Error while disabling rule \"{0}\":", ruleName);
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
        }
    }
}
