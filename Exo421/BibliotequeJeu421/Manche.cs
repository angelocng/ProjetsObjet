using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BibliotequeJeu421
{
    public class Manche
    {
        private byte nbLancerEffectue;
        private readonly byte nbLancerMax;
        private De[] sesDes;
        public byte GetNbLancerEffectue { get { return nbLancerEffectue; } }
        public Manche()
        {
            nbLancerEffectue = 0;
            nbLancerMax = 3;
            sesDes = new De[3] { new De(), new De(), new De() };
            sesDes[0].Rouler();
            sesDes[1].Rouler();
            sesDes[2].Rouler();
        }
        public Manche(byte nbLancerEffectue, byte nbLancerMax, De[] sesDes)
        {
            this.nbLancerEffectue = nbLancerEffectue;
            this.nbLancerMax = nbLancerMax;
            this.sesDes = sesDes;
        }

        public Manche(Manche _mancheACopier) : this(_mancheACopier.nbLancerEffectue,
            _mancheACopier.nbLancerMax, _mancheACopier.sesDes)
        { }

        public string VoirDes()
        {
            string resultat = "";
            for (int i = 0; i < 3; i++)
            {
                resultat += this.sesDes[i].GetValeur + " ";
            }
            return resultat;
        }

        public bool AEncoreUnLancer()
        {
            if (this.nbLancerMax > this.nbLancerEffectue)
            {
                return true;
            }
            return false;
        }

        public bool EstGagnante()
        {
            this.Trier();
            if (sesDes[0].GetValeur == 4 && sesDes[1].GetValeur == 2 && sesDes[2].GetValeur == 1)
            {
                return true;
            }
            return false;
        }

        private void Relancer(De[] _numeroDe)
        {
            for (int i = 0; i < _numeroDe.Length; i++)
            {
                _numeroDe[i].Rouler();
            }
            this.nbLancerEffectue++;
        }

        public void Relancer(byte _valeurDe1, byte _valeurDe2)
        {
            if (AEncoreUnLancer())
            {
                int i = 0;
                bool de1Trouve = false;
                bool de2Trouve = false;
                int premierDe = 0;
                int secondDe = 0;
                do
                {
                    if (_valeurDe1 == this.sesDes[i].GetValeur && !de1Trouve)
                    {
                        premierDe = i;
                        de1Trouve = true;
                    }
                    else if (_valeurDe2 == this.sesDes[i].GetValeur && !de2Trouve)
                    {
                        secondDe = i;
                        de2Trouve = true;
                    }
                    i++;
                } while (i < 3 && !(de1Trouve && de2Trouve));
                if (de1Trouve && de2Trouve)
                {
                    De[] deARelancer = new De[2] { this.sesDes[premierDe], this.sesDes[secondDe] };
                    Relancer(deARelancer);
                }
            }
        }

        public void Relancer(byte _valeurDe)
        {
            if (AEncoreUnLancer())
            {
                int i = 0;
                int k = 0;
                do
                {
                    if (_valeurDe == this.sesDes[i].GetValeur)
                    {
                        De[] deARelancer = new De[1] { this.sesDes[i] };
                        Relancer(deARelancer);
                        k++;
                    }
                    i++;
                }
                while (i < 3 && k < 1);
            }
        }

        public void Relancer()
        {
            if (AEncoreUnLancer())
            {
                Relancer(this.sesDes);
            }
        }

        public void Trier()
        {
            Array.Sort(this.sesDes);
            Array.Reverse(this.sesDes);
        }
    }
}
