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
            double dist = Math.Sqrt((N2bis.x-x)*(N2bis.x-x)+(N2bis.y-y)*(N2bis.y-y));
            if (Form1.matrice[x, y] == -1)
                // On triple le coût car on est dans un marécage
                dist = dist*3;
            return dist;
        }

        public override bool EndState()
        {
            return (x == Form1.xfinal) && (y == Form1.yfinal);
        }

        public override List<GenericNode> GetListSucc()
        {
            List<GenericNode> lsucc = new List<GenericNode>();

            for (int dx=-1; dx <= 1; dx++)
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
            return( 0 );
           
        }

        public override string ToString()
        {
            return Convert.ToString(x)+","+ Convert.ToString(y);
        }
    }
}
