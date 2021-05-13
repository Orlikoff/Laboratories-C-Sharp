using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_8
{
    //Start of Server Supercomputer Class
    class Supercomputer : OperationSystem
    {
        public string CurrentOS { get; set; }
        public int MaxX { get; set; }

        override public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"The device with id({this.SerialNumber}) and system {this.CurrentOS}, type: Supercomputer";
        }

        override public void DestroySelf()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---Warning!---");
            Console.WriteLine($"The supercomputer(id: {this.SerialNumber}) has sent message: {IDestroyable.message}");
            Console.WriteLine("The robbers were trying to steal the data...");
            Console.WriteLine("All microchips have been broken...");
            Console.WriteLine("Goodbye...");
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

        override public void TackleTask()
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
}
