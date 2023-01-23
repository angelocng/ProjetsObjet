namespace BibliotequeJeu421
{

    public class De: IComparable<De>
    {
        private byte valeur;
        private readonly byte valeurMin;
        private readonly byte valeurMax;
        private Alea alea;
        public byte GetValeur { get => valeur;}
        public De()
        {
            valeur = 1;
            valeurMin = 1;
            valeurMax = 6;
            alea = Alea.Instance();
        }
        public De(byte _valeurMin, byte _valeurMax)
        {
            valeur = _valeurMin;
            valeurMin = _valeurMax;
            valeurMax = _valeurMin;
            alea = Alea.Instance();
        }
        public void Rouler()
        {
            byte valeurAleatoire = alea.Nouveau(valeurMin, valeurMax);
            this.valeur = valeurAleatoire;
        }

        public int CompareTo(De? other)
        {
            return this.valeur.CompareTo(other?.valeur);
        }
    }
}
