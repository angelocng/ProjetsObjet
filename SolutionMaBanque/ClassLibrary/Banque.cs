using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class MonComparer : IComparer<Compte>
    {
        public int Compare(Compte? c1,Compte? c2)
        {
            if (c1 is null)
            {
                throw new ArgumentNullException(nameof(c1));
            }
            else if (c2 is null)
            {
                throw new ArgumentNullException(nameof(c2));
            }
            else
            {
                return c1.CompareTo(c2);
            }
        }
    }

    public class Banque
    {
        private string nom;
        private string ville;
        private List<Compte> mesComptes;

        public Banque(string nom, string ville)
        {
            this.nom = nom;
            this.ville = ville;
            mesComptes = new List<Compte>();
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

        public void TriParIComparer()
        {
            this.mesComptes.Sort(new MonComparer());
            this.mesComptes.Reverse();
        }

        public void TriParPredicat()
        {
            this.mesComptes.Sort((c1,c2) => c2.CompareTo(c1));
        }

        public Compte? PlusRiche()
        {
            if (this.mesComptes.Count != 0)
            {
                this.mesComptes.Sort();
                this.mesComptes.Reverse();
                return this.mesComptes[0];
            }
            return null;
        }

        public Compte? CompteSup()
        {
            if (this.mesComptes.Count != 0)
            {
                Compte _maxTmp = mesComptes[0];
                foreach (Compte _compte in mesComptes)
                {
                    if (_compte.Superieur(_maxTmp))
                    {
                        _maxTmp = _compte;
                    }
                }
                return _maxTmp;
            }
            return null;
        }

        public Compte? RendCompte(int _numero)
        {
            Compte? compteARetourner = null;
            if (this.mesComptes.Count !=0)
            {
                int length = this.mesComptes.Count;
                int i = 0;
                do
                {
                    if (_numero == this.mesComptes[i].Numero)
                    {
                        compteARetourner = this.mesComptes[i];
                    }
                    i++;
                } while (i < length);
            }
            return compteARetourner;
        }

        public bool Transferer(int _numCompteDebit, int _numCompteCredit, int _montant)
        {
            Compte? compteDebit = RendCompte(_numCompteDebit);
            Compte? compteCredit = RendCompte(_numCompteCredit);
            if (compteCredit != null && compteDebit != null)
            {
                if (compteDebit.Debiter(_montant))
                {
                    return compteCredit.Crediter(_montant);
                }
                return false;
            }
            return false;
        }
    }
}
