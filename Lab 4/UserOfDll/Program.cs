using System;
using System.Runtime.InteropServices;

namespace UserOfDll
{
    class Program
    {
        // Importing fucntions from mine custom DLL
        [DllImportAttribute("C:\\Users\\Orlik\\Desktop\\C#\\Lab 4\\MyDll\\Debug\\MyDll.dll",
            CharSet=CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern float SquareRect(float a, float b);
        [DllImportAttribute("C:\\Users\\Orlik\\Desktop\\C#\\Lab 4\\MyDll\\Debug\\MyDll.dll",
            CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern float SquareCircle(float R);
        [DllImportAttribute("C:\\Users\\Orlik\\Desktop\\C#\\Lab 4\\MyDll\\Debug\\MyDll.dll",
            CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern float SquareEllipse(float a, float b);
        [DllImportAttribute("C:\\Users\\Orlik\\Desktop\\C#\\Lab 4\\MyDll\\Debug\\MyDll.dll",
            CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern float VolumeSphere(float R);
        [DllImportAttribute("C:\\Users\\Orlik\\Desktop\\C#\\Lab 4\\MyDll\\Debug\\MyDll.dll",
            CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern float Volume2Base(float height, float a, float b);
        [DllImportAttribute("C:\\Users\\Orlik\\Desktop\\C#\\Lab 4\\MyDll\\Debug\\MyDll.dll",
            CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern float Volume3Base(float height, float a, float BaseHeight);
        [DllImportAttribute("C:\\Users\\Orlik\\Desktop\\C#\\Lab 4\\MyDll\\Debug\\MyDll.dll",
            CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern float Volume4Base(float height, float a, float BaseHeight);


        // Main Program
        static void Main(string[] args)
        {
            // Welcoming user
            Console.WriteLine("Welcome to simple calculator for\n" +
                "Calculating areas and volumes\n" +
                "Choose from theese options:\n" +
                "1. Rectangle Area\n" +
                "2. Circle Area\n" +
                "3. Ellipse Area\n" +
                "4. Sphere Volume\n" +
                "5. Volume of Straight Parallelogram\n" +
                "6. Volume of Triangle Parallelogram\n" +
                "7. Volume of Not Straight Parallelogram\n" +
                "8. Exit\n");
            while (true)
            {
                Console.Write("> ");
                string Option = Console.ReadLine();
                switch (Option[0])
                {
                    case '1':
                        {
                            float v, arg1, arg2;
                            Console.WriteLine("Input a, then b:");
                            Console.Write("a: ");
                            string a = Console.ReadLine();
                            Console.Write("b: ");
                            string b = Console.ReadLine();
                            try
                            {
                                arg1 = float.Parse(a);
                                arg2 = float.Parse(b);
                            }
                            catch
                            {
                                Console.WriteLine("Check parameters!");
                                break;
                            }
                            v = SquareRect(arg1, arg2);
                            Console.WriteLine($"Area Of Rectangle is: {v}");
                            break;
                        }
                    case '2':
                        {
                            float v, arg1;
                            Console.WriteLine("Input R:");
                            Console.Write("R: ");
                            string R = Console.ReadLine();
                            try
                            {
                                arg1 = float.Parse(R);
                            }
                            catch
                            {
                                Console.WriteLine("Check parameters!");
                                break;
                            }
                            v = SquareCircle(arg1);
                            Console.WriteLine($"Area Of Circle is: {v}");
                            break;
                        }
                    case '3':
                        {
                            float v, arg1, arg2;
                            Console.WriteLine("Input a, then b:");
                            Console.Write("a: ");
                            string a = Console.ReadLine();
                            Console.Write("b: ");
                            string b = Console.ReadLine();
                            try
                            {
                                arg1 = float.Parse(a);
                                arg2 = float.Parse(b);
                            }
                            catch
                            {
                                Console.WriteLine("Check parameters!");
                                break;
                            }
                            v = SquareEllipse(arg1, arg2);
                            Console.WriteLine($"Area Of Ellipse is: {v}");
                            break;
                        }
                    case '4':
                        {
                            float v, arg1;
                            Console.WriteLine("Input R:");
                            Console.Write("R: ");
                            string R = Console.ReadLine();
                            try
                            {
                                arg1 = float.Parse(R);
                            }
                            catch
                            {
                                Console.WriteLine("Check parameters!");
                                break;
                            }
                            v = VolumeSphere(arg1);
                            Console.WriteLine($"Volume Of Sphere is: {v}");
                            break;
                        }
                    case '5':
                        {
                            float v, arg1, arg2, arg3;
                            Console.WriteLine("Input height, then a, then b:");
                            Console.Write("height: ");
                            string height = Console.ReadLine();
                            Console.Write("a: ");
                            string a = Console.ReadLine();
                            Console.Write("b: ");
                            string b = Console.ReadLine();
                            try
                            {
                                arg1 = float.Parse(height);
                                arg2 = float.Parse(a);
                                arg3 = float.Parse(b);
                            }
                            catch
                            {
                                Console.WriteLine("Check parameters!");
                                break;
                            }
                            v = Volume2Base(arg1, arg2, arg3);
                            Console.WriteLine($"Volume of Straight Parallelogram is: {v}");
                            break;
                        }
                    case '6':
                        {
                            float v, arg1, arg2, arg3;
                            Console.WriteLine("Input height, then a, then BaseHeight:");
                            Console.Write("height: ");
                            string height = Console.ReadLine();
                            Console.Write("a: ");
                            string a = Console.ReadLine();
                            Console.Write("BaseHeight: ");
                            string BaseHeight = Console.ReadLine();
                            try
                            {
                                arg1 = float.Parse(height);
                                arg2 = float.Parse(a);
                                arg3 = float.Parse(BaseHeight);
                            }
                            catch
                            {
                                Console.WriteLine("Check parameters!");
                                break;
                            }
                            v = Volume3Base(arg1, arg2, arg3);
                            Console.WriteLine($"Volume of Triangle Parallelogram is: {v}");
                            break;
                        }
                    case '7':
                        {
                            float v, arg1, arg2, arg3;
                            Console.WriteLine("Input height, then a, then BaseHeight:");
                            Console.Write("height: ");
                            string height = Console.ReadLine();
                            Console.Write("a: ");
                            string a = Console.ReadLine();
                            Console.Write("BaseHeight: ");
                            string BaseHeight = Console.ReadLine();
                            try
                            {
                                arg1 = float.Parse(height);
                                arg2 = float.Parse(a);
                                arg3 = float.Parse(BaseHeight);
                            }
                            catch
                            {
                                Console.WriteLine("Check parameters!");
                                break;
                            }
                            v = Volume4Base(arg1, arg2, arg3);
                            Console.WriteLine($"Volume of Triangle Parallelogram is: {v}");
                            break;
                        }
                    case '8':
                        {
                            return;
                        }
                }
            }
        }
    }
}
