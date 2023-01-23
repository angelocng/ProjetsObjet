using System.Numerics;
using System.Runtime.CompilerServices;

namespace ClassLibrary
{
    public class Compte:IComparable<Compte>
    {
        private int decouvertAutorise;
        private string nom;
        private int numero;
        private int solde;
        public int Solde { get => solde; }
        public int Numero { get=> numero;}
        public Compte()
        {
            numero = 0123456;
            nom = "Mon nom";
            solde = 1000;
            decouvertAutorise = -100;
        }
        public Compte(Compte _compteARecopier) :
            this(_compteARecopier.numero, _compteARecopier.nom, _compteARecopier.solde, _compteARecopier.decouvertAutorise){ }
        public Compte(int numero, string nom, int solde, int decouvertAutorise)
        {
            this.numero = numero;
            this.nom = nom;
            this.solde = solde;
            this.decouvertAutorise = decouvertAutorise;
        }
        public override string ToString()
        {
            string affichage;
            affichage = "numero : " + numero + "\t nom : " + nom + "\t solde : " + solde + "\t decouvert autorisé : " + decouvertAutorise;
            return affichage;
        }
        public bool Crediter(int _montantACrediter)
        {
            if (_montantACrediter > 0)
            {
                this.solde += _montantACrediter;
                return true;
            }
            return false;
        }
        public bool Debiter(int _montantADebiter)
        {
            if (_montantADebiter > 0)
            {
                int reste = this.solde - _montantADebiter;
                if (reste > this.decouvertAutorise)
                {
                    this.solde = reste;
                    return true;
                }
            }
            return false;
        }

        public bool Transferer(int _montantATransferer, Compte _compteACrediter)
        {
            bool estDebite = this.Debiter(_montantATransferer);
            if (estDebite)
            {
                return _compteACrediter.Crediter(_montantATransferer);
            }
            return false;
        }

        public int CompareTo(Compte? other)
        {
            return this.solde.CompareTo(other?.solde);
        }

        public bool Superieur(Compte c2)
        {
            if (this.solde > c2.solde)
            {
                return true;
            }
            return false;
        }
    }
}