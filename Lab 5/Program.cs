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
            string[] Props_1 = { "Good Processor", "Quality hardware" };
            string[] Props_2 = { "Nice build", "New Brand" };
            Computer Comp = new Computer(0, "Good OS", "Microsoft", "AMD", "ap2021certof", 32, Props_1);
            Supercomputer SComp = new Supercomputer(5, 2, "Nice", "Apple", "Intel", "ip2021certof", 64, Props_2);
            Comp.CheckData();
            Comp.CheckWorkingAbility();
            Comp.GenerateProcess("Google", "Connecting to google");
            Comp.GenerateProcess("System", "CPU OverLoad Control");
            Comp.DisplayInformation();
            Comp.DisplayProps();
            Comp.TurnOnAntivirus();
            Comp.TurnOnAntivirus();
            Comp.ListProcesses();
            Comp.TackleTask();
            SComp.CheckData();
            SComp.CheckWorkingAbility();
            SComp.GenerateProcess("Intel", "Server side ip control");
            SComp.GenerateProcess("WARN", "GPU Disabled");
            SComp.DisplayInformation();
            SComp.DisplayProps();
            SComp.TurnOnAntivirus();
            SComp.TurnOnAntivirus();
            SComp.ListProcesses();
            SComp.TackleTask();
        }
    }
}
