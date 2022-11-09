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

            bool  PCCercle = true; // Le point courant est dans le cercle
            bool  PFCercle = true; // Le point final est dans le cercle

            bool PCCote= true; // Le point courant est du côté droit
            bool PFCote= true; // Le point final est du côté droit

            bool  PFMarecages = true; // Le point est dans le marécage
            bool  PCMarecages = true; // Le point est dans le marécage
           
            //Initialisation PCCercle
            if(!(x>=3 && x<=8) || !(y>=4 && y<=9))
            {
                PCCercle = false;
            }
            //Initialisation PFCercle
            if(!(Form1.xfinal>=3 && Form1.xfinal<=8) || !(Form1.yfinal>=4 && Form1.yfinal<=9))
            {
                PCCercle = false;
            }
            
            // Initialisation PCCote
            if (x <= 10)
            {
                PCCote= false;
            }
            // Initialisation PFCote
            if (Form1.xfinal <= 10)
            {
                PFCote= false;
            }

            //Initialisation PFMarecages
            if(Form1.yfinal >= 10)
            {
                PFMarecages= false; 
            }
            //Initialisation PCMarecages
            if(y >= 10)
            {
                PCMarecages= false; 
            }

            Node2 pointPassageFrontiere = new Node2();
            pointPassage.x = 10;
            pointPassage.y = 0;

            Node2 pointPassageCercle = new Node2();
            pointPassageCercle.x = 2;
            pointPassageCercle.y = 6;

            double h1=Math.Abs(x - Form1.xfinal) + Math.Abs(y - Form1.yfinal);// Distance point actuel/point final
            double h2=Math.Abs(x - pointPassageFrontiere.x) + Math.Abs(y - pointPassageFrontiere.y);// Distance point actuel/point passage
            double h3=Math.Abs(pointPassageCercle.x - x) + Math.Abs(pointPassageCercle.y - y);// Distance point actuel/point passage cercle
            double h4=Math.Abs(pointPassageCercle.x - pointPassageFrontiere.x) + Math.Abs(pointPassageCercle.y - pointPassageFrontiere.y);// Distance point passage cercle/ point passage
            double h5=Math.Abs(Form1.xfinal - pointPassageFrontiere.x) + Math.Abs(Form1.yfinal - pointPassageFrontiere.y);// Distance point passage/point final
            double h6=Math.Abs(Form1.xfinal - pointPassageCercle.x) + Math.Abs(Form1.yfinal - pointPassageCercle.y);// Distance point passage cerlce/point final

            
            //PC dans le cercle
            if(PCCercle)
            {
                //PF dans le cercle
                if(PFCercle)
                {
                    return(h1);
                }
                //PF en dehors du cercle
                else
                {
                    //PF et PC du même côté
                    if(PFCote=PCCote)
                    {
                        return(h3+h6);
                    }
                    //PF/PC côté différent
                    else
                    {
                        //Marécages
                        if(PFMarecages)
                        {
                            //Si le point est dans le marécage le coût du trajet
                            //final entre PC et PF est multiplié par 3 comme pour
                            //le trajet réel.
                            return(h3+h4+3*h1);
                        }
                        //Non marécages
                        else
                        {
                            return(h3+h4+3*h1);
                        }
                    }
                }
            }
            //PC pas dans le cercle
            else
            { 
                //PF dans le cercle 
                if(PFCercle)
                { 
                    //PF et PC même côté
                    if(PFCote=PCCote)
                    { 
                        return(h3+h1);
                    }
                    //PF/PC côté différent
                    else
                    {
                        //Marécages
                        if(PCMarecages)
                        {
                            //Si le point est dans le marécage le coût du trajet
                            //final entre PC et PF est multiplié par 3 comme pour
                            //le trajet réel.
                            return(3*h2+h4+h1);
                        }
                        //Non marécages
                        else
                        {
                            return(3*h2+h4+h1);
                        }
                    }
                }
                //PF en dehors du cercle 
                else
                {
                    //PF et PC même côté
                    if(PFCote=PCCote)
                    {
                        //Contourner Cercle ?
                        if(!PFCote)
                        {
                            if(y>6 && Form1.yfinal<6 || y<6 && Form1.yfinal>6)
                            {
                                return(h3+h6);
                            }
                            else
                            {
                                return(h1);
                            }
                        }
                        //Marécages ? 
                        else
                        {
                            return(3*h1);
                        }
                    }
                    //PF/PC côté différent 
                    else
                    {
                        if(!PFCote)
                        {
                            //Contourner Cercle 
                            if(Form1.yfinal>6)
                            {
                                return(3*h2+h4+h6);
                            }
                            else
                            {
                                return(3*h2+h5);
                            }
                        }
                        else
                        {
                            //Contourner Cercle 
                            if(y>6)
                            {
                                return(h3+h4+3*h5);
                            }
                            else
                            {
                                return(h2+3*h5);
                            }
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
