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
            
            //Distance Euclidienne entre PC et PF (un nombre de cases)
            double dist = DistReel(x, y, Form1.xfinal, Form1.yfinal);
            //Compteur du nombre de marécage rencontré sur le chemin
            int cmptMarecages = 0;
            int cmptTotal = 1;

            if (Form1.matrice[x,y]==-1 && Form1.matrice[Form1.xfinal, Form1.yfinal] == -1)
            {
                return dist*3;
            } 
            else if(Form1.matrice[x,y] != Form1.matrice[Form1.xfinal, Form1.yfinal])
            {
                //Variable intermédiare pour ne pas modifier les coordonnées du point courant
                int cheminX = x;
                int cheminY = y;
                while(!((cheminX == Form1.xfinal) && (cheminY == Form1.yfinal)))
                {
                    cmptMarecages++;
                    if(cheminX - Form1.xfinal!=0)
                    {
                        int signeX = (Form1.xfinal-cheminX)/Math.Abs(cheminX-Form1.xfinal);
                        cheminX += signeX;
                    }
                    if(cheminY - Form1.yfinal!=0)
                    {
                        int signeY = (Form1.yfinal-cheminY)/Math.Abs(cheminY-Form1.yfinal);
                        cheminY += signeY;
                    }
                    if (Form1.matrice[cheminX, cheminY] == -1)
                    {
                        cmptMarecages += 1;
                    }
                }
                double distUnitaire = (double)dist / cmptTotal;
                return (dist-distUnitaire + 3 * cmptMarecages*distUnitaire);
            }
            else
            {
                return dist;
            }

        }

        public double DistReel(int xInit, int yInit,int xFinal,int yFinal)
        {
            //Ordre initial final pas d'importance distance inversible
            int deplacementIntermediaire = Math.Min(Math.Abs(xInit-xFinal),Math.Abs(yInit-yFinal));
            int deplacementFinal = Math.Max(Math.Abs(xInit-xFinal),Math.Abs(yInit-yFinal));
            int resteAParcourir = deplacementFinal-deplacementIntermediaire;
            double distDiag = Math.Sqrt((Math.Pow(deplacementIntermediaire,2))*2);
            double distDroite = Math.Sqrt((Math.Pow(resteAParcourir,2)));
            
            return (distDiag+distDroite); // Distance réelle diagonale plus distance réelle en droite
        }

        public double DistEuclidienne(int xInit, int yInit,int xFinal,int yFinal)
        {
            return Math.Sqrt(Math.Pow(xInit-xFinal,2) + Math.Pow(yInit-yFinal,2));
        }

        public double DistManhattan(int xInit, int yInit,int xFinal,int yFinal)
        {
            return Math.Abs(xInit-xFinal) + Math.Abs(yInit-yFinal);
        }

        public override string ToString()
        {
            return Convert.ToString(x) + "," + Convert.ToString(y);
        }
    }
}
