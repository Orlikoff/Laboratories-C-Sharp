using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_5
{
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
}
