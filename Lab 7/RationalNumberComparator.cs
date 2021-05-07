using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_7
{
    class RationalNumberComparator: IComparer<RationalNumber>
    {
        public int Compare(RationalNumber n1, RationalNumber n2)
        {
            if (n1.fraction > n2.fraction)
            {
                return 1;
            }
            else if (n1.fraction < n2.fraction)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
