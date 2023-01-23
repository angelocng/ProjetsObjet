using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotequeJeu421
{
    internal class ComparerDes:IComparer<De>
    {
        public int Compare(De? de1, De? de2)
        {
            if (de1 == null || de2 == null)
            {
                throw new ArgumentNullException();
            }
            return de1.CompareTo(de2);
        }
    }
}
