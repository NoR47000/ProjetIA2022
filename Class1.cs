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
            // x et y : coordonnées du point courant
            // Form1.xinitial,... sont accessibles car static et donnent accés aux coordonnées point initial et point final
            // matrice[x,y] //indique le type de case (-1 si marécage, 0 si rien, -2 si obstacle) 

            // Problème 1 : 
            
            bool PCM = false; // Point courant pas dans le marécage
            bool PFM = false; // Point final pas dans le marécage

            double distEucl =Math.Abs(this.x - Form1.xfinal) + Math.Abs(this.y - Form1.yfinal); // Distance euclidienne entre PC et PF
            double distBM ; // Distance du point au bord du marécage
            double distBMPF ; // Distance du bord du marécage au point final
            double distBMPC ; // Distance du bord du marécage au point courant
            int pointPassageX; // Coordonnée X du point de passage marécage
            int pointPassageY; // Coordonnée Y du point de passage marécage

            // Point courant dans le marécage
            if (matrice[x,y] == -1)
            {
                PCM = true;
            }
            // Point final dans le marécage
            if(matrice[Form1.xfinalForm1.yfinal] == -1)
            {
                PFM = true;
            }
            
            // Les deux points sont dans le marécage
            if(PFM && PCM)
            {
                return distEucl*3;
            }
            // Le point courant est seul dans le marécage
            else if (PCM && !PFM)
            {
                // Le point est dans la partie haute du marécage
                if(x+y<=19)
                {
                    pointPassageX = x-(x-10);
                    distBM = Math.Abs(x - pointPassageX)*3;
                    distBMPF = Math.Abs(pointPassageX - Form1.xfinal) + Math.Abs(y - Form1.yfinal);
                    return (distBM+distBMPF);
                }
                // Le point est dans la partie basse du marécage
                else
                {
                    pointPassageY = y-(y-10);
                    distBM = Math.Abs(y - pointPassageY)*3;
                    distBMPF = Math.Abs(x - Form1.xfinal) + Math.Abs(pointPassageY - Form1.yfinal);
                    return (distBM+distBMPF);
                }
            }
            // Le point final est seul dans le marécage
            else if(PFM && !PCM) 
            {
                // Le point est dans la partie haute du marécage
                if(Form1.xfinal+Form1.yfinal<=19)
                {
                    pointPassageX = Form1.xfinal-(Form1.xfinal-10);
                    distBM = Math.Abs(Form1.xfinal - pointPassageX)*3;
                    distBMPC = Math.Abs(pointPassageX - x) + Math.Abs(y - Form1.yfinal);
                    return (distBM+distBMPC);
                }
                // Le point est dans la partie basse du marécage
                else
                {
                    pointPassageY = Form1.yfinal-(Form1.yfinal-10);
                    distBM = Math.Abs(Form1.yfinal - pointPassageY)*3;
                    distBMPC = Math.Abs(Form1.xfinal - x) + Math.Abs(y - pointPassageY);
                    return (distBM+distBMPC);
                }
            }
            else
            {
                return(distEucl);
            }

            // Problème 2 : Décomposition en 2 sous problèmes en passant par un point de passage
            
            // Création d'un noeud au niveau du seul point pour traverser la frontière
            Node2 pointPassageFrontiere = new Node2();
            pointPassageFrontiere.x = 10;
            pointPassageFrontiere.y = 8;

            bool PCCote = true; // Le point courant est du côté droit
            bool PFCote = true; // Le point final est du côté droit

            // Initialisation PCCote
            if (x <= 10)
            {
                PCCote = false;
            }
            // Initialisation PFCote
            if (Form1.xfinal <= 10)
            {
                PFCote = false;
            }

            // Les deux points sont du même côté
            if (PCCote != PFCote)
            {
                return (Math.Abs(x - pointPassageFrontiere.x) + Math.Abs(y - pointPassageFrontiere.y) + Math.Abs(pointPassageFrontiere.x - Form1.xfinal) + Math.Abs(pointPassageFrontiere.y - Form1.yfinal));
            }
            // Les points sont de part et d'autre de la frontière
            else
            {
                return (Math.Abs(x - Form1.xfinal) + Math.Abs(y - Form1.yfinal));
            }

            // Problème 3 : Décomposition en plusieurs sous problèmes en fonction de la position relative des points 
            
            bool PCCercle = true; // Le point courant est dans le cercle
            bool PFCercle = true; // Le point final est dans le cercle

            bool PCCote = true; // Le point courant est du côté droit
            bool PFCote = true; // Le point final est du côté droit

            bool PFMarecages = true; // Le point est dans le marécage
            bool PCMarecages = true; // Le point est dans le marécage

            // Initialisation PCCercle
            if (!(x >= 3 && x <= 8) || !(y >= 4 && y <= 9))
            {
                PCCercle = false;
            }
            // Initialisation PFCercle
            if (!(Form1.xfinal >= 3 && Form1.xfinal <= 8) || !(Form1.yfinal >= 4 && Form1.yfinal <= 9))
            {
                PFCercle = false;
            }

            // Initialisation PCCote
            if (x <= 10)
            {
                PCCote = false;
            }
            // Initialisation PFCote
            if (Form1.xfinal <= 10)
            {
                PFCote = false;
            }

            // Initialisation PFMarecages
            if (matrice[Form1.xfinal,Form1.yfinal] == -1)
            {
                PFMarecages = false;
            }
            // Initialisation PCMarecages
            if (matrice[x,y] == -1)
            {
                PCMarecages = false;
            }

            // Définition du point de passage obligatoire si on veut changer de côté
            Node2 pointPassageFrontiere = new Node2();
            pointPassageFrontiere.x = 10;
            pointPassageFrontiere.y = 0;

            // Défintion du point de passage obligatoire si on veut entrer ou sortir du cercle 
            Node2 pointPassageCercle = new Node2();
            pointPassageCercle.x = 2;
            pointPassageCercle.y = 6;

            // Défintion d'un point de sorti arbitraire du marégage
            Node2 pointPassageMarecage = new Node2();
            pointPassageMarecage.x = 12;
            pointPassageMarecage.y = 10;

            // Distance point courant/point final
            double h1 = Math.Abs(x - Form1.xfinal) + Math.Abs(y - Form1.yfinal);

            // Distance point courant/point passage frontière
            double h2 = Math.Abs(x - pointPassageFrontiere.x) + Math.Abs(y - pointPassageFrontiere.y);

            // Distance point courant/point passage cercle
            double h3 = Math.Abs(pointPassageCercle.x - x) + Math.Abs(pointPassageCercle.y - y);

            // Distance point passage cercle/ point passage frontière
            double h4 = Math.Abs(pointPassageCercle.x - pointPassageFrontiere.x) + Math.Abs(pointPassageCercle.y - pointPassageFrontiere.y);

            // Distance point passage frontière/point final
            double h5 = Math.Abs(Form1.xfinal - pointPassageFrontiere.x) + Math.Abs(Form1.yfinal - pointPassageFrontiere.y);

            // Distance point passage cerlce/point final
            double h6 = Math.Abs(Form1.xfinal - pointPassageCercle.x) + Math.Abs(Form1.yfinal - pointPassageCercle.y);

            // Distance point passage frontière/point passage marécage
            double h7 = Math.Abs(pointPassageMarecage.x - pointPassageFrontiere.x) + Math.Abs(pointPassageMarecage.y - pointPassageFrontiere.y);

            // Distance point passage marécage/point final
            double h8 = Math.Abs(pointPassageMarecage.x - Form1.xfinal) + Math.Abs(pointPassageMarecage.y - Form1.yfinal);

            // Distance point courant/point passage marécage
            double h9 = Math.Abs(pointPassageMarecage.x - x) + Math.Abs(pointPassageMarecage.y - y);

            // Creation d'un dictionnaire associant une distance particulière à sa valeur.
            Dictionary<string, double> distanceH = new Dictionary<string, double>();
            distanceH.Add("PCtoPF", h1);
            distanceH.Add("PCtoPPF", h2);
            distanceH.Add("PCtoPPC", h3);
            distanceH.Add("PPCtoPPF", h4);
            distanceH.Add("PPFtoPF", h5);
            distanceH.Add("PPCtoPF", h6);
            distanceH.Add("PPFtoPPM", h7);
            distanceH.Add("PPMtoPF", h8);
            distanceH.Add("PCtoPPM", h9);


            // PC dans le cercle
            if (PCCercle)
            {
                // PF dans le cercle
                if (PFCercle)
                {
                    return (distanceH["PCtoPF"]);
                }
                // PF en dehors du cercle
                else
                {
                    // PF et PC du même côté
                    if (PFCote == PCCote)
                    {
                        return (distanceH["PCtoPPC"] + distanceH["PPCtoPF"]);
                    }
                    // PF/PC côté différent
                    else
                    {
                        // PF est dans le marécage
                        if (PFMarecages)
                        {
                            // Si le point est dans le marécage le coût du trajet
                            // entre PPF et PF est multiplié par 3 comme pour
                            // le trajet réel.
                            return (distanceH["PCtoPPC"] + distanceH["PPCtoPPF"] + 3 * distanceH["PPFtoPF"]);
                        }
                        // PF est situé en dessous du marégage
                        else
                        {
                            return (distanceH["PCtoPPC"] + distanceH["PPCtoPPF"] + 3 * distanceH["PPFtoPPM"] + distanceH["PPMtoPF"]);
                        }
                    }
                }
            }
            // PC pas dans le cercle
            else
            {
                // PF dans le cercle 
                if (PFCercle)
                {
                    // PF et PC même côté
                    if (PFCote == PCCote)
                    {
                        return (distanceH["PCtoPPC"] + distanceH["PPCtoPF"]);
                    }
                    // PF/PC côté différent
                    else
                    {
                        // PC est dans le marécage
                        if (PCMarecages)
                        {
                            // Si le point est dans le marécage le coût du trajet
                            // entre PPF et PC est multiplié par 3 comme pour
                            // le trajet réel.
                            return (3 * distanceH["PCtoPPF"] + distanceH["PPCtoPPF"] + distanceH["PPCtoPF"]);
                        }
                        // PC en dessous du marécage
                        else
                        {
                            return (distanceH["PCtoPPM"] + 3 * distanceH["PPFtoPPM"] + distanceH["PPCtoPPF"] + distanceH["PPCtoPF"]);
                        }
                    }
                }
                // PF en dehors du cercle 
                else
                {
                    // PF et PC même côté
                    if (PFCote == PCCote)
                    {
                        // Dans le cas où les points sont du côté gauche
                        // On va regarder s'il est necessaire de contourner le cercle
                        if (!PFCote)
                        {
                            if ((y > 6 && Form1.yfinal < 6) || (y < 6 && Form1.yfinal > 6))
                            {
                                return (distanceH["PCtoPPC"] + distanceH["PPCtoPF"]);
                            }
                            else
                            {
                                return (distanceH["PCtoPF"]);
                            }
                        }
                        // Dans le cas où les points sont du côté droit
                        // On va regarder où ils sont placés par rapport au marécage
                        else
                        {
                            // PC et PF dans le marécage
                            if (PCMarecages && PFMarecages)
                            {
                                return (3 * distanceH["PCtoPF"]);
                            }
                            // Un des deux en dehors
                            else if (PCMarecages != PFMarecages)
                            {
                                // C'est PC qui est dans le marécage
                                if (PCMarecages)
                                {
                                    return (3 * distanceH["PCtoPPM"] + distanceH["PPMtoPF"]);
                                }
                                // C'est PF qui est dans le marécage
                                else
                                {
                                    return (distanceH["PCtoPPM"] + 3 * distanceH["PPMtoPF"]);
                                }
                            }
                            // Les deux points sont en dehors
                            else
                            {
                                return (distanceH["PCtoPF"]);
                            }
                        }
                    }
                    // PF/PC côté différent 
                    else
                    {
                        // PF est à gauche donc PC à droite
                        if (!PFCote)
                        {
                            // Condition sur PF qui nous indique de contourner le cercle 
                            if (Form1.yfinal > 6)
                            {
                                // PC est dans le marécage
                                if (PCMarecages)
                                {
                                    return (3 * distanceH["PCtoPPF"] + distanceH["PPCtoPPF"] + distanceH["PPCtoPF"]);
                                }
                                // PC est en dessous du marécage
                                else
                                {
                                    return (distanceH["PCtoPPM"] + 3 * distanceH["PPFtoPPM"] + distanceH["PPCtoPPF"] + distanceH["PPCtoPF"]);
                                }
                            }
                            // On ne doit pas contourner le cercle 
                            else
                            {
                                // PC est dans le marécage
                                if (PCMarecages)
                                {
                                    return (3 * distanceH["PCtoPPF"] + distanceH["PPFtoPF"]);
                                }
                                // PC est en dessous du marécage
                                else
                                {
                                    return (distanceH["PCtoPPM"] + 3 * distanceH["PPMtoPPF"] + distanceH["PPFtoPF"]);
                                }
                            }
                        }
                        // PF est à droite donc PC à gauche
                        else
                        {
                            // Condition sur PC qui nous indique de contourner le cercle  
                            if (y > 6)
                            {
                                // PF est dans le marécage
                                if (PFMarecages)
                                {
                                    return (distanceH["PCtoPPC"] + distanceH["PPCtoPPF"] + 3 * distanceH["PPFtoPF"]);
                                }
                                // PF est en dessous du marécage
                                else
                                {
                                    return (distanceH["PCtoPPC"] + distanceH["PPCtoPPF"] + 3 * distanceH["PPFtoPPM"] + distanceH["PPMtoPF"]);
                                }
                            }
                            // On ne doit pas contourner le cercle
                            else
                            {
                                // PF est dans le marécage
                                if (PFMarecages)
                                {
                                    return (distanceH["PCtoPPF"] + 3 * distanceH["PPFtoPF"]);
                                }
                                // PF est en dessous du marécage
                                else
                                {
                                    return (distanceH["PCtoPPF"] + 3 * distanceH["PPFtoPPM"] + distanceH["PPMtoPF"]);
                                }
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
