using System;
using System.Collections.Generic;


namespace Lab_3
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
    class Processor: ALU
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

        public Model(string Manufacturer, string VerificationCode, int NumberOfCores, int YearOfRelease, int OsBit):
            base(NumberOfCores, YearOfRelease, OsBit)
        {
            this.Manufacturer = Manufacturer;
            this.VerificationCode = VerificationCode;
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


    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Model New_Device = new Model("Intel", "ip2021certof", 8, 2021, 64);
            New_Device.CheckWorkingAbility();
            New_Device.CheckData();
            New_Device.DisplayInformation();
            Model New_Device2 = new Model("OrlikInc", "op2021certof", 8, 2021, 64);
            New_Device2.CheckWorkingAbility();
            New_Device2.CheckData();
            New_Device2.DisplayInformation();
        }
    }
}
