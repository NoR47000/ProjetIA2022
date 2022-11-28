using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA2022
{
    public class Node2 : GenericNode
    {
        public int x;
        public int y;

        // Méthodes abstrates, donc à surcharger obligatoirement avec override dans une classe fille
        public override bool IsEqual(GenericNode N2)
        {
            Node2 N2bis = (Node2)N2;

            return (x == N2bis.x) && (y == N2bis.y);
        }

        public override double GetArcCost(GenericNode N2)
        {
            // Ici, N2 ne peut être qu'1 des 8 voisins, inutile de le vérifier
            Node2 N2bis = (Node2)N2;
            double dist = Math.Sqrt((N2bis.x - x) * (N2bis.x - x) + (N2bis.y - y) * (N2bis.y - y));
            if (Form1.matrice[x, y] == -1)
                // On triple le coût car on est dans un marécage
                dist = dist * 3;
            return dist;
        }

        public override bool EndState()
        {
            return (x == Form1.xfinal) && (y == Form1.yfinal);
        }

        public override List<GenericNode> GetListSucc()
        {
            List<GenericNode> lsucc = new List<GenericNode>();

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if ((x + dx >= 0) && (x + dx < Form1.nbcolonnes)
                            && (y + dy >= 0) && (y + dy < Form1.nblignes) && ((dx != 0) || (dy != 0)))
                        if (Form1.matrice[x + dx, y + dy] > -2)
                        {
                            Node2 newnode2 = new Node2();
                            newnode2.x = x + dx;
                            newnode2.y = y + dy;
                            lsucc.Add(newnode2);
                        }
                }

            }
            return lsucc;
        }


        public override double CalculeHCost()
        {

        }

        public double DistReel(int xInit, int yInit, int xFinal, int yFinal)
        {
            //Ordre initial final pas d'importance distance inversible
            int deplacementIntermediaire = Math.Min(Math.Abs(xInit - xFinal), Math.Abs(yInit - yFinal));
            int deplacementFinal = Math.Max(Math.Abs(xInit - xFinal), Math.Abs(yInit - yFinal));
            int resteAParcourir = deplacementFinal - deplacementIntermediaire;
            double distDiag = Math.Sqrt((Math.Pow(deplacementIntermediaire, 2)) * 2);
            double distDroite = Math.Sqrt((Math.Pow(resteAParcourir, 2)));

            return (distDiag + distDroite); // Distance réelle diagonale plus distance réelle en ligne droite
        }

        public double DistAvecMarecage(int xDebut, int yDebut, double distance, int xFin, int yFin)
        {
            int cmptMarecages = 0;
            int cmptTotal = 1;

            //Variable intermédiare pour ne pas modifier les coordonnées du point courant
            int cheminX = xDebut;
            int cheminY = yDebut;
            while (!((cheminX == xFin) && (cheminY == yFin)))
            {
                cmptTotal++;
                if (cheminX - xFin != 0)
                {
                    int signeX = (xFin - cheminX) / Math.Abs(cheminX - xFin);
                    cheminX += signeX;
                }
                if (cheminY - yFin != 0)
                {
                    int signeY = (yFin - cheminY) / Math.Abs(cheminY - yFin);
                    cheminY += signeY;
                }
                if (Form1.matrice[cheminX, cheminY] == -1)
                {
                    cmptMarecages += 1;
                }
            }
            //La distance totale est alors la somme du nombre de marécage rencontré fois trois
            //plus le reste des cases à parcourir pour arriver à PF
            double distUnitaire = (double)distance / cmptTotal;
            distance = distance - distUnitaire * cmptMarecages + 3 * cmptMarecages * distUnitaire;
            return distance;
        }

        public double DistEuclidienne(int xInit, int yInit, int xFinal, int yFinal)
        {
            return Math.Sqrt(Math.Pow(xInit - xFinal, 2) + Math.Pow(yInit - yFinal, 2));
        }

        public double DistManhattan(int xInit, int yInit, int xFinal, int yFinal)
        {
            return Math.Abs(xInit - xFinal) + Math.Abs(yInit - yFinal);
        }

        public override string ToString()
        {
            return Convert.ToString(x) + "," + Convert.ToString(y);
        }
    }
}
