using NetFwTypeLib;
using System;
using System.Collections.Generic;

namespace FireEater.Commands
{
    public class Enumerate : ICommand
    {
        public static string CommandName => "enumerate";

        public void Execute(Dictionary<string, string> arguments)
        {
            if (arguments.Count > 1)
            {
                Console.WriteLine("[-] The \"enumerate\" command does not support any arguments");
                Environment.Exit(0);
            }
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWPolicy2"));

            int fwPolicyType = fwPolicy2.CurrentProfileTypes;

            Console.WriteLine("[*] Enumerating firewall profiles");

            Console.WriteLine("\tDomain Profile:");
            if (fwPolicy2.FirewallEnabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_DOMAIN])
            {
                Console.WriteLine("\t\tStatus: ENABLED");
            }
            else
            {
                Console.WriteLine("\t\tStatus: DISABLED");
            }
            if (fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_DOMAIN])
            {
                Console.WriteLine("\t\tNotifications: DISABLED");
            }
            else
            {
                Console.WriteLine("\t\tNotifications: ENABLED");
            }

            Console.WriteLine("\n\tPrivate Profile:");
            if (fwPolicy2.FirewallEnabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_PRIVATE])
            {
                Console.WriteLine("\t\tStatus: ENABLED");
            }
            else
            {
                Console.WriteLine("\t\tStatus: DISABLED");
            }
            if (fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_PRIVATE])
            {
                Console.WriteLine("\t\tNotifications: DISABLED");
            }
            else
            {
                Console.WriteLine("\t\tNotifications: ENABLED");
            }

            Console.WriteLine("\n\tPublic Profile:");
            if (fwPolicy2.FirewallEnabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_PUBLIC])
            {
                Console.WriteLine("\t\tStatus: ENABLED");
            }
            else
            {
                Console.WriteLine("\t\tStatus: Disabled");
            }
            if (fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_PUBLIC])
            {
                Console.WriteLine("\t\tNotifications: DISABLED");
            }
            else
            {
                Console.WriteLine("\t\tNotifications: ENABLED");
            }

            switch (fwPolicyType)
            {
                case 1:
                    Console.WriteLine("\n[*] The active firewall profile is: DOMAIN");
                    break;
                case 2:
                    Console.WriteLine("\n[*] The active firewall profile is: PRIVATE");
                    break;
                case 4:
                    Console.WriteLine("\n[*] The active firewall profile is: PUBLIC");
                    break;
                default:
                    Console.WriteLine("\n[*] Could not determine the active firewall profile: {0}", fwPolicyType);
                    break;
            }
        }
    }
}
