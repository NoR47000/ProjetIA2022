//GCost caculé en fonction distEuclidienne<distManhattan ainsi pour toute nos estimation 
//on devra prendre comme distance la distance euclidienne 

// Problème 1 : 

//Dans ce problème nous n'avons  pas le droit de tester la
//présence d’un marécage à une position donnée, notre heuristique 
//doit rester valable mêmesi on change la zone marécageuse.

//Pour cela la détection de franchissement de marécage dans notre
//heuristique doit ce faire exclusivement grâce à la valuer de matrice[x,y]
//On doit alors créer un chemin passant par des coordonnées entière et 
//vérifier le type de case rencontrée

//Pour avoir un chemin de case entière on va prendre en distance de référence
//la distance de Manhattan entre 2 points.

// Problème 1 : 

//GCost caculé en fonction distEuclidienne<distManhattan ainsi pour toute nos estimation 
//on devra prendre comme distance la distance euclidienne 

// Problème 1 : 

//Dans ce problème nous n'avons  pas le droit de tester la
//présence d’un marécage à une position donnée, notre heuristique 
//doit rester valable mêmesi on change la zone marécageuse.

//Pour cela la détection de franchissement de marécage dans notre
//heuristique doit ce faire exclusivement grâce à la valuer de matrice[x,y]
//On doit alors créer un chemin passant par des coordonnées entière et 
//vérifier le type de case rencontrée

//Pour avoir un chemin de case entière on va prendre en distance de référence
//la distance de Manhattan entre 2 points.

//Distance Manhattan entre PC et PF (un nombre de cases)
<<<<<<< Updated upstream
double dist = DistReel(x,y,Form1.xfinal,Form1.yfinal); 

//Compteur du nombre de marécage rencontré sur le chemin
int cmptMarecages =0;
int cmptTotal = 1;
=======
double distManhattan = Math.Abs(this.x - Form1.xfinal) + Math.Abs(this.y - Form1.yfinal);

//Compteur du nombre de marécage rencontré sur le chemin
int cmpt = 0;
>>>>>>> Stashed changes

//Variable intermédiare pour ne pas modifier les coordonnées du point courant
int cheminX = x;
int cheminY = y;
<<<<<<< Updated upstream
while(cheminX!=Form1.xfinal || cheminY!=Form1.yfinal)
{
    cmptTotal+=1;
    if(cheminX<Form1.xfinal)
=======
while (cheminX != Form1.xfinal && cheminY != Form1.yfinal)
{
    if (cheminX < Form1.xfinal)
>>>>>>> Stashed changes
    {
        cheminX += 1;
    }
    else if (cheminX > Form1.xfinal)
    {
        cheminX -= 1;
    }

    if (cheminY < Form1.yfinal)
    {
        cheminY += 1;
    }
    else if (cheminY > Form1.yfinal)
    {
        cheminY -= 1;
    }

<<<<<<< Updated upstream
    if (Form1.matrice[cheminX, cheminY] == -1)
    {
       cmptMarecages+=1;
    }
=======
    if (matrice[cheminX, cheminY] == -1) ; cmpt += 1;
>>>>>>> Stashed changes
}

//La distance totale est alors la somme du nombre de marécage rencontré fois trois
//plus le reste des cases à parcourir pour arriver à PF
<<<<<<< Updated upstream
double distUnitaire = (double) dist/cmptTotal;
return(dist + 2*(cmptMarecages/cmptTotal)*dist);
=======
return (3 * cmpt + (distManhattan - cmpt));
>>>>>>> Stashed changes

//Enoncer le problème si on est en haut à gauche et bas à droite du marécage
//Chemin le plus court on sort du marécage donc vu que l'estimation passe par
//le marécage on aura une estimation plus élevée que le chemin reel. 