using System;
using System.Runtime.InteropServices;

namespace KeyLogger
{
    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)] static extern int MessageBox(int hWnd, string text, string caption, uint type);

        static void Main(string[] args)
        {
            MessageBox(0, "Hello", "Title", 0);
        }
    }
}
