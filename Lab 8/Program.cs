using System;
using System.Collections.Generic;

namespace Lab_8
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


    // Start of RegistrationProtocol class
    class RegistrationProtocol
    {
        static public void SimpleReg(string code)
        {
            Console.WriteLine($"The device with id:{code} is now officially registered!");
        }

        static public void WorldCertification(string code)
        {
            Console.WriteLine($"The device with id:{code} has been added to the UNESCO objects!");
        }

        static public void CompetitiveProgrammingCertification(string code)
        {
            Console.WriteLine($"The device with id:{code} was chosen to present our planet on Galaxy Code Competition!");
        }
    }
    // End of RegistrationProtocol class


    // Start of Event to register the device
    class EventToRegister
    {
        public delegate void RegistrationService(string code);
        public event RegistrationService RegisterDevice;

        public void Register(string code)
        {
            RegisterDevice(code);
        }
    }
    // End of Event to register the device


    // Delegate for tasks

    // Delegate for tasks

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t--- Creating devices ---");
            Console.ForegroundColor = ConsoleColor.Gray;
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t--- Checking the devices ---");
            Console.ForegroundColor = ConsoleColor.Gray;
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t--- Generating processes ---");
            Console.ForegroundColor = ConsoleColor.Gray;
            DEVICES[0].GenerateProcess("Google", "Connecting to google");
            DEVICES[0].GenerateProcess("System", "CPU OverLoad Control");
            DEVICES[0].ListProcesses();
            DEVICES[1].GenerateProcess("Intel", "Server side ip control");
            DEVICES[1].GenerateProcess("WARN", "GPU Disabled");
            DEVICES[1].ListProcesses();
            DEVICES[2].GenerateProcess("Google", "Check the connection reliability");
            DEVICES[2].GenerateProcess("WARN", "BAD CONNECTION");
            DEVICES[2].ListProcesses();

            // List Of IDestroyable
            List<IDestroyable> TO_DESTROY = new List<IDestroyable>();
            TO_DESTROY.Add(Comp);
            TO_DESTROY.Add(SComp);
            TO_DESTROY.Add(MComp);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t--- Demonstration of destroy ---");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < TO_DESTROY.Count; i++)
            {
                TO_DESTROY[i].DestroySelf();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{DEVICES[0]}");
            Console.WriteLine($"{DEVICES[1]}");
            Console.WriteLine($"{DEVICES[2]}");
            Console.ForegroundColor = ConsoleColor.Gray;

            // First conference with events
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t--- Conference ---");
            Console.ForegroundColor = ConsoleColor.Gray;
            EventToRegister CONFERNCE = new EventToRegister();
            CONFERNCE.RegisterDevice += RegistrationProtocol.SimpleReg;
            CONFERNCE.RegisterDevice += RegistrationProtocol.WorldCertification;
            CONFERNCE.Register(DEVICES[0].getSN());
            CONFERNCE.Register(DEVICES[2].getSN());

            // Anonimus method
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t--- Tackle of os tasks ---");
            Console.ForegroundColor = ConsoleColor.Gray;
            DEVICES[1].TackleOSTask(delegate()
            {
                Console.WriteLine("Collecting data!");
            });
        }
    }
}
