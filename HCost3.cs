// Probl�me 3 : D�composition en plusieurs sous probl�mes en fonction de la position relative des points 

bool PCCercle = true; // Le point courant est dans le cercle
bool PFCercle = true; // Le point final est dans le cercle

bool PCCote = true; // Le point courant est du c�t� droit
bool PFCote = true; // Le point final est du c�t� droit

bool PFMarecages = true; // Le point est dans le mar�cage
bool PCMarecages = true; // Le point est dans le mar�cage

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
if (Form1.matrice[Form1.xfinal, Form1.yfinal] == -1)
{
    PFMarecages = false;
}
// Initialisation PCMarecages
if (Form1.matrice[x, y] == -1)
{
    PCMarecages = false;
}

// D�finition du point de passage obligatoire si on veut changer de c�t�
Node2 pointPassageFrontiere = new Node2();
pointPassageFrontiere.x = 10;
pointPassageFrontiere.y = 0;

// D�fintion du point de passage obligatoire si on veut entrer ou sortir du cercle 
Node2 pointPassageCercle = new Node2();
pointPassageCercle.x = 2;
pointPassageCercle.y = 6;

// D�fintion d'un point de sorti arbitraire du mar�gage
Node2 pointPassageMarecage = new Node2();
pointPassageMarecage.x = 15;
pointPassageMarecage.y = 10;

// Distance point courant/point final
double h1 = DistReel(x, y, Form1.xfinal, Form1.yfinal);

// Distance point courant/point passage fronti�re
double h2 = DistReel(x, y, pointPassageFrontiere.x, pointPassageFrontiere.y);

// Distance point courant/point passage cercle
double h3 = DistReel(x, y, pointPassageCercle.x, pointPassageCercle.y);

// Distance point passage cercle/ point passage fronti�re
double h4 = DistReel(pointPassageCercle.x, pointPassageCercle.y, pointPassageFrontiere.x, pointPassageFrontiere.y);

// Distance point passage fronti�re/point final
double h5 = DistReel(pointPassageFrontiere.x, pointPassageFrontiere.y, Form1.xfinal, Form1.yfinal);

// Distance point passage cerlce/point final
double h6 = DistReel(pointPassageCercle.x, pointPassageCercle.y, Form1.xfinal, Form1.yfinal);

// Distance point passage fronti�re/point passage mar�cage
double h7 = DistReel(pointPassageFrontiere.x, pointPassageFrontiere.y, pointPassageMarecage.x, pointPassageMarecage.y);

// Distance point passage mar�cage/point final
double h8 = DistReel(pointPassageMarecage.x, pointPassageMarecage.y, Form1.xfinal, Form1.yfinal);

// Distance point courant/point passage mar�cage
double h9 = DistReel(x, y, pointPassageMarecage.y, pointPassageMarecage.x);

// Creation d'un dictionnaire associant une distance particuli�re � sa valeur.
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
        // PF et PC du m�me c�t�
        if (PFCote == PCCote)
        {
            return (distanceH["PCtoPPC"] + distanceH["PPCtoPF"]);
        }
        // PF/PC c�t� diff�rent
        else
        {
            // PF est dans le mar�cage
            if (PFMarecages)
            {
                // Si le point est dans le mar�cage le co�t du trajet
                // entre PPF et PF est multipli� par 3 comme pour
                // le trajet r�el.
                return (distanceH["PCtoPPC"] + distanceH["PPCtoPPF"] + 3 * distanceH["PPFtoPF"]);
            }
            // PF est situ� en dessous du mar�gage
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
        // PF et PC m�me c�t�
        if (PFCote == PCCote)
        {
            return (distanceH["PCtoPPC"] + distanceH["PPCtoPF"]);
        }
        // PF/PC c�t� diff�rent
        else
        {
            // PC est dans le mar�cage
            if (PCMarecages)
            {
                // Si le point est dans le mar�cage le co�t du trajet
                // entre PPF et PC est multipli� par 3 comme pour
                // le trajet r�el.
                return (3 * distanceH["PCtoPPF"] + distanceH["PPCtoPPF"] + distanceH["PPCtoPF"]);
            }
            // PC en dessous du mar�cage
            else
            {
                return (distanceH["PCtoPPM"] + 3 * distanceH["PPFtoPPM"] + distanceH["PPCtoPPF"] + distanceH["PPCtoPF"]);
            }
        }
    }
    // PF en dehors du cercle 
    else
    {
        // PF et PC m�me c�t�
        if (PFCote == PCCote)
        {
            // Dans le cas o� les points sont du c�t� gauche
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
            // Dans le cas o� les points sont du c�t� droit
            // On va regarder o� ils sont plac�s par rapport au mar�cage
            else
            {
                // PC et PF dans le mar�cage
                if (PCMarecages && PFMarecages)
                {
                    return (3 * distanceH["PCtoPF"]);
                }
                // Un des deux en dehors
                else if (PCMarecages != PFMarecages)
                {
                    // C'est PC qui est dans le mar�cage
                    if (PCMarecages)
                    {
                        return (3 * distanceH["PCtoPPM"] + distanceH["PPMtoPF"]);
                    }
                    // C'est PF qui est dans le mar�cage
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
        // PF/PC c�t� diff�rent 
        else
        {
            // PF est � gauche donc PC � droite
            if (!PFCote)
            {
                // Condition sur PF qui nous indique de contourner le cercle 
                if (Form1.yfinal > 6)
                {
                    // PC est dans le mar�cage
                    if (PCMarecages)
                    {
                        return (3 * distanceH["PCtoPPF"] + distanceH["PPCtoPPF"] + distanceH["PPCtoPF"]);
                    }
                    // PC est en dessous du mar�cage
                    else
                    {
                        return (distanceH["PCtoPPM"] + 3 * distanceH["PPFtoPPM"] + distanceH["PPCtoPPF"] + distanceH["PPCtoPF"]);
                    }
                }
                // On ne doit pas contourner le cercle 
                else
                {
                    // PC est dans le mar�cage
                    if (PCMarecages)
                    {
                        return (3 * distanceH["PCtoPPF"] + distanceH["PPFtoPF"]);
                    }
                    // PC est en dessous du mar�cage
                    else
                    {
                        return (distanceH["PCtoPPM"] + 3 * distanceH["PPMtoPPF"] + distanceH["PPFtoPF"]);
                    }
                }
            }
            // PF est � droite donc PC � gauche
            else
            {
                // Condition sur PC qui nous indique de contourner le cercle  
                if (y > 6)
                {
                    // PF est dans le mar�cage
                    if (PFMarecages)
                    {
                        return (distanceH["PCtoPPC"] + distanceH["PPCtoPPF"] + 3 * distanceH["PPFtoPF"]);
                    }
                    // PF est en dessous du mar�cage
                    else
                    {
                        return (distanceH["PCtoPPC"] + distanceH["PPCtoPPF"] + 3 * distanceH["PPFtoPPM"] + distanceH["PPMtoPF"]);
                    }
                }
                // On ne doit pas contourner le cercle
                else
                {
                    // PF est dans le mar�cage
                    if (PFMarecages)
                    {
                        return (distanceH["PCtoPPF"] + 3 * distanceH["PPFtoPF"]);
                    }
                    // PF est en dessous du mar�cage
                    else
                    {
                        return (distanceH["PCtoPPF"] + 3 * distanceH["PPFtoPPM"] + distanceH["PPMtoPF"]);
                    }
                }
            }
        }
    }
}
