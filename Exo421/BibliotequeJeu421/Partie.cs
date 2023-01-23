using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BibliotequeJeu421
{
    public class Partie
    {
        private int nbManchesSouhaitees;
        private int nbManchesEffectuees;
        private ushort score;
        private Manche mancheCourante;

        public Partie(int _nbManchesSouhaitees)
        {
            this.nbManchesSouhaitees = _nbManchesSouhaitees;
            this.nbManchesEffectuees = 0;
            this.score = (ushort)(_nbManchesSouhaitees * 10);
            this.mancheCourante = new Manche();
        }

        public Partie() : this(10) { }

        public ushort GetScore { get => score; }

        public bool AEncoreUneMancheAJouer()
        {
            return (this.nbManchesEffectuees<this.nbManchesSouhaitees);
        }

        public void CreerUneNouvelleManche()
        {
            this.mancheCourante = new Manche();
            this.nbManchesEffectuees++;
            Console.WriteLine("Nombre de manches restantes : " + (this.nbManchesSouhaitees - this.nbManchesEffectuees));
            Console.WriteLine("Saisir entrée pour continuer. ");
            Console.ReadLine();
        }

        public bool MancheCouranteAEncoreLancer()
        {
            return this.mancheCourante.AEncoreUnLancer();
        }

        public bool MancheCouranteEstGagnante()
        {
            if (this.mancheCourante.EstGagnante())
            {
                score += 30;
                return true;
            }
            else
            {
                score -= 10;
                return false;
            }
        }

        private string SaisieNombreDeALancer()
        {
            Console.WriteLine("Combien de dés à relancer ? (1,2,3)");
            string? saisie = Console.ReadLine();
            if (Regex.IsMatch(saisie, @"[1|2|3]{1}"))
            {
                return saisie; 
            }
            return SaisieNombreDeALancer();
        }

        public void LancerDesMancheCourante()
        {
            mancheCourante.Relancer();
            mancheCourante.Trier();
            Console.WriteLine("Lancer n°" + mancheCourante.GetNbLancerEffectue + "\tDés obtenus : " + mancheCourante.VoirDes());

            while (this.MancheCouranteAEncoreLancer() && !this.mancheCourante.EstGagnante())
            {
                string saisie = SaisieNombreDeALancer();
                if (saisie == "3")
                {
                    mancheCourante.Relancer();
                }
                if (saisie == "2")
                {
                    Console.WriteLine("Quels dés à relancer ? Premier dé : ");
                    string? saisie1 = Console.ReadLine();
                    Console.WriteLine("Quels dés à relancer ? Second dé : ");
                    string? saisie2 = Console.ReadLine();
                    mancheCourante.Relancer(Convert.ToByte(saisie1), Convert.ToByte(saisie2));
                }
                if (saisie == "1")
                {
                    Console.WriteLine("Quel dé à relancer ? ");
                    string? saisie3 = Console.ReadLine();
                    mancheCourante.Relancer(Convert.ToByte(saisie3));
                }
                mancheCourante.Trier();
                Console.Clear();
                Console.WriteLine("Lancer n°" + mancheCourante.GetNbLancerEffectue + "\tDés obtenus: " + mancheCourante.VoirDes());
            }
            Console.WriteLine("La manche est " + (MancheCouranteEstGagnante() ? "gagnée : +30 points :)" : "perdue : -10 points :("));

        }
    }
}