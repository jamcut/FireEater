using System;

namespace FireEater
{
    public class Info
    {
        public static void Usage()
        {
            string usage = @"
Usage:

Enumerate firewall profiles and notification settings:

    FireEater.exe enumerate

Disable/Enable firewall notifications (requires admin privileges):
    
    FireEater.exe disable-notifications (enable-notifications)

Disable/Enable firewall rule (requires admin privileges):
    
    FireEater.exe disable-rule (enable-rule) /rulename:<name of firewall rule>

Delete firewall rule (requires admin privileges):
    
    FireEater.exe delete-rule /rulename:<name of firewall rule>

Add firewall rule (requires admin privileges):
    
    FireEater.exe add-rule
        /rulename:<name of firewall rule>
        /ruledescription:<description for rule>
        /ruleips<comma-separated IP addresses> (OR)
        /ruleipfile:<path to newline-separated IP addresses file>
    
    By default firewall rules will be enabled for all profiles (domain, private, public).
    To prevent a rule from enabling automatically pass the ""/disable"" argument.

List all firewall rules
    
    FireEater.exe list-rules

Enumerate properties for a specific firewall rule
    
    FireEater.exe list-rule /rulename:<name of firewall rule>
";

            Console.WriteLine(usage);
        }

        public static void Banner()
        {
            //Console.WriteLine("    ,.   (   .      )        .      \"");
            //Console.WriteLine("   (\")  )'     ,'        )  . (`     '`");
            //Console.WriteLine(" .; )  ' (( (\"); (, (((  ;)  \"  )\"");
            //Console.WriteLine(" _\"., ,._'_.,)_(..,( . )_  _')_') (. _..( '..");
            //Console.WriteLine("---------------------------------------------");
            //Console.WriteLine("        eeee eeeee eeeee eeee eeeee");
            //Console.WriteLine("        8    8   8   8   8    8   8");
            //Console.WriteLine("        8eee 8eee8   8e  8eee 8eee8e");
            //Console.WriteLine("        88   88  8   88  88   88   8");
            //Console.WriteLine("        88ee 88  8   88  88ee 88   8");

            string banner = @"
________/\\\\\_______________________________________________________________________________________________________________________        
 ______/\\\///________________________________________________________________________________________________________________________       
  _____/\\\_______/\\\__________________________________________________________________________/\\\___________________________________      
   __/\\\\\\\\\___\///___/\\/\\\\\\\______/\\\\\\\\________________/\\\\\\\\___/\\\\\\\\\_____/\\\\\\\\\\\_____/\\\\\\\\___/\\/\\\\\\\__     
    _\////\\\//_____/\\\_\/\\\/////\\\___/\\\/////\\\_____________/\\\/////\\\_\////////\\\___\////\\\////____/\\\/////\\\_\/\\\/////\\\_    
     ____\/\\\______\/\\\_\/\\\___\///___/\\\\\\\\\\\_____________/\\\\\\\\\\\____/\\\\\\\\\\_____\/\\\_______/\\\\\\\\\\\__\/\\\___\///__   
      ____\/\\\______\/\\\_\/\\\_________\//\\///////_____________\//\\///////____/\\\/////\\\_____\/\\\_/\\__\//\\///////___\/\\\_________  
       ____\/\\\______\/\\\_\/\\\__________\//\\\\\\\\\\____________\//\\\\\\\\\\_\//\\\\\\\\/\\____\//\\\\\____\//\\\\\\\\\\_\/\\\_________ 
        ____\///_______\///__\///____________\//////////______________\//////////___\////////\//______\/////______\//////////__\///__________
";
            Console.WriteLine(banner);
        }
    }
}
