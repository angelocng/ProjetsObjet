using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotequeJeu421
{
    public class Jeu
    {
        private int nbManche;
        private Partie maPartie;
        public Jeu(int nbManche)
        {
            this.maPartie = new Partie(nbManche);
            this.nbManche = nbManche;
        }
        public void Jouer()
        {
            while (maPartie.AEncoreUneMancheAJouer() && (maPartie.GetScore > 0))
            {
                Console.WriteLine("Votre score est de : " + maPartie.GetScore + " points. ");
                maPartie.LancerDesMancheCourante();
                maPartie.CreerUneNouvelleManche();
                Console.Clear();
            }
            Console.WriteLine("Votre score est de : " + maPartie.GetScore + " point" + ((maPartie.GetScore > 1) ? "s. " : ". "));

        }
    }
}
