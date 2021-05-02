using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    // Start of Mainframe Class
    class Mainframe : OperationSystem
    {
        public string CurrentOS { get; set; }
        public string Spec { get; set; }

        override public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"The device with id({this.SerialNumber}) and system {this.CurrentOS}";
        }

        override public void DestroySelf()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---Warning!---");
            Console.WriteLine($"The mainframe(id: {this.SerialNumber}) has sent message: {IDestroyable.message}");
            Console.WriteLine("Spotted suspicious connections in the newtwork...");
            Console.WriteLine("Clearing all the data on the servers...");
            Console.WriteLine("Dead but not broken...");
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

        override public void TackleTask()
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
}
