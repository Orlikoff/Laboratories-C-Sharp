using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_7
{
    public class RationalNumber
    {
        private int m_;
        private int n_;
        public int n
        {
            get
            {
                return n_;
            }
            set
            {
                n_ = value;
            }
        }
        public int m
        {
            set
            {
                while (value <= 0)
                {
                    Console.WriteLine("Input correct m: ");
                    value = int.Parse((Console.ReadLine()));
                }
                m_= value;
            }

            get
            {
                return m_;
            }
        }

        public RationalNumber(int N, int M)
        {
            if (N / M > 1) 
            { 
            }
            n = N;
            m = M;
        }

        public void PrintTheNumber()
        {
            Console.WriteLine($"{this.n}/{this.m}");
        }
    }
}
