using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotequeJeu421
{
    public class Alea:Random
    {
        private static Alea monAlea = null;
        private Alea()
        {
        }
        public static Alea Instance()
        {
            if (monAlea == null)
            {
                monAlea= new Alea();
            }
            return monAlea;
        }
        public byte Nouveau(byte valMin,byte valMax)
        {
            return (byte)this.Next((int)valMin,(int)(valMax+1));
        }
    }
}
