using System;
using System.Collections.Generic;

namespace Lab_5
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
    enum OSModel: int
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
            Computer Comp = new Computer(0, "Good OS", "Microsoft", "AMD", "ap2021certof", 32, Props_1);
            Supercomputer SComp = new Supercomputer(5, 2, "Nice", "Apple", "Intel", "ip2021certof", 64, Props_2);
            DEVICES.Add(Comp);
            DEVICES.Add(SComp);
            for (int i = 0; i < 2; i++)
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
        }
    }
}
