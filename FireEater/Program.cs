using System;

namespace FireEater
{
    public class Program
    {
        // From http://www.ohmancorp.com/files/RefWin-AdvFirewall-JEnumFWRules.txt
        public const int NET_FW_PROFILE2_DOMAIN = 1;
        public const int NET_FW_PROFILE2_PRIVATE = 2;
        public const int NET_FW_PROFILE2_PUBLIC = 4;
        public const int NET_FW_PROFILE2_ALL = 2147483647;

        public const int NET_FW_IP_PROTOCOL_TCP = 6;
        public const int NET_FW_IP_PROTOCOL_UDP = 17;
        public const int NET_FW_IP_PROTOCOL_ICMPv4 = 1;
        public const int NET_FW_IP_PROTOCOL_ICMPv6 = 58;

        public const int NET_FW_RULE_DIRECTION_IN = 1;
        public const int NET_FW_RULE_DIRECTION_OUT = 2;

        public const int NET_FW_ACTION_BLOCK = 0;
        public const int NET_FW_ACTION_ALLOW = 1;

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Info.Banner();
                Info.Usage();
                return;
            }
            try
            {
                var parsed = ArgumentParser.Parse(args);
                if (parsed.ParsedOk == false)
                {
                    Console.WriteLine("[-] Failed to parse arguments");
                    return;
                }
                else
                {
                    var commandName = args.Length != 0 ? args[0] : "";
                    var commandFound = new CommandCollection().ExecuteCommand(commandName, parsed.Arguments);

                    if (commandFound == false)
                    {
                        Info.Banner();
                        Info.Usage();
                        Console.WriteLine("[-] Failed to find command name in arguments");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[-] Unhandled error:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
