using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6
{
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

        public int yearOfRelease;
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
}
