using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
    // Start of Abstract OperationSystem Class
    abstract class OperationSystem : Model, IDestroyable, IComparable<OperationSystem>, IFormattable
    {
        public string Title { get; private set; }
        public string CompanyName { get; private set; }
        public List<Process> Processes = new List<Process>();

        private bool AVLever = false;

        public int CompareTo(OperationSystem o)
        {

            return this.yearOfRelease.CompareTo(o.yearOfRelease);
        }

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
            if (name == "")
            {
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

        abstract public void TackleTask();
        public abstract void DestroySelf();
        public abstract string ToString(string format, IFormatProvider formatProvider);
    }
    // End of Abstract OperationSystem Class
}
