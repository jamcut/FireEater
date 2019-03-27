using NetFwTypeLib;
using System;
using System.Collections.Generic;

namespace FireEater.Commands
{
    public class EnableNotifications : ICommand
    {
        public static string CommandName => "enable-notifications";

        public void Execute(Dictionary<string, string> arguments)
        {
            if (arguments.Count > 1)
            {
                Console.WriteLine("[-] The \"enablenotifications\" command does not support any arguments");
                Environment.Exit(0);
            }

            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWPolicy2"));
            Console.WriteLine("[*] Attempting to enable firewall notifications for each profile");

            Console.WriteLine("\n\tDomain profile:");
            if (fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_DOMAIN] is false)
            {
                // Notifications already enabled
                Console.WriteLine("\t\tNotifications already enabled");
            }
            else
            {
                // Attempt to enable notifications
                Console.WriteLine("\t\tAttempting to enable notifications");
                try
                {
                    fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_DOMAIN] = false;
                    Console.WriteLine("\t\tSuccess!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\t\t[-] Error: {0}", e.Message);
                }
            }

            Console.WriteLine("\n\tPrivate profile:");
            if (fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_PRIVATE] is false)
            {
                // Notifications already enabled
                Console.WriteLine("\t\tNotifications already enabled");
            }
            else
            {
                // Attempt to enable notifications
                Console.WriteLine("\t\tAttempting to enable notifications");
                try
                {
                    fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_PRIVATE] = false;
                    Console.WriteLine("\t\tSuccess!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\t\t[-] Error: {0}", e.Message);
                }
            }

            Console.WriteLine("\n\tPublic profile:");
            if (fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_PUBLIC] is false)
            {
                // Notifications already enabled
                Console.WriteLine("\t\tNotifications already enabled");
            }
            else
            {
                // Attempt to enable notifications
                Console.WriteLine("\t\tAttempting to enable notifications");
                try
                {
                    fwPolicy2.NotificationsDisabled[(NET_FW_PROFILE_TYPE2_)Program.NET_FW_PROFILE2_PUBLIC] = false;
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