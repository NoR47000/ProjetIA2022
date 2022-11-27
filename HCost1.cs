//GCost caculé en fonction distEuclidienne<distManhattan ainsi pour toute nos estimation 
//on devra prendre comme distance la distance euclidienne 

// Problème 1 : 

//Dans ce problème nous n'avons  pas le droit de tester la
//présence d’un marécage à une position donnée, notre heuristique 
//doit rester valable même si on change la zone marécageuse.

//Pour cela la détection de franchissement de marécage dans notre
//heuristique doit ce faire exclusivement grâce à la valuer de matrice[x,y]
//On doit alors créer un chemin passant par des coordonnées entière et 
//vérifier le type de case rencontrée

//Pour avoir un chemin de case entière on va prendre en distance de référence
//la distance de Manhattan entre 2 points.

//Distance Euclidienne entre PC et PF (un nombre de cases)
double dist = DistReel(x, y, Form1.xfinal, Form1.yfinal);
//Compteur du nombre de marécage rencontré sur le chemin
int cmptMarecages = 0;
int cmptTotal = 1;

if (Form1.matrice[x, y] == -1 && Form1.matrice[Form1.xfinal, Form1.yfinal] == -1)
{
    return dist * 3;
}
else if (Form1.matrice[x, y] != Form1.matrice[Form1.xfinal, Form1.yfinal])
{
    //Variable intermédiare pour ne pas modifier les coordonnées du point courant
    int cheminX = x;
    int cheminY = y;
    while (!((cheminX == Form1.xfinal) && (cheminY == Form1.yfinal)))
    {
        cmptMarecages++;
        if (cheminX - Form1.xfinal != 0)
        {
            int signeX = (Form1.xfinal - cheminX) / Math.Abs(cheminX - Form1.xfinal);
            cheminX += signeX;
        }
        if (cheminY - Form1.yfinal != 0)
        {
            int signeY = (Form1.yfinal - cheminY) / Math.Abs(cheminY - Form1.yfinal);
            cheminY += signeY;
        }
        if (Form1.matrice[cheminX, cheminY] == -1)
        {
            cmptMarecages += 1;
        }
    }
    //La distance totale est alors la somme du nombre de marécage rencontré fois trois
    //plus le reste des cases à parcourir pour arriver à PF
    double distUnitaire = (double)dist / cmptTotal;
    return (dist - distUnitaire*cmptMarecages + 3 * cmptMarecages * distUnitaire);
}
else
{
    return dist;
}
