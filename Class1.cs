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

            //return (Math.Sqrt((this.x - Form1.xfinal)*(this.x - Form1.xfinal) + (this.y - Form1.yfinal)*(this.y - Form1.yfinal)));
            
            //Problème 2 : Décomposition en 2 sous problèmes en passant par un point de passage
            /*
            Node2 pointPassage = new Node2();
            pointPassage.x = 10;
            pointPassage.y = 8;

            bool PI= true; // false si gauche true si droite
            bool PF= true; // false si gauche true si droite
            if (x <= 10)
            {
                PI= false;
            }

            if (Form1.xfinal <= 10)
            {
                PF= false;
            }
            // Test si du même côté
            if (PI != PF)
            {
                return (Math.Abs(x - pointPassage.x) + Math.Abs(y - pointPassage.y) + Math.Abs(pointPassage.x - Form1.xfinal) + Math.Abs(pointPassage.y - Form1.yfinal));
            }
            else
            {
                return (Math.Abs(x - Form1.xfinal) + Math.Abs(y - Form1.yfinal));
            }
            */

            
            //Problème 3 : 

            bool PI= true; // false si gauche true si droite
            bool PF= true; // false si gauche true si droite

            //Test même côté
            if (x <= 10)
            {
                PI= false;
            }

            if (Form1.xfinal <= 10)
            {
                PF= false;
            }

            Node2 pointPassage = new Node2();
            pointPassage.x = 10;
            pointPassage.y = 0;

            Node2 pointPassageCercle = new Node2();
            pointPassageCercle.x = 2;
            pointPassageCercle.y = 6;

            double h1=Math.Abs(x - Form1.xfinal) + Math.Abs(y - Form1.yfinal);// Distance point actuel/point final
            double h2=Math.Abs(x - pointPassage.x) + Math.Abs(y - pointPassage.y);// Distance point actuel/point passage
            double h3=Math.Abs(pointPassageCercle.x - x) + Math.Abs(pointPassageCercle.y - y);// Distance point actuel/point passage cercle
            double h4=Math.Abs(pointPassageCercle.x - pointPassage.x) + Math.Abs(pointPassageCercle.y - pointPassage.y);// Distance point passage cercle/ point passage
            double h5=Math.Abs(Form1.xfinal - pointPassage.x) + Math.Abs(Form1.yfinal - pointPassage.y);// Distance point passage/point final
            double h6=Math.Abs(Form1.xfinal - pointPassageCercle.x) + Math.Abs(Form1.yfinal - pointPassageCercle.y);// Distance point passage cerlce/point final

            //Test si points de départ et arrivée dans le cercle
            //Point initial dans le cercle
            if((x>=3 && x<=8) && (y>=4 && y<=9))
            {
                if((Form1.xfinal>=3 && Form1.xfinal<=8) && (Form1.yfinal >=4 && Form1.yfinal <=9))
                {
                     return h1;
                }
                else
                {
                    // côtés différents
                    if (PI != PF)
                    {
                        return  h3 + h4 + h5;
                    }
                    //Même coté
                    else
                    {
                        return h3 + h6;
                    }
                }
            }
            // Point initial en dehors du cercle
            else
            {
                if((Form1.xfinal>=3 && Form1.xfinal<=8) && (Form1.yfinal >=4 && Form1.yfinal <=9))
                {
                     if (PI != PF)
                    {
                        return  h2 + h4 + h6;
                    }
                    //Même coté
                    else
                    {
                        return h3 + h6;
                    }
                }
                else
                {
                    // côtés différents
                    if (PI != PF)
                    {
                        if(Form1.yinitial>=6 && Form1.yfinal<6)
                        {
                            return h2+h3+h5;
                        }
                        return  h2+h5;
                    }
                    //Même coté
                    else
                    {
                        if(Form1.yinitial>=6 && Form1.yfinal < 6)
                        {
                            return h1+h3;
                        }
                        return h1;
                    }
                }
            }
        }

        }

        public override string ToString()
        {
            return Convert.ToString(x) + "," + Convert.ToString(y);
        }
    }
}
