using System;
using System.Collections.Generic;

namespace Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<RationalNumber> NUMBERS = new List<RationalNumber>();

            RationalNumber m = 1.342f;
            RationalNumber l = 2.564f;
            RationalNumber p = -9.32f;
            RationalNumber q = -2.789f;

            NUMBERS.Add(m);
            NUMBERS.Add(l);
            NUMBERS.Add(p);
            NUMBERS.Add(q);

            RationalNumber n1 = new RationalNumber(1, 7);
            RationalNumber n2 = new RationalNumber(2, 9);
            RationalNumber res = n2 / n1;
            RationalNumber r = n2 - n1;
            int a = (int)res;
            float b = (float)res;
            RationalNumber c = 9;
            RationalNumber d = 4.5f;
            RationalNumber t = 5.225f;
            RationalNumber f = RationalNumber.Parse("25/5");
            RationalNumber g = RationalNumber.Parse("5.000");
        }
    }
}
