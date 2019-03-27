using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireEater.Commands
{
    public class ListRule : ICommand
    {
        public static string CommandName => "list-rule";

        public void Execute(Dictionary<string, string> arguments)
        {
            string ruleName = string.Empty;

            if (! arguments.ContainsKey("/rulename"))
            {
                Console.WriteLine("[-] The \"list-rule\" command requires the \"rulename\" argument.");
                return;
            }
            else
            {
                ruleName = arguments["/rulename"];
            }

            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWPolicy2"));
            INetFwRules currentRules = fwPolicy2.Rules;
            
            foreach (INetFwRule3 rule in currentRules)
            {
                if (rule.Name == ruleName)
                {
                    string ruleProtocol = string.Empty;
                    switch (rule.Protocol)
                    {
                        case 256:
                            ruleProtocol = "*";
                            break;
                        case 0:
                            ruleProtocol = "HOPOPT";
                            break;
                        case 1:
                            ruleProtocol = "ICMPv4";
                            break;
                        case 2:
                            ruleProtocol = "IGMP";
                            break;
                        case 6:
                            ruleProtocol = "TCP";
                            break;
                        case 17:
                            ruleProtocol = "UDP";
                            break;
                        case 41:
                            ruleProtocol = "IPv6";
                            break;
                        case 43:
                            ruleProtocol = "IPv6-Route";
                            break;
                        case 44:
                            ruleProtocol = "IPv6-Frag";
                            break;
                        case 47:
                            ruleProtocol = "GRE";
                            break;
                        case 58:
                            ruleProtocol = "ICMPv6";
                            break;
                        case 59:
                            ruleProtocol = "IPv6-NoNxt";
                            break;
                        case 60:
                            ruleProtocol = "IPv6-Opts";
                            break;
                        case 112:
                            ruleProtocol = "VRRP";
                            break;
                        case 113:
                            ruleProtocol = "PGM";
                            break;
                        case 115:
                            ruleProtocol = "L2TP";
                            break;
                        default:
                            ruleProtocol = string.Format("Unknown ({0})", rule.Protocol.ToString());
                            break;
                    }

                    string ruleAction = string.Empty;
                    switch (rule.Action.ToString())
                    {
                        case "NET_FW_ACTION_ALLOW":
                            ruleAction = "Allow";
                            break;
                        case "NET_FW_ACTION_BLOCK":
                            ruleAction = "Block";
                            break;
                        default:
                            ruleAction = string.Format("Unknown ({0})", rule.Action.ToString());
                            break;
                    }

                    string ruleDirection = string.Empty;
                    switch (rule.Direction.ToString())
                    {
                        case "NET_FW_RULE_DIR_IN":
                            ruleDirection = "Inbound";
                            break;
                        case "NET_FW_RULE_DIR_OUT":
                            ruleDirection = "Outbound";
                            break;
                        default:
                            ruleDirection = string.Format("Unknown ({0})", rule.Direction.ToString());
                            break;
                    }

                    Console.WriteLine("\n\tName: {0}", rule.Name);
                    if (rule.Description != null)
                    {
                        Console.WriteLine("\tDescription: {0}", rule.Description);
                    }
                    if (rule.Grouping != null)
                    {
                        Console.WriteLine("\tGrouping: {0}", rule.Grouping);
                    }
                    if (ruleDirection != string.Empty)
                    {
                        Console.WriteLine("\tDirection: {0}", ruleDirection);
                    }
                    if (ruleAction != string.Empty)
                    {
                        Console.WriteLine("\tAction: {0}", ruleAction);
                    }
                    if (rule.ApplicationName != null)
                    {
                        Console.WriteLine("\tApplication: {0}", rule.ApplicationName);
                    }
                    
                    Console.WriteLine("\tEnabled: {0}", rule.Enabled.ToString());
                    Console.WriteLine("\tProtocol: {0}", ruleProtocol);

                    if (rule.LocalAddresses != null)
                    {
                        Console.WriteLine("\tLocal Addresses: {0}", rule.LocalAddresses);
                    }
                    if (rule.LocalPorts != null)
                    {
                        Console.WriteLine("\tLocal Ports: {0}", rule.LocalPorts);
                    }
                    if (rule.LocalUserAuthorizedList != null)
                    {
                        Console.WriteLine("\tLocal Authorized Users: {0}", rule.LocalUserAuthorizedList);
                    }
                    if (rule.RemoteAddresses != null)
                    {
                        Console.WriteLine("\tRemote Addresses: {0}", rule.RemoteAddresses);
                    }
                    if (rule.RemotePorts != null)
                    {
                        Console.WriteLine("\tRemote Ports: {0}", rule.RemotePorts);
                    }
                    if (rule.RemoteMachineAuthorizedList != null)
                    {
                        Console.WriteLine("\tRemote Authorized Machines: {0}", rule.RemoteMachineAuthorizedList);
                    }
                    if (rule.RemoteUserAuthorizedList != null)
                    {
                        Console.WriteLine("\tRemote Authorized Users: {0}", rule.RemoteUserAuthorizedList);
                    }
                    if (rule.serviceName != null)
                    {
                        Console.WriteLine("\tService Name: {0}", rule.serviceName);
                    }
                    
                    return;
                }
            }
            Console.WriteLine("\n[*] Could not find rule: {0}", ruleName);
            return;
        }
    }
}
