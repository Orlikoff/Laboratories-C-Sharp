using System;
using System.Collections.Generic;

namespace Lab_7
{
    class Program
    {
        static void Main(string[] args)
        { 
            RationalNumber n1 = new RationalNumber(1, 7);
            RationalNumber n2 = new RationalNumber(2, 9);
            RationalNumber res = n2 / n1;
            RationalNumber r = n2 - n1;
            int a = (int)res;
            float b = (float)res;
            RationalNumber c = 9;
            RationalNumber d = 4.5f;
            RationalNumber t = 5.225f;
            Console.WriteLine(d == t);
            Console.WriteLine(t);
            Console.WriteLine(r);
            RationalNumber f = RationalNumber.Parse("25/5");
            RationalNumber g = RationalNumber.Parse("5.000");
            Console.WriteLine(f);
            Console.WriteLine(g);
            Console.WriteLine(g > f);
        }
    }
}
