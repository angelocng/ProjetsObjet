using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class MonComparer3 : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x is null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            else if (!(x is Compte))
            {
                throw new ArgumentException(nameof(x), "x is not a Compte");
            }
            else if (y is null)
            {
                throw new ArgumentNullException(nameof(y));
            }
            else if (y is not Compte)
            {
                throw new ArgumentException(nameof(x), "y is not a Compte");
            }
            else
            {
                return ((Compte)x).CompareTo((Compte)y);
            }
        }
    }
}
