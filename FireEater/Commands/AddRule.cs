using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FireEater.Commands
{
    public class AddRule : ICommand
    {
        public static string CommandName => "add-rule";

        public void Execute(Dictionary<string, string> arguments)
        {
            string ruleName = string.Empty;
            string ruleDescription = string.Empty;
            string ruleDirection = "out";
            string ruleAction = "block";
            List<string> ruleIPs = new List<string>();
            string ruleIPFile = string.Empty;
            bool ruleEnabled = true;

            if (! arguments.ContainsKey("/rulename"))
            {
                Console.WriteLine("[-] The \"addrule\" command requires the \"rulename\" argument.");
                return;
            }

            ruleName = arguments["/rulename"];

            if (! (arguments.ContainsKey("/ruleips") || arguments.ContainsKey("/ruleipfile") ))
            {
                Console.WriteLine("[-] The \"addrule\" command requires ONE of the following arguments: \"ruleips\", \"ruleipfile\"");
                return;
            }

            if (arguments.ContainsKey("/ruleips") && arguments.ContainsKey("/ruleipfile"))
            {
                Console.WriteLine("[-] The \"addrule\" command requires ONE of the following arguments: \"ruleips\", \"ruleipfile\"");
                return;
            }

            if (arguments.ContainsKey("/ruleips"))
            {
                string[] IPs = arguments["/ruleips"].Split(',');
                foreach (string ip in IPs)
                {
                    ruleIPs.Add(ip);
                }
            }

            if (arguments.ContainsKey("/ruleipfile"))
            {
                try
                {
                   string[] IPs = File.ReadAllLines(arguments["/ruleipfile"], Encoding.UTF8);
                    foreach (string ip in IPs)
                    {
                        ruleIPs.Add(ip);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[-] Error attemptig to read file: {0}", arguments["ruleipfile"]);
                    Console.WriteLine(e.Message);

                    return;
                }
            }

            if (arguments.ContainsKey("/ruledescription"))
            {
                ruleDescription = arguments["/ruledescription"];
            }

            if (arguments.ContainsKey("/ruleDirection"))
            {
                ruleDirection = arguments["/ruledirection"];
            }

            if (arguments.ContainsKey("/ruleaction"))
            {
                ruleAction = arguments["/ruleaction"];
            }

            if (arguments.ContainsKey("/disable"))
            {
                ruleEnabled = false;
            }

            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWPolicy2"));
            INetFwRules currentRules = fwPolicy2.Rules;

            foreach (INetFwRule rule in currentRules)
            {
                if (rule.Name == ruleName)
                {
                    Console.WriteLine("[-] Rule with name {0} already exists.", rule.Name);
                    return;
                }
            }

            INetFwRule fwRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            fwRule.Name = ruleName;
            fwRule.Profiles = Program.NET_FW_PROFILE2_ALL;
            fwRule.RemoteAddresses = string.Join(",", ruleIPs.ToArray());
            fwRule.Description = ruleDescription;

            if (ruleAction == "block")
            {
                fwRule.Action = Program.NET_FW_ACTION_BLOCK;

                if (ruleDirection == "out")
                {
                    fwRule.Direction = (NET_FW_RULE_DIRECTION_)Program.NET_FW_RULE_DIRECTION_OUT;
                }
                else
                {
                    fwRule.Direction = (NET_FW_RULE_DIRECTION_)Program.NET_FW_RULE_DIRECTION_IN;
                }
            }
            else
            {
                fwRule.Action = (NET_FW_ACTION_)Program.NET_FW_ACTION_ALLOW;
            }
            fwRule.Enabled = ruleEnabled;
            currentRules.Add(fwRule);
        }
    }
}
