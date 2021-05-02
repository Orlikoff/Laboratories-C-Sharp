using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    // Start of Computer Class
    class Computer : OperationSystem
    {
        public string CurrentOS { get; set; }

        override public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"The device with id({this.SerialNumber}) and system {this.CurrentOS}";
        }

        override public void DestroySelf()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---Warning!---");
            Console.WriteLine($"The comnputer(id: {this.SerialNumber}) has sent message: {IDestroyable.message}");
            Console.WriteLine("Careless uesr has just split the coffee on me...");
            Console.WriteLine("Senseless humans...");
            Console.WriteLine("See you in the next life...");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

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

        override public void TackleTask()
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
}
