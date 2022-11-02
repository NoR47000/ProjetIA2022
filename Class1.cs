using System;
using System.Collections.Generic;
using System.Linq;
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

            //x et y du noeaud examiné
            //Form1.xinitial et Form1.yinitial qui sont accessible car static
            //Form1.xfinal Form1.yfinal
            //matrice[x,y] indique le type de case (-1 si marécage, 0 si rien, -2 si obstacle) 

            //Problème 1 : 

            return (Math.Sqrt((x - Form1.xfinal) ^ 2 + (y - Form1.yfinal) ^ 2));

            //Problème 2 : Décomposition en 2 sous problèmes en passant par un point de passage

            Node2 pointPassage = new Node2(10, 20);

            if (x < 10)
                return (Math.Sqrt((x - pointPassage.x) ^ 2 + (y - pointPassage.y) ^ 2));
            else
                return (Math.Sqrt((x - Form1.xfinal) ^ 2 + (y - Form1.yfinal) ^ 2));

            //Problème 3 : 
            Node2 pointInterdit1 = new Node2(1, 1);
            Node2 pointInterdit2 = new Node2(1, 1);
            //Devant l'entrée interdite
            Node2 pointPassage1 = new Node2(1, 1);
            //En haut
            Node2 pointPassage2 = new Node2(10, 20);
            if (x < 10)
            {
                if (x != pointInterdit1.x && x != pointInterdit2.x && y != pointInterdit1.y && y != pointInterdit2.y)
                    return (Math.Sqrt((x - pointPassage1.x) ^ 2 + (y - pointPassage1.y) ^ 2));
                else
                    return (1000);
            }
            else
                return (Math.Sqrt((x - Form1.xfinal) ^ 2 + (y - Form1.yfinal) ^ 2));

            return (0);

        }

        public override string ToString()
        {
            return Convert.ToString(x) + "," + Convert.ToString(y);
        }
    }
}
