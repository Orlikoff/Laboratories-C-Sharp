using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_8
{
    // Start of ALU Class
    class ALU
    {
        private static List<string> SerialNumbersList = new List<string>();
        private bool IsTurnedOn = false;
        protected string SerialNumber { get; }
        protected bool IsBlocked = false;

        public static event ActiveTask OnCreation;

        public string getSN()
        {
            return this.SerialNumber;
        }

        public static void RegisterTask(ActiveTask method)
        {
            OnCreation += method;
        }

        public static void UnRefgsterTask(ActiveTask method)
        {
            OnCreation -= method;
        }

        public void StartRegistration()
        {
            Console.WriteLine(this.SerialNumber);
        }

        public ALU()
        {
            SerialNumber = GenerateSerialNumber();
            OnCreation?.Invoke();
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
}
