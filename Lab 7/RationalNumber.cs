using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lab_7
{
    public class RationalNumber: IComparable<RationalNumber>, IFormattable
    {
        private int m_;
        private int n_;
        public float fraction;
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
            n = N;
            m = M;
            fraction = (float)n / (float)m;
            EuclidianAlgorithm();
        }

        public int CompareTo(RationalNumber obj)
        { 
            if (obj != null)
            {
                if (this.fraction == obj.fraction)
                {
                    return 0;
                }
                else if (this.fraction <= obj.fraction)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                throw new Exception("Theese objects are incomparable!");
            }   
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null) format = "N";
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "F":
                    return $"{this.n}/{this.m}";
                case "D":
                    return $"{this.fraction}";
                case "I":
                    return $"{this.n}/{this.m} = {this.fraction}";
                default:
                    if (m == 1)
                    {
                        return $"{this.n}";
                    }
                    return $"{this.n}/{this.m}";
            } 
        }

        public float GetDecimalRepresentation()
        {
            return this.fraction;
        }

        private void EuclidianAlgorithm()
        {
            if (n == 0)
            {
                return;
            }
            int tempN;
            int tempM = m;
            if (n < 0)
            {
                tempN = -n;
            }
            else
            {
                tempN = n;
            }

            while (tempN != tempM)
            {
                if (tempN > tempM)
                {
                    tempN = tempN - tempM;
                }
                else
                {
                    tempM = tempM - tempN;
                }
            }

            n = n / tempN;
            m = m / tempM;
        }

        // Math operations
        public static RationalNumber operator +(RationalNumber n1, RationalNumber n2)
        {
            int newM = n1.m * n2.m;
            int newN1 = n1.n * n2.m;
            int newN2 = n2.n * n1.m;
            RationalNumber result = new RationalNumber(newN1 + newN2, newM);

            return result;
        }

        public static RationalNumber operator -(RationalNumber n1, RationalNumber n2)
        {
            int newM = n1.m * n2.m;
            int newN1 = n1.n * n2.m;
            int newN2 = n2.n * n1.m;
            RationalNumber result = new RationalNumber(newN1 - newN2, newM);

            return result;
        }

        public static RationalNumber operator *(RationalNumber n1, RationalNumber n2)
        {
            RationalNumber result = new RationalNumber(n1.n * n2.n, n1.m * n2.m);

            return result;
        }

        public static RationalNumber operator /(RationalNumber n1, RationalNumber n2)
        {
            RationalNumber result = new RationalNumber(n1.n * n2.m, n1.m * n2.n);

            return result;
        }

        public static implicit operator RationalNumber(int n)
        {
            return new RationalNumber(n, 1);
        }

        public static implicit operator RationalNumber(float f)
        {
            string number = f.ToString();
            string[] buf = number.Split(',');
            if (buf.Length == 1)
            {
                return new RationalNumber(Int32.Parse(buf[0]), 1);
            }
            int newM = 1;
            int newN = 1;
            for (int i = 0; i < buf[1].Length; i++)
            {
                newM *= 10;
            }
            if (buf[0][0] == '-')
            {
                buf[0] = buf[0].Replace("-", string.Empty);
                newN = Int32.Parse(buf[0]) * newM + Int32.Parse(buf[1]);
                newN = -newN;
            } 
            else {
                buf[0].Replace("-", string.Empty);
                newN = Int32.Parse(buf[0]) * newM + Int32.Parse(buf[1]);
            }

            return new RationalNumber(newN, newM);
        }

        public static explicit operator int(RationalNumber number)
        {
            return (int)number.fraction;
        }

        public static explicit operator float(RationalNumber number)
        {
            return number.fraction;
        }

        public static RationalNumber Parse(string str)
        {
            string[] buf;

            if (str.Split('/').Length != 1)
            {
                buf = str.Split('/');
                return new RationalNumber(Int32.Parse(buf[0]), Int32.Parse(buf[1]));
            }
            else if (str.Split(',').Length != 1)
            {
                buf = str.Split(',');
                int newM = 1;
                int newN = 1;
                for (int i = 0; i < buf[1].Length; i++)
                {
                    newM *= 10;
                }
                if (buf[0][0] == '-')
                {
                    buf[0] = buf[0].Replace("-", string.Empty);
                    newN = Int32.Parse(buf[0]) * newM + Int32.Parse(buf[1]);
                    newN = -newN;
                }
                else
                {
                    buf[0].Replace("-", string.Empty);
                    newN = Int32.Parse(buf[0]) * newM + Int32.Parse(buf[1]);
                }

                return new RationalNumber(newN, newM);
            }
            else if (str.Split('.').Length != 1)
            {
                buf = str.Split('.');
                int newM = 1;
                int newN = 1;
                for (int i = 0; i < buf[1].Length; i++)
                {
                    newM *= 10;
                }
                if (buf[0][0] == '-')
                {
                    buf[0] = buf[0].Replace("-", string.Empty);
                    newN = Int32.Parse(buf[0]) * newM + Int32.Parse(buf[1]);
                    newN = -newN;
                }
                else
                {
                    buf[0].Replace("-", string.Empty);
                    newN = Int32.Parse(buf[0]) * newM + Int32.Parse(buf[1]);
                }

                return new RationalNumber(newN, newM);
            }
            else
            {
                throw new Exception("This format is not supported");
            }
        }

        // Logical Operations
        public static bool operator ==(RationalNumber n1, RationalNumber n2)
        {
            int newN1 = n1.n * n2.m;
            int newN2 = n2.n * n1.m;

            if (newN1 == newN2)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(RationalNumber n1, RationalNumber n2)
        {
            int newN1 = n1.n * n2.m;
            int newN2 = n2.n * n1.m;

            if (newN1 != newN2)
            {
                return true;
            }
            return false;
        }

        public static bool operator <=(RationalNumber n1, RationalNumber n2)
        {
            int newN1 = n1.n * n2.m;
            int newN2 = n2.n * n1.m;

            if (newN1 <= newN2)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(RationalNumber n1, RationalNumber n2)
        {
            int newN1 = n1.n * n2.m;
            int newN2 = n2.n * n1.m;

            if (newN1 >= newN2)
            {
                return true;
            }
            return false;
        }

        public static bool operator <(RationalNumber n1, RationalNumber n2)
        {
            int newN1 = n1.n * n2.m;
            int newN2 = n2.n * n1.m;

            if (newN1 < newN2)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(RationalNumber n1, RationalNumber n2)
        {
            int newN1 = n1.n * n2.m;
            int newN2 = n2.n * n1.m;

            if (newN1 > newN2)
            {
                return true;
            }
            return false;
        }
    }
}
