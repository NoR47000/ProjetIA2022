// Problème 2 : Décomposition en 2 sous problèmes en passant par un point de passage 

// Création d'un noeud au niveau du seul point pour traverser la frontière
Node2 pointPassageFrontiere = new Node2();
pointPassageFrontiere.x = 10;
pointPassageFrontiere.y = 8;

bool PCCote = true; // Le point courant est du côté droit
bool PFCote = true; // Le point final est du côté droit

// Distance du point courant au point de passage de la frontière
double h1 = DistReel(x, y, pointPassageFrontiere.x, pointPassageFrontiere.y);
h1 = DistAvecMarecage(x, y, h1, pointPassageFrontiere.x, pointPassageFrontiere.y);

// Distance du point de passage de la frontière au point final
double h2 = DistReel(pointPassageFrontiere.x, pointPassageFrontiere.y, Form1.xfinal, Form1.yfinal);
h2 = DistAvecMarecage(pointPassageFrontiere.x, pointPassageFrontiere.y, h2, Form1.xfinal, Form1.yfinal);

// Distance
double h3 = DistReel(x, y, Form1.xfinal, Form1.yfinal);
h3 = DistAvecMarecage(x, y, h3, Form1.xfinal, Form1.yfinal);

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

// Les points sont de part et d'autre de la frontière
if (PCCote != PFCote)
{
    return (h1 + h2);
}
// Les deux points sont du même côté
else
{
    return h3;
}