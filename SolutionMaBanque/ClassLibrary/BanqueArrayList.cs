using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;

namespace ClassLibrary
{
    class MonComparer2 : IComparer<Compte>
    {
        public int Compare(Compte? c1, Compte? c2)
        {
            if (c1 is not null)
            {
                return c1.CompareTo(c2);
            }
            return 0;
        }
    }
    public class BanqueArrayList
    {
        private string nom;
        private string ville;
        private ArrayList mesComptes;
        public BanqueArrayList(string nom, string ville)
        {
            this.nom = nom;
            this.ville = ville;
            mesComptes = new ArrayList();
        }

        private void AjouterCompte(Compte _unCompte)
        {
            mesComptes.Add(new Compte(_unCompte));
        }

        public void AjouterCompte(int _num, string _nom, int _solde, int _decouvertAutorise)
        {
            Compte _compte = new Compte(_num, _nom, _solde, _decouvertAutorise);
            mesComptes.Add(_compte);
        }

        public override string ToString()
        {
            string affichage;
            affichage = base.ToString() + "\tNom : " + nom + "\tville : " + ville + "\n-----------------------------\n";
            foreach (Compte _compte in mesComptes)
            {
                affichage += _compte.ToString() + "\n";
            }
            return affichage;
        }

        public void TriParComparer()
        {
            this.mesComptes.Sort(new MonComparer3());
            this.mesComptes.Reverse();
        }

        public Compte? RendCompte(int _numero)
        {
            Compte? compteARetourner = null;
            if (this.mesComptes.Count != 0)
            {
                int i = 0;
                while (i < this.mesComptes.Count)
                {
                    if (this.mesComptes[i] is Compte)
                    {
                        if (_numero == ((Compte?)mesComptes[i])?.Numero)
                        {
                            compteARetourner = (Compte?)this.mesComptes[i];
                        }
                    }
                    i++;
                }
            }
            return compteARetourner;
        }

        public bool Transferer(int _numCompteDebit, int _numCompteCredit, int _montant)
        {
            Compte? compteDebit = RendCompte(_numCompteDebit);
            Compte? compteCredit = RendCompte(_numCompteCredit);
            if (compteCredit != null && compteDebit != null)
            {
                return compteDebit.Transferer(_montant, compteCredit);
            }
            return false;
        }
    }
}
