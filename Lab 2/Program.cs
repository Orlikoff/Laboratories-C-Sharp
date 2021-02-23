using System;
using System.Text;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start of task with DateTime
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---Task with DateTime objects---\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            string currentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            string currentTime2 = DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK");

            int[] numbers = new int[10];
            int[] numbers2 = new int[10];
            foreach (char symbol in currentTime)
            {
                switch (symbol)
                {
                    case '0':
                        {
                            numbers[0]++;
                            break;
                        }
                    case '1':
                        {
                            numbers[1]++;
                            break;
                        }
                    case '2':
                        {
                            numbers[2]++;
                            break;
                        }
                    case '3':
                        {
                            numbers[3]++;
                            break;
                        }
                    case '4':
                        {
                            numbers[4]++;
                            break;
                        }
                    case '5':
                        {
                            numbers[5]++;
                            break;
                        }
                    case '6':
                        {
                            numbers[6]++;
                            break;
                        }
                    case '7':
                        {
                            numbers[7]++;
                            break;
                        }
                    case '8':
                        {
                            numbers[8]++;
                            break;
                        }
                    case '9':
                        {
                            numbers[9]++;
                            break;
                        }
                }
            }

            foreach (char symbol in currentTime2)
            {
                switch (symbol)
                {
                    case '0':
                        {
                            numbers2[0]++;
                            break;
                        }
                    case '1':
                        {
                            numbers2[1]++;
                            break;
                        }
                    case '2':
                        {
                            numbers2[2]++;
                            break;
                        }
                    case '3':
                        {
                            numbers2[3]++;
                            break;
                        }
                    case '4':
                        {
                            numbers2[4]++;
                            break;
                        }
                    case '5':
                        {
                            numbers2[5]++;
                            break;
                        }
                    case '6':
                        {
                            numbers2[6]++;
                            break;
                        }
                    case '7':
                        {
                            numbers2[7]++;
                            break;
                        }
                    case '8':
                        {
                            numbers2[8]++;
                            break;
                        }
                    case '9':
                        {
                            numbers2[9]++;
                            break;
                        }
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{currentTime}");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Number of {i} in current date-time is: {numbers[i]}");
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"\n{currentTime2}");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Number of {i} in current2 date-time is: {numbers2[i]}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---End of task with DateTime objects---\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            //End of task with DateTime


            //Start of task with StringBuilder
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---Start of task with StringBuilder objects---\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Input the string: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine() + " ";
            Console.ForegroundColor = ConsoleColor.Gray;

            StringBuilder reversedString = new StringBuilder();

            StringBuilder currentWord = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    currentWord.Append(input[i]);
                }
                else
                {
                    currentWord.Append(' ');
                    reversedString.Insert(0, currentWord);
                    currentWord.Clear();
                }
            }

            reversedString.Remove(reversedString.Length - 1, 1);

            Console.WriteLine("\nThe string with reversed words is:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{reversedString.ToString()}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---End of task with StringBuilder objects---\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            //End of task with StringBuilder


            //Start of task with Random
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---Start of task with Random objects---\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            string dataString = "oashfgsdhfadcfniwhfvuicinugweycrmfe" +
                "yrarxhmFFDUAHGCGCIHCUGFVSCHJB" +
                "JVDJFHSDSPVdibvsdinvsbfdasfcgbfcnsjkvcvxhGCOHCGCGBWVGOHOJ" +
                "dhsycgnwrxfidmcgeucgjoifdkgdsdzgbdvahszqwkfx" +
                "hmcgregFFDSKNXBFGUWNMUINGFYMWGFGFNYg" +
                "fcunygeiwmfewiotacnyYUGHUGKFYWBNTXMUFWGMYGIUFGfdhkfgdsf"; // length is 256

            Console.WriteLine("The string you want is: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Random randomiser = new Random();

            for (int i = 0; i < 30; i++)
            {
                Console.Write(dataString[randomiser.Next(0, 256)] + " ");
            }
            Console.Write("\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---End of task with Random objects---\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            //End of taks with Random

            //Waiting for user
            Console.ReadKey();
        }
    }
}
