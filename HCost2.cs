//On a décidé de ne pas prendre en compte les marécages. Ils sont isolés, ainsi même 
//si l'algo les contourne pour avoir le plus cours chemin, ce chemin s'écarte très peu
//du chemin estimé sans marécage.

//Pour ce problème nous n'avons pas la necessitée d'avoir un chemin suivant des coordonnées
//entières nous utiliserons donc la distance euclidienne.  

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

// Les points sont de part et d'autre de la frontière
if (PCCote != PFCote)
{
    return (DistReel(x, y, pointPassageFrontiere.x, pointPassageFrontiere.y) + DistReel(pointPassageFrontiere.x, pointPassageFrontiere.y, Form1.xfinal, Form1.yfinal));
}
// Les deux points sont du même côté
else
{
    return DistReel(x, y, Form1.xfinal, Form1.yfinal);
}