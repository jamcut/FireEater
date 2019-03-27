using NetFwTypeLib;
using System;
using System.Collections.Generic;

namespace FireEater.Commands
{
    public class DisableNotifications : ICommand
    {
        public static string CommandName => "disable-notifications";

        public void Execute(Dictionary<string, string> arguments)
        {
            if (arguments.Count > 1)
            {
                Console.WriteLine("[-] The \"disablenotifications\" command does not support any arguments");
                Environment.Exit(0);
            }

            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWPolicy2"));
            Console.WriteLine("[*] Attempting to disable firewall notifications for each profile");

            Console.WriteLine("\n\tDomain profile:");
            if (fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_DOMAIN] is true)
            {
                // Notifications already disabled
                Console.WriteLine("\t\tNotifications already disabled");
            }
            else
            {
                // Attempt to disable notifications
                Console.WriteLine("\t\tAttempting to disable notifications");
                try
                {
                    fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_DOMAIN] = true;
                    Console.WriteLine("\t\tSuccess!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\t\t[-] Error: {0}", e.Message);
                }
            }

            Console.WriteLine("\n\tPrivate profile:");
            if (fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_PRIVATE] is true)
            {
                // Notifications already disabled
                Console.WriteLine("\t\tNotifications already disabled");
            }
            else
            {
                // Attempt to disable notifications
                Console.WriteLine("\t\tAttempting to disable notifications");
                try
                {
                    fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_PRIVATE] = true;
                    Console.WriteLine("\t\tSuccess!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\t\t[-] Error: {0}", e.Message);
                }
            }

            Console.WriteLine("\n\tPublic profile:");
            if (fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_PUBLIC] is true)
            {
                // Notifications already disabled
                Console.WriteLine("\t\tNotifications already disabled");
            }
            else
            {
                // Attempt to disable notifications
                Console.WriteLine("\t\tAttempting to disable notifications");
                try
                {
                    fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_PUBLIC] = true;
                    Console.WriteLine("\t\tSuccess!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\t\t[-] Error: {0}", e.Message);
                }
            }
        }
    }
}