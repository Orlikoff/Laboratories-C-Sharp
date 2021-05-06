using System;
using System.Collections.Generic;

namespace Lab_6
{
    // Start of Process structure
    struct Process
    {
        public string Name;
        public string Info;
        public string Id;

        public void DisplayInfo()
        {
            Console.WriteLine($"--- Id:{Id} Name: {Name} Info:{Info}");
        }
    }
    // End of Process strucure


    // Start of OSModel enum
    enum OSModel : int
    {
        Windows = 0,
        MacOS,
        Ubuntu,
        ParrotOS,
        Arch
    }
    // End of OSModel enum


    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            List<OperationSystem> DEVICES = new List<OperationSystem>();
            string[] Props_1 = { "Good Processor", "Quality hardware" };
            string[] Props_2 = { "Nice build", "New Brand" };
            string[] Props_3 = { "Reliable", "A lot of servers" };
            Computer Comp = new Computer(0, "Good OS", "Microsoft", "AMD", "ap2021certof", 32, Props_1);
            Supercomputer SComp = new Supercomputer(5, 2, "Nice", "Apple", "Intel", "ip2021certof", 64, Props_2);
            Mainframe MComp = new Mainframe("For Server Work", 4, "Nice", "Microsoft", "OrlikInc", "op2021certof", 64, Props_3);
            DEVICES.Add(Comp);
            DEVICES.Add(SComp);
            DEVICES.Add(MComp);
            DEVICES.Sort();
            for (int i = 0; i < DEVICES.Count; i++)
            {
                DEVICES[i].CheckData();
                DEVICES[i].CheckWorkingAbility();
                DEVICES[i].DisplayInformation();
                DEVICES[i].DisplayProps();
                DEVICES[i].TurnOnAntivirus();
                DEVICES[i].TurnOnAntivirus();
                DEVICES[i].TackleTask();
            }
            DEVICES[0].GenerateProcess("Google", "Connecting to google");
            DEVICES[0].GenerateProcess("System", "CPU OverLoad Control");
            DEVICES[0].ListProcesses();
            DEVICES[1].GenerateProcess("Intel", "Server side ip control");
            DEVICES[1].GenerateProcess("WARN", "GPU Disabled");
            DEVICES[1].ListProcesses();
            DEVICES[2].GenerateProcess("Google", "Check the connection reliability");
            DEVICES[2].GenerateProcess("WARN", "BAD CONNECTION");
            DEVICES[2].ListProcesses();
            DEVICES[0].DestroySelf();
            DEVICES[1].DestroySelf();
            DEVICES[2].DestroySelf();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{DEVICES[0]}");
            Console.WriteLine($"{DEVICES[1]}");
            Console.WriteLine($"{DEVICES[2]}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
