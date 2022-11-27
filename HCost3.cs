// Problème 3 : Décomposition en plusieurs sous problèmes en fonction de la position relative des points 

bool PCCercle = true; // Le point courant est dans le cercle
bool PFCercle = true; // Le point final est dans le cercle

bool PCCote = true; // Le point courant est du côté droit
bool PFCote = true; // Le point final est du côté droit

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
pointPassageMarecage.x = 15;
pointPassageMarecage.y = 10;

// Distance point courant/point final
double h1 = DistReel(x, y, Form1.xfinal, Form1.yfinal);
h1 = DistAvecMarecage(x, y, h1, Form1.xfinal, Form1.yfinal);

// Distance point courant/point passage frontière
double h2 = DistReel(x, y, pointPassageFrontiere.x, pointPassageFrontiere.y);
h2 = DistAvecMarecage(x, y, h2, pointPassageFrontiere.x, pointPassageFrontiere.y);

// Distance point courant/point passage cercle
double h3 = DistReel(x, y, pointPassageCercle.x, pointPassageCercle.y);
h3 = DistAvecMarecage(x, y, h3, pointPassageCercle.x, pointPassageCercle.y);

// Distance point passage cercle/ point passage frontière
double h4 = DistReel(pointPassageCercle.x, pointPassageCercle.y, pointPassageFrontiere.x, pointPassageFrontiere.y);
h4 = DistAvecMarecage(pointPassageCercle.x, pointPassageCercle.y, h4, pointPassageFrontiere.x, pointPassageFrontiere.y);

// Distance point passage frontière/point final
double h5 = DistReel(pointPassageFrontiere.x, pointPassageFrontiere.y, Form1.xfinal, Form1.yfinal);
h5 = DistAvecMarecage(pointPassageFrontiere.x, pointPassageFrontiere.y, h5, Form1.xfinal, Form1.yfinal);

// Distance point passage cercle/point final
double h6 = DistReel(pointPassageCercle.x, pointPassageCercle.y, Form1.xfinal, Form1.yfinal);
h6 = DistAvecMarecage(pointPassageCercle.x, pointPassageCercle.y, h6, Form1.xfinal, Form1.yfinal);

// Creation d'un dictionnaire associant une distance particulière à sa valeur.
Dictionary<string, double> distanceH = new Dictionary<string, double>();
distanceH.Add("PCtoPF", h1);
distanceH.Add("PCtoPPF", h2);
distanceH.Add("PCtoPPC", h3);
distanceH.Add("PPCtoPPF", h4);
distanceH.Add("PPFtoPF", h5);
distanceH.Add("PPCtoPF", h6);

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
            return (distanceH["PCtoPPC"] + distanceH["PPCtoPPF"] + distanceH["PPFtoPF"]);
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
            return (distanceH["PCtoPPF"] + distanceH["PPCtoPPF"] + distanceH["PPCtoPF"]);
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
                return (distanceH["PCtoPF"]);
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
                    return (distanceH["PCtoPPF"] + distanceH["PPCtoPPF"] + distanceH["PPCtoPF"]);
                }
                // On ne doit pas contourner le cercle 
                else
                {
                    return (distanceH["PCtoPPF"] + distanceH["PPFtoPF"]);
                }
            }
            // PF est à droite donc PC à gauche
            else
            {
                // Condition sur PC qui nous indique de contourner le cercle  
                if (y > 6)
                {
                    return (distanceH["PCtoPPC"] + distanceH["PPCtoPPF"] + distanceH["PPFtoPF"]);
                }
                // On ne doit pas contourner le cercle
                else
                {
                    return (distanceH["PCtoPPF"] + distanceH["PPFtoPF"]);
                }
            }
        }
    }
}
