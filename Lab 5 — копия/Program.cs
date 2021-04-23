using System;
using System.Collections.Generic;

namespace Lab_5
{
    // Start of ALU Class
    class ALU
    {
        private static List<string> SerialNumbersList = new List<string>();
        private bool IsTurnedOn = false;
        protected string SerialNumber { get; }
        protected bool IsBlocked = false;

        public ALU()
        {
            SerialNumber = GenerateSerialNumber();
        }

        private string GenerateSerialNumber()
        {
            string AlNum = "";
            string Alphabet = "abcdefghijklmnopqrstuvwxyz" +
                              "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string Numbers = "1234567890";
            Random randomiser = new Random();

            do
            {
                for (int i = 0; i < 20; i++)
                {
                    int toggle = randomiser.Next(0, 2);
                    if (toggle == 0)
                    {
                        AlNum += Alphabet[randomiser.Next(0, 52)];
                    }
                    else
                    {
                        AlNum += Numbers[randomiser.Next(0, 10)];
                    }
                }
            } while (SerialNumbersList.Contains(AlNum));

            SerialNumbersList.Add(AlNum);

            return AlNum;
        }

        static public void DisplaySerialNumbers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < ALU.SerialNumbersList.Count; i++)
            {
                Console.WriteLine($"Device {i + 1}, id: " + SerialNumbersList[i]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        protected void SwitchPower()
        {
            IsTurnedOn = !IsTurnedOn;
            string ans = IsTurnedOn ? "on" : "off";
            if (!IsBlocked)
            {
                Console.WriteLine($"Device (id:{SerialNumber}) has been turned {ans}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-----------Device is blocked-----------");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
    // End of ALU Class


    // Start of Processor Class
    class Processor : ALU
    {
        private bool DataIsvalid = true;

        private int numberOfCores;
        private int NumberOfCores
        {
            set
            {
                if (value > 256 || value < 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n---Warning---");
                    Console.WriteLine("Check the number of cores...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    DataIsvalid = false;
                }
                else
                {
                    numberOfCores = value;
                }
            }

            get
            {
                return numberOfCores;
            }
        }

        private int yearOfRelease;
        private int YearOfRelease
        {
            set
            {
                if (value < 1999 || value > 2021)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n---Warning---");
                    Console.WriteLine("Check the year...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    DataIsvalid = false;
                }
                else
                {
                    yearOfRelease = value;
                }
            }

            get
            {
                return yearOfRelease;
            }
        }

        private int OSBit;
        private int _OSBit
        {
            set
            {
                if (value != 32 && value != 64 && value != 86)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n---Warning---");
                    Console.WriteLine("Check the OS Bit parameter...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    DataIsvalid = false;
                }
                else
                {
                    OSBit = value;
                }
            }

            get
            {
                return OSBit;
            }
        }

        public Processor(int NumberOfCores, int YearOfRelease, int NumOfBits)
        {
            this._OSBit = NumOfBits;
            this.NumberOfCores = NumberOfCores;
            this.YearOfRelease = YearOfRelease;
        }

        public Processor(int NumberOfCores, int NumOfBits)
        {
            this._OSBit = NumOfBits;
            this.NumberOfCores = NumberOfCores;
            this.YearOfRelease = 2021;
        }

        public Processor(int NumOfBits)
        {
            this._OSBit = NumOfBits;
            this.NumberOfCores = 8;
            this.YearOfRelease = 2021;
        }

        public void DisplayInformation()
        {
            if (DataIsvalid && !IsBlocked)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n---Processor Configuration---");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Device (id: {SerialNumber}) has the next configuration:\n"
                    + $"Number of cores is: {numberOfCores}\n"
                    + $"Year of it's release: {yearOfRelease}\n"
                    + $"OS: {OSBit}-bit");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                if (!IsBlocked)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n---Warning---");
                    Console.WriteLine("Check all the parameters of the CPU!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Making auto tests...");
                    CheckWorkingAbility();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------Device is blocked-----------");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        public void CheckWorkingAbility()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n---Checking working ability---");
            Console.WriteLine("Turning on the electricity supply...");
            SwitchPower();
            SwitchPower();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Checking if the parameters are right...");
            if (!DataIsvalid && !IsBlocked)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n---Critical Warning---");
                Console.WriteLine($"Processor (id: {SerialNumber}) can't work with wrong parameters,");
                Console.WriteLine("Please check againg all the data\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                if (!IsBlocked)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n---Sucsessfully passed all the tests---");
                    Console.WriteLine("Processor is ready for working...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------Device is blocked-----------");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
    // End of Processor Class


    // Start of Model Class
    class Model : Processor
    {
        private string[] _info;

        private string _manufacturer;
        private string Manufacturer
        {
            set
            {
                if (value != "Intel" && value != "AMD" && value != "OrlikInc")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThere is no such model nowadays...");
                    Console.WriteLine("Try another brand name :3");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    _manufacturer = value;
                }
            }

            get
            {
                return _manufacturer;
            }
        }

        private string _verificationCode;
        private string VerificationCode
        {
            set
            {
                if (_manufacturer == "Intel" && value == "ip2021certof")
                {
                    _verificationCode = value;
                }
                else if (_manufacturer == "AMD" && value == "ap2021certof")
                {
                    _verificationCode = value;
                }
                else if (_manufacturer == "OrlikInc" && value == "op2021certof")
                {
                    _verificationCode = value;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nSorry, but your device (id: {SerialNumber}) seems to be unregistered...");
                    Console.WriteLine("Blocking processor...");
                    Console.WriteLine("Processor has been blocked, good luck");
                    Console.WriteLine("Do not use unregistered hardware in the future :3");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    IsBlocked = true;
                }
            }
        }

        public Model(string Manufacturer, string VerificationCode, int NumberOfCores, int YearOfRelease, int OsBit, string[] ExtraInfo) :
            base(NumberOfCores, YearOfRelease, OsBit)
        {
            this.Manufacturer = Manufacturer;
            this.VerificationCode = VerificationCode;
            _info = ExtraInfo;
        }

        public Model(string Manufacturer, string VerificationCode, int NumberOfCores, int OsBit, string[] ExtraInfo) :
            base(NumberOfCores, OsBit)
        {
            this.Manufacturer = Manufacturer;
            this.VerificationCode = VerificationCode;
            _info = ExtraInfo;
        }

        public Model(string Manufacturer, string VerificationCode, int OsBit, string[] ExtraInfo) :
            base(OsBit)
        {
            this.Manufacturer = Manufacturer;
            this.VerificationCode = VerificationCode;
            _info = ExtraInfo;
        }

        public string this[int index]
        {
            get
            {
                return _info[index];
            }
            set
            {
                _info[index] = value;
            }
        }

        public void DisplayProps()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Props for the processor under id: {SerialNumber}");
            for (int i = 0; i < _info.Length; i++)
            {
                Console.WriteLine("-" + _info[i]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void CheckData()
        {
            if (!IsBlocked)
            {
                Console.WriteLine("\nDATA IS CHECKED...");
            }
        }
    }
    // End of Model Class


    // Start of Abstract OperationSystem Class
    abstract class OperationSystem: Model
    {
        public string Title {get; private set;}
        public string CompanyName { get; private set; }
        static public List<Process> Processes = new List<Process>();

        private bool AVLever = false;
        
        public OperationSystem(string title, string companyName,
            string Manufacturer, string VerificationCode, int NumberOfCores, int YearOfRelease, int OsBit, string[] ExtraInfo) :
            base(Manufacturer, VerificationCode, NumberOfCores, YearOfRelease, OsBit, ExtraInfo)
        {
            Title = title;
            CompanyName = companyName;
        }

        public OperationSystem(string title, string companyName,
            string Manufacturer, string VerificationCode, int NumberOfCores, int OsBit, string[] ExtraInfo) :
            base(Manufacturer, VerificationCode, NumberOfCores, OsBit, ExtraInfo)
        {
            Title = title;
            CompanyName = companyName;
        }

        public OperationSystem(string title, string companyName,
            string Manufacturer, string VerificationCode, int OsBit, string[] ExtraInfo) :
            base(Manufacturer, VerificationCode, OsBit, ExtraInfo)
        {
            Title = title;
            CompanyName = companyName;
        }

        public void TurnOnAntivirus()
        {
            AVLever = !AVLever;
            if (AVLever)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Anti Virus has been truned on");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("---WARNING---");
                Console.WriteLine("Anti Virus has been truned off");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private string GenerateId()
        {
            string id = "";
            string Alphabet = "abcdefghijklmnopqrstuvwxyz" +
                              "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string Numbers = "1234567890";
            bool resume = false;
            Random randomiser = new Random();

            do
            {
                for (int i = 0; i < 20; i++)
                {
                    int toggle = randomiser.Next(0, 2);
                    if (toggle == 0)
                    {
                        id += Alphabet[randomiser.Next(0, 52)];
                    }
                    else
                    {
                        id += Numbers[randomiser.Next(0, 10)];
                    }
                }
                for (int i = 0; i < Processes.Count; i++)
                {
                    if (Processes[i].Id == id)
                    {
                        resume = true;
                    }
                }
            } while (resume);

            return id;
        }

        public void GenerateProcess(string ProcessName, string ProcessInfo)
        {
            Process Data = new Process();
            Data.Name = ProcessName;
            Data.Info = ProcessInfo;
            Data.Id = GenerateId();
            Processes.Add(Data);
        }

        public string DeleteProcess(string ProcessId)
        {
            string name = "";
            for (int i = 0; i < Processes.Count; i++)
            {
                if (Processes[i].Id == ProcessId)
                {
                    name = Processes[i].Name;
                    Processes.RemoveAt(i);
                    break;
                }
            }
            if (name == ""){
                return "NO SUCH PROCESS";
            }
            else
            {
                return $"The process {name} has been deleted";
            }
        }

        public void ListProcesses()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n---List of Processes---");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < Processes.Count; i++)
            {
                Processes[i].DisplayInfo();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
    // End of Abstract OperationSystem Class


    // Start of Computer Class
    class Computer:OperationSystem
    {
        public string CurrentOS { get; set; }

        private void DefineSystem(int index) {
            switch (index)
            {
                case 0:
                    {
                        CurrentOS = "Windows";
                        break;
                    }
                case 1:
                    {
                        CurrentOS = "MacOs";
                        break;
                    }
                case 2:
                    {
                        CurrentOS = "Ubuntu";
                        break;
                    }
                case 3:
                    {
                        CurrentOS = "ParrotOS";
                        break;
                    }
                case 4:
                    {
                        CurrentOS = "Arch";
                        break;
                    }
            }
        }

        public Computer(int osInt, string title, string companyName,
            string Manufacturer, string VerificationCode,
            int NumberOfCores, int YearOfRelease,
            int OsBit, string[] ExtraInfo) : base(title, companyName,
            Manufacturer, VerificationCode, NumberOfCores,
            YearOfRelease, OsBit, ExtraInfo)
        {
            DefineSystem(osInt);
        }

        public Computer(int osInt, string title, string companyName,
            string Manufacturer, string VerificationCode,
            int NumberOfCores,
            int OsBit, string[] ExtraInfo) : base(title, companyName,
            Manufacturer, VerificationCode, NumberOfCores, OsBit, ExtraInfo)
        {
            DefineSystem(osInt);
        }

        public Computer(int osInt, string title, string companyName,
            string Manufacturer, string VerificationCode,
            int OsBit, string[] ExtraInfo) : base(title, companyName,
            Manufacturer, VerificationCode, OsBit, ExtraInfo)
        {
            DefineSystem(osInt);
        }

        public void TackleTask()
        {
            if (!IsBlocked)
            {
                Console.WriteLine("\n---Loading---");
                Console.WriteLine("---Starting Tasks---");
                ListProcesses();
                Console.WriteLine("Downloading Movies...");
                Console.WriteLine("Posting pictures on FaceBook");
                Console.WriteLine("Establishing Connections");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DEVICE IS BLOCKED");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
    // End of Computer Class


    // Start of Mainframe Class
    class Mainframe : OperationSystem
    {
        public string CurrentOS { get; set; }
        public string Spec { get; set; }

        private void DefineSystem(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        CurrentOS = "Windows";
                        break;
                    }
                case 1:
                    {
                        CurrentOS = "MacOs";
                        break;
                    }
                case 2:
                    {
                        CurrentOS = "Ubuntu";
                        break;
                    }
                case 3:
                    {
                        CurrentOS = "ParrotOS";
                        break;
                    }
                case 4:
                    {
                        CurrentOS = "Arch";
                        break;
                    }
            }
        }

        public Mainframe(string spec, int osInt, string title, string companyName,
            string Manufacturer, string VerificationCode,
            int NumberOfCores, int YearOfRelease,
            int OsBit, string[] ExtraInfo) : base(title, companyName,
            Manufacturer, VerificationCode, NumberOfCores,
            YearOfRelease, OsBit, ExtraInfo)
        {
            DefineSystem(osInt);
            Spec = spec;
        }

        public Mainframe(string spec, int osInt, string title, string companyName,
            string Manufacturer, string VerificationCode,
            int NumberOfCores,
            int OsBit, string[] ExtraInfo) : base(title, companyName,
            Manufacturer, VerificationCode, NumberOfCores, OsBit, ExtraInfo)
        {
            DefineSystem(osInt);
            Spec = spec;
        }

        public Mainframe(string spec, int osInt, string title, string companyName,
            string Manufacturer, string VerificationCode,
            int OsBit, string[] ExtraInfo) : base(title, companyName,
            Manufacturer, VerificationCode, OsBit, ExtraInfo)
        {
            DefineSystem(osInt);
            Spec = spec;
        }

        public void TackleTask()
        {
            if (!IsBlocked)
            {
                Console.WriteLine("\n---Loading---");
                Console.WriteLine("---Starting Tasks---");
                ListProcesses();
                Console.WriteLine($"Spec {Spec} has been activated");
                Console.WriteLine("Recieveing data from satellite");
                Console.WriteLine("Making rquests to http://fonts.google.com/");
                Console.WriteLine("Establishing Connections");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DEVICE IS BLOCKED");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
    // End of Mainframe Class


    //Start of Server Supercomputer Class
    class Supercomputer : OperationSystem
    {
        public string CurrentOS { get; set; }
        public int MaxX { get; set; }

        private void DefineSystem(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        CurrentOS = "Windows";
                        break;
                    }
                case 1:
                    {
                        CurrentOS = "MacOs";
                        break;
                    }
                case 2:
                    {
                        CurrentOS = "Ubuntu";
                        break;
                    }
                case 3:
                    {
                        CurrentOS = "ParrotOS";
                        break;
                    }
                case 4:
                    {
                        CurrentOS = "Arch";
                        break;
                    }
            }
        }

        public Supercomputer(int maxX, int osInt, string title, string companyName,
            string Manufacturer, string VerificationCode,
            int NumberOfCores, int YearOfRelease,
            int OsBit, string[] ExtraInfo) : base(title, companyName,
            Manufacturer, VerificationCode, NumberOfCores,
            YearOfRelease, OsBit, ExtraInfo)
        {
            DefineSystem(osInt);
            MaxX = maxX;
        }

        public Supercomputer(int maxX, int osInt, string title, string companyName,
            string Manufacturer, string VerificationCode,
            int NumberOfCores,
            int OsBit, string[] ExtraInfo) : base(title, companyName,
            Manufacturer, VerificationCode, NumberOfCores, OsBit, ExtraInfo)
        {
            DefineSystem(osInt);
            MaxX = maxX;
        }

        public Supercomputer(int maxX, int osInt, string title, string companyName,
            string Manufacturer, string VerificationCode,
            int OsBit, string[] ExtraInfo) : base(title, companyName,
            Manufacturer, VerificationCode, OsBit, ExtraInfo)
        {
            DefineSystem(osInt);
            MaxX = maxX;
        }

        public void TackleTask()
        {
            if (!IsBlocked)
            {
                Console.WriteLine("\n---Loading---");
                Console.WriteLine("---Starting Tasks---");
                ListProcesses();
                Console.WriteLine($"Solving formulas with max power of x: x^{MaxX}");
                Console.WriteLine("Getting the answers");
                Console.WriteLine("Connecting to all the computers in the world");
                Console.WriteLine("Establishing Connections");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DEVICE IS BLOCKED");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
    // End of Supercomputer class


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
